using LibraryAvion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAvion
{
    public class UnitTestAvion
    {
        [Test]
        public void TestConstructeur()
        {
            Avion avion = new Avion(1, 100);

            Assert.AreEqual(70, avion.GetMaxPlaces(AvionPassager.TypePlace.Eco));
            Assert.AreEqual(10, avion.GetMaxPlaces(AvionPassager.TypePlace.Business));
            Assert.AreEqual(20, avion.GetMaxPlaces(AvionPassager.TypePlace.Premier));
        }
    }
}
