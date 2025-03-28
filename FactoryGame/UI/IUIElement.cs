using Microsoft.Xna.Framework.Graphics;

namespace SurvivalGame.UI
{
    interface IUIElement
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
