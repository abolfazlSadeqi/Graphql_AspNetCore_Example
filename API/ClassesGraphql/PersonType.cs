using DAL.Model;
using GraphQL.Types;

namespace API.ClassesGraphql;

public class PersonType : ObjectGraphType<Person>
{
    public PersonType()
    {
        Field(x => x.ID, type: typeof(IdGraphType)).Description("ID");
        Field(x => x.FirstName).Description("FirstName.");
        Field(x => x.LastName).Description("LastName.");
        Field(x => x.Email).Description("Email.");
        Field(x => x.AdditionalContactInfo).Description("AdditionalContactInfo.");
        Field(x => x.CreateDate).Description("CreateDate.");
        Field(x => x.ModifiedDate).Description("ModifiedDate.");
        Field(x => x.Suffix).Description("Suffix.");

    }
}
