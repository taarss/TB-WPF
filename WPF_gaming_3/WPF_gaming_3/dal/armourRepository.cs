using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WPF_gaming_3.backend;

namespace WPF_gaming_3.dal
{
    public class armourRepository
    {
        public List<armourItem> GetArmourItems()
        {
            business business = new business();
            DataSet dataSet = business.Execute("SELECT * FROM ArmourClass");
            DataTable armourTable = dataSet.Tables[0];
            List<armourItem> armourItems = new List<armourItem>();
            foreach (DataRow itemRow in armourTable.Rows)
            {
                armourItems.Add(
                    new armourItem((int)itemRow["defEffect"], (int)itemRow["value"], (string)itemRow["iconPath"], (string)itemRow["itemName"], (string)itemRow["description"])
                    );
            }
            return armourItems;
        }
    }
}
