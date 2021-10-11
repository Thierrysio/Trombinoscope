using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using Trombinoscope.Modeles;

namespace Trombinoscope.Services
{
   public  class GestionDataBase
    {
        #region Attributs
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        #endregion
        #region Constructeurs
        public GestionDataBase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        #endregion
        #region Methodes
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        });
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Etudiant).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Etudiant)).ConfigureAwait(false);

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Appreciation).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Appreciation)).ConfigureAwait(false);

                }
               
                initialized = true;
            }
        }

        public Task<int> SaveItemEtudiantAsync(Etudiant item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAppreciationAsync(Appreciation item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task MiseAJourRelation(object item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }        
        public Task<int> DeleteItemsAsyncAppreciation()
        {
            return Database.DeleteAllAsync<Appreciation>();
        }        
        public ObservableCollection<Etudiant> GetItemsEtudiantsAsync()
        {
            ObservableCollection<Etudiant> resultat = new ObservableCollection<Etudiant>();
            List<Etudiant> liste =  Database.Table<Etudiant>().ToListAsync().Result;
            foreach (Etudiant unEtudiant in liste)
            {
                resultat.Add(unEtudiant);
            }
            return resultat;
        }
        public Task<Etudiant> GetEtudiantAvecRelations(Etudiant item)
        {
            return Database.GetWithChildrenAsync<Etudiant>(item.ID);
        }
        public Task<Etudiant> GetItemAsync(int id)
        {
            return Database.Table<Etudiant>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        #endregion
    }
}
