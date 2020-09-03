using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_gaming_3.backend
{
    public class item
    {
        private int value;
        private string iconPath;
        private string itemName;
        private string description;

        public int Value { get => value; set => this.value = value; }
        public string IconPath { get => iconPath; set => iconPath = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string Description { get => description; set => description = value; }

        public item(int value, string iconPath, string itemName, string description)
        {
            this.Value = value;
            this.IconPath = iconPath;
            this.ItemName = itemName;
            this.Description = description;
        }



    }
}
