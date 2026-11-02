using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Vehicle> vehicleList = new ObservableCollection<Vehicle>();
        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
            listViewVehicles.ItemsSource = vehicleList;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                Vehicle vehicle;

                if(pickerType.SelectedIndex == 0)
                {
                    vehicle = new Car();
                }
                else if (pickerType.SelectedIndex == 1)
                {
                    vehicle = new MC();
                }
                else
                {
                    vehicle = new Truck();
                }

                vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                vehicle.Manufacturer = entryManufacturer.Text;
                vehicle.Model = entryModel.Text;

                if (!int.TryParse(entryYearModel.Text, out int parsedYear))
                {
                    throw new ArgumentException("Du måste fylla i en giltig årsmodell med siffror.");
                }
                vehicle.YearModel = parsedYear;

                vehicleList.Add(vehicle);
                

                ClearTextFields();
            }

            // här "fångas" eventuella felmeddelanden från Vehicle
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            IEnumerable<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.OfType<Car>();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.OfType<MC>();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.OfType<Truck>();

            }
            else
            {

                filteredList = vehicleList;

            }

            listViewVehicles.ItemsSource = filteredList;
        }


        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {

                labelSearchResult.Text = foundVehicle.GetDescription();
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

        private void ClearTextFields()
        {
            entryRegistrationNumber.Text = string.Empty;
            entryManufacturer.Text = string.Empty;
            entryModel.Text = string.Empty;
            entryYearModel.Text = string.Empty;


        }

    }
}
