using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Net;
using System.Xml.Linq;
using GraphqlProject.Helpers;
using Microsoft.EntityFrameworkCore;
using GraphQL.Client.Abstractions;

[Route("api/[controller]")]
[ApiController]
public class TransferController : ControllerBase
{
    readonly GraphqlDbContext _dbContext;
    public TransferController(GraphqlDbContext dbContext)
    {
        _dbContext = dbContext;          
    }

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
     customers(first:100) {
     data{
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
        }
        }}"
        };
        var graphQLResponse = graphHttpClient.SendQueryAsync<Response>(graphQLRequest);

            foreach (var customerDataContainer in graphQLResponse.Result.Data.Customers.Data)
            {
            
                var customerData = customerDataContainer.Products;
            _dbContext.Customers.Add(customerDataContainer);

            foreach (var product in customerData)
                {
            _dbContext.Products.Add(product);
            }               
            }
            _dbContext.SaveChanges();

            return Ok();
        

    }
}