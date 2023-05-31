using DAL.Model;
using DAL.Repository;
using GraphQL;
using GraphQL.Types;

namespace API.ClassesGraphql.Mutations;

public class PersonStatusMutation : ObjectGraphType
{
    // Add
    public PersonStatusMutation(IUnitOfWork repository)
    {
        Field<PersonStatusType>(
            "createPersonStatus",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PersonStatusAddType>>
            {

                Name = "personstatus"

            }),
            resolve: context =>
            {
                PersonStatus personStatus = new PersonStatus();
                try
                {
                    var personstatus = context.GetArgument<PersonStatus>("personstatus");
                    repository.PersonStatus.Add(personstatus);
                    int _code = repository.Save();


                    personStatus.ID = _code;
                    personStatus.Value = personstatus.Value;

                }
                catch (Exception ex)
                {
                    personStatus.ID = -1;
                    personStatus.Value = "";
                }
                return personStatus;
            }
        );
    }
}
