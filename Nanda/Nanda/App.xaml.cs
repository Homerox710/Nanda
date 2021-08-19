<<<<<<< Updated upstream
﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nanda
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
=======
﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nanda.BaseDatos;

namespace Nanda
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }
        public App(string filename)
        {
            InitializeComponent();
            SQLConnect.Inicializador(filename);
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
>>>>>>> Stashed changes
