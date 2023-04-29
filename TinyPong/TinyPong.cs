using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyPong
{
    public class TinyPong : Game
    {
        public GraphicsDeviceManager Graphics { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public KeyboardManager KeyboardManager { get; set; }
        public IActiveGameScreen ActiveGameScreen { get; set; }
        public GameTime GameTime { get; set; }

        /// <summary>
        /// This is the constructor for the game.
        /// </summary>
        public TinyPong()
        {
            Graphics = new GraphicsDeviceManager(this);

            //set resolution suitable for a pong game
            Graphics.PreferredBackBufferWidth = 800;
            Graphics.PreferredBackBufferHeight = 480;
            Graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// This is called when the game is first initialized.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ActiveGameScreen = new MainMenuScreen(this);
            KeyboardManager = new KeyboardManager();

            base.Initialize();
        }



        /// <summary>
        /// This is called when the game should load all content.
        /// </summary>
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            ActiveGameScreen.LoadContent(Content);
            ActiveGameScreen.SetupMenuItems();
        }

        /// <summary>
        /// This is called when the game should unload all content.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            GameTime = gameTime;
            KeyboardManager.Update();
            ActiveGameScreen.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            //This is the background color of the game
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here. 
            SpriteBatch.Begin();
            ActiveGameScreen.Draw();
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}