using System;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Collision;

namespace The_Prison_Escape
{
    public class Circle : CircleCollider
    {
        public static Random r = new();

        public Circle(Vector2 pos) : base(new RayWrapper.Vars.Circle(pos, 10))
        {
            tag = "ball";
            removeWhenOutOfBounds = true;
            
            var phi = 2 * Math.PI * r.NextDouble();
            var vx = .25f * Math.Cos(phi);
            var vy = .25f * Math.Sin(phi);

            velocity = new Vector2((float) vx, (float) vy);
        }

        public override void RenderShape(Vector2 pos)
        {
            Raylib.BeginMode2D(Global.Global.camera);
            Raylib.DrawCircle((int) pos.X, (int) pos.Y, radius, Raylib.DARKBLUE.EditColor(a: -100));
            Raylib.EndMode2D();
        }
        
        // public override void FirstCollision(Collider c)
        // {
        //     if (c is not Circle) 
        //         return;
        //
        //     c.velocity = new Vector2();
        // }
        
    } 
}
