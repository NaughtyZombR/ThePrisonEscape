using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using Raylib_CsLo.InternalHelpers;
using RayWrapper;
using RayWrapper.Collision;
using RayWrapper.Objs;
using RayWrapper.Vars;
using The_Prison_Escape.Graphics.Characters;
using The_Prison_Escape.Graphics.UI;
using The_Prison_Escape.Node;
using static Raylib_CsLo.Raylib;
using static RayWrapper.Collision.Collision;
using static RayWrapper.GameBox;

namespace The_Prison_Escape.Graphics.Characters
{
    public class Player : Node.Node
    {
        public static float moveSpeed = 1.52f;
        private Vector2 moveVector;

        private static double currentFrame;
        private static int numLastFrame = 2;

        private static Directions currentDir = Directions.Down;
        // private int moveIndicatorX;
        // private int moveIndicatorY;

        private Player player;
        
        public enum Directions
        {
            Up,
            Left,
            Down,
            Right
        }
        //
        // public Dictionary<Directions, bool> DirOfCollisions = new Dictionary<Directions, bool>()
        // {
        //     {Directions.Up, false},
        //     {Directions.Left, false},
        //     {Directions.Down, false},
        //     {Directions.Right, false}
        // };


        
        
        
        public Player(Rectangle rect) : base(rect, Textures.PlayerTexture)
        {
            tag = "player";
            //texture = Global1.Graphics1.texPlayer;
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
            
            //velocity = moveVector * moveSpeed;
            Position = new Vector2(Position.X + moveVector.X * moveSpeed, Position.Y + moveVector.Y * moveSpeed);
            rect = new Rectangle(Position.X, Position.Y, rect.width, rect.height);

            
            Collision();


            //Console.WriteLine((velocity.X) + " " + velocity.Y);


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

        private void Collision()
        {
            void StopMove(RectCollider collider, Directions dir, bool isGreaterZero)
            {
                var temp = isGreaterZero ? -1 : 1;

                switch (dir)
                {
                    case Directions.Left or Directions.Right:
                        Position = new Vector2(collider.Position.X + collider.rect.width * temp, Position.Y);
                        rect = new Rectangle(collider.Position.X + collider.rect.width * temp, Position.Y, rect.width,
                            rect.height);
                        break;
                    
                    case Directions.Up or Directions.Down:
                        Position = new Vector2(Position.X, collider.rect.y + collider.rect.height * temp);
                        rect = new Rectangle(Position.X, collider.rect.y + collider.rect.height * temp, rect.width, 
                            rect.height);
                        break;
                }
            }
            
            for (var i = (int)rect.X/16 * 16; i < (rect.x + rect.width)/16 * 16; i+=16)
            for (var j = (int)rect.Y/16 * 16; j < (rect.y + rect.height)/16 * 16; j+=16)
            {
                float[,,] arr;
                var node = Global.Global.nodes.Where(e => e.Position.X == i && 
                                                          e.Position.Y == j && e.tag == "wall");
                
                
                
                
                
                
                foreach (var n in node)
                {
                    switch (moveVector.X)
                    {
                        case > 0:
                            StopMove(n, Directions.Left, true);
                            break;
                        case < 0:
                            StopMove(n, Directions.Right, false);
                            break;
                    }

                    switch (moveVector.Y)
                    {
                        case > 0:
                            StopMove(n, Directions.Down, true);
                            break;
                        case < 0:
                            StopMove(n, Directions.Up, false);
                            break;
                    }
                    
                    
                    moveVector = Vector2.Zero;
                }
            
            }
        }

        public override void InCollision(Collider c)
        {
            if (c is Node.Node && c.tag == "wall") 
            {
                
            } 
        }
        
        // public override void ExitCollision(Collider c)
        // {
        //     if (c is Node.Node)
        //     {
        //     }
        // }
        //
        
        public override void RenderShape(Vector2 pos)
        {
            BeginMode2D(Global.Global.camera);
            
            DrawTextureRec(Textures.PlayerTexture, new Rectangle(16*(int)currentFrame, 16, 16, 16),pos, WHITE);

            EndMode2D();
        }
    }
}