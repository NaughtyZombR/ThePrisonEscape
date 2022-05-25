using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Collision;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Collision;
using static Raylib_CsLo.Raylib;
using RayWrapper.Objs;
using The_Prison_Escape.Graphics.Characters;
using static The_Prison_Escape.Global.Global;

namespace The_Prison_Escape.Node
{ 
    // ------------------------- //
    // Base of every game object //
    // ------------------------- //

    public class Node : RectCollider
    {
        // -- // -- // -- // -- //
        //FIELDS
        // -- // -- // -- // -- //

        private Texture texture;

        // -- // -- // -- // -- //
        //CONSTRUCTORS
        // -- // -- // -- // -- //
        
        public Node(Vector2 pos, Vector2 size, Texture texture) : base(RectWrapper.AssembleRectFromVec(pos, size))
        {
            this.texture = texture;
        }
        
        public Node(Rectangle rect, Texture texture) : base(rect)
        {
            this.texture = texture;
        }
        
        public Node(Rectangle rect) : base(rect)
        {
        }
        
        
        
        // -- // -- // -- // -- // -- //
        //PUBLIC METHODS
        // -- // -- // -- // -- // -- //

        public void SetTexture(Texture tex)
        {
            this.texture = tex;
        }
        
        public void SetPosition(Vector2 vec)
        {
            Position = vec;
            rect = new Rectangle(vec.X, vec.Y, rect.width, rect.height);
        }

        public override void RenderShape(Vector2 pos)
        {
            BeginMode2D(Global.Global.camera);
            //DrawTextureRec(texture, rect, pos, WHITE);
            DrawTexture(texture, (int)pos.X, (int)pos.Y, WHITE);
            EndMode2D();
            //DrawTexturePro(texture, rect, rect.NewMoveTo(pos), new Vector2(), 0, WHITE);
        }
        
        // public override void FirstCollision(Collider c)
        // {
        //     if (c is not Player) 
        //         return;
        //     
        //     c.velocity.Y = -c.velocity.Y;
        // }
    }
}