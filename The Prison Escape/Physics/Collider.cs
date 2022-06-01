using System.Collections.Generic;
using System.Numerics;
using RayWrapper.Vars;

namespace The_Prison_Escape.Physics
{
    public abstract class Collider : GameObject
    {
        public override Vector2 Position
        {
            get => pos;
            set => pos = value;
        }

        public static long id;
        public Vector2 velocity = Vector2.Zero;

        public long currentId;
        public string tag = "def";

        public bool removeWhenOutOfBounds = false;

        public Vector2 pos;
        private readonly List<Collider> buffer = new();
        private readonly List<Collider> backBuffer = new();

        protected Collider(Vector2 pos)
        {
            (this.pos, currentId) = (pos, id);
            id++;
        }

        protected override void UpdateCall()
        {
        }

        protected override void RenderCall() => RenderShape(Position);
        public abstract void RenderShape(Vector2 pos);

        public void Dispose()
        {
        }

        public void DestoryObject()
        {
            Dispose();
        }

        ~Collider() => DestoryObject();
    }
}