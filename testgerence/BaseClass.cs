using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;
using apigerence;

namespace testgerence
{
    public class BaseClass : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient Client;

        protected static readonly string Pathbase = "/api/v1/";
        
        protected static readonly string ContentType = "application/json; charset=utf-8";

        protected BaseClass() =>
            Client = new WebApplicationFactory<Startup>().CreateClient();
    }
}
