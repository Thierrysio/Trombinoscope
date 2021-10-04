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

            new Etudiant("ROBIN", "oceane", "datenaissance", "oceane.jpg");
            new Etudiant("DESABLENS", "maeva", "datenaissance", "maeva.jpg");
            new Etudiant("L'HER", "emilie", "datenaissance", "emilie.jpg");
            new Etudiant("LEMARCHAND", "alan", "datenaissance", "alan.jpg");
            new Etudiant("BIGNON", "anthony", "datenaissance", "anthony.jpg");
            new Etudiant("CHASSAN", "armand", "datenaissance", "armand.jpg");
            new Etudiant("TOINEN", "benoit", "datenaissance", "benoit.jpg");
            new Etudiant("CABIOCH", "enzo", "datenaissance", "enzo.jpg");
            new Etudiant("DUAULT", "gurvan", "datenaissance", "gurvan.jpg");
            new Etudiant("THOMAS", "jean-andre", "datenaissance", "jeanandre.jpg");
            new Etudiant("VILLALARD", "kelig", "datenaissance", "kelig.jpg");
            new Etudiant("LE PAVEC", "malo", "datenaissance", "malo.jpg");
            new Etudiant("CHENEVIERE", "manon", "datenaissance", "manon.jpg");
            new Etudiant("TACON", "romain", "datenaissance", "romain.jpg");
            new Etudiant("TAZARART", "thereza", "datenaissance", "thereza.jpg");
            new Etudiant("DARGHI", "wassil", "datenaissance", "wassil.jpg");





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
                    foreach (Etudiant unEtudiant in Etudiant.CollClasse)
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
