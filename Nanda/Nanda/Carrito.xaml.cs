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
            foreach (var item in Products)
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
            if (saldo > total)
            {
                user.Saldo -= total;
                //Falta Conectar correo

                string EmailOrigen = "nandacr236@gmail.com";
                var Consulta = SQLConnect.Instancia.GetAllUsers();
                var Usuario = Login.user;
                var usuario = (from user in Consulta where user.Username == Usuario.Username select user).First();
                string EmailDestino = usuario.Email;
                string password = "ULACIT123";

                MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Factura Electronica Nanda", Facturar());
       

                oMailMessage.IsBodyHtml = true;

                SmtpClient oSmtpCliente = new SmtpClient("smtp.gmail.com");
                oSmtpCliente.EnableSsl = true;
                oSmtpCliente.UseDefaultCredentials = false;
                oSmtpCliente.Port = 587;
                oSmtpCliente.Credentials = new System.Net.NetworkCredential(EmailOrigen, password);

                oSmtpCliente.Send(oMailMessage);
                oSmtpCliente.Dispose();

                await App.MasterDet.Detail.Navigation.PushAsync(new MainPage());
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
        public string Facturar()
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
    }
}