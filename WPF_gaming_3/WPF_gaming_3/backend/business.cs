using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using WPF_gaming_3.CharCreation;
using WPF_gaming_3.backend;
using WPF_gaming_3;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace WPF_gaming_3.backend
{
    public class business
    {
        

        public playerClass pClass;
        public player playerObject;
        public List<dungoen> dungoens;
        public void createClass(string className, int stregthP, int agilityP, int luckP, string playerName)
        {
            playerClass p1Class = new playerClass(className);
            if (p1Class.ClassName == "warrior")
            {
                p1Class.Def = 11;
                p1Class.MaxHP = 153;
                p1Class.MaxStamina = 41;
            }
            else
            {
                p1Class.Def = 6;
                p1Class.MaxHP = 79;
                p1Class.MaxStamina = 54;
            }
            pClass = p1Class;
            playerObject = new player(playerName, pClass, 1, 0, 100, stregthP, agilityP, luckP, 0);
        
        }


        public void selcectSound()
        {
            MediaPlayer selcect = new MediaPlayer();
            Uri selectPath = new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/select.wav");
            selcect.Open(selectPath);
            selcect.Play();
        }

        public void createDungoen(int dungoenIndex)
        {
          dungoens  = new List<dungoen>()
            {
            new dungoen("Chambers of the Unknown Forest",
                1,
                120,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1/areabg.png",
                new List<enemy>
                {
                    new enemy(60, " Wild Goblin ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/download.png", false, 13, 20, 50),
                    new enemy(80, " Rouge Pumpkin Famer ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/pumpkinMan.png", true, 3, 40, 120)
                }
                )
                ,
              new dungoen("The Desert Caverns",
                3,
                250,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaBg.png",
                new List<enemy>
                {
                    new enemy(80, " Gaara of Sand ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand2.gif", false, 17, 50, 200),
                    new enemy(120, " Sand Howler ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand.gif", true, 20, 70, 240),

                }
                ),
                
            new dungoen("The Bloodfall Catacombs",
                5,
                600,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaBg.png",
                new List<enemy>
                {
                    
                     new enemy(80, " Flame Bison ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaEnemy1.gif", false, 20, 100, 300),
                     new enemy(120, "Cinder Monster ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaBoss3.png", true, 27, 140, 380)
                
                    }
                )
            };


            
        }

            public List<consumeItem> consumes = new List<consumeItem>()
            {
                new consumeItem(40, 60, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/potion1.png", "Small Healing Potion"),
                new consumeItem(80, 130, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/potion2.png", "Large Healing Postion"),
                new consumeItem(30, 40, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/food1.png", "Small Chunk of Meat"),
                new consumeItem(50, 70, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/food2.png", "Medium Chunk of Meat"),
                new consumeItem(70, 100, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/food3.png", "Large Chunk of Meat"),
            };



        public List<armourItem> armourItems = new List<armourItem>()
            {
                new armourItem(1, 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour1helm.png", ""),
                new armourItem(3, 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour1chest.png", ""),
                new armourItem(3, 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour2helm.png", ""),
                new armourItem(5, 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour2chest.png", ""),
                new armourItem(6, 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour3helm.png", ""),
                new armourItem(7, 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour3chest.png", ""),
        };

        public List<weaponItem> weaponItems = new List<weaponItem>()
        {
            new weaponItem(5, false, "", 200, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword1.png", "Peasent Sword"),
            new weaponItem(8, false, "", 350, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword2.png", "Solid Iron Sword"),
            new weaponItem(11, false, "", 700, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword3.png", "Blessed Iron Sword"),
            new weaponItem(16, true, "A holy sword blessed by the frost gods. A hit from this sword will result in the enemy facing the mighty frost gods waith", 8000, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword4.png", "Holy Frost Sword"),
            new weaponItem(20, true, "A sword made of the rarest minerals from the deepest depts of hell. A hit from this sword will cast your eneimes in hell fire!", 30000, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword5.png", "Blessed Iron Sword"),
        };

        

    }
}
