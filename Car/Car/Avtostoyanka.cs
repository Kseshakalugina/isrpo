using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    
    class Avtostyanka
    {
        private bool[] place;
        private List<Car> list = new List<Car>(); 
        
        public Avtostyanka(int count)
        {
            place = new bool[count];
        }


        public void AddCar(Car car) 
        {
            for (int i = 0; i < place.Length; i++)
            {
                if (place[i] == false)
                {
                    place[i] = true;
                    list.Add(car);
                    return;
                }
            }
            Console.WriteLine("Нет свободных мест");
        }
        public void DeleteCar(string number) 
        {
            foreach (Car car in list)
            {
                if (car.Number == number)
                {
                    list.Remove(car);
                    place[((MyCar)car).Order] = false;
                    return;
                }
            }
            Console.WriteLine("Машины с таким номер не существет ",number);
        }
        public void RemCar(int n) 
        {
            foreach (Car car in list)
            {
                if (((MyCar)car).Order == n)
                {
                    list.Remove(car);
                    place[((MyCar)car).Order] = false;
                    return;
                }
            }
            Console.WriteLine("Нет такой машины: [{0}]", n);
        }
        public void PrintAllCar() 
        {
            foreach (Car car in list)
            {
                Console.WriteLine(car);
            }
        }
        public void Find(string param) // поиск (номер/цвет/владелец)
        {
            Console.WriteLine("Поиск с параметром: [{0}]", param);
            foreach (Car car in list)
            {
                if (car.Color == param || car.Number == param || ((MyCar)car).Owner == param)
                {
                    Console.WriteLine(car);
                }
            }
        }
        public void Find(int place) // поиск (номер места на стоянке)
        {
            Console.WriteLine("Поиск с параметром: [{0}]", place);
            foreach (Car car in list)
            {
                if (((MyCar)car).Order == place)
                {
                    Console.WriteLine(car);
                }
            }
        }

        
    }
}




