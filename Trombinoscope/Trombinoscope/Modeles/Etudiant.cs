using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public static ObservableCollection<Etudiant> CollEtudiantsPresents = new ObservableCollection<Etudiant>();
        public static ObservableCollection<Etudiant> CollEtudiantsAbsents = new ObservableCollection<Etudiant>();

        private int _id;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _photo;
        private string _photoPalmares;
        private ObservableCollection<Appreciation> _lesAppreciations;



        #endregion

        #region Constructeurs

        public Etudiant()
        {

        }

        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }
        public string Photo { get => _photo; set => _photo = value; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Appreciation> LesAppreciations { get => _lesAppreciations; set => _lesAppreciations = value; }
        public string PhotoPalmares { get => _photoPalmares; set => _photoPalmares = value; }
        #endregion

        #region Methodes

        public  static Etudiant GetEtudiantSelectionne()
        {
            if (Etudiant.GetListeEtudiantsPresents().Count > 0)
            {
                ObservableCollection<Etudiant> collProvisoire = new ObservableCollection<Etudiant>();
                
                foreach (Etudiant unEtudiant in Etudiant.GetListeEtudiantsPresents())
                {
                    try
                    {
                        Etudiant theEtudiant = App.Database.GetItemAvecRelations<Etudiant>(unEtudiant).Result;
                        double totalAppreciations = (double)theEtudiant.LesAppreciations.Count * 10;
                        if (theEtudiant.LesAppreciations.Count > 0)
                        {
                            int compteur = 0;

                            foreach (Appreciation uneAppreciation in theEtudiant.LesAppreciations)
                            {
                                switch (uneAppreciation.UneAppreciation)
                                {
                                    case "Tres insuffisant":
                                        compteur -= 10;
                                        break;
                                    case "Insuffisant":
                                        compteur -= 5;
                                        break;
                                    case "Satisfaisant":
                                        compteur += 5;
                                        break;
                                    case "Tres satisfaisant":
                                        compteur += 10;
                                        break;
                                    default:
                                        compteur += 0;
                                        break;

                                }
                            }

                            /////////////////////////
                            if (compteur / totalAppreciations * 100 > 75)
                            {
                                unEtudiant.PhotoPalmares = "A4etoiles.png";
                            }
                            else if (compteur / totalAppreciations * 100 > 50)
                            {
                                unEtudiant.PhotoPalmares = "A3etoiles.png";
                            }
                            else if (compteur / totalAppreciations * 100 > 25)
                            {
                                unEtudiant.PhotoPalmares = "A2etoiles.png";
                                collProvisoire.Add(unEtudiant);
                            }
                            else
                            {
                                unEtudiant.PhotoPalmares = "A1etoile.png";
                                collProvisoire.Add(unEtudiant);
                            }

                            compteur = 0;
                            

                        }
                        else
                        {
                            collProvisoire.Add(unEtudiant);
                        }
                    }
                    catch
                    {
                        collProvisoire.Add(unEtudiant);
                    }
                }


                if (collProvisoire.Count > 0)
                { 
                    return collProvisoire[Constantes.rnd.Next(0, collProvisoire.Count - 1)]; 
                }
                else 
                { 
                    return Etudiant.CollEtudiantsPresents[Constantes.rnd.Next(0, Etudiant.CollEtudiantsPresents.Count - 1)]; 
                }
            }
            else
            {
                return null;
            }
        }
        public static ObservableCollection<Etudiant> GetListeEtudiants()
        {
            return App.Database.GetItemsAsync<Etudiant>();
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
        public static async Task<Etudiant> AjoutItemSqlite(Etudiant param)
        {
            await App.Database.SaveItemAsync<Etudiant>(param);
            return param;

        }


        #endregion
    }


}
