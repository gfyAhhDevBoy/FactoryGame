using FactoryGame.Scenes;
using FactoryGame.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace FactoryGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Vector2 Scale = new Vector2(10, 10);

        SceneManager _sceneManager;
        InputManager _input;

        Player _player;
        Camera _camera;

        public static readonly int ScreenWidth = 1920;
        public static readonly int ScreenHeight = 1080;

        MainMenuScene _menuScene;
        GameScene _gameScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _sceneManager = new();
            _input = new();
            _camera = new(Vector2.Zero);

            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new(Content.Load<Texture2D>("player"), new Vector2(200, 200), Scale);

            _menuScene = new();
            _gameScene = new(_player, _camera);
            _sceneManager.LoadScene(_menuScene, Content);
            _menuScene.playButton.ClickEvent += PlayButton_ClickEvent;

            // TODO: use this.Content to load your game content here
        }

        private void PlayButton_ClickEvent(object sender, System.EventArgs e)
        {
            _sceneManager.UnloadScene();
            _sceneManager.LoadScene(_gameScene, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _input.Update();

            _sceneManager.GetCurrentScene().Update(gameTime);

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _sceneManager.GetCurrentScene().Draw(_spriteBatch);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
