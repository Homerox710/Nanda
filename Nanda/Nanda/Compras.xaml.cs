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
    //public IEnumerable<Sales> Compras { get; set; }
    public partial class Compras : ContentPage
    {
        public Compras()
        {
            InitializeComponent();
            //Compras = new List<Sales>();
            BindingContext = this;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Sales;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sales venta = e.SelectedItem as Sales;
            if (venta.Credit > 1)
            {
                ((NavigationPage)this.Parent).PushAsync(new Abonos(venta));
            }

        }
    }
}