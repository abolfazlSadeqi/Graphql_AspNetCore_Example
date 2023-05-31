using DAL.Model;
using GraphQL.Types;

namespace API.ClassesGraphql;

public class PersonStatusType : ObjectGraphType<PersonStatus>
{
    public PersonStatusType()
    {
        Field(x => x.ID).Description("Id");
        Field(x => x.Value).Description("Value.");

    }
}
