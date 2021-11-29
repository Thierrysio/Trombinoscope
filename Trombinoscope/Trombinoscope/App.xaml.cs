using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Trombinoscope.Modeles;
using Trombinoscope.Services;
using Trombinoscope.Vues;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trombinoscope
{

    public partial class App : Application
    {
        static GestionDataBase database;
        public ObservableCollection<Etudiant> listeEtudiants;
        public App()
        {
            InitializeComponent();
            GetListe();
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

        public static GestionDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GestionDataBase();
                }
                return database;
            }
        }

        public async Task GetListe()
        {
            //await App.database.DeleteItemsAsyncEtudiant();

            listeEtudiants =   App.Database.GetItemsAsync<Etudiant>();
            
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "ROBIN") == null) await Etudiant.AjoutItemSqlite(new Etudiant {Nom= "ROBIN",Prenom = "oceane", DateNaissance =new DateTime(2002, 10, 24),Photo = "oceane.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "DESABLENS") == null) await Etudiant.AjoutItemSqlite(new Etudiant { Nom = "DESABLENS", Prenom = "maeva", DateNaissance = new DateTime(2002, 02, 24), Photo = "maeva.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "L'HER") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "L'HER", Prenom = "emilie", DateNaissance = new DateTime(2002, 12, 03), Photo = "emilie.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "LEMARCHAND") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "BIGNON", Prenom = "anthony", DateNaissance = new DateTime(2002, 12, 18), Photo = "anthony.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "CHASSAN") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "CHASSAN", Prenom = "armand", DateNaissance = new DateTime(2000, 12, 27), Photo = "armand.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "TOINEN") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "TOINEN", Prenom = "benoit", DateNaissance = new DateTime(2002, 04, 11), Photo = "benoit.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "CABIOCH") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "CABIOCH", Prenom = "enzo", DateNaissance = new DateTime(2003, 10, 07), Photo = "enzo.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "DUAULT") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "DUAULT", Prenom = "gurvan", DateNaissance = new DateTime(2001, 04, 16), Photo = "gurvan.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "THOMAS") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "THOMAS", Prenom = "jean-andre", DateNaissance = new DateTime(2002, 10, 21), Photo = "jeanandre.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "VILLALARD") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "VILLALARD", Prenom = "kelig", DateNaissance = new DateTime(2003, 06, 12), Photo = "kelig.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "LE PAVEC") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "LE PAVEC", Prenom = "malo", DateNaissance = new DateTime(2002, 09, 23), Photo = "malo.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "CHENEVIERE") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "CHENEVIERE", Prenom = "manon", DateNaissance = new DateTime(2000, 07, 27), Photo = "manon.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "TACON") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "TACON", Prenom = "romain", DateNaissance = new DateTime(1999, 11, 02), Photo = "romain.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "TAZARART") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "TAZARART", Prenom = "thereza", DateNaissance = new DateTime(2001, 06, 16), Photo = "thereza.jpg" });
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "DARGHI") == null) await Etudiant.AjoutItemSqlite(new Etudiant{ Nom = "DARGHI", Prenom = "wassil", DateNaissance = new DateTime(2000, 10, 13), Photo = "wassil.jpg" });

           
        }
    }
}
