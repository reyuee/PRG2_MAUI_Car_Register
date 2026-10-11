using System.Text.RegularExpressions;
namespace PRG_MAUI_Car_Register.Model
{
    public abstract class Vehicle
    {
        // Medlemsvariabler
        
        
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;

        private int yearModel;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle()
        {
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


       public abstract string GetDescription();

       public override string ToString()
        {
            return GetDescription();
        }


    }   
}
