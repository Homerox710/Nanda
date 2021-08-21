using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nanda.BaseDatos;

namespace Nanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {

        public Master()
        {
            InitializeComponent();

            btnAcerca.Clicked += BtnAcerca_Clicked;
            btnUbicacion.Clicked += BtnUbicacion_Clicked;
            btnAbonos.Clicked += BtnAbonos_Clicked;
        }

        private async void BtnAbonos_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new Compras());
        }

        private async void BtnUbicacion_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new Ubicacion());
        }

        private async void BtnAcerca_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new Acerca());
        }
    }
}