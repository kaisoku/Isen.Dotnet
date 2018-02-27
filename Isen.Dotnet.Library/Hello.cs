using System;

namespace Isen.Dotnet.Library
{
    //renvoie des salutations
    public class Hello
    {
        public static string Greet(string name){
            string message = "Hello " +name;
            return message;
        }
    }
}
