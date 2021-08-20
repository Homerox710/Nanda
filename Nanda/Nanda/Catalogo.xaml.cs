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
    public partial class Catalogo : ContentPage
    {
        public IEnumerable <Producto> Products { get; private set; }
        public Catalogo()
        {
            InitializeComponent();
            // Products = Lista de productos
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