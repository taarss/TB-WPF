using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class armourItem : item
    {
        private int defEffect;
        private string description;

        public armourItem(int defEffect, int value, string iconPath, string itemName, string description) : base(value, iconPath, itemName)
        {
            this.DefEffect = defEffect;
            this.Description = description;
        }

        public int DefEffect { get => defEffect; set => defEffect = value; }
        public string Description { get => description; set => description = value; }
    }
}
