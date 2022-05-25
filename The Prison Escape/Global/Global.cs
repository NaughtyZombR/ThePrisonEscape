using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;
using Raylib_CsLo;
using The_Prison_Escape.Graphics;
using The_Prison_Escape.Graphics.Characters;

namespace The_Prison_Escape.Global
{
    public class Global
    {
        public static Game game = null;
        public static Camera2D camera = new();
        public static List<Node.Node> nodes = new();
        public static Player player;
        public static int CellSize => 16;

        public static readonly Dictionary<int, Tile> TilesDict = 
            JsonConvert.DeserializeObject<Dictionary<int, Tile>>(File.ReadAllText("assets/tiles.json"));
        
        public static readonly int[] IdWalls = {4,8,12,16,17,20,21,23,25,28,29,31,32,33,36,37,40,
            41,45,49,52,53,56,57,60,64,77,81,85,89,93,97};
        public static readonly int[] IdUnbreakable = {1,2,3,4};
    }
}