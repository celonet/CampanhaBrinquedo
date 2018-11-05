using System.Data;
using System.Data.SqlClient;

namespace Transporte.Full
{
    public class SqlServerFactory : IConnectionFactory<IDbConnection>
    {
        public IDbConnection GetConnection()
        {
            var connString = @"";
            return new SqlConnection(connString);
        }
    }
}