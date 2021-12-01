using System;
using System.Collections.Generic;
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
            /* TODO : A faire 
             * 
             * Retourne tous les avions dont le taux de remplissage est inférieur ou égal à celui indiqué
             * 
             **/
            return null;
        }
        #endregion


        public void AfficherAvions()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("AfficherAvions");

            foreach (Avion avion in listeAvions)
            {
                /* TODO : Ajouter la FicheDescriptive dans l'Avion
                 * 
                 * La fiche descriptive doit indiquer au moins le taux de remplissage et le montant HT des billets des passagers
                 * 
                 *
                 * se souvenir que :
                 * 
                 * 10 % => place Business, prix 300 €
                 * 20 % => place Premier, prix 210 €
                 * le reste => place Eco, prix 90 €
                 * 
                 */
                Console.WriteLine(avion.FicheDescriptive);
            }
        }

        public List<AvionPassager> PassagersAvions()
        {
            /* TODO : retourne la liste des passagers ayant pris l'avion
             * 
             * ATTENTION : un passager ayant prix 2 avions différents ne doit apparaitre qu'une seule fois !!
             * 
             */
			 
			 return null;
        }


        public List<Avion> AvionsPassager(Passager passager)
        {
            return AvionsPassager(passager.Id);
        }
        public List<Avion> AvionsPassager(int id)
        {
            /* TODO : retourne la liste des avions pris par le passager
             * 
             */
			 return null;
        }
    }
}
