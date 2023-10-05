using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Avtostyanka park = new Avtostyanka(10);
            park.AddCar("A111AB", "red", "BMW");
            park.AddCar("B234CK", "green", "Петя", "Rools-Royce");
            park.AddCar("B493MX", "blue", "Коля", "Lada");
            park.AddCar("Y393AA", "grey", "Дима", "Mercedes ");
            park.PrintAllCar();
            Console.WriteLine("--------------------------------------");
            park.DeleteCar("B493MX");
            park.AddCar("E610BM", "red", "Другой Петя", " Toyota ");
            park.PrintAllCar();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
            park.Find("A111AB");
            Console.ReadKey();
        }

    }   
}
