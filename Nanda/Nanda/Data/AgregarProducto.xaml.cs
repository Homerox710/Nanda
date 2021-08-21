using Nanda.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nanda.Data
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarProducto : ContentPage
    {
        public AgregarProducto()
        {
            InitializeComponent();
            btn.Clicked += Btn_Clicked;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            string nombre = name.Text;
            string marca = brand.Text;
            string descrip = description.Text;
            int precio = int.Parse(price.Text);
            string cate = categorie.Text;
            string imagen = image.Text;

            SQLConnect.Instancia.AddNewProduct(nombre, marca, descrip, precio, cate, imagen);
            mensaje.Text = "Insertado";
        }
    }
}