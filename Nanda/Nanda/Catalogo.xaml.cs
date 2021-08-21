using Nanda.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogo : ContentPage
    {
        public IEnumerable<Products> Products { get; private set; }
        public List<Products> Carrito { get; private set; }
        public Products ProductoSeleccionado { get; set; }
        public Catalogo()
        {
            InitializeComponent();
            btnCarrito.Clicked += BtnCarrito_Clicked;

            Products = new List<Products>
            {
               
                new Products()
                {
                    Name = "P40",
                    Brand = "Huawei",
                    Category = "cel",
                    Description = "8GB RAM, 250GB Almacenamiento",
                    Price = 500,
                    Img = "cel.jpg"
                },
                new Products()
                {
                    Name = "Tab 3",
                    Brand = "Samsung",
                    Category = "tab",
                    Description = "8GB RAM, 250GB Almacenamiento",
                    Price = 800,
                    Img = "tablet.jpg"
                },
                new Products()
                {
                    Name = "Speaker",
                    Brand = "Marley",
                    Category = "aud",
                    Description = "Contra agua",
                    Price = 700,
                    Img = "speaker.jpg"
                },
                new Products()
                {
                    Name = "OnePlus 5T",
                    Brand = "OnePlus",
                    Category = "cel",
                    Description = "8 RAM, 218 GB",
                    Price = 350,
                    Img = "oneplus.png"
                },
                new Products()
                {
                    Name = "Galaxy Z Fold",
                    Brand = "Samsung",
                    Category = "cel",
                    Description = "5G, 8 RAM, 256 GB",
                    Price = 1800,
                    Img = "fold.jpg"
                },
                new Products()
                {
                    Name = "Iphone 12",
                    Brand = "Apple",
                    Category = "cel",
                    Description = "6 RAM, 64GB",
                    Price = 700,
                    Img = "iphone.jpg"
                },
                new Products()
                {
                    Name = "Tab P11 Pro",
                    Brand = "Lenovo",
                    Category = "tab",
                    Description = "6 RAM, 128 GB, Snapdragon 730G Octa-core",
                    Price = 550,
                    Img = "tabp11.jpg"
                },
                new Products()
                {
                    Name = "Tab S6",
                    Brand = "Samsung",
                    Category = "tab",
                    Description = "6 RAM, 64 GB",
                    Price = 420,
                    Img = "tabs6.jpg"
                },
                new Products()
                {
                    Name = "iPad Pro",
                    Brand = "Apple",
                    Category = "cel",
                    Description = "8 RAM, 256 GB",
                    Price = 900,
                    Img = "ipad.jpg"
                },
                new Products()
                {
                    Name = "Airpods",
                    Brand = "Apple",
                    Category = "aud",
                    Description = "Wireless, Sonido envolvente",
                    Price = 230,
                    Img = "airpods.jpg"
                },
                new Products()
                {
                    Name = "Tab S6",
                    Brand = "Samsung",
                    Category = "cel",
                    Description = "6 RAM, 64 GB",
                    Price = 420,
                    Img = "tabs6.jpg"
                },
                new Products()
                {
                    Name = "Charge 4",
                    Brand = "JBL",
                    Category = "aud",
                    Description = "Altavoz bluetooth, resistente al agua",
                    Price = 150,
                    Img = "charge.jpg"
                }
               
            };
            
            //Products = SQLConnect.Instancia.GetAllProducts();
            BindingContext = this;
            
        }

        private async void BtnCarrito_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new Carrito(Carrito));
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Products;
            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Products Item = e.SelectedItem as Products;
            ProductoSeleccionado =
            new Products()
            {
                Name = Item.Name,
                Brand = Item.Brand,
                Category = Item.Category,
                Description = Item.Description,
                Price = Item.Price,
                Img = Item.Img
            };
        }
        public async Task AvisoAsync() 
        {
            await DisplayAlert("Control Alert", ProductoSeleccionado.Name, "OK");
        }

        private void Action(object sender, EventArgs e) //Agrega al Carrito
        {
            /*Products producto = new Products();
            producto = ProductoSeleccionado;
            Carrito.Add(producto);*/
            AgregarProducto();
        }
        public async Task AgregarProducto()
        {
            await Agregar();
            AvisoAsync();
        }
        private async Task Agregar() 
        {
            Carrito.Add(ProductoSeleccionado);
        }
    }
}