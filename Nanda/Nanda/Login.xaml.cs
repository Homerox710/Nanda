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
    public partial class Login : ContentPage
    {
        public static Users user = new Users();
        public Login()
        {
            InitializeComponent();
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
            btnIr.Clicked += BtnIr_Clicked;
        }

        private void BtnIr_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Consulta = SQLConnect.Instancia.GetAllUsers(); //Agarra todos los usuarios existentes 
                var usuario = (from user in Consulta where user.Username == txtUsuario.Text select user).First(); //Consulta si el TXT es igual a algun usuario registrado
                if (usuario.Password == txtPassword.Text) //Como ya se valido usuario, se valida la contraseña
                {
                    user = usuario; //Coge el user de la tabla para meterlo dentro de la consulta y asimilar la contraseña
                    ((NavigationPage)this.Parent).PushAsync(new MainPage()); //Redirecciona al MainPage
                }
                else
                {
                    StatusMessage.Text = string.Format("Contraseña incorrecta"); //Mensaje Label
                }
            }
            catch (Exception)
            {

                StatusMessage.Text = string.Format("Usuario no existe"); //Mensaje Label
            }
            
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
    }
}