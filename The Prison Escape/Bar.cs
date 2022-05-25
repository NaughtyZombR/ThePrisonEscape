using System;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Collision;
using RayWrapper.Vars;
using static Raylib_CsLo.Raylib;
using The_Prison_Escape.Graphics;

namespace The_Prison_Escape
{
    public class Bar : RectCollider
    {
        public bool vert;
        public Bar(Vector2 pos, Vector2 size) : base(RectWrapper.AssembleRectFromVec(pos, size))
        {
            tag = "bar";
        }

        public override void RenderShape(Vector2 pos)
        {
            //rect.NewMoveTo(pos).Draw(GRAY);
            
            DrawTexturePro(Textures.PlayerTexture, rect, rect.NewMoveTo(pos), new Vector2(), 0, WHITE);
        }

        public override void FirstCollision(Collider c)
        {
            if (c is not Circle) 
                return;

            if (vert)
            {
                c.velocity.X = -c.velocity.X;
            }
            else 
                c.velocity.Y = -c.velocity.Y;
        }

    }
}