using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    //Alexander Rasmussen	    au566287
    //Christoffer Broberg       au559138
    //Jakob Dybdahl             au567226
    //Lars Holm                 au479361

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All-inclusive Audi R8");
            ICar Audi = new LEDFrontLightwAudiLaserlight(new CeramicBrake( new CruiseControl(new WheelRim(new EnlargedFuelTank(new AudiR8())))));

            Console.WriteLine("{0:C}",Audi.GetCost());
            Console.WriteLine(Audi.GetAccessories());

            Console.WriteLine("\nAudi R8, budget version");

            ICar Audib = new CruiseControl(new AudiR8());

            Console.WriteLine("{0:C}", Audib.GetCost());
            Console.WriteLine(Audib.GetAccessories());


        }
    }
}
