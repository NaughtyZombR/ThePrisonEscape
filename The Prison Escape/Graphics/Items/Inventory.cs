using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using static Raylib_CsLo.Raylib;
using Rectangle = Raylib_CsLo.Rectangle;

namespace The_Prison_Escape.Graphics.Items
{
    public class Inventory
    {
        public List<InventoryCells> inventoryList = new();

        public Inventory()
        {
            for (var seqNumButton = 0; seqNumButton < 6; seqNumButton++)
                inventoryList.Add(new InventoryCells(new Rectangle(22, 22 * seqNumButton, 22, 22)));
        }

        public void Update()
        {
            void SwitchCellPressed(int indexCell)
            {
                if (!inventoryList.Any(c => c.isPressed) || inventoryList[indexCell].isPressed)
                    inventoryList[indexCell].isPressed = !inventoryList[indexCell].isPressed;
            }
            
            switch (GetKeyPressed())
            {
                case (int)KeyboardKey.KEY_ONE:
                    SwitchCellPressed(0);
                    break;
                
                case (int)KeyboardKey.KEY_TWO:
                    SwitchCellPressed(1);
                    break;
                
                case (int)KeyboardKey.KEY_THREE:
                    SwitchCellPressed(2);
                    break;
                
                case (int)KeyboardKey.KEY_FOUR:
                    SwitchCellPressed(3);
                    break;
                
                case (int)KeyboardKey.KEY_FIVE:
                    SwitchCellPressed(4);
                    break;
                
                case (int)KeyboardKey.KEY_SIX:
                    SwitchCellPressed(5);
                    break;
            }
            
            foreach (var cell in inventoryList)
            {
                if (cell.rect.IsMouseIn() && IsMouseButtonPressed(MOUSE_LEFT_BUTTON))
                    SwitchCellPressed(inventoryList.IndexOf(cell));

                cell.RenderShape(Vector2.Zero);
                
                if (cell.rect.IsMouseIn() && cell.hasItem && IsMouseButtonPressed(MOUSE_RIGHT_BUTTON)) 
                    cell.item.PutItemOnGround();
                
                if (cell.isPressed && cell.hasItem)
                    cell.item.UseItem();
            }
        }
    }
}