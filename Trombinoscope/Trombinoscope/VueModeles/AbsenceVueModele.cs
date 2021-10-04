using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Trombinoscope.Modeles;
using Xamarin.Forms;

namespace Trombinoscope.VueModeles
{
    class AbsenceVueModele : BaseVueModele
    {
        #region Attributs

        private Etudiant _unEtudiant;
        
        #endregion

        #region Constructeurs

        public AbsenceVueModele()
        {
            CommandBoutonPresent = new Command(ActionCommandBoutonPresent);

            CommandBoutonAbsent = new Command(ActionCommandBoutonAbsent);

            UnEtudiant = Etudiant.CollClasse[0];

        }

        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonPresent { get; }
        public ICommand CommandBoutonAbsent { get; }


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

        public void ActionCommandBoutonPresent()
        {
            Etudiant.AjoutCollEtudiantsPresents(this.UnEtudiant);
            UnEtudiant = Etudiant.CollClasse[this.GetIndexCollEtudiants() + 1];

        }

        public void ActionCommandBoutonAbsent()
        {
            Etudiant.AjoutCollEtudiantsAbsents(this.UnEtudiant);
            UnEtudiant = Etudiant.CollClasse[this.GetIndexCollEtudiants() + 1];
        }

        private int GetIndexCollEtudiants()
        {
 
                    return Etudiant.CollClasse.IndexOf(UnEtudiant);
   
        }

        #endregion
    }
}
