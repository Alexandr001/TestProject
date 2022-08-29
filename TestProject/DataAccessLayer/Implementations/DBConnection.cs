using Microsoft.Data.SqlClient;

namespace TestProject.DataAccessLayer.Implementations
{
    public static class DBConnection
    {
        private const string CONNECT = "Data Sourse=.; Initial Catalog=SmartwayTestDB; Integrated Security=true; Trust Server Certificate=true;";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(CONNECT);
        }
    }
}
