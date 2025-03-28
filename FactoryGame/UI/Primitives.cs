using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SurvivalGame.UI
{
    class UIRectangle : IUIElement
    {
        public Rectangle DestRect;
        public Texture2D Texture;
        public UIRectangle(int x, int y, int width, int height, Color color, GraphicsDevice graphicsDevice)
        {
            Texture = new(graphicsDevice, 1, 1);
            Texture.SetData([color]);

            DestRect = new(x, y, width, height);
        }

        public UIRectangle(Vector2 pos, int width, int height, Color color, GraphicsDevice graphicsDevice)
        {
            Texture = new(graphicsDevice, 1, 1);
            Texture.SetData([color]);

            DestRect = new((int)pos.X, (int)pos.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, DestRect, Color.White);
        }

        public void Update()
        {
        }
    }
}
