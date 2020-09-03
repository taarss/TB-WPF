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
                new ability("rend", 4, 5, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior1.jpg"),
                new ability("heroic strike", 50, 6, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior2.jpg"),
                new ability("charge", 3, 4, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior3.jpg"),
                new ability("eat", 8, 10, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior4.jpg")
            };

        List<ability> deathKnightAbilities = new List<ability>()
            {
                new ability("death and decay", 70, 4, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk1.jpg"),
                new ability("death coil", 8, 5, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk2.jpg"),
                new ability("festering strike", 11, 9, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk3.jpg"),
                new ability("death strike", 11, 14, "C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk4.jpg")
            };

        public void setAbility(string className)
        {

             
            if (className == "warrior")
            {
                ability1 = warriorAbilities[0];
                ability2 = warriorAbilities[1];
                ability3 = warriorAbilities[2];
                healAbility4 = warriorAbilities[3];
                
            }
            else
            {
                ability1 = deathKnightAbilities[0];
                ability2 = deathKnightAbilities[1];
                ability3 = deathKnightAbilities[2];
                healAbility4 = deathKnightAbilities[3];
                
            }
        }

    }
}
