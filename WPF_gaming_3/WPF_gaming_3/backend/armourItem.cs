using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class armourItem : item
    {
        private int defEffect;
        private bool isHelmet;

        public armourItem(int defEffect, int value, string iconPath, string itemName, string description, bool isHelmet) : base(value, iconPath, itemName, description)
        {
            this.DefEffect = defEffect;
            this.IsHelmet = isHelmet;
        }

        public int DefEffect { get => defEffect; set => defEffect = value; }
        public bool IsHelmet { get => isHelmet; set => isHelmet = value; }
    }
}
