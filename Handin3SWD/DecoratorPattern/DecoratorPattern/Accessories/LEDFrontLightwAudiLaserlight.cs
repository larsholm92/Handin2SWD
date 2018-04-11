using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class LEDFrontLightwAudiLaserlight: CarDecorator
    {
        public LEDFrontLightwAudiLaserlight(ICar car) : base(car)
        {
        }
        public override double GetCost()
        {
            return Car.GetCost() + 73395;
        }

        public override string GetAccessories()
        {
            return Car.GetAccessories() + ", LED FrontLight Package";
        }
    }
}
