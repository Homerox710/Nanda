using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ubicacion : ContentPage
    {
        public Ubicacion()
        {
            InitializeComponent();
            btnAbrir.Clicked += BtnAbrir_Clicked;
            btnAbrirUH.Clicked += BtnAbrirUH_Clicked;
            BtnCall.Clicked += BtnCall_Clicked;
            btnAbrirCM.Clicked += BtnAbrirCM_Clicked;
        }

        private void BtnAbrirCM_Clicked(object sender, EventArgs e)
        {
           
        }

        private void BtnAbrirUH_Clicked(object sender, EventArgs e)
        {
            UbicacionCM();

        }
        public async Task avisoAsync()
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }


        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(txtNumero.Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("No se puede hacer la llamada", "Intentelo mas tarde", "OK");
            }
        }
        private async void UbicacionCM()
        {

            if (!Double.TryParse(txtLatitudCM.Text, out double lat))
                return;
            if (!Double.TryParse(txtLongitudCM.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }
        private async void UbicacionH()
        {

            if (!Double.TryParse(txtLatitudH.Text, out double lat))
                return;
            if (!Double.TryParse(txtLongitudH.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }
        private async void UbicacionM()
        {

            if (!Double.TryParse(txtLatitud.Text, out double lat))
                return;
            if (!Double.TryParse(txtLongitud.Text, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }
        private void BtnAbrir_Clicked(object sender, EventArgs e)
        {
            UbicacionM();
        }
    }
}