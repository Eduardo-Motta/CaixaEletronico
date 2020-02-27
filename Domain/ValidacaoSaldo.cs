using Entities;
using Entities.Domain.Exceptions;
using ViewModels;

namespace Domain
{
    public class ValidacaoSaldo
    {
        const decimal VALOR_MINIMO_SALDO = 0m;
        private readonly ContaCorrente _contaCorrente;
        private readonly MovimentacaoConta _movimentacao;

        public ValidacaoSaldo(ContaCorrente contaCorrente, MovimentacaoConta movimentacao)
        {
            _contaCorrente = contaCorrente;
            _movimentacao = movimentacao;
        }

        public void Validar()
        {
            if((_contaCorrente.Saldo - _movimentacao.Valor) < VALOR_MINIMO_SALDO)
                throw new SaldoInsuficienteException("Saldo insuficiente.");
        }
    }
}
