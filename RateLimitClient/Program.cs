using System.Net.Http.Json;

class Program
{
    private static readonly HttpClient httpClient = new HttpClient();
    static async Task Main(string[] args)
    {
        Console.WriteLine("ENTER TO START");
        Console.ReadLine();
        string[] users = { "sagar", "john", "peter" };
        Task[] tasks = new Task[18];
        int taskIndex = 0; 
        foreach (var item in users)
        {
            for (int i = 0; i < 6; i++)
            {
                tasks[taskIndex++] = Task.Run(async () =>
                {
                    using var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7111/api/Books");
                    request.Headers.Add("my-name", item);

                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine($"Req - {taskIndex} {item}- {response.StatusCode}");
                });
            }
        }      


        await Task.WhenAll(tasks);

        Console.ReadLine();
    }
}