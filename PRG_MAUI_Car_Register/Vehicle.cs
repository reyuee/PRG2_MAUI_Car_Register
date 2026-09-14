using System.Text.RegularExpressions;
namespace PRG_MAUI_Car_Register
{
    class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;

        private int yearModel;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Registreringsnummer får inte vara tomt.");
                }

                bool isValid = Regex.IsMatch(value, "^[A-Z]{3}[0-9]{2}[A-Z0-9]$");

                if (!isValid)
                {
                    throw new ArgumentException("Fel format formatet måste vara ABC123 eller ABC12A.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        //TODO Tillverkare ska valideras, sparas i objektet och visas i UI
        public string Model
        {
            get { return model; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("En bil modell kan inte vara tom.");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-')
                    {
                        throw new ArgumentException("Modell får endast innehålla bokstäver, siffror, mellanslag och bindestreck.");
                    }
                }

                this.model = value;
            }
        }

        //TODO Modell ska valideras, sparas i objektet och visas i UI
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("En bils märke måste bestå av bokstäver, det kan inte vara tomt.");
                }


                foreach (char c in value)
                {
                    if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-')
                    {
                        throw new ArgumentException("Märke får endast innehålla bokstäver, siffror, mellanslag och bindestreck.");
                    }
                }

                this.manufacturer = value;
            }
        }

        public int YearModel
        {
            get { return yearModel; }
            set
            {
                string stringValue = value.ToString();

                if (value < 1895 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Ogiltig årsmodell.");
                }

                if (!Regex.IsMatch(stringValue, "^[1-2][0-9][0-9][0-9]$"))
                {
                    throw new ArgumentException("Årsmodellen måste bestå av fyra siffror.");
                }

                this.yearModel = value;
            }
        }

        
        

           

        

        //TODO Lägg till möjligheten att spara realistisk årsmodell, validera, spara och visa i objektet och visas i UI. Tips: Regex.IsMatch()


        //TODO Modifiera overriden på ToString() så att allt visas som önskat i UIs listBox
        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model;
        }
    }
}
