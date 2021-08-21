using Nanda.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Nanda.Login;
using System.Net.Mail;
using static Nanda.Login;

namespace Nanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]



    public partial class Carrito : ContentPage
    {
        public int total = 0;
        public List<Products> Products { get; private set; }
        public Carrito(List<Products> Carrito)
        {
            InitializeComponent();
            Products = Carrito;
            foreach (var item in Products) //Por cada producto, se le suma al total
            {
                total = total + item.Price;
            }
            lblTotal.Text += total.ToString();
            BindingContext = this;
            btnPagar.Clicked += BtnPagar_Clicked;
        }

        private async void BtnPagar_Clicked(object sender, EventArgs e)
        {
            var saldo = Login.user.Saldo;
            if (saldo > total) //Asi se asegura que tenga dinero en la tarjeta
            {
                user.Saldo -= total; //Resta el Saldo - Total 

                string EmailOrigen = "nandacr236@gmail.com"; //Correo de Nanda
                var Consulta = SQLConnect.Instancia.GetAllUsers();
                var Usuario = Login.user;
                var usuario = (from user in Consulta where user.Username == Usuario.Username select user).First();
                string EmailDestino = usuario.Email; //Agarra el correo del usuario ingresado
                string password = "ULACIT123"; //Contraseña de Nanda

                MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Factura Electronica Nanda", Facturar());
                //Este es el mensaje que despliega en el correo
       
                oMailMessage.IsBodyHtml = true;

                SmtpClient oSmtpCliente = new SmtpClient("smtp.gmail.com"); //Protocolo para envio simple de correos
                oSmtpCliente.EnableSsl = true;
                oSmtpCliente.UseDefaultCredentials = false;
                oSmtpCliente.Port = 587;
                oSmtpCliente.Credentials = new System.Net.NetworkCredential(EmailOrigen, password);

                oSmtpCliente.Send(oMailMessage);
                oSmtpCliente.Dispose();

                AvisoAsync(); //Aviso de que se realizo la transferencia

                await App.MasterDet.Detail.Navigation.PushAsync(new MainPage()); //Regresa al MainPage
            }
            else
            {
                StatusMessage.Text = string.Format("Saldo insuficiente");
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Products;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Products;
        }
        public string Facturar() //Sintaxis que se mostrara dentro del correo
        {
            var factura = "Lista de productos de la compra: \n\n";
            foreach (var producto in Products)
            {
                factura += $"Nombre del producto: {producto.Name} \n" +
                    $"Marca: {producto.Brand}\n" +
                    $"Descripcion: {producto.Description}\n" +
                    $"Precio: {producto.Price}\n\n" ;
            }
            factura += $"Total: {total}";
            return factura;
        }
        public async Task AvisoAsync()
        {
            await DisplayAlert("Factura","Se realizo correctamente la transferencia. Revise su correo para mayor detalle :)", "OK");
        }
    }
}