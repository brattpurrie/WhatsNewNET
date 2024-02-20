using Xunit.Abstractions;

namespace WhatsNewNET.Tests
{
    /// <summary>
    /// if the given api is not working use https://github.com/public-apis/public-apis to find a new one.
    /// </summary>
    public class HttpClient_Exercises
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public HttpClient_Exercises(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        /// <summary>
        /// Exercise 1: GET call to https://cat-fact.herokuapp.com/facts/random using HTTP client factory.
        /// reference: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0    
        /// hints
        ///     * you have to use dependency injection
        ///     * Register .AddHttpClient, resolve IHttpClientFactory
        ///
        /// Goal of this exercise:
        ///     * Get a feeling for httpclient factory
        /// </summary>

        [Fact]
        public async Task Exercise_1()
        {
        }



        /// <summary>
        /// Exercise 2: Using polly, GET call to https://cat-fact.herokuapp.com/facts/random with HTTP client factory 
        /// reference: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0    
        /// hints
        ///     * you have to use dependency injection,  Register .AddHttpClient, resolve IHttpClientFactory
        ///     * create a simple model to deserialize
        ///     
        /// goal of this exercise:
        ///     * Use Microsoft.Extensions.Http.Resilience
        /// </summary>

        [Fact]
        public async Task Exercise_2()
        {

        }

        /// <summary>
        /// Exercise 3: Implement httpclient with httpclient factory that uses a dynamic way to set a token or api key
        /// </summary>

        [Fact]
        public async Task Exercise_3()
        {
        }


        /// <summary>
        /// Exercise 4: advanced, try to generate a http client based on a open api definition.
        /// hints
        ///  * use something like Nswag or similar
        ///
        /// Goal of the exercise:
        ///  * Don't write http clients yourself if you can let them be generated for you
        ///
        /// if interested I can show a short demo.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Exercise_4()
        {
        }
    }
}
