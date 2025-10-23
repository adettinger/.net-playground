using System;
using System.Net.Http;
using System.Threading.Tasks;

class AsyncDemo
{
    class AsyncProgram
    {
        public static async Task Main()
        {
            string url1 = "https://jsonplaceholder.typicode.com/todos/1";
            string url2 = "https://jsonplaceholder.typicode.com/todos/2";

            Task<string> result1Task = FetchDataAsync(url1);
            Task<string> result2Task = FetchDataAsync(url2);

            Console.WriteLine("Simulating other work...");

            string result1 = await result1Task;
            string result2 = await result2Task;

            Console.WriteLine($"Result from {url1}: {result1}");
            Console.WriteLine($"Result from {url2}: {result2}");
            Console.ReadLine(); //Keeping console window open
        }

        static async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return ($"Error: {response.StatusCode}");
                }
            }
        }
    }
}