using Raylib_CsLo;
using RayWrapper.Objs;

namespace The_Prison_Escape.Graphics
{
    public static class Textures
    {
        //Images
        private static readonly ImageObj playerImage = new("assets/Player/PlayerMovement.png");
        public static readonly ImageObj groundImage = new ("assets/Levels/ground.png");
        private static readonly ImageObj tilesImage = new ("assets/Levels/tiles/tutorial.png");


        // Textures
        public static readonly TextureObj PlayerTexture = playerImage.texture;
        public static readonly TextureObj groundTexture = groundImage.texture;
        public static readonly TextureObj tilesTexture = tilesImage.texture;
    }
}