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

namespace The_Prison_Escape.Graphics.UI
{
    public class LevelWithBalls : GameLoop
    {
        private List<Bar> objList = new List<Bar>();

    public override void Init()
    {
        InitPhysics(8,8);
        
        var wx = WindowSize.X;
        var wy = WindowSize.Y;

        collisionRules.TryAdd("bar", "ball");

        objList = new List<Bar>
        {
        
            new Bar(new Vector2(0, 0), new Vector2(wx, 16)),
            new Bar(new Vector2(0, wy - 16), new Vector2(wx, 16)),
            new Bar(new Vector2(0, 0), new Vector2(16, wy)) { vert = true },
            new Bar(new Vector2(wx - 16, 0), new Vector2(16, wy)) { vert = true }
        };
        new Bar(new Vector2(400), new Vector2(600, 16));

        RegisterGameObj(new Text(new Actionable<string>(() => $"{CountColliders() - 4}"),
            new Vector2(12, 60), RED), new Text(new Actionable<string>(() => $@"Collision Time
                    cur: {CurrentCollision}ms
                    avg: {TimeAverage}ms
                    high: {CollisionHigh}ms".Replace("\r", "")), new Vector2(300, 50), SKYBLUE));
    }

    public override void UpdateLoop()
    {
        //update
        // foreach (Node.Node node in root.get_children())
        // {
        //     if (node is PhysicsNode physics_node) 
        //     { 
        //         //update transformation
        //         physics_node._physics_update(deltaTime);
        //     }
        //
        //     //physics
        //     node._update_global_transform();
        // }


        if (objList.Any(x => x.rect.IsMouseIn()) && IsMouseButtonPressed(MOUSE_RIGHT_BUTTON))
            foreach (var obj in objList)
                obj.DestoryObject();

        if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            for (var i = 0; i < 10; i++) new Circle(mousePos);
            // GameBox.Dispose();
            //DeregisterGameObj();
            // scene = new Level();
            // scene.Init();
            // scene.AddScene(new Level());
            // scene.ChangeScene(1);
        }
    }

    public override void RenderLoop() => DrawFPS(12, 12);
    }
}