using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositorioBase : IRepository
    {
        private readonly IDbConnection Conexao;

        public RepositorioBase(IConfiguration configuration)
        {
            Conexao = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Conexao.Open();
        }

        public void Dispose()
        {
            Conexao?.Dispose();
        }

        public Task<T> Obter<T>(object obj) where T : class
        {
            return Conexao.GetAsync<T>(obj);
        }

        public Task<bool> Alterar<T>(T obj) where T : class
        {
            return Conexao.UpdateAsync<T>(obj);
        }
    }
}
