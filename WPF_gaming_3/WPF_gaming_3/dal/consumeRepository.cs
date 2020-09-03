using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WPF_gaming_3.backend;

namespace WPF_gaming_3.dal
{
    public class consumeRepository
    {
        public List<consumeItem> GetConsumeItems()
        {
            business business = new business();
            DataSet dataSet = business.Execute("SELECT * FROM ConsumeClass");
            DataTable consumeTable = dataSet.Tables[0];
            List<consumeItem> consumeItems = new List<consumeItem>();
            foreach (DataRow itemRow in consumeTable.Rows)
            {
                consumeItems.Add(
                    new consumeItem((int)itemRow["healEffect"], (int)itemRow["value"], (string)itemRow["iconPath"], (string)itemRow["itemName"], (string)itemRow["description"])
                    );
            }
            return consumeItems;
        }
    }
}
