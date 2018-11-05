using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Transporte.Full.Data.Repositories
{
    public class CriancaRepository
    {
        private readonly IConnectionFactory<IDbConnection> _connectionFactory;

        public CriancaRepository(IConnectionFactory<IDbConnection> connectionFactory) => _connectionFactory = connectionFactory;

        public IEnumerable<Crianca> GetCriancas()
        {
            IEnumerable<Crianca> criancas = new List<Crianca>();
            using ( var connection = _connectionFactory.GetConnection() )
            {
                criancas = connection.Query<Crianca>(SqlStatements.GetChilds);
            }

            return criancas;
        }
    }
}
