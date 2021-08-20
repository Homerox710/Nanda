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
    public partial class Catalogo : TabbedPage
    {
        /*public IEnumerable<Products> Celphones { get; private set; }
        public IEnumerable<Products> Tablets { get; private set; }
        public IEnumerable<Products> Audio { get; private set; }*/
        public Catalogo()
        {
            InitializeComponent();
            // Los filtramos con consultas Linq
            /*Celphones = from product in data.Products where product.Type == "Cel" select product;
            Tablets = from product in data.Products where product.Type == "Tab" select product;
            Audio = from product in data.Products where product.Type == "Audio" select product;*/
            // Enviamos el contexto
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