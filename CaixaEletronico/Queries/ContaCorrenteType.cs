using GraphQL.Types;
using ViewModels;

namespace CaixaEletronico.Queries
{
    public class ContaCorrenteType : ObjectGraphType<ContaCorrenteModel>
    {
        public ContaCorrenteType()
        {
            Name = "ContaCorrente";

            Field(x => x.Conta).Description("Numero da Conta");
            Field(x => x.Saldo).Description("Saldo da Conta");
        }
    }
}
