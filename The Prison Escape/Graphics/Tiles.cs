using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static The_Prison_Escape.Global.Global;

namespace The_Prison_Escape.Graphics
{
    public struct Tile
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        

        public Tile(int x, int y, string tileName = "")
        {
            name = tileName;
            this.x = x;
            this.y = y;
        }
    }
    public class Tiles : Node.Node
    {
        private readonly int tileId;
        public Tiles(int idTile, Rectangle rect) : base(rect)
        {
            tileId = idTile;

            if (IdWalls.Contains(tileId))
                tag = "wall";
            else if (IdBars.Contains(tileId))
                tag = "bars";
            else if (IdUnbreakable.Contains(tileId))
                tag = "unbreakable";
            else
                tag = "floor";
        }
        
        public override void RenderShape(Vector2 pos)
        {
            BeginMode2D(camera);
            
            DrawTextureRec(Textures.TilesTexture, 
                new Rectangle(TilesDict[tileId].x * CellSize, TilesDict[tileId].y * CellSize, 
                CellSize, CellSize),pos, WHITE);

            EndMode2D();
        }

    }
}