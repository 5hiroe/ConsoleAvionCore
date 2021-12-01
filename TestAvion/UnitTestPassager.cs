using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
    public class UnitTestPassager
    {
        [Test]
        public void TestConstructeur()
        {
            // Paramètres : Id, Nom, Date de naissance, Points fidélités
            Passager passager = new Passager(1, "DUPONT", new DateTime(1998, 5, 24), 4);
            Assert.Pass();
        }
        [Test]
        public void TestConstructeur2()
        {
            // Paramètres : Id, Nom, Date de naissance
            // Pas de Points fidélités dans le constructeur, valeur par défaut = 0
            Passager passager = new Passager(1, "DUPONT", new DateTime(1998, 5, 24));
            Assert.Pass();
        }
    }
}
