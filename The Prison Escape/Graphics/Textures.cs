using System.Data;
using System.Net;
using Raylib_CsLo;
using RayWrapper.Objs;

namespace The_Prison_Escape.Graphics
{
    public static class Textures
    {
         private static readonly ImageObj playerImage = new("assets/Player/PlayerMovement.png");
         private static readonly ImageObj groundImage = new("assets/Levels/ground.png");
         private static readonly ImageObj tilesImage = new("assets/Levels/tiles/tutorial.png");
         private static readonly ImageObj itemsImage = new("assets/Graphics/items/items.png");
         private static readonly ImageObj guiImage = new("assets/Graphics/GUI/GUI.png");
         private static readonly ImageObj guiInventoryImage = new("assets/Graphics/GUI/InventoryButtons.png");
         private static readonly ImageObj guiButtonsImage = new("assets/Graphics/GUI/Buttons.png");
         
         public static readonly TextureObj PlayerTexture = playerImage.texture;
         public static readonly TextureObj GroundTexture = groundImage.texture;
         public static readonly TextureObj TilesTexture = tilesImage.texture;
         public static readonly TextureObj ItemsTexture = itemsImage.texture;
         public static readonly TextureObj GuiTexture = guiImage.texture;
         public static readonly TextureObj GuiInventoryTexture = guiInventoryImage.texture;
         public static readonly TextureObj GuiButtonsImageTexture = guiButtonsImage.texture;


    }
}