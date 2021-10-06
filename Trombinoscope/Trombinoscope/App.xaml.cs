using System;
using Trombinoscope.Modeles;
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

            new Etudiant("ROBIN", "oceane", new DateTime(2002, 10, 24), "oceane.jpg");
            new Etudiant("DESABLENS", "maeva", new DateTime(2002, 02, 24), "maeva.jpg");
            new Etudiant("L'HER", "emilie", new DateTime(2002, 12, 03), "emilie.jpg");
            new Etudiant("LEMARCHAND", "alan", new DateTime(2002, 11, 21), "alan.jpg");
            new Etudiant("BIGNON", "anthony", new DateTime(2002, 12, 18), "anthony.jpg");
            new Etudiant("CHASSAN", "armand", new DateTime(2000, 12, 27), "armand.jpg");
            new Etudiant("TOINEN", "benoit", new DateTime(2002, 04, 11), "benoit.jpg");
            new Etudiant("CABIOCH", "enzo", new DateTime(2003, 10, 07), "enzo.jpg");
            new Etudiant("DUAULT", "gurvan", new DateTime(2001, 04, 16), "gurvan.jpg");
            new Etudiant("THOMAS", "jean-andre", new DateTime(2002, 10, 21), "jeanandre.jpg");
            new Etudiant("VILLALARD", "kelig", new DateTime(2003, 06, 12), "kelig.jpg");
            new Etudiant("LE PAVEC", "malo", new DateTime(2002, 09, 23), "malo.jpg");
            new Etudiant("CHENEVIERE", "manon", new DateTime(2000, 07, 27), "manon.jpg");
            new Etudiant("TACON", "romain", new DateTime(1999, 11, 02), "romain.jpg");
            new Etudiant("TAZARART", "thereza", new DateTime(2001, 06, 16), "thereza.jpg");
            new Etudiant("DARGHI", "wassil", new DateTime(2000, 10, 13), "wassil.jpg");

            MainPage = new AbsenceListeVue();
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
