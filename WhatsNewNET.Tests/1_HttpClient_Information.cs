using System.Net.NetworkInformation;
using System.Net;
using Xunit.Abstractions;
using System.Net.Http.Json;
using System.Threading;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace WhatsNewNET.Tests
{
    public class HttpClient_Information
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public HttpClient_Information(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Windows will hold a connection in this state for 240 seconds, even if you implement 'using' correct in combination with http client
        /// It is set by [HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\TcpTimedWaitDelay
        /// There is a limit to how quickly Windows can open new sockets so if you exhaust the connection pool then you’re likely to see error like:
        ///     Unable to connect to the remote server
        ///     System.Net.Sockets.SocketException: Only one usage of each socket address(protocol/network address/port) is normally permitted.
        /// </summary>
        [Fact]
        public async Task Socket_starvation_the_problem()
        {
            var amount_of_calls = 1000;
            var tasks = new List<Task>();

            var maxConcurrentTasks = 10;
            var semaphore = new SemaphoreSlim(maxConcurrentTasks);
            for (var i = 0; i < amount_of_calls; i++)
            {
                tasks.Add(Task.Run(async () =>
                {

                    await semaphore.WaitAsync();
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            await client.GetAsync("http://aspnetmonsters.com");
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            var tcpConnectionsBefore = GetTCPConnections();

            await Task.WhenAll(tasks);

            var tcpConnectionsafter = GetTCPConnections();
            _testOutputHelper.WriteLine($"Increase in TCP connections {tcpConnectionsafter - tcpConnectionsBefore}");
        }

        [Fact]
        public async Task Socket_starvation_the_solution()
        {
            var client = new HttpClient();
            var amount_of_calls = 1000;
            var tasks = new List<Task>();


            var maxConcurrentTasks = 10;
            var semaphore = new SemaphoreSlim(maxConcurrentTasks);
            for (var i = 0; i < amount_of_calls; i++)
            {
                tasks.Add(Task.Run(async () =>
                {

                    await semaphore.WaitAsync();
                    try
                    {
                        await client.GetAsync("http://aspnetmonsters.com");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            var tcpConnectionsBefore = GetTCPConnections();

            await Task.WhenAll(tasks);

            var tcpConnectionsafter = GetTCPConnections();
            _testOutputHelper.WriteLine($"Increase in TCP connections {tcpConnectionsafter - tcpConnectionsBefore}");
        }


        private int GetTCPConnections()
        {
            string targetIpAddress = "3.220.40.113";

            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var connections = properties.GetActiveTcpConnections();

            return connections
                .Where(connection => connection.RemoteEndPoint.Address.ToString() == targetIpAddress)
                .Count();
        }
    }
}
