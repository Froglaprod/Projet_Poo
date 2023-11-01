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
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerTest()
        {
            // Arrange
            int x = 50;
            int y = 34;
            int hpDefault = 50;

            // Act
            Player player = new Player(x, y, hpDefault);

            // Assert
            Assert.AreEqual(x, player.x);
            Assert.AreEqual(y, player.y);
            Assert.AreEqual(hpDefault, player.hpDefault);
        }
    }
}