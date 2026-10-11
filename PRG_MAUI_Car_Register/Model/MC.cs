using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    public class MC : Vehicle
    {
        public override string GetDescription()
        {
            return $"MC\t{RegistrationNumber}\t{Manufacturer}\t{Model}\t{YearModel}";
        }
    }
}
