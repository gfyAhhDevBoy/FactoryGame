using Microsoft.Xna.Framework.Graphics;

namespace FactoryGame.UI
{
    interface IUIElement
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
