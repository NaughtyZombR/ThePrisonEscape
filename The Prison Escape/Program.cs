// using System;
// using System.IO;
// using System.Numerics;
// using Raylib_cs;
// using The_Prison_Escape.Global;
// using RayWrapper;

using System.Collections.Generic;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Objs;
using RayWrapper.Vars;
using The_Prison_Escape.Graphics.UI;
using The_Prison_Escape.Node;
using static Raylib_CsLo.Raylib;
using static RayWrapper.Collision.Collision;
using static RayWrapper.GameBox;


namespace The_Prison_Escape
{
    internal static class Program
    {
        
        private static void Main()
        {
            
            SceneManager.AddScene("Level",new Level());
            SceneManager.AddScene("LevelWithBalls",new LevelWithBalls());
            
            new GameBox(SceneManager.Scenes["Level"], new Vector2(1280, 720),
                "The Prison Escape", 60);
        }

        // public override void Init()
        // {
        //     InitPhysics(8, 8);
        //     var wx = WindowSize.X;
        //     var wy = WindowSize.Y;
        //
        //     collisionRules.TryAdd("bar", "ball");
        //
        //     sd = new Bar(new Vector2(0, 0), new Vector2(wx, 16));
        //     // new Bar(new Vector2(0, wy-16), new Vector2(wx, 16));
        //     // new Bar(new Vector2(0, 0), new Vector2(16, wy)) { vert = true };
        //     // new Bar(new Vector2(wx-16, 0), new Vector2(16, wy)) { vert = true };
        //     // new Bar(new Vector2(400), new Vector2(600, 1));
        //
        //     RegisterGameObj(new Text(new Actionable<string>(() => $"{CountColliders() - 4}"), 
        //             new Vector2(12, 60), RED), new Text(new Actionable<string>(() => $@"Collision Time
        //             cur: {CurrentCollision}ms
        //             avg: {TimeAverage}ms
        //             high: {CollisionHigh}ms".Replace("\r", "")), new Vector2(300, 50), SKYBLUE));
        // }
        //
        // public override void UpdateLoop()
        // {
        //     
        //     // if(sd.rect.IsMouseIn() && IsMouseButtonPressed(MOUSE_RIGHT_BUTTON))
        //     //     sd.DestoryObject();
        //     
        //     if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        //     {
        //         for (var i = 0; i < 100; i++) new Circle(mousePos);
        //     }
        // }
        //
        // public override void RenderLoop() => DrawFPS(12, 12);
        //

    
    // static class Program
    // {
    //     public static void Main()
    //     {
    //         var screenWidth = 800;
    //         var screenHeight = 450;
    //         Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
    //         Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
    //         Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE); // Window configuration flags
    //         Raylib.InitWindow(screenWidth, screenHeight, "The Prison Escape");
    //
    //         var target = Raylib.LoadRenderTexture(screenWidth, screenHeight);
    //
    //
    //         var camera = new Camera2D
    //         {
    //             target = new Vector2(screenWidth, screenHeight),
    //             offset = new Vector2(0, 0),
    //             rotation = 0.0f,
    //             zoom = 1.0f
    //         };
    //
    //
    //         var background = Raylib.LoadTexture("assets/MainMenu/theme.png");
    //
    //         Raylib.SetTargetFPS(60);
    //
    //         while (!Raylib.WindowShouldClose())
    //         {
    //             screenHeight = Raylib.GetScreenHeight();
    //             screenWidth = Raylib.GetScreenWidth();
    //
    //             Raylib.BeginDrawing();
    //
    //             Raylib.BeginTextureMode(target);
    //
    //
    //             Raylib.ClearBackground(Color.WHITE);
    //
    //             Raylib.DrawTexturePro(background,
    //                 new Rectangle(0, 0, background.width, background.height),
    //                 new Rectangle(0, 0, screenWidth, screenHeight),
    //                 new Vector2(),
    //                 0,
    //                 Color.WHITE);
    //
    //             Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
    //
    //
    //            
    //
    //             Raylib.EndTextureMode();
    //
    //
    //             Raylib.DrawTexturePro(target.texture,
    //                 new Rectangle(0, 0, 800, -480),
    //                 new Rectangle(0, 0, screenWidth, screenHeight),
    //                 new Vector2(),
    //                 0.0f,
    //                 Color.WHITE);
    //
    //             Raylib.EndDrawing();
    //         }
    //
    //         Raylib.CloseWindow();
    //     }
        
        // private static void generate_game_world(string dataFilePath)
        // {
        //     const int	CellSize = 64;
        //     const char	CellWall = 'W';
        //     const char	CellTank = 'T';
        //
        //     try
        //     {
        //         var file = new StreamReader(dataFilePath);
        //
        //         int world_width;
        //
        //         var line = file.ReadLine();
        //         if (line != null)
        //             world_width = line.Length;  //The width of the world is the length of the first line
        //         else
        //         {
        //             Console.WriteLine("Error: the first line of the file is empty");
        //             return;
        //         }
        //
        //         int current_y = 0;
        //         while (line != null)
        //         {
        //             for (int current_x = 0; current_x < line.Length; ++current_x)
        //             {
        //                 char current_cell = line[current_x];
        //                 Vector2 current_pos = new Vector2(current_x * CellSize + CellSize / 2, current_y * CellSize + CellSize / 2);
        //
        //                 if (current_cell == CellWall)
        //                 {
        //                     PhysicsNode node = new PhysicsNode(root);
        //                     node.set_texture(Graphics.texture_wall);
        //                     node.set_position(current_pos);
        //
        //                     //Add to collision manager
        //                     physics_nodes.Add(node);
        //                 }
        //                 if (current_cell == CellTank)
        //                 {
        //                     var tank = new Tank(root);
        //                     tank.set_position(current_pos);
        //                     Console.WriteLine("\n\nTank was created at: \n" + current_pos);
        //                     //Add to collision manager
        //                     physics_nodes.Add(tank);
        //                 }
        //             }
        //
        //             ++current_y;
        //             line = file.ReadLine();
        //         }
        //
        //         //add nodes to collision_manager
        //         foreach (PhysicsNode node in physics_nodes)
        //         {
        //             collision_manager.add_node(node);
        //         }
        //
        //         file.Close();
        //         file.Dispose();
        //
        //     } catch(Exception e)
        //     {
        //         Console.WriteLine("Exception: " + e.Message);
        //     }
			     //
        // }
        
    }
}
