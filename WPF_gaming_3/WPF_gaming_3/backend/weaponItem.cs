using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class weaponItem : item
    {
        private int attackEffect;
        private bool isLegendary;
        private string descreption;

        public weaponItem(int attackEffect, bool isLegendary, string descreption, int value, string iconPath, string itemName) : base(value, iconPath, itemName)
        {
            this.AttackEffect = attackEffect;
            this.IsLegendary = isLegendary;
            this.Descreption = descreption;
        }

        public int AttackEffect { get => attackEffect; set => attackEffect = value; }
        public bool IsLegendary { get => isLegendary; set => isLegendary = value; }
        public string Descreption { get => descreption; set => descreption = value; }
    }
}
