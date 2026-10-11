using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    public class Truck : Vehicle
    {
        public override string GetDescription()
        {
            return $"Lastbil\t{RegistrationNumber}\t{Manufacturer}\t{Model}\t{YearModel}";
        }
    }
}