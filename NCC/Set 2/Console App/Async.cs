using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Set2_Async
{
    class Async
    {
        public static async Task<string> GetStringAsync()
        {
            Console.WriteLine("\nFetching string asynchronously...");
            await Task.Delay(3000);
            Console.WriteLine("Fetched string!\n");
            return "String Data";
        }

        public static async Task<int> GetIntAsync(string data)
        {
            Console.WriteLine("\nFetching int asynchronously...");
            await Task.Delay(1000);
            Console.WriteLine("Fetched int!\n");
            return 20;
        }

        public static void Run()
        {
            Console.WriteLine("Starting async method...");
            var stringTask = GetStringAsync();

            var intTask = GetIntAsync("Some data");

            Console.WriteLine("\nWaiting for tasks to complete...\n");

            Task.WaitAll(stringTask, intTask);

            Console.WriteLine("All tasks completed!\n");
        }
    }
}
