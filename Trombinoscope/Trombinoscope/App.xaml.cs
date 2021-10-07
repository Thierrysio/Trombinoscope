using System;
using System.Collections.Generic;
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
        public List<Etudiant> listeEtudiants;
        public    App()
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
            
            listeEtudiants = await  Etudiant.GetListSQLite();

            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "ROBIN") == null) Etudiant.AjoutItemSqlite(new Etudiant("ROBIN", "oceane", new DateTime(2002, 10, 24), "oceane.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "DESABLENS") == null) Etudiant.AjoutItemSqlite(new Etudiant("DESABLENS", "maeva", new DateTime(2002, 02, 24), "maeva.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "L'HER") == null) Etudiant.AjoutItemSqlite(new Etudiant("L'HER", "emilie", new DateTime(2002, 12, 03), "emilie.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "LEMARCHAND") == null) Etudiant.AjoutItemSqlite(new Etudiant("BIGNON", "anthony", new DateTime(2002, 12, 18), "anthony.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "CHASSAN") == null) Etudiant.AjoutItemSqlite(new Etudiant("CHASSAN", "armand", new DateTime(2000, 12, 27), "armand.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "TOINEN") == null) Etudiant.AjoutItemSqlite(new Etudiant("TOINEN", "benoit", new DateTime(2002, 04, 11), "benoit.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "CABIOCH") == null) Etudiant.AjoutItemSqlite(new Etudiant("CABIOCH", "enzo", new DateTime(2003, 10, 07), "enzo.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "DUAULT") == null) Etudiant.AjoutItemSqlite(new Etudiant("DUAULT", "gurvan", new DateTime(2001, 04, 16), "gurvan.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "THOMAS") == null) Etudiant.AjoutItemSqlite(new Etudiant("THOMAS", "jean-andre", new DateTime(2002, 10, 21), "jeanandre.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "VILLALARD") == null) Etudiant.AjoutItemSqlite(new Etudiant("VILLALARD", "kelig", new DateTime(2003, 06, 12), "kelig.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "LE PAVEC") == null) Etudiant.AjoutItemSqlite(new Etudiant("LE PAVEC", "malo", new DateTime(2002, 09, 23), "malo.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "CHENEVIERE") == null) Etudiant.AjoutItemSqlite(new Etudiant("CHENEVIERE", "manon", new DateTime(2000, 07, 27), "manon.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "TACON") == null) Etudiant.AjoutItemSqlite(new Etudiant("TACON", "romain", new DateTime(1999, 11, 02), "romain.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "TAZARART") == null) Etudiant.AjoutItemSqlite(new Etudiant("TAZARART", "thereza", new DateTime(2001, 06, 16), "thereza.jpg"));
            if (listeEtudiants.FirstOrDefault(cus => cus.Nom == "DARGHI") == null) Etudiant.AjoutItemSqlite(new Etudiant("DARGHI", "wassil", new DateTime(2000, 10, 13), "wassil.jpg"));

            //int x = await App.database.DeleteItemsAsyncAppreciation();
        }
    }
}
