using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using Rander._2D;
using Rander.TestScripts;
using System;
using Rander;
using Rander._3D;

namespace Rander
{
    public class MyGame : Game
    {
        static int TargetFPS = 144;
        static bool VSync = true;

        public static GraphicsDeviceManager graphics;
        public static Draw2D Drawing;
        public static Game gameWindow;
        public static GameTime Gametime = new GameTime();

        public static Camera3D Cam3D;

        static List<Component> BaseScripts = new List<Component>();

        public static Dictionary<string, Object2D> Objects2D = new Dictionary<string, Object2D>();
        public static Dictionary<string, Object3D> Objects3D = new Dictionary<string, Object3D>();

        public MyGame()
        {
            Debug.LogWarning("Initializing...");
            graphics = new GraphicsDeviceManager(this);

            // Sets up the window to device's resolution and in full screen
            TargetElapsedTime = TimeSpan.FromSeconds((float)1 / TargetFPS);
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = VSync;

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;

            gameWindow = this;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Load Default Values
            DefaultValues.DefaultFont = ContentLoader.LoadFont("Defaults/Arial");
            DefaultValues.PixelTexture = ContentLoader.LoadTexture("Defaults/Pixel.png");
            Screen.Width = graphics.PreferredBackBufferWidth;
            Screen.Height = graphics.PreferredBackBufferHeight;

            GraphicsDevice.SetVertexBuffer(new VertexBuffer(GraphicsDevice, new VertexDeclaration(new VertexElement[] { new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0) }), 8, BufferUsage.None));

            // Load Base Scripts
            BaseScripts.Add(new MouseInput());
            BaseScripts.Add(new Rand());
            BaseScripts.Add(new Time());

            foreach (Component Com in BaseScripts)
            {
                Com.Start();
            }

            // Create New 3D Camera
            Cam3D = new Camera3D(new Vector3(0, 0, 0), new Vector3(0, 0, 0));

            Debug.LogSuccess("Initialization Complete!");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Debug.LogWarning("Loading Content...");

            // Create a new SpriteBatch, which can be used to draw textures.
            Drawing = new Draw2D(GraphicsDevice);

            if (Main.OnGameLoad())
            {
                Debug.LogSuccess("Finished!");
            }
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Debug.LogError("Closing Main Window...");
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // Update important scripts first
                foreach (Component Scr in BaseScripts)
                {
                    Scr.Update();
                }

                Main.OnUpdate();

                // Update 3D
                foreach (Object3D Obj in Objects3D.Values)
                {
                    foreach (Component3D Com in Obj.Components)
                    {
                        Com.Update();
                    }
                }

                // Update 2D
                foreach (Object2D Obj in Objects2D.Values)
                {
                    foreach (Component2D Com in Obj.Components)
                    {
                        Com.Update();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Gametime = gameTime;

            if (IsActive) {
                graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

                Drawing.Begin();
                // Updates Base Scripts
                foreach (Component Com in BaseScripts)
                {
                    Com.Draw();
                }

                Main.OnDraw();

                // Draws 3D
                foreach (Object3D Obj in Objects3D.Values)
                {
                    Obj.Draw();
                }

                // Draws 2D
                foreach (Object2D Obj in Objects2D.Values) {
                    Obj.Draw();
                }
                Drawing.End();
            }

            base.Draw(gameTime);
        }
    }

    public class DefaultValues
    {
        public static SpriteFont DefaultFont;
        public static Texture2D PixelTexture;
    }

    public class Screen
    {
        public static int Width;
        public static int Height;
    }

    public class Draw2D : SpriteBatch
    {
        public GraphicsDevice graphicsDevice;

        public Draw2D(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public void DrawLine(Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            Draw(DefaultValues.PixelTexture, r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
