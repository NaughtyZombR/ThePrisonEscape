using Raylib_CsLo;
using RayWrapper;

namespace The_Prison_Escape.Global1
{
    public class Graphics1
    {
        // paths to textures //

        public static string player = "assets/Player/player.png";
        public static string wall = "assets/sprWall.png";
        // public static string empty_grid = "assets/sprEmptyGrid.png";

        // pre loaded textures //

        public static Texture texPlayer = get_texture_from_path(player);
        public static Texture texWall = get_texture_from_path(wall);
        // public static Texture texEmpty = get_texture_from_path(empty_grid);

        // create a texture based on path and return it //

        public static Texture get_texture_from_path(string path)
        {
            var image = Raylib.LoadImage(path);
            var result = Raylib.LoadTextureFromImage(image);
            
            Raylib.UnloadImage(image);

            return result;
        }
    }
}