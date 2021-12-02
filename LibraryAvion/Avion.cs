using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
    public class Avion
    {
        static double PRIX_BUSINESS = 300;
        static double PRIX_PREMIER = 210;
        static double PRIX_ECO = 90;
		
        #region Attributs
        private int id;
        private int nbPlace;

        private int maxPlaceBusiness;
        private int maxPlacePremier;
        private int maxPlaceEco;
        private List<AvionPassager> listeAvionPassagers;
        #endregion

        #region Propriétés
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int NbPlace
        {
            get
            {
                return nbPlace;
            }
            set
            {
                nbPlace = value;
            }
        }
        public double TauxRemplissage
        {
            get
            {
                int placeRestantes = nbPlace - ListPassager.Count;
                double tauxRemplissage = (placeRestantes * 100.0) / nbPlace;

                return tauxRemplissage;
            }
        }
        public List<AvionPassager> ListPassager
        {
            get
            {
                return listeAvionPassagers;
            }
        }
        public string FicheDescriptive
        {
            get
            {
                return ("L'avion est rempli à " + TauxRemplissage + "%, il y a " + RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Eco) + "réservations en classe Eco, " + RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Business) + "réservations en classe Buisness, et " + RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Premier) +"réservations en classe Premier.");

            }
        }
        #endregion

        #region Constructeur
        public Avion(int id, int nbPlace)
        {
            Id = id;
            NbPlace = nbPlace;
            /* TODO : se souvenir que :
             * 
             * 10 % => place Business, prix 300 €
             * 20 % => place Premier, prix 210 €
             * le reste => place Eco, prix 90 €
             * 
             */
        }
        #endregion
		

        public int GetMaxPlaces(AvionPassager.TypePlace typePlacePassager)
        {
            int places = maxPlaceEco; // Par défaut

            switch (typePlacePassager)
            {
                case AvionPassager.TypePlace.Business:
                    places = maxPlaceBusiness;
                    break;
                case AvionPassager.TypePlace.Premier:
                    places = maxPlacePremier;
                    break;
            }

            return places;
        }

        #region CRUD
        // Ajouter un avionPassager : le C dans CRUD
        public bool AjouterAvionPassager(AvionPassager avionPassager)
        {
            if (avionPassager == null)
                throw new Exception("l'argumment est null");

            AvionPassager p = RechercherAvionPassager(avionPassager.Passager.Id);/* TODO: indiquer le passager recherché*/
            if (p != null)
                return false; // Le passager existe déjà

            if (NbPlace <= ListPassager.Count)
                return false; //L'avion est plein

            if (avionPassager.TypePlacePassager == AvionPassager.TypePlace.Business)
            {
                if (RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Business).Count >= maxPlaceBusiness)
                {
                    return false; //Il n'y a plus de place en Buisness
                }
            }
            if (avionPassager.TypePlacePassager == AvionPassager.TypePlace.Eco)
            {
                if (RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Eco).Count >= maxPlaceEco)
                {
                    return false; //Il n'y a plus de place en Eco
                }
            }
            if (avionPassager.TypePlacePassager == AvionPassager.TypePlace.Premier)
            {
                if (RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Premier).Count >= maxPlacePremier)
                {
                    return false; //Il n'y a plus de place en Premier
                }
            }
            
            /* TODO : Ajouter uniquement si les contraintes sont respectées : nb place et type de place
             * 
             *
             * A chaque ajout d'un passager il gagne 2 points de fidélités
             *
             */
            avionPassager.Passager.PointFidelite += 2;
            listeAvionPassagers.Add(avionPassager);
            return true;
        }

        // Supprimer un avionPassager : le D dans CRUD
        public bool SupprimerAvionPassager(AvionPassager avionPassager)
        {
            return SupprimerAvionPassager(avionPassager.Passager.Id);
        }
        public bool SupprimerAvionPassager(int id)
        {
            AvionPassager ap = RechercherAvionPassager(id); /* TODO: indiquer le passager recherché*/
            if (ap == null)
                return false; // Le passager n'existe pas

            listeAvionPassagers.Remove(ap);
            /* TODO : il faut certainement corriger des choses par rapport aux contraintes de pt de fidélité */
            return true;
        }
        #endregion

        #region Méthodes de recherche
        public AvionPassager RechercherAvionPassager(int id)
        {
            foreach (var passager in listeAvionPassagers)
            {
                if (passager.Passager.Id == id)
                {
                    return passager;
                }
            }

            return null;
        }
        public List<AvionPassager> RechercherAvionPassagerTypePlace(AvionPassager.TypePlace typePlace)
        {
            List<AvionPassager> listTemp = new List<AvionPassager>();
            
            foreach (var passager in listeAvionPassagers)
            {
                if (passager.TypePlacePassager == typePlace)
                {
                    listTemp.Add(passager);
                }
            }

            return listTemp;
        }
        #endregion
    }
}
