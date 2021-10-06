﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Trombinoscope.Modeles
{
    public class Etudiant
    {
        #region Attributs

        public static ObservableCollection<Etudiant> CollClasse = new ObservableCollection<Etudiant>();

        public static ObservableCollection<Etudiant> CollEtudiantsPresents = new ObservableCollection<Etudiant>();
        public static ObservableCollection<Etudiant> CollEtudiantsAbsents = new ObservableCollection<Etudiant>();

        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _photo;

        

        #endregion

        #region Constructeurs


        public Etudiant(string nom, string prenom, DateTime dateNaissance, string photo)
        {
            Etudiant.CollClasse.Add(this);
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = dateNaissance;
            _photo = photo;
        }

        #endregion

        #region Getters/Setters
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }
        public string Photo { get => _photo; set => _photo = value; }

        #endregion

        #region Methodes

        public static Etudiant GetEtudiantSelectionne()
        {
             
            if(Etudiant.GetListeEtudiantsPresents().Count > 0)
            {
                return Etudiant.CollEtudiantsPresents[Constantes.rnd.Next(0, Etudiant.GetListeEtudiantsPresents().Count - 1)]; 
            }
            else 
            {
                return null;
            }
        }

        public static ObservableCollection<Etudiant> GetListeEtudiants()
        {
            return Etudiant.CollClasse;
            
            /*foreach(Etudiant unEtudiant in Etudiant.CollClasse)
            {
                resultat.Add(unEtudiant);
            }
            return resultat;
            */
        }
        public static ObservableCollection<Etudiant> GetListeEtudiantsPresents()
        {
            return Etudiant.CollEtudiantsPresents;
        }
        public static ObservableCollection<Etudiant> GetListeEtudiantsAbsents()
        {
             return Etudiant.CollEtudiantsAbsents;
        }

        public static void AjoutCollEtudiantsPresents(Etudiant param)
        {
            Etudiant.CollEtudiantsPresents.Add(param);
        }
        public static void AjoutCollEtudiantsAbsents(Etudiant param)
        {
            Etudiant.CollEtudiantsAbsents.Add(param);
        }

        #endregion
    }
}
