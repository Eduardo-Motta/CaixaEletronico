using CaixaEletronico.Queries;
using GraphQL.Types;
using Services;
using ViewModels;

namespace CaixaEletronico.Mutations
{
    public class ContaCorrenteMutation : ObjectGraphType
    {
        public ContaCorrenteMutation(IContaCorrenteServices contaCorrenteService)
        {
            Name = "ContaCorrenteMutation";

            Field<ContaCorrenteType>(
                "sacar",
                arguments: new QueryArguments(
                        new QueryArgument<IntGraphType> { Name = "conta" },
                        new QueryArgument<DecimalGraphType> { Name = "valor" }
                ),
                resolve: context =>
                {
                    var conta =  contaCorrenteService.Sacar(
                        new MovimentacaoConta(
                            context.GetArgument<long>("conta"),
                            context.GetArgument<decimal>("valor")
                    ));

                    return conta;
                }
            );

            Field<ContaCorrenteType>(
                "depositar",
                arguments: new QueryArguments(
                        new QueryArgument<IntGraphType> { Name = "conta" },
                        new QueryArgument<DecimalGraphType> { Name = "valor" }
                ),
                resolve: context =>
                {
                    var conta = contaCorrenteService.Depositar(
                        new MovimentacaoConta(
                            context.GetArgument<long>("conta"),
                            context.GetArgument<decimal>("valor")
                    ));

                    return conta;
                }
            );
        }
    }
}
