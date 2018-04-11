using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class CruiseControl : CarDecorator
    {
        public CruiseControl(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return Car.GetCost() + 6495;
        }

        public override string GetAccessories()
        {
            return Car.GetAccessories() + ", Cruise Control";
        }
    }
}
