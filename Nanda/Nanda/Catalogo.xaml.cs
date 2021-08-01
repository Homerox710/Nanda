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
    public partial class Catalogo : TabbedPage
    {
        public IEnumerable<Producto> Celphones { get; private set; }
        public IEnumerable<Producto> Tablets { get; private set; }
        public IEnumerable<Producto> Audio { get; private set; }
        public Catalogo()
        {
            InitializeComponent();
            Data data = new Data();
            // Los filtramos con consultas Linq
            Celphones = from product in data.Products where product.Type == "Cel" select product;
            Tablets = from product in data.Products where product.Type == "Tab" select product;
            Audio = from product in data.Products where product.Type == "Audio" select product;
            // Enviamos el contexto
            BindingContext = this;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Producto;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Producto;
        }
    }
}