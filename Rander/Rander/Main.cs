/////////////////////////////////////
///         Main Loop/Vars        ///
///          Use: Global          ///
///         Attatch: N/A          ///
/////////////////////////////////////

using Microsoft.Xna.Framework;

using Rander._2D;
using Rander.TestScripts;

namespace Rander
{
    class Main
    {
        // Load game's resources and instantiate stuff here
        public static bool OnGameLoad()
        {
            new Object2D("FPSText", new Vector2(10, 5), new Vector2(100, 100), 0, Color.Green, new Component2D[] { new Text2DComponent("FPS"), new FPSScript() });

            return true;
        }

        // Updates consistently (30TPS)
        public static void OnUpdate()
        {

        }

        // Updates inconsistently (Can go from 1-Infinity TPS), main use is for rendering things on-screen
        public static void OnDraw()
        {

        }
    }
}
