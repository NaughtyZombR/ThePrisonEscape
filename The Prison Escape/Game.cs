using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_CsLo;
using RayWrapper;
using RayWrapper.Objs;
using RayWrapper.Vars;
using The_Prison_Escape.Graphics.UI;
using The_Prison_Escape.Node;
using static Raylib_CsLo.Raylib;
using static RayWrapper.Collision.Collision;
using static RayWrapper.GameBox;

namespace The_Prison_Escape
{
    public class Game : GameLoop
    {
        public enum Modes
    {
        Menu,
        Level,
        Editor,
        LevelWithBalls
    }

    Modes mode = Modes.Menu;

    Node.Node root;

    public Game(Modes _initial_mode)
    {
        
        //Global.Global.game = this;
        //root = new Node.Node(null);
        changeMode(_initial_mode);
    }

    public void changeMode(Modes _mode)
    {
        mode = _mode;

        //clear roots
        //root = new Node.Node(null);
        //ui_root = new UI();
        //collision_manager.clear();

        //create content based on mode
        if (mode == Modes.Level)
        {
            SwitchScene("Level");
            
            
            
            //GameBox.scene = new Level();
            //var button_size = new Vector2(96, 64);
            //Button button_menu = new Button(button_size, "Back");
            //button_menu._set_parent(ui_root);
            //button_menu.set_action(change_to_menu);
        }
        else if (mode == Modes.Editor)
        {
            //LevelEditor level_editor = new LevelEditor(GetScreenWidth(), GetScreenHeight());
            //level_editor._set_parent(ui_root);
        }
        else if (mode == Modes.Menu)
        {
            MainMenu mainMenu = new MainMenu(new Vector2(WindowSize.X, WindowSize.Y));
            //main_menu._set_parent(ui_root);
        }
        else if (mode == Modes.LevelWithBalls)
        {
            SwitchScene("LevelWithBalls");
            
            
            //new GameBox(new LevelWithBalls(), new Vector2(1280, 720), "collision testing", 500);
        }

    }

    public void update()
    {
        //update
        // foreach (var node in root.get_children())
        // {
        //     if (node is PhysicsNode physicsNode)
        //     {
        //         //update transformation
        //         //physicsNode._physics_update(deltaTime);
        //     }
        // }
    }

    public override void Init()
    {
    }

    public override void UpdateLoop()
    {
    }

    public override void RenderLoop()
    {
    }
    
    
    }
}