using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;


namespace JustinaBack.Models
{
    public class FrameworkDatabase
    {
        #region Private Field Members
        private string connectionString;
        private SqlConnection _connection;
        #endregion

        #region Constructors and Initialization
        private FrameworkDatabase() { }

        public FrameworkDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return this.connectionString; }
        }
        #endregion

        #region Public Methods
        public SqlConnection CreateConnection
        {
            get
            {
                if (this._connection != null)
                    return this._connection;

                return new SqlConnection(ConnectionString);
            }
        }

        public SqlTransaction CreateTransaction()
        {
            var connection = OpenConnection();
            return connection.BeginTransaction();
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection? connection = null;
            try
            {
                connection = this.CreateConnection;
                connection.Open();
                //DataLogger.WriteToLog("Connection opened");
            }
            catch
            {
                if (connection != null)
                    connection.Close();
                throw;
            }
            return connection;
        }

        public SqlCommand GetSqlStringCommand(SqlConnection connection, string query)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentException("The value can not be null or an empty string.", "query");
            SqlCommand command = CreateCommand(CommandType.Text, query);
            InitializeCommand(command, connection);
            return command;
        }

        public SqlCommand GetSqlStringCommand(SqlTransaction transaction, string query)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentException("The value can not be null or an empty string.", "query");
            SqlCommand command = CreateCommand(CommandType.Text, query);
            InitializeCommand(command, transaction);
            return command;
        }

        public void AddInParameter(SqlCommand command, string name, DbType dbType, object? value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.DbType = dbType;
            param.Value = value ?? DBNull.Value;

            command.Parameters.Add(param);
        }

        public void AddOutParameter(SqlCommand command, string name, DbType dbType, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.DbType = dbType;
            //param.Size = size;
            param.Value = value ?? DBNull.Value;
            param.Direction = ParameterDirection.Output;
            //param.IsNullable = nullable;
            //param.SourceColumn = sourceColumn;
            //param.SourceVersion = sourceVersion;

            command.Parameters.Add(param);
        }

        public SqlTransaction BeginTransaction(SqlTransaction transaction, SqlConnection connection)
        {
            if (transaction == null)
            {
                transaction = connection.BeginTransaction();
            }
            return transaction;
        }
        #endregion

        #region Private Methods

        private void InitializeCommand(SqlCommand command, SqlConnection connection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (connection == null) throw new ArgumentNullException("connection");
            command.Connection = connection;
        }

        private void InitializeCommand(SqlCommand command, SqlTransaction transaction)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (transaction == null) throw new ArgumentNullException("connection");
            InitializeCommand(command, transaction.Connection);
            command.Transaction = transaction;
        }

        private SqlCommand CreateCommand(CommandType commandType, string commandText)
        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentException("The value can not be null or an empty string.", "commandText");
            //SqlCommand command = CreateCommand(commandType, commandText);
            var command = new SqlCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }
        #endregion

        #region Database Administration
        public void CreateDatabase()
        {
            var connStringBuilder = new SqlConnectionStringBuilder(this.ConnectionString);
            string? dataFileName = null;
            string? logFileName = null;
            var attachDBFile = connStringBuilder.AttachDBFilename;
            if (string.IsNullOrEmpty(attachDBFile))
            {
                dataFileName = null;
                logFileName = null;
            }
            else
            {
                if (string.IsNullOrEmpty(attachDBFile)
                    || !attachDBFile.StartsWith("|datadirectory|", StringComparison.OrdinalIgnoreCase))
                    dataFileName = attachDBFile;
                else
                {
                    var rootFolderObject = AppDomain.CurrentDomain.GetData("DataDirectory");
                    var rootFolderPath = rootFolderObject as string;
                    if (rootFolderPath == String.Empty)
                        rootFolderPath = AppDomain.CurrentDomain.BaseDirectory;
                    dataFileName = attachDBFile.Substring("|datadirectory|".Length);
                    if (dataFileName.StartsWith(@"\", StringComparison.Ordinal))
                        dataFileName = dataFileName.Substring(1);
                    var fixedRoot = rootFolderPath.EndsWith(@"\", StringComparison.Ordinal)
                                ? rootFolderPath
                                : rootFolderPath + @"\";
                    dataFileName = fixedRoot + dataFileName;
                    var directory = new System.IO.FileInfo(dataFileName).Directory;
                    logFileName = System.IO.Path.Combine(directory.FullName, String.Concat(System.IO.Path.GetFileNameWithoutExtension(dataFileName), "_log.ldf"));
                }
            }
            var databaseName = connStringBuilder.InitialCatalog;
            // https://msdn.microsoft.com/en-us/library/ms176061.aspx
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE DATABASE ");
            sb.Append("[");
            sb.Append(databaseName);
            sb.Append("]");
            if (!string.IsNullOrEmpty(dataFileName))
            {
                sb.Append(" ON PRIMARY ");
                sb.Append("(name=");
                sb.Append("N'" + System.IO.Path.GetFileName(dataFileName).Replace("'", "''") + "'");
                sb.Append(", filename=");
                sb.Append("N'" + dataFileName.Replace("'", "''") + "'");
                sb.Append(")");
                sb.Append(" LOG ON ");
                sb.Append("(name=");
                sb.Append("N'" + System.IO.Path.GetFileName(logFileName).Replace("'", "''") + "'");
                sb.Append(", filename=");
                sb.Append("N'" + logFileName.Replace("'", "''") + "'");
                sb.Append(")");
                // sb.Append(" COLLATE SQL_Latin1_General_CP1_CI_AI ");
            }
            var createCommand = sb.ToString();
            var connStringBuilder2 = new SqlConnectionStringBuilder(ConnectionString)
            {
                InitialCatalog = "master",
                AttachDBFilename = string.Empty
            };
            using (var masterConn = new SqlConnection(connStringBuilder2.ConnectionString))
            {
                var command = new SqlCommand(createCommand, masterConn);
                masterConn.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region RunLocalStoredCommands
        public void RunLocalStoredCommands(System.Reflection.Assembly assembly, string resourceName)
        {
            System.IO.TextReader textReader = new System.IO.StreamReader(assembly.GetManifestResourceStream(resourceName));
            RunLocalStoredCommands(textReader);
        }

        public void RunLocalStoredCommands(System.IO.TextReader textReader)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = textReader.ReadToEnd();

            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction() as SqlTransaction;
                // transaction.IsolationLevel = IsolationLevel.ReadUncommitted;
                command.Transaction = transaction;
                command.Connection = connection;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                ex.ToString();
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {
                // when trasaction is commited (transaction.Commit()) the .Net Framework set the connection property to null
                // we need to get the connection from the command
                if (connection != null && connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }

        public void ExecuteNonQuery(CommandType commandType, string sqlStatement)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlStatement;

            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlTransaction? transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction() as SqlTransaction;
                // transaction.IsolationLevel = IsolationLevel.ReadUncommitted;
                command.Transaction = transaction;
                command.Connection = connection;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                ex.ToString();
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {
                // when trasaction is commited (transaction.Commit()) the .Net Framework set the connection property to null
                // we need to get the connection from the command
                if (connection != null && connection.State == ConnectionState.Open)
                    command.Connection.Close();
            }
        }

        //public SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        //{
        //    using (SqlCommand command = CreateCommand(commandType, commandText))
        //    {
        //        //return ExecuteReader(command);
        //        SqlConnection connection = OpenConnection();
        //        InitializeCommand(command, connection);

        //        try
        //        {
        //            //return DoExecuteReader(command, CommandBehavior.CloseConnection);
        //            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //            return reader;
        //        }
        //        catch
        //        {
        //            connection.Close();
        //            throw;
        //        }
        //    }
        //}

        //protected void RunLocalStoredCommands(string resourceName) {
        //    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //    this.RunLocalStoredCommands(assembly, resourceName);
        //}
        #endregion

        #region Database Information
        /// <summary>
        /// Gets the Data Source of Database Server Name defined by the connection string.
        /// </summary>
        public string DataSource
        {
            get
            {
                var dataSource = String.Empty;
                using (var connection = this.CreateConnection)
                {
                    dataSource = connection.DataSource;
                }
                return dataSource;
            }
        }

        /// <summary>
        /// Gets the Data Source of Database Server Name defined by the connection string.
        /// </summary>
        public string InitialCatalog
        {
            get
            {
                var dbName = String.Empty;
                using (var connection = this.CreateConnection)
                {
                    dbName = connection.Database;
                }
                return dbName;
            }
        }
        #endregion
    }
}
