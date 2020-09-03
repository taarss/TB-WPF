using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class weaponItem : item
    {
        public int attackEffect;
        private bool isLegendary;

        public weaponItem(int attackEffect, string descreption, int value, string iconPath, string itemName, bool isLegendary) : base(value, iconPath, itemName, descreption)
        {
            this.AttackEffect = attackEffect;
            this.isLegendary = isLegendary;
        }

        public int AttackEffect { get => attackEffect; set => attackEffect = value; }
        
    }
}
