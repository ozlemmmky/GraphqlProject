using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphqlProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Net;
using System.Xml.Linq;

[Route("api/[controller]")]
[ApiController]
public class TransferController : ControllerBase
{
   
    [HttpGet, Route("get-all")]
    public async Task<IActionResult> GetTransfer()
    {
        var endpoint = "https://playground.geniousoft.com/graphql";

        var httpClientOption = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri(endpoint)
        };


        var graphHttpClient = new GraphQLHttpClient(httpClientOption, new NewtonsoftJsonSerializer());
        var graphQLRequest = new GraphQLRequest
        {
            Query = @"
                 query {
     customer(id: ""1"") {
         id
         name
         type
         email
         address
         city
         state
         products {
                id
             amount
             status
             billed_date
             paid_date
            }
        }}"
 
};

        var graphQLResponse = graphHttpClient.SendQueryAsync<Response>(graphQLRequest);
        return Ok(graphQLResponse);
    }
}