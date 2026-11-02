using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; } = 50000;

        public override string GetDescription()
        {
            return $"{RegistrationNumber}\tLastbil\t{Manufacturer}\t{Model}\t{YearModel}\tMaxlast: {LoadCapacity} kg";
        }
    }
}