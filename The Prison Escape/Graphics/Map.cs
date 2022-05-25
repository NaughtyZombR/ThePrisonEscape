using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;
using Raylib_CsLo;
using RayWrapper.Collision;
using RayWrapper.Objs;
using The_Prison_Escape.Global1;
using The_Prison_Escape.Graphics;
using The_Prison_Escape.Graphics.Characters;
using The_Prison_Escape.Node;
using static The_Prison_Escape.Global.Global;
using Rectangle = Raylib_CsLo.Rectangle;

namespace The_Prison_Escape
{
    public class Map
    {
        // public readonly Blocks[,] Level;
        // public readonly Point PlayerPosition;
        // // public readonly Point Exit;
        // // public readonly Point[] Chests;
        //
        // private Map(Blocks[,] level, Point playerPosition)
        // {
        //     Level = level;
        //     PlayerPosition = playerPosition;
        //     // Exit = exit;
        //     // Chests = chests;
        // }
		      //
        // public static Map GenerateGameWorld(string mapDataFilePath)
        // {
        //     
        //     return FromLines(lines);
        // }
        //
        // public static Map FromLines(string[] lines)
        // {
        //     var level = new Blocks[lines[0].Length, lines.Length];
        //     var playerPosition = Point.Empty;
        //     
        //     for (var y = 0; y < lines.Length; y++)
        //     {
        //         for (var x = 0; x < lines[0].Length; x++)
        //         {
        //             switch (lines[y][x])
        //             {
        //                 case 'P':
        //                     level[x, y] = Blocks.Player;
        //                     playerPosition = new Point(x, y);
        //                     break;
        //                 case 'W':
        //                     level[x, y] = Blocks.Wall;
        //                     break;
        //                 default:
        //                     continue;
        //             }
        //         }
        //     }
        //     return new Map(level, playerPosition);
        // }
        
        // public bool InBounds(Point point)
        // {
        //     var bounds = new Rectangle(0, 0, Level.GetLength(0), Level.GetLength(1));
        //     return bounds.Contains(point);
        // }
        
        
        // ---------------------------------------------------- //
        // generate game world based on the path to a text file //

        public static List<Node.Node> GenerateGameWorld(string dataFilePath)
        {
            const int CellSize = 16;
            const int CellPlayer = 9999;
            const int CellEmpty = 0;

            var ground = new Node.Node(new Rectangle(-300, -300, 1500, 1500), Textures.groundTexture);

            
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
                                player = new Player(new Rectangle(currentPos.X,currentPos.Y,CellSize, CellSize));
                                player.tag = "player";
                                nodes.Add(player);
                                //player.set_position(currentPos);
                                Console.WriteLine("\n\nPlayer was created at: \n" + currentPos);
                                //Add to collision manager
                                //physics_nodes.Add(player);
                                break;
                            }

                            case CellEmpty:
                                break;

                            default:
                            {
                                // var currentTexture = Textures.tilesTexture;
                                // currentTexture.SetSize(new Vector2(16,16));
                                var obj = new Tiles(currentCell, new Rectangle(currentPos.X, currentPos.Y, CellSize, CellSize));
                                
                                //var node = new Node.Node(new Rectangle(currentPos.X,currentPos.Y,CellSize, CellSize), currentTexture);
                            
                            
                            
                                nodes.Add(obj);
                                break;
                            }
                        }
                    }

                    ++currentY;
                    line = file.ReadLine();
                }

                //add nodes to collision_manager
                // foreach (PhysicsNode node in physics_nodes)
                // {
                //     collision_manager.add_node(node);
                // }

                file.Close();
                file.Dispose();

            } catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return nodes;

        }
        
        
    }
}