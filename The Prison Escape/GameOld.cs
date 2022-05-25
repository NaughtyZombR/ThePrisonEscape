using System.Numerics;
using Raylib_CsLo;
namespace The_Prison_Escape
{
    public class GameOld
    {
        public static void Run()
        {
            var screenWidth = 800;
            var screenHeight = 450;
            Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE); // Window configuration flags
            Raylib.InitWindow(screenWidth, screenHeight, "The Prison Escape");

            var target = Raylib.LoadRenderTexture(screenWidth, screenHeight);


            var camera = new Camera2D
            {
                target = new Vector2(screenWidth, screenHeight),
                offset = new Vector2(0, 0),
                rotation = 0.0f,
                zoom = 1.0f
            };


            var background = Raylib.LoadTexture("assets/MainMenu/theme.png");

            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                screenHeight = Raylib.GetScreenHeight();
                screenWidth = Raylib.GetScreenWidth();

                Raylib.BeginDrawing();

                Raylib.BeginTextureMode(target);


                Raylib.ClearBackground(Raylib.WHITE);

                Raylib.DrawTexturePro(background,
                    new Rectangle(0, 0, background.width, background.height),
                    new Rectangle(0, 0, screenWidth, screenHeight),
                    new Vector2(),
                    0,
                    Raylib.WHITE);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Raylib.BLACK);




                Raylib.EndTextureMode();


                Raylib.DrawTexturePro(target.texture,
                    new Rectangle(0, 0, 800, -480),
                    new Rectangle(0, 0, screenWidth, screenHeight),
                    new Vector2(),
                    0.0f, new Color(255,255,255, 0));

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}