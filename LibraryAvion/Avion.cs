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

        private double tauxRemplissage;
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
                tauxRemplissage = (ListeAvionPassagers.Count * 100.0) / nbPlace;

                return tauxRemplissage;
            }
        }
        public List<AvionPassager> ListeAvionPassagers
        {
            get
            {
                return listeAvionPassagers;
            }
            set
            {
                listeAvionPassagers = value;
            }
        }
        public string FicheDescriptive
        {
            get
            {
                return ("L'avion " + Id + " est rempli à " + TauxRemplissage.ToString("F1") + "%, il y a " + RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Eco).Count + " réservations en classe Eco (" +PRIX_ECO +"€), " + RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Business).Count + " réservations en classe Buisness (" +PRIX_BUSINESS +"€), et " + RechercherAvionPassagerTypePlace(AvionPassager.TypePlace.Premier).Count +" réservations en classe Premier (" +PRIX_PREMIER +"€).");

            }
        }

        public int MaxPlaceBusiness
        {
            get => maxPlaceBusiness;
            set => maxPlaceBusiness = value;
        }

        public int MaxPlacePremier
        {
            get => maxPlacePremier;
            set => maxPlacePremier = value;
        }

        public int MaxPlaceEco
        {
            get => maxPlaceEco;
            set => maxPlaceEco = value;
        }

        #endregion

        #region Constructeur
        public Avion(int id, int nbPlace)
        {
            Id = id;
            NbPlace = nbPlace;

            MaxPlaceBusiness = (10 * NbPlace) / 100;
            MaxPlacePremier = (20 * NbPlace) / 100;
            MaxPlaceEco = NbPlace - MaxPlaceBusiness - MaxPlacePremier;

            ListeAvionPassagers = new List<AvionPassager>();
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

            if (NbPlace <= ListeAvionPassagers.Count)
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
            foreach (var avionPassager in listeAvionPassagers)
            {
                if (avionPassager.Passager.Id == id)
                {
                    return avionPassager;
                }
            }

            return null;
        }
        public List<AvionPassager> RechercherAvionPassagerTypePlace(AvionPassager.TypePlace typePlace)
        {
            List<AvionPassager> listTemp = new List<AvionPassager>();
            
            foreach (var passager in ListeAvionPassagers)
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
