using System;
using System.Collections.Generic;
using System.Text;
using WPF_gaming_3.backend;

namespace WPF_gaming_3.backend
{
     public class dungoen
    {
        business businessClass = new business();

        private string dungoenName;
        private int dungoenDifficulty;
        private int exReward;
        private int reqLvl;
        private string imgPath;
        private string imgBgPath;
        private List<enemy> enemyList;

        public dungoen(string dungoenName, int dungoenDifficulty, int exReward, int reqLvl, string imgPath, string imgBgPath)
        {
            this.dungoenName = dungoenName;
            this.dungoenDifficulty = dungoenDifficulty;
            this.exReward = exReward;
            this.reqLvl = reqLvl;
            this.imgPath = imgPath;
            this.imgBgPath = imgBgPath;
        }

        public string DungoenName { get => dungoenName; set => dungoenName = value; }
        public int DungoenDifficulty { get => dungoenDifficulty; set => dungoenDifficulty = value; }
        public int ExReward { get => exReward; set => exReward = value; }
        public int ReqLvl { get => reqLvl; set => reqLvl = value; }
        public string ImgPath { get => imgPath; set => imgPath = value; }
        public string ImgBgPath { get => imgBgPath; set => imgBgPath = value; }
        internal List<enemy> EnemyList { get => enemyList; set => enemyList = value; }

        public List<string> dungoenAtributes(int dungoenDif)
    {
            businessClass.dungoens.
    }
    }

}
