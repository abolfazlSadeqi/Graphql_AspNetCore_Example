
In the project, I tried to create a simple implementation for the whole Graphql in .Net7
 
 We would love to add your content. Just make sure to follow our Code of Conduct
 
## Defined GraphQL:
GraphQL is an open-source, flexible query language (“QL” stands for query language) for APIs, as well as a runtime for query execution on existing data
   
Used the following nuget package
--
Install GraphQL.

Install  GraphQL.Server.Transports.AspNetCore 

Install  GraphQL.Server.Ui.Playground(UI to work with GraphQL and do tests) 

Install  GraphQL.SystemTextJson 


## The following items have been implemented in this project
Implement Query(Base and Read Data)

Mutation

Test and Call


## Tech Specification:
Net7

EF7

Graphql(Fetch Data,Mutations)

Xunit(IntegrationTests)

## In this section, a sample code for the implementation of reading data  (the complete code is available in the project)

Creating GraphQL Specific Objects (Type, Query, Schema)

a) Declaring Type 
      used to describe the kind of item that may be retrieved through your API.
```csharp    
 public class PersonType : ObjectGraphType<Person>
 {
    public PersonType()
    {
    Field(x => x.ID, type: typeof(IdGraphType)).Description("ID");
    Field(x => x.FirstName).Description("FirstName.");
    Field(x => x.LastName).Description("LastName.");
    Field(x => x.Email).Description("Email.");

    }
 }
```  
b) Declaring Query (fetch the data)
```csharp            
public class PersonQuery : ObjectGraphType
{
   public PersonQuery(IUnitOfWork repository)
   {
   Field<ListGraphType<PersonType>>(
   "Persons",
   resolve: context => repository.Person.GetAll()
   );

    }
}
``` 
c) Declaring Schema 
 
schema Include :Query(fetch the data) ,Mutations(Add/Edit/Delete),Subscriptions
```csharp 
public class Graphql_ExampleSchema : Schema
{
    public Graphql_ExampleSchema(IServiceProvider provider)
    : base(provider)
    {
    Query = provider.GetRequiredService<PersonQuery>(); 
    }
}
``` 



