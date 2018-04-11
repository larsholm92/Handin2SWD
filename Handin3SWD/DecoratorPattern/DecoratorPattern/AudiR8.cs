using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class AudiR8 : ICar
    {
        public double GetCost()
        {
            return 3700000;
        }

        public string GetAccessories()
        {
            return "5.2 FSI V10 Plus Quattro";
        }
    }
}
