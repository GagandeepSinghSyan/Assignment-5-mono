using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_5_mono
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //caterpillar variable
        private Caterpillar _caterpillar;
        private int CatterpillarX= 0, CatterpillarY= 0;

        //caterpillar tecture
        private Texture2D _caterpillarSprite;

        public Game1()
        {
            Texture2D[] Flowers = new Texture2D[4];
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _caterpillarSprite = Content.Load<Texture2D>("Caterpillar");

            _caterpillar = new Caterpillar(CatterpillarX, CatterpillarY, 5, _caterpillarSprite);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _caterpillar.Update();
            _caterpillar.GetPostionX(CatterpillarX);
            _caterpillar.GetPostionY(CatterpillarY);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _caterpillar.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}