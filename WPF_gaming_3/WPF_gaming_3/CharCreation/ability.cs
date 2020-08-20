using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.CharCreation
{
    class ability
    {
        private string abilityName;
        private int abilityDmg;
        private int abilityStaminaCost;

        public ability(string abilityName, int abilityDmg, int abilityStaminaCost)
        {
            this.AbilityName = abilityName;
            this.AbilityDmg = abilityDmg;
            this.AbilityStaminaCost = abilityStaminaCost;
        }

        public string AbilityName { get => abilityName; set => abilityName = value; }
        public int AbilityDmg { get => abilityDmg; set => abilityDmg = value; }
        public int AbilityStaminaCost { get => abilityStaminaCost; set => abilityStaminaCost = value; }
    }
}
