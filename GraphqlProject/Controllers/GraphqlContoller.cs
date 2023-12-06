//using GraphQL;
//using GraphQL.Client.Abstractions;
//using GraphQL.Client.Http;
//using GraphQL.Client.Serializer.Newtonsoft;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Net;
//using System.Net.Http;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using static GraphqlController;

//[ApiController]
//[Route("[controller]")]
//public class GraphqlController : ControllerBase
//{
//    private readonly IHttpClientFactory _httpClientFactory;
//    public readonly GraphQLHttpClient _graphQLHttpClient;

//    public GraphqlController(IHttpClientFactory httpClientFactory)
//    {
//        _graphQLHttpClient = GetGraphQlApiClient();
//        _httpClientFactory = httpClientFactory;
//    }
//    public GraphQLHttpClient GetGraphQlApiClient()
//    {
       
//        var endpoint = "https://playground.geniousoft.com/graphql";

//        var httpClientOption = new GraphQLHttpClientOptions
//        {
//            EndPoint = new Uri(endpoint)
//        };

//        return new GraphQLHttpClient(httpClientOption, new NewtonsoftJsonSerializer());
//    }
//    public interface ITransferService
//    {
//        Task<IEnumerable<TransferDto>> GetTransfers();
//    }
//    public class TransferService : GraphqlClientBase, ITransferService
//    {
//        public async Task<IEnumerable<TransferDto>> GetTransfers()
//        {
//            var query = @"query {
//                customer(id: ""1"") {
//                    id
//                    name
//                    type
//         email
//                    address
//         city
//                    state
//         products {
//                        id
//                        amount
//             status
//             billed_date
//             paid_date
//         }
//                }
//            }";

//            var request = new GraphQLRequest(query);


//            var response = await _graphQLHttpClient.SendQueryAsync<TransferQueryResponse>(request);
//            return response.Data.Transfer;
//        }
//    }
//    public class TransferQueryResponse
//    {
//        public IEnumerable<TransferDto> Transfer { get; set; }
//    }

//    public class TransferDto
//    {
//        public int Id { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//    }

//    //[HttpGet(Name = "get")]
//    //public async Task<IActionResult> get()
//    //{
//    //    var graphqlQuery = @"
//    //        query {
//    //            customer(id: ""1"") {
//    //                id
//    //                name
//    //                type
//    //                email
//    //                address
//    //                city
//    //                state
//    //                products {
//    //                    id
//    //                    amount
//    //                    status
//    //                    billed_date
//    //                    paid_date
//    //                }
//    //            }
//    //        }";

//    //    var content = new StringContent(graphqlQuery, Encoding.UTF8, "application/json");

//    //    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://playground.geniousoft.com/graphql")
//    //    {
//    //        Content = content
//    //    };

//    //    try
//    //    {
//    //        var httpClient = _httpClientFactory.CreateClient();
//    //        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

//    //        if (httpResponseMessage.IsSuccessStatusCode)
//    //        {
//    //            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
//    //            var jsonResponse = await JsonSerializer.DeserializeAsync<GraphQLResponse>(contentStream);

//    //            return Ok(jsonResponse);
//    //        }
//    //        else
//    //        {
//    //            return BadRequest();
//    //        }
//    //    }
//    //    catch (Exception ex)
//    //    {
//    //        return BadRequest();
//    //    }
//    //}
//    //public class GraphQLResponse
//    //{
//    //    [JsonPropertyName("data")]
//    //    public Data Data { get; set; }
//    //}

//    //public class Data
//    //{
//    //    [JsonPropertyName("customer")]
//    //    public Customer Customer { get; set; }
//    //}

//    //public class Customer
//    //{
//    //    [JsonPropertyName("id")]
//    //    public string Id { get; set; }

//    //    [JsonPropertyName("name")]
//    //    public string Name { get; set; }

//    //    [JsonPropertyName("type")]
//    //    public string Type { get; set; }

//    //    [JsonPropertyName("email")]
//    //    public string Email { get; set; }

//    //    [JsonPropertyName("address")]
//    //    public string Address { get; set; }

//    //    [JsonPropertyName("city")]
//    //    public string City { get; set; }

//    //    [JsonPropertyName("state")]
//    //    public string State { get; set; }

//    //    [JsonPropertyName("postal_code")]
//    //    public string PostalCode { get; set; }

//    //    [JsonPropertyName("products")]
//    //    public List<Product> Products { get; set; }
//    //}

//    //public class Product
//    //{
//    //    [JsonPropertyName("id")]
//    //    public string Id { get; set; }

//    //    [JsonPropertyName("amount")]
//    //    public int Amount { get; set; }

//    //    [JsonPropertyName("status")]
//    //    public string Status { get; set; }

//    //    [JsonPropertyName("billed_date")]
//    //    public DateTime BilledDate { get; set; }

//    //    [JsonPropertyName("paid_date")]
//    //    public DateTime PaidDate { get; set; }
//    //}



//    //[HttpGet]
//    //public async Task<IActionResult> GraphqlHttp()
//    //{
//    //    var graphQLClient = new GraphQLHttpClient("https://playground.geniousoft.com/graphql");
//    //    var graphqlQuery = @"
//    //        query {
//    //            customer(id: ""1"") {
//    //                id
//    //                name
//    //                type
//    //                email
//    //                address
//    //                city
//    //                state
//    //                products {
//    //                    id
//    //                    amount
//    //                    status
//    //                    billed_date
//    //                    paid_date
//    //                }
//    //            }
//    //        }";
//    //    var response = await graphQLClient.SendQueryAsync(graphqlQuery);
//    //    return Ok(response);
//    //}
//}