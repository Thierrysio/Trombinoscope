using System;
using Trombinoscope.Vues;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trombinoscope
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TrombinoscopeVue();
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
