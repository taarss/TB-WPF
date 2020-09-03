using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class consumeItem : item 
    {
        public int healEffect;

        public consumeItem(int healEffect, int value, string iconPath, string itemName, string descriptionn) : base(value, iconPath, itemName, descriptionn)
        {
            this.HealEffect = healEffect;
        }

        public int HealEffect { get => healEffect; set => healEffect = value; }
       
    }
}
