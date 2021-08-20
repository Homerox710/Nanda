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
    public partial class Abonos : ContentPage
    {
        public Sales Venta { get; set; }
        public Abonos (Sales venta)
        {
            InitializeComponent();
            Venta = venta;
            BindingContext = this;
        }
    }
}