using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asynchronous_Programming
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //create task and start it
            //...wait for it to comlete
            Task task = new Task(ProcessDataAsync);
            task.Start();
            task.Wait();
           
            Console.ReadLine();
        }
        static async void ProcessDataAsync()
        {
            //start the HandleFile method
            Task<int> task = HandleFileAsync("C:\\Users\\derob\\Desktop\\Derrick M.Butoyi");
            //control returns here before HandleFileAsync returns.
            //...Prompt user 
            Console.WriteLine("please wait patiently" + "while i do something important.");

            //Wait for the HandleFile task to complete 
            //display the results.

            int x = await task;
            Console.WriteLine("count:" + x);
            // Wait for the HandleFile task to complete.
            // ... Display its results.
           
        }
        static async Task<int> HandleFileAsync(string file)
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
        }

    }

    
}
