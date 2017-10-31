using BlogSpot.Api;
using Microsoft.Owin.Hosting;
using System;

namespace BlogSpot.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var host = WebApp.Start<StartUp>("http://localhost:9992"))
            {
                Console.ReadKey();
            }
        }
    }
}
