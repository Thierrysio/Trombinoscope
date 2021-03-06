using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trombinoscope.VueModeles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trombinoscope.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrombinoscopeVue : ContentPage
    {
      readonly  TrombinoscopeVueModele vueModele;
        public TrombinoscopeVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new TrombinoscopeVueModele();
           
            Manote.ValueChanged += Manote_ValueChanged;
        }

        private void Manote_ValueChanged(object sender,ValueChangedEventArgs e)
        {
            vueModele.ActionValueChangedNote(Manote.Value);
        }

    }
}