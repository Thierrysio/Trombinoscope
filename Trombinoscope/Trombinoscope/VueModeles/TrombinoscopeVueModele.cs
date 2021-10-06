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


        #endregion

        #region Constructeurs

        public TrombinoscopeVueModele()
        {
            CommandBoutonGo = new Command(ActionCommandBoutonGo);


        }

        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonGo { get; }


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

        public async void ActionCommandBoutonGo()
        {

            await Task.Run(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (Etudiant unEtudiant in Etudiant.GetListeEtudiantsPresents())
                    {
                        Task.Delay(i*80).Wait();
                        UnEtudiant = unEtudiant;
                    }
                }
            });

            UnEtudiant = Etudiant.GetEtudiantSelectionne();

        }

 
        #endregion
    }
}
