using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using The_Prison_Escape.Graphics.Characters;
using static The_Prison_Escape.Global.Global;
using Rectangle = Raylib_CsLo.Rectangle;

namespace The_Prison_Escape.Graphics;

public static class Map
{
    public static List<Node.Node> GenerateGameWorld(string dataFilePath)
    {
        const int CellSize = 16;
        const int CellPlayer = 9999;
        const int CellEmpty = 0;

        var result = new List<Node.Node>();

        var ground = new Node.Node(new Rectangle(-300, -300, 1500, 1500), Textures.GroundTexture);
        result.Add(ground);
            
        try
        {
            var file = new StreamReader(dataFilePath);
                
            var line = file.ReadLine();
            if (line == null)
            {
                Console.WriteLine("Error: the first line of the file is empty");
                return null;
            }
                
            var currentY = 0;
            while (line != null)
            {
                var currentLine = line.Split("_");
                    
                for (var currentX = 0; currentX < currentLine.Length; ++currentX)
                {
                    var currentCell = Convert.ToInt32(currentLine[currentX]);
                    var currentPos = new Vector2(currentX * CellSize, currentY * CellSize);

                    switch (currentCell)
                    {
                        case CellPlayer:
                        {
                            player = new Player(new Rectangle(currentPos.X,currentPos.Y,
                                CellSize, CellSize));
                            
                            result.Add(player);
                            break;
                        }

                        case CellEmpty:
                            break;

                        default:
                        {
                            var obj = new Tiles(currentCell, new Rectangle(currentPos.X, currentPos.Y, 
                                CellSize, CellSize));

                            result.Add(obj);
                            break;
                        }
                    }
                }

                ++currentY;
                line = file.ReadLine();
            }
            
            file.Close();
            file.Dispose();

        } catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return result;

    }
        
        
}