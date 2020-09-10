using Microsoft.VisualStudio.TestTools.UnitTesting;
/*using WPF_gaming_3.backend;
using WPF_gaming_3.CharCreation;
using WPF_gaming_3;*/
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerNameTest()
        {
            WPF_gaming_3.CharCreation.playerClass playerClass2 = new WPF_gaming_3.CharCreation.playerClass("death knight");
            WPF_gaming_3.CharCreation.player player2 = new WPF_gaming_3.CharCreation.player("Christian", playerClass2, 1, 0, 100, 5, 3, 2, 0, new List<WPF_gaming_3.backend.item>());
            string actual = player2.PlayerName;
            string expected = "Christian";

            Assert.AreEqual(expected, actual, null ,"Name not valid");
        }

    }
}
