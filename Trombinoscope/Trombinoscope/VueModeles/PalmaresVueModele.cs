using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trombinoscope.Modeles;
using Trombinoscope.Vues;
using Xamarin.Forms;

namespace Trombinoscope.VueModeles
{
    class PalmaresVueModele : BaseVueModele
    {
        #region Attributs
        ObservableCollection<Etudiant> _maListePalmares;
        #endregion

        #region Constructeurs

        public PalmaresVueModele()
        {
            ObservableCollection<Etudiant> listeProvisoire = Etudiant.GetListSQLite();
            Etudiant SalarieStored;
            double compteur = 0, totalAppreciations = 0;
            foreach (Etudiant unEtudiant in listeProvisoire)
            {
                SalarieStored = App.Database.GetEtudiantAvecRelations(unEtudiant).Result;
                totalAppreciations = (double)SalarieStored.LesAppreciations.Count * 10;
                foreach (Appreciation appreciation in SalarieStored.LesAppreciations)
                {
                    switch (appreciation.UneAppreciation)
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
                }
                else
                {
                    unEtudiant.PhotoPalmares = "A1etoile.png";
                }

                this.UpdateTableEtudiant(unEtudiant);
                compteur = 0;
                totalAppreciations = 0;
            }
            MaListePalmares = new ObservableCollection<Etudiant>(listeProvisoire.OrderByDescending(c => c.PhotoPalmares));
        }
        #endregion

            #region Getters/Setters
        public ICommand CommandBack=> new Command(() => Application.Current.MainPage = new TrombinoscopeVue());
        public ObservableCollection<Etudiant> MaListePalmares
        {
            get
            {
                return _maListePalmares;
            }
            set
            {
                SetProperty(ref _maListePalmares, value);
            }
        }

        #endregion

        #region Methodes

        public async void UpdateTableEtudiant(Etudiant param)
            {
            await App.Database.SaveItemEtudiantAsync(param);
    }

    #endregion
}
}
