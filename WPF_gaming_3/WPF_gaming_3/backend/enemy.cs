using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    class enemy
    {
        private int hp;
        private string name;
        private string imgPath;
        private bool isBoss;

        public enemy(int hp, string name, string imgPath, bool isBoss)
        {
            this.Hp = hp;
            this.Name = name;
            this.ImgPath = imgPath;
            this.IsBoss = isBoss;
        }

        public int Hp { get => hp; set => hp = value; }
        public string Name { get => name; set => name = value; }
        public string ImgPath { get => imgPath; set => imgPath = value; }
        public bool IsBoss { get => isBoss; set => isBoss = value; }
    }
}
