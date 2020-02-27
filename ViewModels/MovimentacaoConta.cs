namespace ViewModels
{
    public class MovimentacaoConta
    {
        public MovimentacaoConta(long conta, decimal valor)
        {
            Conta = conta;
            Valor = valor;
        }

        public long Conta { get; }

        public decimal Valor { get; }
    }
}
