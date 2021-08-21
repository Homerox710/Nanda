using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nanda.BaseDatos;
using static Nanda.Login;

namespace Nanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recargas : ContentPage
    {
        public Recargas()
        {
            InitializeComponent();
            btnRecargar.Clicked += BtnRecargar_Clicked;
        }

        private void BtnRecargar_Clicked(object sender, EventArgs e)
        {
            var Usuario = Login.user; 
            string Id = Usuario.Username;
            int Recarga = Int32.Parse(entryRecarga.Text);
            Usuario.Saldo += Recarga;
            SQLConnect.Instancia.UpdateUser(user);
            StatusMessage.Text = SQLConnect.Instancia.EstadoMensaje;
        }
    }
}