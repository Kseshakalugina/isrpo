using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Car
    {

        private string number; // номер
        private string color; // цвет       
        private Marka marka;
        


            public enum Marka
            {
                Toyota = 1,
                BMW = 2,
                Mercedes = 3,
                Lada = 4,
                Rolls_Royce = 5

            }
            public Car(string num, string col, Marka mar)
            {
                number = num;
                color = col;
                marka = mar;
                
                

                
            }
        public string Number
        {
            get { return number; }
        }
        public string Color
        {
            get { return color; }
        }
        public Marka Brand
        {
            get { return marka; }
        }
        public override string ToString()
        {
            return string.Format("Номер:[{0}], Цвет:[{1}], Марка :[{2}] ", number, color, marka);
        }
    }
}
