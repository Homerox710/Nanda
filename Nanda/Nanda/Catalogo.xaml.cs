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
        public Catalogo()
        {
            InitializeComponent();
            InitializeComponent();
            Products = new List<Products>
            {
                new Products()
                {
                    Name = "P40",
                    Brand = "Huawei",
                    Category = "Cel",
                    Description = "8GB RAM, 250GB Almacenamiento",
                    Price = "$500",
                    Img = "cel.jpg"
                },
                new Products()
                {
                    Name = "Tab 3",
                    Brand = "Samsung",
                    Category = "Tab",
                    Description = "8GB RAM, 250GB Almacenamiento",
                    Price = "$800",
                    Img = "tablet.jpg"
                },
                new Products()
                {
                    Name = "Speaker",
                    Brand = "Marley",
                    Category = "Audio",
                    Description = "Contra agua",
                    Price = "$700",
                    Img = "speaker.jpg"
                }
            };
            //Products = SQLConnect.Instancia.GetAllProducts();
            BindingContext = this;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Products;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Products;
        }
    }
}