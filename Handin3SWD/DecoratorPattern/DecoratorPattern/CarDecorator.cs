using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class CarDecorator : ICar
    {
        protected ICar Car;

        protected CarDecorator(ICar car)
        {
            Car = car;
        }

        public virtual  double GetCost()
        {
            return Car.GetCost();
        }

        public virtual string GetAccessories()
        {
            return Car.GetAccessories();
        }
    }
}
