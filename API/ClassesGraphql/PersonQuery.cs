using DAL.Repository;
using GraphQL;
using GraphQL.Types;

namespace API.ClassesGraphql;

public class PersonQuery : ObjectGraphType
{
    public PersonQuery(IUnitOfWork repository)
    {
        Field<ListGraphType<PersonType>>(
           "Persons",
           resolve: context => repository.Person.GetAll()
       );


        Field<PersonType>(
           "GetPerson",
           arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ID" }),
           resolve: context =>
           {
               var id = context.GetArgument<int>("ID");
               return repository.Person.GetById(id);
           }
       );
    }
}
