using Entities;
using System.Threading.Tasks;

namespace Tests.Services
{
    public class Base
    {
        public Task<ContaCorrente> ObterContaCorrente1111()
        {
            return Task<ContaCorrente>.Factory.StartNew(() => new ContaCorrente
            {
                Conta = 1111,
                Saldo = 120
            });
        }
    }
}
