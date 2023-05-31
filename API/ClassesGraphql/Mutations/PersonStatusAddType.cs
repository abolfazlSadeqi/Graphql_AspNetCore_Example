using GraphQL.Types;

namespace API.ClassesGraphql.Mutations;



public class PersonStatusAddType : InputObjectGraphType
{
    public PersonStatusAddType()
    {
        Name = "personstatusInput";
        Field<NonNullGraphType<StringGraphType>>("value");
    }
}
