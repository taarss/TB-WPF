using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF_gaming_3.CharCreation;
using System.Collections.Generic;
using WPF_gaming_3.backend;
using WPF_gaming_3.dal;
using System;
using System.Data;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        public const string DebitAmountLessThanZeroMessage = "Gold amount is less than zero";

        [TestMethod]
        public void TestMethod1()
        {
            playerClass playerClass = new playerClass("death knight");
            player player = new player("Christian", playerClass, 1, 0, 100, 4, 4, 2, 0, new List<WPF_gaming_3.backend.item>());
            string actual = player.PlayerName;
            string expected = "Christian";
            Assert.AreEqual(expected, actual, null, "Name now valid");
        }

        [TestMethod]
        public void goldIsNotNegative()
        {
            playerClass playerClass = new playerClass("death knight");
            player player = new player("Christian", playerClass, 1, 0, 100, 4, 4, 2, 10, new List<WPF_gaming_3.backend.item>());
            if (player.Gold < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", player.Gold, DebitAmountLessThanZeroMessage);
            }
        }
        [TestMethod]
        public void checkGold()
        {
            playerClass playerClass = new playerClass("death knight");
            try
            {
                player player = new player("Christian", playerClass, 1, 0, 100, 4, 4, 2, 10, new List<WPF_gaming_3.backend.item>());
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "Error");
                
            }
        
        }

        [TestMethod]
        public void checkDungoenImgPath()
        {
            business business = new business();
            foreach (var item in business.dungoens)
            {
                if (string.IsNullOrWhiteSpace(item.ImgPath))
                {
                    //Works
                }
                else
                {
                    throw new System.ArgumentException("Dungoen needs a loading image path");
                }
                
            }
        }

        [TestMethod]
        public void checkDungoenBgImgPath()
        {
            business business = new business();
            foreach (var item in business.dungoens)
            {
                if (string.IsNullOrWhiteSpace(item.ImgBgPath))
                {
                    //Works
                }
                else
                {
                   56 throw new System.ArgumentException("Dungoen needs a background image path");
                }
            }
        }

        [TestMethod]
        public void checkDungoenHasEnemy()
        {
            business business = new business();
            foreach (var item in business.dungoens)
            {
                if (item.Enemies.Count >= 1)
                {
                    //Works
                }
                else
                {
                    throw new System.ArgumentException("dungoen needs at least 1 enemy");
                }

            }
        }

        [TestMethod]
        public void checkArmourItems()
        {
            armourRepository armourRepository = new armourRepository();
            List<armourItem> armourItems = armourRepository.GetArmourItems();
            int expectedArmourItems = 6;
                if (armourItems.Count < expectedArmourItems)
                {
                    throw new System.ArgumentException("Not all armour item got loaded from the database");                    
                }
                else if (armourItems.Count > expectedArmourItems)
                {
                    throw new System.ArgumentException("More armour items than exptected got loaded from the database. Either check the ArmourItems() method or increase the amount of expected armour itens/" +
                        "");
                }


        }

    }
}
