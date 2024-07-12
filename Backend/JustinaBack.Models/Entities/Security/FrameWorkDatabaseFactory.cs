
namespace JustinaBack.Models
{
    public class FrameworkDatabaseFactory
    {
        public static FrameworkDatabase? CreateDatabase(string connectionString)
        {
            //var configuration = ConfigurationInfo.GetConfiguration();
            //var connectionString = configuration.GetSection("ConnectionStrings").GetSection(connectionName).Value;

            if (!String.IsNullOrEmpty(connectionString))
            {
                FrameworkDatabase database = new FrameworkDatabase(connectionString);
                return database;
            }
            else
            {
                return null;
            }
        }
    }
}
