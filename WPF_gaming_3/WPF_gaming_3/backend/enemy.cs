using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class enemy
    {
        private int hp;
        private string name;
        private string imgPath;
        private bool isBoss;
        private int power;
        private int xpReward;
        private int goldReward;

        public enemy(int hp, string name, string imgPath, bool isBoss, int power, int xpReward, int goldReward)
        {
            this.Hp = hp;
            this.Name = name;
            this.ImgPath = imgPath;
            this.IsBoss = isBoss;
            this.Power = power;
            this.XpReward = xpReward;
            this.GoldReward = goldReward;
        }

        public int Hp { get => hp; set => hp = value; }
        public string Name { get => name; set => name = value; }
        public string ImgPath { get => imgPath; set => imgPath = value; }
        public bool IsBoss { get => isBoss; set => isBoss = value; }
        public int Power { get => power; set => power = value; }
        public int XpReward { get => xpReward; set => xpReward = value; }
        public int GoldReward { get => goldReward; set => goldReward = value; }
    }
}
