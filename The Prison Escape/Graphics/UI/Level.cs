using System.Numerics;
using Raylib_CsLo;
using RayWrapper.Vars;
using The_Prison_Escape.Graphics.Items;
using static Raylib_CsLo.Raylib;
using static RayWrapper.GameBox;
using Rectangle = Raylib_CsLo.Rectangle;

using static The_Prison_Escape.Global.Global;

namespace The_Prison_Escape.Graphics.UI
{
    public class Level : GameLoop
    {
        public override void Init()
        {
            SetWindowIcon(LoadImage("assets/Graphics/Icon.png"));
            
            camera = new Camera2D
            {
                offset = new Vector2(WindowSize.X / 2.0f, WindowSize.Y / 2.0f),
                rotation = 0.0f,
                zoom = 5.0f
            };
            
            nodes = Map.GenerateGameWorld("assets/Worlds/created_level.txt");

            inventory = new Inventory();
            
            items.Add(new Items.Items(1,new Rectangle(player.Position.X + 40, player.Position.Y, 
                16, 16)));
            items.Add(new Items.Items(9,new Rectangle(player.Position.X + 80, player.Position.Y, 
                16, 16)));
        }

        public override void UpdateLoop()
        {
            mousePos = GetScreenToWorld2D(mousePos, camera);
            camera.target = new Vector2(player.Position.X + 20.0f, player.Position.Y + 20.0f);
            
            player.Movement();
        }

        public override void RenderLoop()
        {
            DrawFPS(12, 12);
            
            nodes.ForEach(el => el.RenderShape(el.Position));
            items.ForEach(el => el.RenderShape(el.Position));

            
            DrawTexturePro(Textures.GuiTexture, 
                new Rectangle(0,0, Textures.GuiTexture.Size.X,Textures.GuiTexture.Size.Y),
                new Rectangle(0,0, WindowSize.X,WindowSize.Y), Vector2.Zero, 0,WHITE);
            
            DrawTextureEx(Textures.GuiButtonsImageTexture, 
                new Vector2(WindowSize.X - Textures.GuiButtonsImageTexture.Size.X * 3 - 1, 
                    WindowSize.Y - Textures.GuiButtonsImageTexture.Size.Y * 3 - 1), 0, 3, WHITE);

            inventory.Update();
            player.RenderShape(player.Position);
        }
    }

}