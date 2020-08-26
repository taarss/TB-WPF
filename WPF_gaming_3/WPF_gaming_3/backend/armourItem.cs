using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class armourItem : item
    {
        private int defEffect;

        public armourItem(int defEffect, int value, string iconPath, string itemName) : base(value, iconPath, itemName)
        {
            this.DefEffect = defEffect;
        }

        public int DefEffect { get => defEffect; set => defEffect = value; }
    }
}
