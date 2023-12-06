using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class BasicModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BasicModel(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public async Task OnGet()
    {
        var graphqlQuery = @"
        {
            ""query"": ""query {
                customers(first: 20, page: 1) {
                    data {
                        name
                        products {
                            amount
                        }
                    }
                }
            }""
        }";

        var content = new StringContent(graphqlQuery, Encoding.UTF8, "application/json");

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://playground.geniousoft.com/graphql-playground")
        {
            Content = content
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            // Burada dönen JSON içeriği ile ne yapmak istediğinizi ekleyebilirsiniz.
        }
    }
}
