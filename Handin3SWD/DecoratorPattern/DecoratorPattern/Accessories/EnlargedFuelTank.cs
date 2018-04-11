using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class EnlargedFuelTank : CarDecorator
    {
        public EnlargedFuelTank(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return Car.GetCost() + 41242;
        }

        public override string GetAccessories()
        {
            return Car.GetAccessories() + ", 83 liter fuel tank";
        }


    }
}
