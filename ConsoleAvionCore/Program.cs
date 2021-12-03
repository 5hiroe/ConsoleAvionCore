using System;
using System.Collections.Generic;
using System.Text;

using LibraryAvion;

namespace ConsoleAvionCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Passager dupont = new Passager(1, "DUPONT", new DateTime(1998, 5, 24)); // Pts de fidélité = 0
            Passager henry = new Passager(2, "HENRY", new DateTime(1981, 7, 8), 6); // Pts de fidélité = 6
            Passager p3 = new Passager(3, "MALTAN", new DateTime(1961, 3, 14), 42); // Pts de fidélité = 42
            Passager p4 = new Passager(4, "P4", new DateTime(1998, 5, 24)); // Pts de fidélité = 0
            Passager p5 = new Passager(5, "P5", new DateTime(1984, 4, 21)); // Pts de fidélité = 0
            Passager p6 = new Passager(6, "P6", new DateTime(1995, 10, 1)); // Pts de fidélité = 0

            Avion avion1 = new Avion(1, 30);
            avion1.AjouterAvionPassager(new AvionPassager(dupont, AvionPassager.TypePlace.Business));
            avion1.AjouterAvionPassager(new AvionPassager(henry, AvionPassager.TypePlace.Eco));
            avion1.AjouterAvionPassager(new AvionPassager(p4, AvionPassager.TypePlace.Eco));

            // DUPONT a pris une place dans 2 avions différents
            Avion avion2 = new Avion(2, 40);
            avion2.AjouterAvionPassager(new AvionPassager(dupont, AvionPassager.TypePlace.Premier));
            avion2.AjouterAvionPassager(new AvionPassager(p3, AvionPassager.TypePlace.Business));
            avion2.AjouterAvionPassager(new AvionPassager(p5, AvionPassager.TypePlace.Business));
            avion1.AjouterAvionPassager(new AvionPassager(p6, AvionPassager.TypePlace.Eco));

            Aeroport aeroport = new Aeroport();
            aeroport.AjouterAvion(avion1);
            aeroport.AjouterAvion(avion2);

            aeroport.AfficherAvions();

            // Dans la méthode suivante, DUPONT apparait une seule fois
            Console.WriteLine("***********************");
            Console.WriteLine("AfficherPassagersAvions");
            List<AvionPassager> passagers = aeroport.PassagersAvions();
			AfficherPassagers(passagers);


            // Affiche tous les avions pris par DUPONT (p1) : avion 1 et 2
            Console.WriteLine("***********************");
            Console.WriteLine("AfficherAvionsPassager pour " + dupont.Nom);
            List<Avion> avions = aeroport.AvionsPassager(dupont);
            AfficherAvions(avions);
        }

        static void AfficherPassagers(List<AvionPassager> passagers)
        {
            // Affichage
            foreach (AvionPassager avionPassager in passagers)
            {
                Console.WriteLine(avionPassager.Passager.Identite);
            }
        }

        static void AfficherAvions(List<Avion> avions)
        {
            // Affichage
            foreach (Avion avion in avions)
            {
                Console.WriteLine("Avion n° " + avion.Id);
            }
        }
    }
}
