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
                var Consulta = SQLConnect.Instancia.GetAllUsers();
                var usuario = (from user in Consulta where user.Username == txtUsuario.Text select user).First();
                if (usuario.Password == txtPassword.Text)
                {
                    user = usuario;
                    ((NavigationPage)this.Parent).PushAsync(new MainPage());
                }
                else
                {
                    StatusMessage.Text = string.Format("Contraseña incorrecta");
                }
            }
            catch (Exception)
            {

                StatusMessage.Text = string.Format("Usuario no existe");
            }
            
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }
    }
}