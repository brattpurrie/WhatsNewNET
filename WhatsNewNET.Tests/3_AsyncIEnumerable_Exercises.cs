using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using static WhatsNewNET.Tests._3_AsyncIEnumerable_Exercises;

namespace WhatsNewNET.Tests
{
    public class _3_AsyncIEnumerable_Exercises
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public _3_AsyncIEnumerable_Exercises(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        /// <summary>
        /// Exercise 1: GET call to https://cat-fact.herokuapp.com/facts using GetFromJsonAsAsyncEnumerable & the correct class to map to
        /// reference: https://learn.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8
        /// hints
        ///     * IAsyncEnumerable doesnt do anything yet
        ///     * Similarly to IEnumerable
        ///     * Create a simple record type
        ///
        /// Goal of this exercise:
        ///     * Get a feeling for IAsyncEnumerable
        ///     * Consume the API using the AsyncEnumerable value
        [Fact]
        public async Task Exercise_1()
        {

        }
    }
}
