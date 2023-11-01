using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Tests
{
    [TestClass()]
    public class AlienTests
    {
        [TestMethod()]
        public void moveRightTest()
        {
            //Arrange


            //Act

            //Assert

        }

        [TestMethod()]
        public void AlienTest()
        {
            // Arrange
            int x = 1;
            int y = 2;
            int hpDefault = 100;

            // Act
            Alien alien = new Alien(x, y, hpDefault);

            // Assert
            Assert.AreEqual(x, alien.x);
            Assert.AreEqual(y, alien.y);
            Assert.AreEqual(hpDefault, alien.hpDefault);
        }
    }
}