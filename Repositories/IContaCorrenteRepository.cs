using Entities;
using System;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IContaCorrenteRepository : IDisposable
    {
        Task<ContaCorrente> ObterConta(long conta);
        Task<bool> Alterar(ContaCorrente conta);
    }
}
