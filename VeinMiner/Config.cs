using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
                FileTools.CreateIfNot(Path.Combine(TShock.SavePath, "VeinMiner.json"), JsonConvert.SerializeObject(new Config()
                {
                    Exchange = new()
                    {
                        new()
                        {
                            OnlyGiveItem = true,
                            MinSize = 10,
                            Type = 169,
                            Item = new() { { 953, 1 }, { 2425, 5 } }
                        }
                    },
                    Tile = new() { 7, 166, 6, 167, 9, 168, 8, 169, 37, 22, 204, 56, 58, 107, 221, 108, 222, 111, 223, 211, 408, 123, 224, 404, 178, 63, 64, 65, 66, 67, 68 }
                }, Formatting.Indented));

                VeinMiner.Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(TShock.SavePath, "VeinMiner.json")));
                if (args != null)
                    TShock.Log.ConsoleInfo($"<VeinMiner> Config reloaded.");
            }
            catch (Exception ex) { TShock.Log.Error(ex.Message); TShock.Log.ConsoleError("<VeinMiner> Failed to read config file."); }
        }
        public bool Enable { get; set; } = true;
        public bool Broadcast { get; set; } = true;
        public bool PutInInventory { get; set; } = true;
        public List<int> Tile { get; set; } = new();
        public List<Exchange> Exchange { get; set; } = new();
    }
    public struct Exchange
    {
        public bool OnlyGiveItem;
        public int MinSize;
        public int Type;
        public Dictionary<int, int> Item;
    }
}
