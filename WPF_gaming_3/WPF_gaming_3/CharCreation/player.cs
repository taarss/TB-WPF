using System;
using System.Collections.Generic;
using System.Text;
using WPF_gaming_3.backend;

namespace WPF_gaming_3.CharCreation
{
    public class player
    {
        private string playerName;
        private playerClass playerClass;
        private int playerLvl;
        private int xp;
        private int nextLvlUp;
        private int strength;
        private int agility;
        private int luck;
        private int gold;
        private List<item> inventory;


        public player(string playerName, playerClass playerClass, int playerLvl, int xp, int nextLvlUp, int strength, int agility, int luck, int gold, List<item> inventory)
        {
            this.PlayerName = playerName;
            this.PlayerClass = playerClass;
            this.PlayerLvl = playerLvl;
            this.Xp = xp;
            this.NextLvlUp = nextLvlUp;
            this.Strength = strength;
            this.Agility = agility;
            this.Luck = luck;
            this.Gold = gold;
            this.inventory = inventory;
        }

        public string PlayerName { get => playerName; set => playerName = value; }
        public playerClass PlayerClass { get => playerClass; set => playerClass = value; }
        public int PlayerLvl { get => playerLvl; set => playerLvl = value; }
        public int Xp { get => xp; set => xp = value; }
        public int NextLvlUp { get => nextLvlUp; set => nextLvlUp = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Agility { get => agility; set => agility = value; }
        public int Luck { get => luck; set => luck = value; }
        public int Gold { get => gold; set => gold = value; }
        public List<item> Inventory { get => inventory; set => inventory = value; }
    }
}

