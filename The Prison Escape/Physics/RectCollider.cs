using System.Numerics;
using Raylib_CsLo;
using RayWrapper;

namespace The_Prison_Escape.Physics
{
    public abstract class RectCollider : Collider
    {
        public override Vector2 Size => rect.Size();

        public Rectangle rect;
        
        public RectCollider(Rectangle rect) : base(rect.Pos()) => this.rect = rect;

        public static implicit operator Rectangle(RectCollider rc) => rc.rect.Clone();
    }
}