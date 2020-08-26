using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class consumeItem : item 
    {
        private int healEffect;

        public consumeItem(int healEffect, int value, string iconPath, string itemName) : base(value, iconPath, itemName)
        {
            this.HealEffect = healEffect;
        }

        public int HealEffect { get => healEffect; set => healEffect = value; }

        
    }
}
