using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using static Raylib_CsLo.Raylib;
using static The_Prison_Escape.Global.Global;
using Rectangle = Raylib_CsLo.Rectangle;

namespace The_Prison_Escape.Graphics.Characters
{
    public class Player : Node.Node
    {
        private const float MoveSpeed = 1.52f;
        private Vector2 moveVector;

        private static double currentFrame;
        private static int numLastFrame = 2;

        private static Directions currentDir = Directions.Down;

        private enum Directions
        {
            Up,
            Left,
            Down,
            Right
        }

        public Player(Rectangle rect) : base(rect, Textures.PlayerTexture)
        {
            tag = "player";
        }

        public void Movement()
        {

            var keyUp = IsKeyDown(KeyboardKey.KEY_W) || IsKeyDown(KeyboardKey.KEY_UP);
            var keyLeft = IsKeyDown(KeyboardKey.KEY_A) || IsKeyDown(KeyboardKey.KEY_LEFT);
            var keyDown = IsKeyDown(KeyboardKey.KEY_S) || IsKeyDown(KeyboardKey.KEY_DOWN);
            var keyRight = IsKeyDown(KeyboardKey.KEY_D) || IsKeyDown(KeyboardKey.KEY_RIGHT);

            var hMove = (keyLeft ? -1 : 0) + (keyRight ? 1 : 0);
            var vMove = (keyUp ? -1 : 0) + (keyDown ? 1 : 0);

            Animate(keyUp, keyLeft, keyDown, keyRight);


            moveVector = new Vector2(hMove, vMove);

            if (moveVector.Length() > 1)
                moveVector = Vector2.Normalize(moveVector);

            var velocityPlayer = moveVector * MoveSpeed;

            var originPosition = Position;
            
            Position = new Vector2(Position.X + velocityPlayer.X, Position.Y + velocityPlayer.Y);
            rect = new Rectangle(Position.X, Position.Y, rect.width, rect.height);

            if (Collision())
            {
                Position = originPosition;
                rect = new Rectangle(Position.X, Position.Y, rect.width, rect.height);
            }
            
        }

        private static void Animate(bool keyUp, bool keyLeft, bool keyDown, bool keyRight)
        {
            currentFrame += 0.05;

            if (currentFrame < numLastFrame - 2 || currentFrame >= numLastFrame)
                currentFrame = numLastFrame - 2;

            if (keyUp)
                currentDir = Directions.Up;
            if (keyLeft)
                currentDir = Directions.Left;
            if (keyDown)
                currentDir = Directions.Down;
            if (keyRight)
                currentDir = Directions.Right;

            numLastFrame = currentDir switch
            {
                Directions.Down => 2,
                Directions.Up => 4,
                Directions.Left => 6,
                Directions.Right => 8,
                _ => numLastFrame
            };
        }

        private bool Collision()
        {
            var tempNodes = nodes.Where(el =>
                el.rect.IsColliding(rect) &&
                el.tag is "wall" or "bars");

            var enumerableNodes = tempNodes.ToList();
            
            return enumerableNodes.Count != 0;

        }
    
    public override void RenderShape(Vector2 pos)
        {
            BeginMode2D(camera);
            
            DrawTextureRec(Textures.PlayerTexture, 
                new Rectangle(16*(int)currentFrame, 16, 16, 16),pos, WHITE);

            EndMode2D();
        }
    }
}