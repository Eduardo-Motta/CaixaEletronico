using System;

namespace Domain.Exceptions
{
    public class ContaNaoEncontradaException : Exception
    {
        public ContaNaoEncontradaException(string mensagem) : base(mensagem)
        {
        }
    }
}
