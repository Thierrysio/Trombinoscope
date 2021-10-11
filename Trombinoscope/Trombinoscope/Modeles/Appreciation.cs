using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Trombinoscope.Modeles
{
    [Table("Appreciation")]
    public class Appreciation
    {
        #region Attributs

        private int _id;
        private DateTime _laDate;
        private string _uneAppreciation;
        private int _etudiantId;

        #endregion

        #region Constructeurs



        public Appreciation()
        {
           
        }


        #endregion

        #region Getters/Setters
        [PrimaryKey,AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public DateTime LaDate { get => _laDate; set => _laDate = value; }
        public string UneAppreciation { get => _uneAppreciation; set => _uneAppreciation = value; }

        [ForeignKey(typeof(Etudiant))]     // Specify the foreign key
        public int EtudiantId { get => _etudiantId; set => _etudiantId = value; }

        #endregion

        #region Methodes
        
        #endregion
    }
}
