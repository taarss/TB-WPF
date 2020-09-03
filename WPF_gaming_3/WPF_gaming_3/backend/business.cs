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
        public List<dungoen> dungoens = new List<dungoen>();
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
            playerObject = new player(playerName, pClass, 1, 0, 100, stregthP, agilityP, luckP, 100000,  inventory);
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
        public List<Enemy> GetEnemies(int dungoenIndex)
        {
            List<Enemy> enemies = new List<Enemy>(); 
            DataSet dataSet = Execute("SELECT * FROM Enemy WHERE dungoenId = "+(dungoenIndex+1));
            DataTable enemyIndexTable = dataSet.Tables[0];
            foreach (DataRow item in enemyIndexTable.Rows)
            {
                enemies.Add(new Enemy(Convert.ToInt32(item["hp"]), item["name"].ToString(), item["imgPath"].ToString(), Convert.ToBoolean(item["isBoss"]), Convert.ToInt32(item["power"]), Convert.ToInt32(item["xpReward"]), Convert.ToInt32(item["goldReward"])));
            }
            return enemies;
        }






        public void createDungoen(int dungoenIndex)
        {
            dungoens = new List<dungoen>();
            DataSet dataSet = Execute("SELECT * FROM Dungoen");
            DataTable dungoenTable = dataSet.Tables[0];
            foreach (DataRow item in dungoenTable.Rows)
            {
                dungoens.Add(new dungoen(
                    item["dungoenName"].ToString(),
                    Convert.ToInt32(item["dungoenDifficulty"]),
                    Convert.ToInt32(item["exReward"]),
                    Convert.ToInt32(item["reqLvl"]),
                    item["imgPath"].ToString(),
                    item["imgBgPath"].ToString(),
                    GetEnemies(dungoenIndex)));
            }              
        }     
    }
}
