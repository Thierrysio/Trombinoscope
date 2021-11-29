using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Trombinoscope.Modeles;
using Trombinoscope.Vues;
using Xamarin.Forms;

namespace Trombinoscope.VueModeles
{
    public class TrombinoscopeVueModele : BaseVueModele
    {
        #region Attributs

        private Etudiant _unEtudiant;
        private double _note;
        private string _commentaire;

        #endregion

        #region Constructeurs

        public TrombinoscopeVueModele()
        {
            UnEtudiant = new Etudiant
            {
                Nom = "",
                Prenom = "",
                DateNaissance = DateTime.Now,
                Photo = "intro.jpg"
            };
        }

        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonGo => new Command(ActionCommandBoutonGo);
        public ICommand CommandBoutonAppreciation => new Command(ActionAppreciation);
        public ICommand CommandNext => new Command(() => Application.Current.MainPage = new PalmaresVue());


        public Etudiant UnEtudiant
        {
            get
            {
                return _unEtudiant;
            }
            set
            {
                SetProperty(ref _unEtudiant, value);
            }
        }
        public string Commentaire
        {
            get
            {
                return _commentaire;
            }
            set
            {
                SetProperty(ref _commentaire, value);
            }
        }
        public double Note
        {
            get
            {
                return _note;
            }
            set
            {
                SetProperty(ref _note, value);
            }
        }
        #endregion

        #region Methodes

        public void ActionValueChangedNote(double param)
        {

            if (param > 0.75) { Commentaire = "Tres satisfaisant"; }
            else if (param > 0.50) { Commentaire = "Satisfaisant"; }
            else if (param > 0.25) { Commentaire = "Insuffisant"; }
            else if (param < 0.25) { Commentaire = "Tres insuffisant"; }

        }
        public async void ActionAppreciation()
        {
            int nbStored = 0;
            //await App.Database.DeleteItemsAsyncAppreciation();
            if ((Commentaire == "")||(Commentaire == "Ok - c'est fait"))
            {
                Commentaire = "et alors !!";
                return;
            }
            Etudiant SalarieStored = await App.Database.GetItemAvecRelations<Etudiant>(UnEtudiant);

            Appreciation A1 = new Appreciation
            {
                UneAppreciation = Commentaire,
                LaDate = DateTime.Now
            };
            SalarieStored.LesAppreciations.Add(A1);

            nbStored =await App.Database.SaveItemAsync<Appreciation>(A1);

            await App.Database.MiseAJourItemRelation(SalarieStored);

            Commentaire = "Ok - c'est fait";

        }
        public  void ActionCommandBoutonGo()
        {
            Commentaire = "";

            this.Rotate();

            
        }
        public async void Rotate()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (Etudiant unEtudiant in Etudiant.GetListeEtudiantsPresents())
                    {
                        Task.Delay(i * 80).Wait();
                        UnEtudiant = unEtudiant;
                    }
                }
            });
            
            UnEtudiant = Etudiant.GetEtudiantSelectionne();
        }
        #endregion
    }
}
