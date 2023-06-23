using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Assignment_5_mono
{
    enum GameState
    {
        TitleScreen,
        MainScreen,
        EndScreen,
    }

    public class Game1 : Game
    {
        //resolution for window
        private int _windowWidth = 1920;
        private int _windowHeight = 1080;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //caterpillar variable
        private Caterpillar _caterpillar;

        //caterpillar texture
        private Texture2D _caterpillarSprite;

        //tree variables
        private Tree _tree, _tree2, _tree3, _tree4, _tree5, _tree6;

        //tree texture
        private Texture2D _treeTexture;

        //random number
        private Random _randomNumber= new Random(), _randomNumber2 = new Random(), _randomNumber3 = new Random(), _randomNumber4 = new Random(), _randomNumber5 = new Random(), _randomNumber6 = new Random();

        //declaration of screen state
        GameState _state;

        public Game1()
        {
            //flower array
            Texture2D[] Flowers = new Texture2D[4];

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //change window size
            _graphics.PreferredBackBufferWidth = _windowWidth;
            _graphics.PreferredBackBufferHeight = _windowHeight;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //random object
            _randomNumber = new Random();

            //load caterpilar texture
            _caterpillarSprite = Content.Load<Texture2D>("Caterpillar");

            //constructor for caterpillar
            _caterpillar = new Caterpillar(_randomNumber.Next(50, 1820), _randomNumber.Next(800, 1000), 5, _caterpillarSprite);

            //load tree texture
            _treeTexture = Content.Load<Texture2D>("tree");

            //constructor for tree1
            _tree = new Tree(_randomNumber.Next(50, 1720), _randomNumber.Next(50, 380), _treeTexture);

            //constructor for tree2
            _tree2 = new Tree(_randomNumber2.Next(50, 1720), _randomNumber2.Next(50, 380), _treeTexture);

            //constructor for tree1
            _tree3 = new Tree(_randomNumber.Next(50, 1720), _randomNumber.Next(50, 380), _treeTexture);

            //constructor for tree2
            _tree4 = new Tree(_randomNumber2.Next(50, 1720), _randomNumber2.Next(50, 380), _treeTexture);

            //constructor for tree1
            _tree5 = new Tree(_randomNumber.Next(50, 1720), _randomNumber.Next(50, 380), _treeTexture);

            //constructor for tree2
            _tree6 = new Tree(_randomNumber2.Next(50, 1720), _randomNumber2.Next(50, 380), _treeTexture);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _caterpillar.Update();

            //for enum input
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                _state = GameState.TitleScreen;
                Console.WriteLine("Changed to TitleScreen");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                _state = GameState.EndScreen;
                Console.WriteLine("Changed to EndScren");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.N))
            {
                _state = GameState.MainScreen;
                Console.WriteLine("Changed to MainScreen");
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            //1st tree drew
            _tree.Draw(_spriteBatch);

            //2nd tree drew
            _tree2.Draw(_spriteBatch);

            //1st tree drew
            _tree3.Draw(_spriteBatch);

            //2nd tree drew
            _tree4.Draw(_spriteBatch);

            //1st tree drew
            _tree5.Draw(_spriteBatch);

            //2nd tree drew
            _tree6.Draw(_spriteBatch);

            //draw caterpillar
            _caterpillar.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}