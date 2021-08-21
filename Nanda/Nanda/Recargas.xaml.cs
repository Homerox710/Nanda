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
            var Usuario = Login.user; //Usa el usuario del Login ya registrado
            string Id = Usuario.Username; //Crea una variable para insertar este dato
            int Recarga = Int32.Parse(entryRecarga.Text); //Conversion del Entry a Int
            Usuario.Saldo += Recarga; //Se le suma el saldo del usuario más la recarga escrita
            SQLConnect.Instancia.UpdateUser(user); //Hace el update en el campo de Saldo
            StatusMessage.Text = SQLConnect.Instancia.EstadoMensaje;
        }
    }
}