using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class consumeItem : item 
    {
        public int healEffect;
        public readonly string itemName;
        public string description;

        public consumeItem(int healEffect, int value, string iconPath, string itemName, string descriptionm, string typeItem) : base(value, iconPath, itemName, typeItem)
        {
            this.HealEffect = healEffect;
            this.itemName = itemName;
            this.description = description;
        }

        public int HealEffect { get => healEffect; set => healEffect = value; }

        
    }
}
