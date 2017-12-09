using System;
using Nancy.Hosting.Self;

namespace Docker.Mono.NancyDemo
{
    public static class HTML
    {
        public static string toHTML(this string message)
        {
            return $"<h1><center>{message}</center></h1>";
        }
    }

    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => "C# ~ Nancy - Hello World!".toHTML();
            Get["/os"] = _ => Environment.OSVersion.ToString().toHTML();
        }

        static void Main(string[] args)
        {
            var url = "http://localhost";
            var port = 12345;

            var uri = new Uri($"{url}:{port}/");
            var host = new NancyHost(uri);

            Console.WriteLine($"Starting Nancy App - listening on port {url}:{port}/!");
            host.Start();
            Console.ReadKey();
            host.Stop();
            Console.WriteLine("Nancy Stopped. Good bye!");
        }
    }
}
