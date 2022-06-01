using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Raylib_CsLo;
using The_Prison_Escape.Graphics;
using The_Prison_Escape.Graphics.Characters;
using The_Prison_Escape.Graphics.Items;

namespace The_Prison_Escape.Global
{
    public class Global
    {
        public static Camera2D camera = new();
        public static List<Node.Node> nodes = new();
        public static List<Items> items = new();
        public static Player player;
        public static Inventory inventory;
        public static int CellSize => 16;
        public static int ItemSize => 16;

        public static readonly Dictionary<int, Tile> TilesDict = 
            JsonConvert.DeserializeObject<Dictionary<int, Tile>>(File.ReadAllText("assets/tiles.json"));
        
        public static readonly Dictionary<int, Item> ItemsDict = 
            JsonConvert.DeserializeObject<Dictionary<int, Item>>(File.ReadAllText("assets/items.json"));
        
        public static readonly int[] IdWalls = {4,8,12,16,17,20,21,25,28,29,31,32,33,36,37,40,
            41,45,49,52,53,56,57,60,64};

        public static readonly int[] IdBars = { 60,64,77,81,85,89,93,97};
        
        public static readonly int[] IdUnbreakable = {6,7,11,15,19,23,24,26,30,34,38,42,46,50,
            54,58,68,79,83,87,90,91,95};

        public static readonly int[] IdItemsCanBreakWall = { 9 };
    }
}