using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Trombinoscope.Modeles;
using Trombinoscope.Vues;
using Xamarin.Forms;

namespace Trombinoscope.VueModeles
{
    class AbsenceListeVueModele : BaseVueModele
    {
        #region Attributs

        private ObservableCollection<Etudiant> _listeEtudiant;
        private ObservableCollection<object> _selectedEtudiants;
        private Etudiant _unEtudiant;
        #endregion

        #region Constructeurs

        public AbsenceListeVueModele()
        {

            
            ListeEtudiant = Etudiant.GetListeEtudiants();

            SelectedEtudiants = new ObservableCollection<object>();
            
        }

        #endregion

        #region Getters/Setters

        public ICommand SelectionChangedCommandEtudiant => new Command(Method);
        public ICommand CommandBoutonGo => new Command(ActionCommandBoutonGo);

        public ObservableCollection<Etudiant> ListeEtudiant
        {
            get
            {
                return _listeEtudiant;
            }
            set
            {
                SetProperty(ref _listeEtudiant, value);
            }
        }

        public ObservableCollection<object> SelectedEtudiants
        {
            get
            {
                return _selectedEtudiants;
            }
            set
            {
                SetProperty(ref _selectedEtudiants, value);
            }
        }

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

        #endregion

        #region Methodes
        public void Method()
        {
            if (SelectedEtudiants.Count >0)
            UnEtudiant = (Etudiant) this.SelectedEtudiants[SelectedEtudiants.Count - 1];
        }

        public void ActionCommandBoutonGo()
        {
            foreach(Etudiant unetudiant in Etudiant.CollClasse)
            {
                if (!this.SelectedEtudiants.Contains(unetudiant))
                {
                    Etudiant.AjoutCollEtudiantsPresents(unetudiant);
                }
            }

            int x = Etudiant.CollEtudiantsPresents.Count;

            Application.Current.MainPage = new NavigationPage(new TrombinoscopeVue());

        }
        #endregion
    }
}
