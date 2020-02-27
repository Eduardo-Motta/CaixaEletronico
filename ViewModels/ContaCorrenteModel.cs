namespace ViewModels
{
    public class ContaCorrenteModel
    {
        public ContaCorrenteModel(long conta, decimal saldo)
        {
            Conta = conta;
            Saldo = saldo;
        }

        public long Conta { get; }

        public decimal Saldo { get; }
    }
}
