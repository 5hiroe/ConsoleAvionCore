using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryAvion
{
    public class Aeroport
    {
        #region Attributs
        private List<Avion> listeAvions = new List<Avion>();
        #endregion

        #region CRUD
        // Ajouter un avion : le C dans CRUD
        public bool AjouterAvion(Avion avion)
        {
            if (avion == null)
            {
                throw new Exception("L'avion est null");
            }

            foreach (var avions in listeAvions)
            {
                if (avion == avions)
                {
                    return false;
                }
            }
            
            listeAvions.Add(avion);
            return true;
        }

        // Supprimer un avion : le D dans CRUD
        public bool SupprimerAvion(Avion avion)
        {
            return SupprimerAvion(avion.Id);
        }
        public bool SupprimerAvion(int id)
        {
            Avion p = RechercherAvion(id);
            if (p == null)
                return false; // L'avion n'existe pas

            listeAvions.Remove(p);
            return true;
        }
        #endregion

        #region Méthodes de recherche
        public Avion RechercherAvion(int id)
        {
            foreach (var avions in listeAvions)
            {
                if (avions.Id == id)
                {
                    return avions;
                }
            }
            return null;
        }


        public List<Avion> RechercherAvionsRemplissage(double tauxRemplissage)
        {
            List<Avion> listTemp = new List<Avion>();
            
            foreach (var avion in listeAvions)
            {
                if (avion.TauxRemplissage <= tauxRemplissage)
                {
                    listTemp.Add(avion);
                }
            }
            return listTemp;
        }
        #endregion


        public void AfficherAvions()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("AfficherAvions");

            foreach (Avion avion in listeAvions)
            {
                Console.WriteLine(avion.FicheDescriptive);
            }
        }

        public List<AvionPassager> PassagersAvions()
        {
            List<AvionPassager> listTemp = new List<AvionPassager>();
            bool isHere = false;
            foreach (var avion in listeAvions)
            {
                foreach (var avionPassager in avion.ListeAvionPassagers)
                {
                    if (listTemp.Count != 0)
                    {
                        foreach (var element in listTemp)
                        {
                            if (element.Passager == avionPassager.Passager)
                            {
                                isHere = true;
                            }
                        }
                    }

                    if (!isHere)
                    { 
                        listTemp.Add(avionPassager);
                    }

                    isHere = false;

                }
            }

            return listTemp;
            /* TODO : retourne la liste des passagers ayant pris l'avion
             * 
             * ATTENTION : un passager ayant prix 2 avions différents ne doit apparaitre qu'une seule fois !!
             * 
             */

        }


        public List<Avion> AvionsPassager(Passager passager)
        {
            return AvionsPassager(passager.Id);
        }
        public List<Avion> AvionsPassager(int id)
        {
            List<Avion> listTemp = new List<Avion>();

            foreach (var avion in listeAvions)
            {
                foreach (var avionPassager in avion.ListeAvionPassagers)
                {
                    if (avionPassager.Passager.Id == id)
                    {
                        listTemp.Add(avion);
                    }
                }
            }
            return listTemp;
        }
    }
}
