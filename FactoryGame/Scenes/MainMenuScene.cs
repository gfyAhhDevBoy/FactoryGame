using FactoryGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryGame.Scenes
{
    class MainMenuScene : IScene
    {
        UIManager ui;
        public TextButtonElement playButton;

        public void Load(ContentManager content)
        {
            ui = new();
            playButton = new(new(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2), "Play", content.Load<SpriteFont>("MenuText"), Color.White, Color.LightGray);
            ui.Add(playButton);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ui.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            ui.Update();
        }

        public void Unload()
        {
        }
    }
}
