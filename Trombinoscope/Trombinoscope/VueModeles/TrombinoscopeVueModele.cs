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

            new Etudiant("ROBIN", "oceane", new DateTime(2002,10,24), "oceane.jpg");
            new Etudiant("DESABLENS", "maeva", new DateTime(2002,02,24), "maeva.jpg");
            new Etudiant("L'HER", "emilie", new DateTime(2002,12,03), "emilie.jpg");
            new Etudiant("LEMARCHAND", "alan", new DateTime(2002,11,21), "alan.jpg");
            new Etudiant("BIGNON", "anthony", new DateTime(2002, 12, 18), "anthony.jpg") ;
            new Etudiant("CHASSAN", "armand", new DateTime(2000,12,27), "armand.jpg");
            new Etudiant("TOINEN", "benoit", new DateTime(2002,04,11), "benoit.jpg");
            new Etudiant("CABIOCH", "enzo", new DateTime(2003,10,07), "enzo.jpg");
            new Etudiant("DUAULT", "gurvan", new DateTime(2001,04,16), "gurvan.jpg");
            new Etudiant("THOMAS", "jean-andre", new DateTime(2002,10,21), "jeanandre.jpg");
            new Etudiant("VILLALARD", "kelig", new DateTime(2003,06,12), "kelig.jpg");
            new Etudiant("LE PAVEC", "malo", new DateTime(2002,09,23), "malo.jpg");
            new Etudiant("CHENEVIERE", "manon", new DateTime(2000,07,27), "manon.jpg");
            new Etudiant("TACON", "romain", new DateTime(1999,11,02), "romain.jpg");
            new Etudiant("TAZARART", "thereza", new DateTime(2001,06,16), "thereza.jpg");
            new Etudiant("DARGHI", "wassil", new DateTime(2000,10,13), "wassil.jpg");





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
