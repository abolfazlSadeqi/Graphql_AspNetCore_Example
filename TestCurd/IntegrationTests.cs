using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Castle.Core.Resource;
using DAL.Model;
using System.Text.Json;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Text.Json;
using GraphQL.Client.Abstractions.Websocket;
using API.Dto;
using TestCurd;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQL;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TestCurd.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DefaultAPI.UnitTesting
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<API.Startup>>
    {

        public readonly GraphQLHttpClient _graphQLHttpClient;

        public IntegrationTests(WebApplicationFactory<API.Startup> factory)
        {
            if (_graphQLHttpClient == null)
            {
                _graphQLHttpClient = GetGraphQlApiClient();
            }
        }

        public GraphQLHttpClient GetGraphQlApiClient()
        {

            return new GraphQLHttpClient(Setting.UrlGraphQl, new SystemTextJsonSerializer());
        }

        [Fact]
        public async Task CreatePersonStatus()
        {

            //Arrange
            string LastName = "test3";
            var _GraphQLRequest = new GraphQLRequest
            {
                Query = @"mutation CreatePS($personstatus:personstatusInput!){
                                                  createPersonStatus(personstatus:$personstatus)
                                                  {
                                                iD,value
                                                  }
                                                }",
                OperationName = "CreatePS",
                Variables = new
                {
                    personstatus = new { value = LastName }
                }
            };


            // Assert

            var response = await _graphQLHttpClient
                          .SendQueryAsync<data_create>(_GraphQLRequest);

            // Assert
            Assert.NotNull(response.Data);
            Assert.True(response.Data.createPersonStatus.iD == 1);


        }


        [Fact]
        public async Task GetPersonById()
        {

            //Arrange

            string Id = "3";


            // Assert
            var response = await _graphQLHttpClient
                          .SendQueryAsync<data>(@"query GetPersonById($iD: ID!) {
                                          getPerson(iD: $iD) {
                                          lastName
                                              }
                        }",
                          new
                          {
                              iD = Id
                          }, "GetPersonById");


            // Assert
            Assert.NotNull(response.Data);
            Assert.True(response.Data.getPerson.lastName != "");




        }

        [Fact]
        public async Task GetPersonAll()
        {

            //Arrange


            // Act

            var response = await _graphQLHttpClient
                          .SendQueryAsync<data_All>(@"
                                        query {
                                          persons {
                                           lastName 
                                          }
                                }

                        ");
            // Assert
            Assert.NotNull(response.Data);
            Assert.True(response.Data.persons.Count() > 0);


        }





    }


}