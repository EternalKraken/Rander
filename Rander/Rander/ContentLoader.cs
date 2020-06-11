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
            Texture2D Tex = null;
            // If texture is already in memory, reference that instead of having to load the texture again
            if (Loaded2DTextures.ContainsKey(Path.GetFileNameWithoutExtension(Game.gameWindow.Content.RootDirectory + "/" + Image))) {
                Loaded2DTextures.TryGetValue(Path.GetFileNameWithoutExtension(Game.gameWindow.Content.RootDirectory + "/" + Image), out Tex);
            } else
            {
                if (File.Exists(Game.gameWindow.Content.RootDirectory + "/" + Image)) {
                    FileStream ImageStream = File.OpenRead(Game.gameWindow.Content.RootDirectory + "/" + Image);
                    Tex = Texture2D.FromStream(Game.graphics.GraphicsDevice, ImageStream);
                    ImageStream.Dispose();

                    Loaded2DTextures.Add(Path.GetFileNameWithoutExtension(Game.gameWindow.Content.RootDirectory + "/" + Image), Tex);
                } else
                {
                    Debug.LogError("The Image \"" + Game.gameWindow.Content.RootDirectory + "/" + Image + "\" does not exist!", true, 2);
                }
            }

            return Tex;
        }

        public static SpriteFont LoadFont(string Font)
        {
            SpriteFont outFont = null;
            // If font is already in memory, reference that instead of having to load the texture again
            if (LoadedFonts.ContainsKey(Path.GetFileNameWithoutExtension(Game.gameWindow.Content.RootDirectory + "/" + Font)))
            {
                LoadedFonts.TryGetValue(Path.GetFileNameWithoutExtension(Game.gameWindow.Content.RootDirectory + "/" + Font), out outFont);
            } else
            {
                if (File.Exists(Game.gameWindow.Content.RootDirectory + "/" + Font + ".xnb")) {
                    outFont = Game.gameWindow.Content.Load<SpriteFont>(Font);
                    LoadedFonts.Add(Path.GetFileNameWithoutExtension(Game.gameWindow.Content.RootDirectory + "/" + Font), outFont);
                } else
                {
                    Debug.LogError("The Font \"" + Game.gameWindow.Content.RootDirectory + "/" + Font + ".xnb" + "\" does not exist!", true, 2);
                }
            }

            return outFont;
        }
    }
}
