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
using System.Data;
using System.Data.SqlClient;

namespace WPF_gaming_3.backend
{
    public class business
    {
        

        public playerClass pClass;
        public player playerObject;
        public List<dungoen> dungoens;
        public List<consumeItem> consumes = new List<consumeItem>();        
        public List<armourItem> armourItems = new List<armourItem>();
        public List<weaponItem> weaponItems = new List<weaponItem>();


        private string connectionString = "Data Source=PC-BB-5987;Initial Catalog=game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataSet resultSet = new DataSet();
        public DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }

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
            List<item> inventory = new List<item>() { };
            pClass = p1Class;
            playerObject = new player(playerName, pClass, 1, 0, 100, stregthP, agilityP, luckP, 10000,  inventory);
           // Execute($"INSERT INTO Player (playerLvl, xp, nextLvlUp, strength, agility, luck, gold) VALUES('{playerName}', 0, 0, 100, {stregthP}, {agilityP}, {luckP})");
        
        }

        public void getPlayerClassFromDB()
        {/*
            DataSet dataSet = Execute("SELECT * FROM PlayerClass WHERE id = 1");
            DataTable playerTable = dataSet.Tables[0];
            foreach (DataRow itemRow in playerTable.Rows)
            {
                playerObject = (
                    new player((string)itemRow["playerName"], playerClass, (int)itemRow["playerLvl"], (int)itemRow["xp"], (int)itemRow["nextLvlUp"], (int)itemRow["strength"], (int)itemRow["agility"], (int)itemRow["luck"], (int)itemRow["gold"], inventory)
                    );
            }*/
        }



        public void getPlayerFromDB(List<item> inventory, playerClass playerClass)
        {
            DataSet dataSet = Execute("SELECT * FROM Player WHERE id = 1");
            DataTable playerTable = dataSet.Tables[0];
            foreach (DataRow itemRow in playerTable.Rows)
            {
                playerObject = (
                    new player((string)itemRow["playerName"], playerClass, (int)itemRow["playerLvl"], (int)itemRow["xp"], (int)itemRow["nextLvlUp"], (int)itemRow["strength"], (int)itemRow["agility"], (int)itemRow["luck"], (int)itemRow["gold"], inventory)
                    );
            }

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
                new List<Enemy>
                {
                    new Enemy(60, " Wild Goblin ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/download.png", false, 13, 20, 50),
                    new Enemy(80, " Rogue Pumpkin Farmer ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/pumpkinMan.png", true, 3, 40, 120)
                }
                )
                ,
              new dungoen("The Desert Caverns",
                3,
                250,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaBg.png",
                new List<Enemy>
                {
                    new Enemy(80, " Gaara of Sand ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand2.gif", false, 17, 50, 200),
                    new Enemy(120, " Sand Howler ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand.gif", true, 20, 70, 240),

                }
                ),
                
            new dungoen("The Bloodfall Catacombs",
                5,
                600,
                0,
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaLoading.png",
                "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaBg.png",
                new List<Enemy>
                {
                    
                     new Enemy(100, " Flame Bison ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaEnemy1.gif", false, 20, 100, 300),
                     new Enemy(150, "Cinder Monster ", "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaBoss3.png", true, 27, 140, 380)
                
                    }
                )
            };


            
        }     
    }
}
