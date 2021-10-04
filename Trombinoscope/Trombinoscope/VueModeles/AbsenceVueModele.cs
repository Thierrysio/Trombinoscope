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

        }

        public void ActionCommandBoutonAbsent()
        {

        }

        #endregion
    }
}
