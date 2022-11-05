using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TShockAPI;
using TShockAPI.Hooks;

namespace VeinMiner
{
    public class Config
    {
        public static void Load(ReloadEventArgs args = null)
        {
            try
            {
                if (!File.Exists(Path.Combine(TShock.SavePath, "VeinMiner.json"))) FileTools.CreateIfNot(Path.Combine(TShock.SavePath, "VeinMiner.json"), JsonConvert.SerializeObject(VeinMiner.Config, Formatting.Indented));
                VeinMiner.Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(TShock.SavePath, "VeinMiner.json")));
                if (args != null) TShock.Log.ConsoleInfo($"<VeinMiner> Config reloaded.");
            }
            catch (Exception ex) { TShock.Log.Error(ex.Message); TShock.Log.ConsoleError("<VeinMiner> Failed to read config file."); }
        }
        public bool Enable = true;
        public bool Broadcast = true;
        public bool PutInInventory = true;
        public List<int> Tile = new() { 7, 166, 6, 167, 9, 168, 8, 169, 37, 22, 204, 56, 58, 107, 221, 108, 222, 111, 223, 211, 408, 123, 224, 404, 178, 63, 64, 65, 66, 67, 68 };
        public List<Exchange> Exchange = new()
        {
            new()
            {
                OnlyGiveItem = true,
                MinSize = 10,
                Type = 169,
                Item = new() { { 953, 1 }, { 2425, 5 } }
            }
        };
    }
    public struct Exchange
    {
        public bool OnlyGiveItem;
        public int MinSize;
        public int Type;
        public Dictionary<int, int> Item;
    }
}
