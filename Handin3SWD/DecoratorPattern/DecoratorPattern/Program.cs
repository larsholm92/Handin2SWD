using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar Audi = new LEDFrontLightwAudiLaserlight(new CeramicBrake( new CruiseControl(new WheelRim(new EnlargedFuelTank(new AudiR8())))));

            Console.WriteLine("{0:C}",Audi.GetCost());
            Console.WriteLine(Audi.GetAccessories());
        }
    }
}
