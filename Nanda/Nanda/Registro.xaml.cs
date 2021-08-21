using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nanda.BaseDatos;

namespace Nanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
            //btnVer.Clicked += BtnVer_Clicked; //Metodo para ver que usuarios hay registrados
        }

        /*private void BtnVer_Clicked(object sender, EventArgs e)
        {
            var allUsers = SQLConnect.Instancia.GetAllUsers();
            userList.ItemsSource = allUsers;
            StatusMessage.Text = SQLConnect.Instancia.EstadoMensaje;
        }*/

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            SQLConnect.Instancia.AddNewUser(txtUsername.Text, txtFullName.Text, txtEmail.Text, txtPassword.Text, txtTarjetaBanco.Text, Int32.Parse(txtCodigoSeguridad.Text));
            //Llama al metodo en SQLConnect para añadir los datos de Users
            StatusMessage.Text = SQLConnect.Instancia.EstadoMensaje;
        }
    }
}