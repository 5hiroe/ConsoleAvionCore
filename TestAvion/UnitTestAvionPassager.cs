using LibraryAvion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvion
{
    public class UnitTestAvionPassager
    {
        [Test]
        public void TestConstructeur()
        {
            Passager passager = new Passager(1, "DUPONT", new DateTime(1998, 5, 24));
            // Paramètres : le passager,le type de place 
            AvionPassager avionPassager = new AvionPassager(passager, AvionPassager.TypePlace.Eco);
            Assert.Pass();
        }
    }
}
