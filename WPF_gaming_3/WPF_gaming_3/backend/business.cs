using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using WPF_gaming_3.CharCreation;
using WPF_gaming_3.backend;
using WPF_gaming_3;
using System.Threading.Tasks;

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
                2,
                120,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1/areabg.png",
                new List<enemy>
                {
                    new enemy(60, "Wild Goblin", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/download.png", false, 13, 60, 50),
                    new enemy(80, "Rouge Pumpkin Famer", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/pumpkinMan.png", true, 3, 150, 120)
                }
                )
                ,
              new dungoen("The Desert Caverns",
                2,
                250,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaBg.png",
                new List<enemy>
                {
                    new enemy(80, "Gaara of the Sand", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand2.gif", false, 17, 250, 200),
                    new enemy(120, "Primitive Sand Howler", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand.gif", true, 20, 320, 240),

                }
                ),
                
            new dungoen("The Bloodfall Catacombs",
                2,
                600,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaBg.png",
                new List<enemy>
                {
                    
                     new enemy(80, "Scarred Flame Bison", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaEnemy1.gif", false, 20, 400, 300),
                     new enemy(120, "Cinder Monster ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaBoss3.png", true, 27, 500, 380)
                
                    }
                )
            };
        }

       

        

    }
}
