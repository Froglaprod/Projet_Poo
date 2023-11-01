using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    [TestClass()]
    public class missileJoueurTests
    {
        [TestMethod()]
        public void UpdateMisilleTest()
        {
            // Arrange
            missileJoueur missile = new missileJoueur(50);
            int y = missile.y;
            missile.missileIsLaunched = true;


            // Act
            missile.UpdateMisille();

            // Assert
            Assert.AreEqual(y - 1, missile.y);
        }
    }
}