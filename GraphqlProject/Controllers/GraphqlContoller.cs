using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class GraphqlController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GraphqlController(IHttpClientFactory httpClientFactory, ILogger<GraphqlController> logger)
    {
        _httpClientFactory = httpClientFactory;
       
    }

    [HttpGet(Name = "get")]
    public async Task<IActionResult> Get()
    {
        var graphqlQuery = @"
            query {
                customers(first: 20, page: 1) {
                    data {
                        name
                        products {
                            amount
                        }
                    }
                }
            }";

        var content = new StringContent(graphqlQuery, Encoding.UTF8, "application/json");

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://playground.geniousoft.com/graphql")
        {
            Content = content
        };

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var jsonResponse = await JsonSerializer.DeserializeAsync<GraphQLResponse>(contentStream);

                return Ok(jsonResponse);
            }
            else
            {                
                return BadRequest();
            }
        }
        catch (Exception ex)
        {       
            return BadRequest();
        }
    }

    public class GraphQLResponse
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("customers")]
        public Customers Customers { get; set; }
    }

    public class Customers
    {
        [JsonPropertyName("data")]
        public List<Customer> Data { get; set; }
    }

    public class Customer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
