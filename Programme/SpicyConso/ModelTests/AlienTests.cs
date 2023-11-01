using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Tests
{
    [TestClass()]
    public class AlienTests
    {


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

        [TestMethod()]
        public void moveLeftTest()
        {
            // Arrange
            Alien alien = new Alien(137, 2, 100);
            alien.invaderDirection = false;
            int x = alien.x;
            int y = alien.y;

            // Act
            alien.moveLeft();

            // Assert

            Assert.AreEqual(x - 1, alien.x);

            if (alien.x == 1)
            {
                Assert.AreEqual(y + 4, alien.y);
                Assert.IsTrue(alien.invaderDirection);
            }
        }

        [TestMethod()]
        public void moveRightTest()
        {
            // Arrange
            Alien alien = new Alien(1, 2, 100);
            alien.invaderDirection = true;
            int x = alien.x;
            int y = alien.y;
            int width = Alien.width - 13;

            // Act
            alien.moveRight();

            // Assert
            Assert.AreEqual(x + 1, alien.x);

            if (alien.x == width)
            {
                Assert.AreEqual(y + 4, alien.y);
                Assert.IsFalse(alien.invaderDirection);
            }

        }
    }
}