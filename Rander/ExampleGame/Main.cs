using ExampleGame.Scripts;
using Microsoft.Xna.Framework;
using Rander;
using Rander._2D;
using Rander.TestScripts;

namespace ExampleGame
{
    class Main
    {
        static Object2D Cursor;

        public static void OnGameLoad()
        {
            new Object2D("FPSText", new Vector2(10, 5), new Vector2(100, 100), 0, Color.Green, new Component2D[] { new Text2DComponent("FPS"), new FPSScript() }); // FPS Counter

            Cursor = new Object2D("Cursor", new Vector2(0, 0), new Vector2(10, 10), 0, Color.White, 1, new Component2D[] { new Image2DComponent(DefaultValues.PixelTexture, Alignment.Center), new CursorReplacement() });
        }

        public static void OnUpdate()
        {

        }
    }
}
