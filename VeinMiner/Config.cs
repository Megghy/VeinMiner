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
            catch (Exception ex) { TShock.Log.Error(ex.Message); TShock.Log.ConsoleError("<VeinMiner> Failed to read VeinMiner.json"); }
        }
        public bool Enable = true;
        public bool Broadcast = true;
        public bool PutInInventory = true;
        public List<int> Tile = new() { 12, 699, 11, 700, 14, 701, 13, 702, 116, 56, 880, 173, 174, 364, 1104, 365, 1105, 366, 1106, 947, 3460, 123, 224, 404 };
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
