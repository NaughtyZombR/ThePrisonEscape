using System.Numerics;
using Raylib_CsLo;
using The_Prison_Escape.Physics;
using static Raylib_CsLo.Raylib;
using static The_Prison_Escape.Global.Global;

namespace The_Prison_Escape.Node
{ 
    public class Node : RectCollider
    {

        private readonly Texture texture;

        public Node(Rectangle rect, Texture texture) : base(rect)
        {
            this.texture = texture;
        }

        protected Node(Rectangle rect) : base(rect)
        {
        }

        public override void RenderShape(Vector2 pos)
        {
            BeginMode2D(camera);
            DrawTexture(texture, (int)pos.X, (int)pos.Y, WHITE);
            EndMode2D();
        }
    }
}