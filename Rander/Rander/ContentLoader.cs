using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Rander
{
    public class ContentLoader
    {

        static Dictionary<string, SpriteFont> LoadedFonts = new Dictionary<string, SpriteFont>();
        static Dictionary<string, Texture2D> Loaded2DTextures = new Dictionary<string, Texture2D>();

        public static Texture2D LoadTexture(string Image)
        {
            Texture2D Tex;
            // If texture is already in memory, reference that instead of having to load the texture again
            if (Loaded2DTextures.ContainsKey(Path.GetFileNameWithoutExtension(MyGame.gameWindow.Content.RootDirectory + "/" + Image))) {
                Loaded2DTextures.TryGetValue(Path.GetFileNameWithoutExtension(MyGame.gameWindow.Content.RootDirectory + "/" + Image), out Tex);
            } else
            {
                FileStream ImageStream = File.OpenRead(MyGame.gameWindow.Content.RootDirectory + "/" + Image);
                Tex = Texture2D.FromStream(MyGame.graphics.GraphicsDevice, ImageStream);
                ImageStream.Dispose();

                Loaded2DTextures.Add(Path.GetFileNameWithoutExtension(MyGame.gameWindow.Content.RootDirectory + "/" + Image), Tex);
            }

            return Tex;
        }

        public static SpriteFont LoadFont(string Font)
        {
            SpriteFont outFont;
            // If font is already in memory, reference that instead of having to load the texture again
            if (LoadedFonts.ContainsKey(Path.GetFileNameWithoutExtension(MyGame.gameWindow.Content.RootDirectory + "/" + Font)))
            {
                LoadedFonts.TryGetValue(Path.GetFileNameWithoutExtension(MyGame.gameWindow.Content.RootDirectory + "/" + Font), out outFont);
            } else
            {
                outFont = MyGame.gameWindow.Content.Load<SpriteFont>(Font);
                LoadedFonts.Add(Path.GetFileNameWithoutExtension(MyGame.gameWindow.Content.RootDirectory + "/" + Font), outFont);
            }

            return outFont;
        }
    }
}
