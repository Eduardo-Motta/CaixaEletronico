using CaixaEletronico.Mutations;
using CaixaEletronico.Queries;
using GraphQL;
using GraphQL.Types;

namespace CaixaEletronico.Schemas
{
    public class ContaCorrenteSchema : Schema
    {
        public ContaCorrenteSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ContaCorrenteQuery>();
            Mutation = resolver.Resolve<ContaCorrenteMutation>();
        }
    }
}
