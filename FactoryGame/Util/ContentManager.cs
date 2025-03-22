using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace FactoryGame.Util
{
    static class ContentManager
    {
        private static Dictionary<string, Texture2D> _textureMap = new();

        public static Texture2D GetTexture(string path)
        {
            if (_textureMap.ContainsKey(path))
            {
                Texture2D foundTexture;
                _textureMap.TryGetValue(path, out foundTexture);
                return foundTexture;
            }

            Texture2D texture;

            try
            {
                texture = Game1.Instance.Content.Load<Texture2D>(path);
            } catch(ContentLoadException e)
            {
                Debug.WriteLine("Couldn't load Texture " + path);
                return null;
            }

            _textureMap.Add(path, texture);

            return texture;
        }
    }
}
