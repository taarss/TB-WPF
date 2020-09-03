using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WPF_gaming_3.backend;

namespace WPF_gaming_3.dal
{
    public class weaponRepository
    {
        public List<weaponItem> GetWeaponItems()
        {
            business business = new business();
            DataSet dataSet = business.Execute("SELECT * FROM WeaponClass");
            DataTable weaponTable = dataSet.Tables[0];
            List<weaponItem> weaponItems = new List<weaponItem>();
            foreach (DataRow itemRow in weaponTable.Rows)
            {
                weaponItems.Add(
                    new weaponItem((int)itemRow["attackEffect"], (string)itemRow["description"], (int)itemRow["value"], (string)itemRow["iconPath"], (string)itemRow["itemName"], (bool)itemRow["isLegendary"])
                    );
            }
            return weaponItems;
        }
    }
}
