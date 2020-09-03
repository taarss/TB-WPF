using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class armourItem : item
    {
        private int defEffect;
        business business = new business();

        public armourItem(int defEffect, int value, string iconPath, string itemName, string description) : base(value, iconPath, itemName, description)
        {
            this.DefEffect = defEffect;
        }

        public int DefEffect { get => defEffect; set => defEffect = value; }

       
    }
}
