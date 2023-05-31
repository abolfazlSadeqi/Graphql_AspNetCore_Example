using API.ClassesGraphql.Mutations;
using GraphQL.Types;

namespace API.ClassesGraphql;

public class Graphql_ExampleSchema : Schema
{
    public Graphql_ExampleSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = provider.GetRequiredService<PersonQuery>();
        Mutation = provider.GetRequiredService<PersonStatusMutation>();

    }
}