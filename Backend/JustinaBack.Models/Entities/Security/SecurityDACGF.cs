using Microsoft.Data.SqlClient;
using System.Data;


namespace JustinaBack.Models
{
    public class SecurityDACGF : BaseDAC
    {
        private bool UsingEF { get; set; }
        #region Constructor
        public SecurityDACGF(string connectionString, bool usingEF = true)
        {
            UsingEF = usingEF;
            Database = FrameworkDatabaseFactory.CreateDatabase(connectionString);
        }

        public SecurityDACGF(string connectionString, SqlTransaction transaction, bool usingEF = true)
        {
            UsingEF = usingEF;
            Transaction = transaction;
            Database = FrameworkDatabaseFactory.CreateDatabase(connectionString);

        }
        #endregion

        #region Private Const String
        #endregion

        #region Query Commands
        private string SELECT_BY_EMAIL
        {
            get
            {
                return UsingEF ? SELECT_BY_LOGIN_NAME_EF : SELECT_BY_LOGIN_NAME_GF;
            }
        }

        // Using EntityFramework for security
        private const string SELECT_BY_LOGIN_NAME_EF = "SELECT * FROM [dbo].[AspNetUsers] WHERE [Email] = @email";
        // Not using EntityFramework for security
        private const string SELECT_BY_LOGIN_NAME_GF = "SELECT * FROM [security].[user] WHERE [login_name] = @login_name";
        #endregion

        #region Public Methods
        public UserEF GetUserByEmail(string email)
        {
            try
            {
                UserEF user = null;

                using (var connection = Database.OpenConnection())
                {
                    var command = Database.GetSqlStringCommand(connection, SELECT_BY_EMAIL);
                    Database.AddInParameter(command, "@email", DbType.String, email);
                    using (var reader = command.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            user = new UserEF();
                            this.FillUserEF(user, reader);
                        }
                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                if (this.Transaction != null && this.Transaction.Connection != null)
                    this.Transaction.Rollback();
                throw;
            }
        }

        public int? GetTenantIdByEmail(string email)
        {
            try
            {
                int? tenantId = null;

                using (var connection = Database.OpenConnection())
                {
                    var command = Database.GetSqlStringCommand(connection, SELECT_BY_EMAIL);
                    Database.AddInParameter(command, "@email", DbType.String, email);
                    using (var reader = command.ExecuteReader(CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            tenantId = reader.GetInt32(reader.GetOrdinal("TenantId"));
                        }
                    }
                }

                return tenantId;
            }
            catch (Exception ex)
            {
                if (this.Transaction != null && this.Transaction.Connection != null)
                    this.Transaction.Rollback();
                throw ex;
            }
        }
        #endregion

        #region Private Methods
        public void FillUserEF(UserEF user, SqlDataReader reader)
        {
            user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
        }
        #endregion

    }
}
