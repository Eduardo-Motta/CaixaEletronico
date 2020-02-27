using System;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public interface IContaCorrenteServices : IDisposable
    {
        Task<decimal> ObterSaldoContaCorrente(long conta);

        Task<ContaCorrenteModel> Sacar(MovimentacaoConta movimentacao);

        Task<ContaCorrenteModel> Depositar(MovimentacaoConta movimentacao);
    }
}
