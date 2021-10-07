using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Trombinoscope.Modeles
{
    [Table("Etudiant")]
    public class Etudiant
    {
        #region Attributs

        public static ObservableCollection<Etudiant> CollClasse = new ObservableCollection<Etudiant>();
        public static ObservableCollection<Etudiant> CollEtudiantsPresents = new ObservableCollection<Etudiant>();
        public static ObservableCollection<Etudiant> CollEtudiantsAbsents = new ObservableCollection<Etudiant>();
        
        private int _id;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _photo;
        private ObservableCollection<Appreciation> _lesAppreciations;

        

        #endregion

        #region Constructeurs
        public Etudiant(string nom, string prenom, DateTime dateNaissance, string photo)
        {
            _id = ID;
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = dateNaissance;
            _photo = photo;
            _lesAppreciations = new ObservableCollection<Appreciation>();


            
        }
        public Etudiant()
        {
            Etudiant.CollClasse.Add(this);

        }

        #endregion

        #region Getters/Setters
        [PrimaryKey,AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }
        public string Photo { get => _photo; set => _photo = value; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Appreciation> LesAppreciations { get => _lesAppreciations; set => _lesAppreciations = value; }


        #endregion

        #region Methodes

        public static Etudiant GetEtudiantSelectionne()
        {
             
            if(Etudiant.GetListeEtudiantsPresents().Count > 0)
            {
                return Etudiant.CollEtudiantsPresents[Constantes.rnd.Next(0, Etudiant.GetListeEtudiantsPresents().Count - 1)]; 
            }
            else 
            {
                return null;
            }
        }
        public static ObservableCollection<Etudiant> GetListeEtudiants()
        {
            return Etudiant.CollClasse;
            
            /*foreach(Etudiant unEtudiant in Etudiant.CollClasse)
            {
                resultat.Add(unEtudiant);
            }
            return resultat;
            */
        }
        public static ObservableCollection<Etudiant> GetListeEtudiantsPresents()
        {
            return Etudiant.CollEtudiantsPresents;
        }
        public static ObservableCollection<Etudiant> GetListeEtudiantsAbsents()
        {
             return Etudiant.CollEtudiantsAbsents;
        }

        public static void AjoutCollEtudiantsPresents(Etudiant param)
        {
            Etudiant.CollEtudiantsPresents.Add(param);
        }
        public static void AjoutCollEtudiantsAbsents(Etudiant param)
        {
            Etudiant.CollEtudiantsAbsents.Add(param);
        }

        public static async Task<List<Etudiant>> GetListSQLite()
        {
            return await App.Database.GetItemsEtudiantsAsync();

        }

        public static async void AjoutItemSqlite(Etudiant param)
        {
            await App.Database.SaveItemAsync(param);
  
        }

       
            #endregion
        }


}
