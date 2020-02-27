using GraphQL.Types;
using Services;

namespace CaixaEletronico.Queries
{
    public class ContaCorrenteQuery : ObjectGraphType
    {
        public ContaCorrenteQuery(IContaCorrenteServices contaCorrenteServices)
        {
            Field<DecimalGraphType>(
                "saldo",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "conta" }),
                resolve: context => {
                    var saldo = contaCorrenteServices.ObterSaldoContaCorrente(context.GetArgument<int>("conta"));
                    
                    return saldo;
                });
        }
    }
}
