using GraphQL.Types;

namespace CaixaEletronico.Mutations
{
    public class ContaCorrenteInputType : InputObjectGraphType
    {
        public ContaCorrenteInputType()
        {
            Name = "contaCorrenteOperacao";

            Field<IntGraphType>("conta", "Número da Conta");

            Field<DecimalGraphType>("valor", "Valor da Operação");
        }
    }
}
