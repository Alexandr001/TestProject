using Microsoft.Data.SqlClient;

namespace TestProject.DataAccessLayer.Implementations
{
    public static class DbConnection
    {
        private const string ADDRESS = "SmartweyTestDB.mssql.somee.com";
        private const string NAME = "SmartweyTestDB";
        private const string LOGIN = "Alexandr001_SQLLogin_1";
        private const string PASSWORD = "ppd8bthp76";
        

        public static SqlConnection CreateConnection()
        {
            const string CONNECTION = $"Data Source={ADDRESS}; " +
                                      $"Initial Catalog={NAME}; " +
                                      $"User id={LOGIN}; " +
                                      $"Password={PASSWORD}; " +
                                      "TrustServerCertificate=True";
            return new SqlConnection(CONNECTION);
        }
    }
}
