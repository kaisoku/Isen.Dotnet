using System;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string result =  Hello.Greet("Kail");
            Console.WriteLine(result);
        }
    }
}
