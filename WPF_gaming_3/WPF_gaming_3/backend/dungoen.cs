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
        private List<enemy> enemies;

        public dungoen(string dungoenName, int dungoenDifficulty, int exReward, int reqLvl, string imgPath, string imgBgPath, List<enemy> enemies)
        {
            this.DungoenName = dungoenName;
            this.DungoenDifficulty = dungoenDifficulty;
            this.ExReward = exReward;
            this.ReqLvl = reqLvl;
            this.ImgPath = imgPath;
            this.ImgBgPath = imgBgPath;
            this.Enemies = enemies;
        }

        public string DungoenName { get => dungoenName; set => dungoenName = value; }
        public int DungoenDifficulty { get => dungoenDifficulty; set => dungoenDifficulty = value; }
        public int ExReward { get => exReward; set => exReward = value; }
        public int ReqLvl { get => reqLvl; set => reqLvl = value; }
        public string ImgPath { get => imgPath; set => imgPath = value; }
        public string ImgBgPath { get => imgBgPath; set => imgBgPath = value; }
        public List<enemy> Enemies { get => enemies; set => enemies = value; }
    }

}
