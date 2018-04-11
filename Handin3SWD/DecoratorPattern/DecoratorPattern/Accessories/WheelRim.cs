using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class WheelRim : CarDecorator
    {
        public WheelRim(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return Car.GetCost() + 32570;
        }

        public override string GetAccessories()
        {
            return Car.GetAccessories() + ", Wheel rim";
        }


    }
}
