using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.HistoryDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class HistoryManager
    {
        public static void AddItem(HistoryItem item)
        {
            var adapter = new HistoryTableAdapter();
            adapter.Insert(item.URL, item.Title, item.Date);   
        }

        public static List<HistoryItem> GetItems()
        {
            var adapter = new HistoryTableAdapter();
            var results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                var item = new HistoryItem();
                item.URL = row.URL;
                item.Title = row.Title;
                item.Date = row.Date;

                results.Add(item);
            }
            HistoryItem newItem = new HistoryItem();
            int i = 0;
            while (i != results.Count)
            {
                if (newItem.URL == results[i].URL)
                {
                    
                    results.Remove(results[i]);
                }
                else
                {
                    newItem = results[i];
                    i++;
                }
            }

            return results;
            //this is for history manager
            //Add a History Manager class, with static methods that can add a history item to the
            //database and get all history items from the database
        }
    }
}
