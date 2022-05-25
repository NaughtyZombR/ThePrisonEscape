using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Objs;
using RayWrapper.Objs.TreeView.TreeNodeChain.NodeShapes;
using RayWrapper.Vars;
using The_Prison_Escape.Graphics.Characters;
using The_Prison_Escape.Graphics.UI;
using The_Prison_Escape.Node;
using static Raylib_CsLo.Raylib;
using static RayWrapper.Collision.Collision;
using static RayWrapper.GameBox;

using static The_Prison_Escape.Global.Global;

namespace The_Prison_Escape.Graphics.UI
{
    public class Level : GameLoop
    {
        private IEnumerable<Node.Node> walls;

        public override void Init()
        {
            InitPhysics(8, 8);

            //collisionRules.TryAdd("wall", "ball");
            collisionRules.TryAdd("wall", "player");
            
            
            camera = new Camera2D
            {
                offset = new Vector2(WindowSize.X / 2.0f, WindowSize.Y / 2.0f),
                rotation = 0.0f,
                zoom = 5.0f
            };
            
            
            nodes = Map.GenerateGameWorld("../Worlds/created_level.txt");
            



            walls = nodes.Where(e => e.tag == "wall");
            //walls.Select(e => e.FirstCollision())

            //new Bar(new Vector2(0, 0), new Vector2(150, 16));
            //new Bar(new Vector2(0, wy-16), new Vector2(wx, 16));
            //new Bar(new Vector2(400), new Vector2(600, 16));


            // var b = new Button(new Vector2(300, 300), "HELLO!!!");
            // b.Clicked += () => Global.Global.game.changeMode(Game.Modes.LevelWithBalls);


            RegisterGameObj(new Text(new Actionable<string>(() => $"{CountColliders()}"),
                new Vector2(12, 60), RED), new Text(new Actionable<string>(() => $@"Collisi1on Time
                    cur: {CurrentCollision}ms
                    avg: {TimeAverage}ms
                    high: {CollisionHigh}ms
                    mousePos: {mousePos}
                    playerVelocity : {player.velocity}
                    playerPos: {player.Position}
                    playerRect: {player.rect.x + " " + player.rect.y}"
                    .Replace("\r", "")), new Vector2(400, 50), DARKBLUE));
        }

        public override void UpdateLoop()
        {
            mousePos = GetScreenToWorld2D(mousePos, camera); //Координаты мыши в координаты мира
            
            
            camera.target = new Vector2(player.Position.X + 20.0f, player.Position.Y + 20.0f);
            

            var destr = walls
                .Where(w => w.tag == "wall" && w.rect.IsMouseIn() && IsMouseButtonPressed(MOUSE_RIGHT_BUTTON));

            foreach (var wall in destr)
            {
                wall.DestoryObject();
            }


            // if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            // {
            //     for (var i = 0; i < 1; i++)
            //         new Circle(mousePos);
            // }

            
            player.Movement();

        }

        public override void RenderLoop()
        {
            DrawFPS(12, 12);
        }
    }

}