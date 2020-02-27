using Entities;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private IRepository _repositorio;

        public ContaCorrenteRepository(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ContaCorrente> ObterConta(long conta)
        {
            return await _repositorio.Obter<ContaCorrente>(conta);
        }

        public async Task<bool> Alterar(ContaCorrente conta)
        {
            return await _repositorio.Alterar<ContaCorrente>(conta);
        }

        public void Dispose()
        {
            _repositorio?.Dispose();
        }
    }
}
