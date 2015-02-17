using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication2.ServiceReference1;
namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            TrackingClient obj = new TrackingClient();
            
            string contact = "359772039";
            string pass = "Admin@123";
            
            Console.WriteLine("The Request consists of");
            Console.WriteLine(obj.Login(contact, pass));
        }
    }
}
