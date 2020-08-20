using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.CharCreation
{
    public class playerClass
    {
        private string className;
        private ability ability1;
        private ability ability2;
        private ability ability3;
        private ability healAbility4;
        private int def;
        private int maxHP;
        private int maxStamina;

        public playerClass(string className)
        {
            ClassName = className;
            setAbility(className);

        }

        public string ClassName { get => className; set => className = value; }
        public int Def { get => def; set => def = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int MaxStamina { get => maxStamina; set => maxStamina = value; }
        internal ability Ability1 { get => ability1; set => ability1 = value; }
        internal ability Ability2 { get => ability2; set => ability2 = value; }
        internal ability Ability3 { get => ability3; set => ability3 = value; }
        internal ability HealAbility4 { get => healAbility4; set => healAbility4 = value; }

        List<ability> warriorAbilities = new List<ability>()
            {
                new ability("rend", 4, 5),
                new ability("heroic strike", 5, 6),
                new ability("charge", 3, 4),
                new ability("eat", 8, 10)
            };

        List<ability> deathKnightAbilities = new List<ability>()
            {
                new ability("death and decay", 7, 4),
                new ability("death coil", 8, 5),
                new ability("festering strike", 11, 9),
                new ability("death strike", 5, 4)
            };

        public void setAbility(string className)
        {
            if (className == "Warrior")
            {
                ability1 = warriorAbilities[0];
                ability2 = warriorAbilities[1];
                ability3 = warriorAbilities[2];
                healAbility4 = warriorAbilities[3];
            }
            else
            {
                ability1 = deathKnightAbilities[0];
                ability1 = deathKnightAbilities[1];
                ability1 = deathKnightAbilities[2];
                healAbility4 = deathKnightAbilities[3];
            }
        }

    }
}
