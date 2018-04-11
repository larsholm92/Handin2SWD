using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class CeramicBrake : CarDecorator
    {
        public CeramicBrake(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return Car.GetCost() + 193321;
        }

        public override string GetAccessories()
        {
            return Car.GetAccessories() + ", Ceramic Brakes";
        }
    }
}
