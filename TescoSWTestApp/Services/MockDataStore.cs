using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TescoSWTestApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TescoSWTestApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        public static string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AppDataStorage.txt");

        public MockDataStore()
        {
            //data loader
            if (!File.Exists(fileName)) { Console.WriteLine("saveFile doesnt exist! Creating an empty one."); File.WriteAllText(fileName, ""); }
            string text = File.ReadAllText(fileName);
            if(text.Length > 0)
            {   
                items = new List<Item>();
                items = JsonConvert.DeserializeObject<List<Item>>(text);
                return;
            }

            //
            DateTime FirstDate = new DateTime(2023, 1, 1);
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Týden 1.", Description=FirstDate.ToString("d")+" - "+FirstDate.AddDays(7).ToString("d") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Týden 2.", Description=FirstDate.AddDays(7).ToString("d")+" - "+FirstDate.AddDays(14).ToString("d") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Týden 3.", Description=FirstDate.AddDays(14).ToString("d")+" - "+FirstDate.AddDays(21).ToString("d") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Týden 4.", Description=FirstDate.AddDays(21).ToString("d")+" - "+FirstDate.AddDays(28).ToString("d")},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Týden 5.", Description=FirstDate.AddDays(28).ToString("d")+" - "+FirstDate.AddDays(35).ToString("d") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Týden 6.", Description=FirstDate.AddDays(35).ToString("d")+" - "+FirstDate.AddDays(42).ToString("d") }
            };
            SaveList();
        }
        

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            SaveList();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            Console.WriteLine("Item Edited");
            SaveList();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);
            SaveList();
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public void SaveList()
        {
            var json = JsonConvert.SerializeObject(items);
            File.WriteAllText(fileName, json);
        }
    }
}