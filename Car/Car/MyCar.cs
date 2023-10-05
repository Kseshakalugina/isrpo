using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class MyCar: Car
    {

        private string owner; // владелец
        private int order; // номер места на стоянке

        public MyCar(string num, string col, string own, int ord, Marka mar) : base(num, col, mar)
        {

        }
        public string Owner
        {
            get { return owner; }
        }
        public int Order
        {
            get { return order; }
        }
        public override string ToString()
        {
            return string.Format("Владелец:[{2}], Место:[{3}]", owner, order);
        }
        
           
    }

    
}
