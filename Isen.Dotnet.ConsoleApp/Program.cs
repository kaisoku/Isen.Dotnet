using System;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string result =  Hello.GreetUpper("Kail");
            Console.WriteLine(result);
        }
    }
}
