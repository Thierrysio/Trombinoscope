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
            CommandBoutonGo = new Command(ActionCommandBoutonGo);
            CommandBoutonAppreciation = new Command(ActionAppreciation);
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
        public ICommand CommandBoutonGo { get; }
        public ICommand CommandBoutonAppreciation { get; }
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
            //await App.Database.DeleteItemsAsyncAppreciation();
            if ((Commentaire == "")||(Commentaire == "Ok - c'est fait"))
            {
                Commentaire = "et alors !!";
                return;
            }
            var SalarieStored = await App.Database.GetEtudiantAvecRelations(UnEtudiant);

            Appreciation A1 = new Appreciation
            {
                UneAppreciation = Commentaire,
                LaDate = DateTime.Now
            };
            SalarieStored.LesAppreciations.Add(A1);

            await App.Database.SaveItemAppreciationAsync(A1);

            await App.Database.MiseAJourRelation(SalarieStored);

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
