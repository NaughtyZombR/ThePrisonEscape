using System.Numerics;
using The_Prison_Escape.Physics;
using static Raylib_CsLo.Raylib;
using static RayWrapper.GameBox;
using static The_Prison_Escape.Global.Global;
using Rectangle = Raylib_CsLo.Rectangle;

namespace The_Prison_Escape.Graphics.Items
{
    public class InventoryCells : RectCollider
    {
        private double currentFrame;
        internal bool isPressed = false;
        private Rectangle rectangle;

        public Items item;
        internal bool hasItem = false;
        
        public InventoryCells(Rectangle rect, Items item = null) : base(rect)
        {
            rectangle = rect;
            this.item = item;
        }

        public override void RenderShape(Vector2 pos)
        {
            rect = new Rectangle(camera.target.X + 115, camera.target.Y + 1 + rectangle.Y * 0.65f - 72,
                rectangle.width/1.65f, rectangle.height/1.65f);
            
            if (isPressed)
            {
                if (currentFrame is < 1 or >= 3)
                    currentFrame = 1;
                
                currentFrame += 0.03;
            }
            else
                currentFrame = 0;

            DrawTexturePro(Textures.GuiInventoryTexture, 
                new Rectangle(rectangle.X * (int)currentFrame, rectangle.Y, rectangle.width, rectangle.height),
                new Rectangle(WindowSize.X-rectangle.width*3, rectangle.Y * 3.3f, 
                    rectangle.width*3, rectangle.height*3), Vector2.Zero, 0, WHITE);
            
           
            item?.RenderShape(Vector2.Zero);
        }
    }
    
}