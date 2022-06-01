using System.Linq;
using System.Numerics;
using RayWrapper;
using static Raylib_CsLo.Raylib;
using static RayWrapper.GameBox;
using static The_Prison_Escape.Graphics.Textures;
using static The_Prison_Escape.Global.Global;
using Rectangle = Raylib_CsLo.Rectangle;

namespace The_Prison_Escape.Graphics.Items
{
    public struct Item
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        

        public Item(int x, int y, string itemName = "")
        {
            name = itemName;
            this.x = x;
            this.y = y;
        }
    }
    public class Items : Node.Node
    {
        public bool isInInvCells;
        private InventoryCells invCell;
        
        private readonly int itemId;

        public Items(int idItem, Rectangle rect) : base(rect)
        {
            itemId = idItem;
            nodes.Add(this);
        }

        public override void RenderShape(Vector2 pos)
        {
            if (rect.IsMouseIn() && (mousePos.X > player.Position.X - 16 &&
                                     mousePos.X < player.Position.X + 32 &&
                                     mousePos.Y > player.Position.Y - 16 &&
                                     mousePos.Y < player.Position.Y + 32)
                                 && IsMouseButtonPressed(MOUSE_RIGHT_BUTTON))
            {
                foreach (var cell in inventory.inventoryList.Where(cell => !cell.hasItem))
                {
                    rect = new Rectangle(0, 0, 0, 0);
                    Position = Vector2.Zero;
                    isInInvCells = true;
                    cell.hasItem = true;
                    cell.item = this;
                    invCell = cell;
                    break;
                }
            }
            
            if (isInInvCells)
            {
                DrawTexturePro(ItemsTexture, 
                    new Rectangle(ItemsDict[itemId].x * ItemSize, ItemsDict[itemId].y * ItemSize, 
                        ItemSize, ItemSize),
                    new Rectangle(WindowSize.X - 64, 4 + 72.5f * inventory.inventoryList.IndexOf(invCell),
                        64, 64), Vector2.Zero, 0, WHITE);
            }
            else
            {
                BeginMode2D(camera);
                DrawTextureRec(ItemsTexture, 
                    new Rectangle(ItemsDict[itemId].x * ItemSize, ItemsDict[itemId].y * ItemSize, 
                    ItemSize, ItemSize), 
                    new Vector2((int)Position.X, (int)Position.Y), WHITE);
                EndMode2D();
            }
        }

        public void PutItemOnGround()
        {
            if (items.Exists(x => x.rect.IsColliding(new Rectangle(player.Position.X, player.Position.Y, 16, 16))))
                return;

            rect = new Rectangle((int)player.Position.X / 16 * 16, (int)player.Position.Y / 16 * 16, 16, 16);
            Position = new Vector2(rect.X, rect.Y);
            isInInvCells = false;
            invCell.hasItem = false;
            invCell.item = null;
            invCell.isPressed = false;
            invCell = null;
        }

        public void UseItem()
        {
            var collisionRect = new Rectangle(player.Position.X - 8, player.Position.Y - 8, 32, 32);
            
            var tempNodes = nodes.Where(el =>
                el.rect.IsColliding(collisionRect) && el.tag == "wall");
            
            var enumerableNodes = tempNodes.ToList();
            if (enumerableNodes.Count == 0) 
                return;
            
            foreach (var node in enumerableNodes.Where(node => 
                         node.rect.IsMouseIn() && IsMouseButtonPressed(MOUSE_LEFT_BUTTON) 
                                               && IdItemsCanBreakWall.Contains(itemId)))
            {
                node.DestoryObject();
                nodes.Remove(node);
            }
        }
    }
}