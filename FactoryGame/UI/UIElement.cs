using Microsoft.Xna.Framework;

namespace FactoryGame.UI
{
    abstract class UIElement
    {
        public Vector2 Position;
        
        public UIElement(Vector2 position)
        {
            Position = position;
        }
    }
}
