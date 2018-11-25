using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CampanhaBrinquedo.Transport.Utils
{
    public class SqlServerFactory : IConnectionFactory<IDbConnection>
    {
        private readonly IConfiguration _configuration;

        public SqlServerFactory(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection GetConnection() => new SqlConnection(_configuration.GetConnectionString("default"));
    }
}