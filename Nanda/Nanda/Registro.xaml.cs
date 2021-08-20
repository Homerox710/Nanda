
﻿using System;
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
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            SQLConnect.Instancia.AddNewUser(txtUsername.Text, txtFullName.Text, txtEmail.Text, txtPassword.Text, Int32.Parse(txtPhone.Text));
            StatusMessage.Text = SQLConnect.Instancia.EstadoMensaje;
        }
    }

}