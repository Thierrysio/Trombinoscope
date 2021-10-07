using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Trombinoscope.Modeles;
using Xamarin.Forms;

namespace Trombinoscope.VueModeles
{
    public class TrombinoscopeVueModele : BaseVueModele
    {
        #region Attributs

        private Etudiant _unEtudiant;
        private double _note;
        private string _commentaire;
        private int _xx;

        #endregion

        #region Constructeurs

        public TrombinoscopeVueModele()
        {
            CommandBoutonGo = new Command(ActionCommandBoutonGo);
            CommandBoutonAppreciation = new Command(ActionAppreciation);

        }

        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonGo { get; }
        public ICommand CommandBoutonAppreciation { get; }


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

        public int Xx
        {
            get
            {
                return _xx;
            }
            set
            {
                SetProperty(ref _xx, value);
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
            var SalarieStored = await App.Database.GetRelationEtudiant(UnEtudiant);
            
            Appreciation A1 = new Appreciation();

            A1.UneAppreciation = Commentaire;
            A1.LaDate = DateTime.Now;

            SalarieStored.LesAppreciations.Add(A1);

            await App.Database.SaveItemAsyncAppreciation(A1);

            await App.Database.MiseAJourRelation(SalarieStored);

            SalarieStored = await App.Database.GetRelationEtudiant(SalarieStored);

            Xx = SalarieStored.LesAppreciations.Count;
        }


        public async void ActionCommandBoutonGo()
        {
            Commentaire = "";
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

            var SalarieStored = await App.Database.GetRelationEtudiant(UnEtudiant);

            Xx = SalarieStored.LesAppreciations.Count;

        }


        #endregion
    }
}
