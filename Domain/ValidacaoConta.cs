using Domain.Exceptions;
using Entities;

namespace Domain
{
    public class ValidacaoConta
    {
        private readonly ContaCorrente _contaCorrente;

        public ValidacaoConta(ContaCorrente contaCorrente)
        {
            _contaCorrente = contaCorrente;
        }

        public void Validar()
        {
            if (_contaCorrente == null)
                throw new ContaNaoEncontradaException("Conta Não Encontrada.");
        }
    }
}
