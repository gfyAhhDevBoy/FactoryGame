using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FactoryGame.UI
{
    class UIRectangle : IUIElement
    {
        Rectangle _rect;
        Texture2D _texture;
        public UIRectangle(int x, int y, int width, int height, Color color, GraphicsDevice graphicsDevice)
        {
            _texture = new(graphicsDevice, 1, 1);
            _texture.SetData([color]);

            _rect = new(x , y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rect, Color.White);
        }

        public void Update()
        {
        }
    }
}
