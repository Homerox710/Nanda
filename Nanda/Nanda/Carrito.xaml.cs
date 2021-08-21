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



    public partial class Carrito : ContentPage
    {
        public List<Products> Products { get; private set; }
        public Carrito(List<Products> Carrito)
        {
            InitializeComponent();
            Products = Carrito;
            int total = 0;
            foreach (var item in Products)
            {
                total = total + item.Price;
            }
            lblTotal.Text += total.ToString();
            BindingContext = this;
            btnPagar.Clicked += BtnPagar_Clicked;
        }

        private void BtnPagar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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