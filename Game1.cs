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
        private int catterpillarX = 0, catterpillarY = 0;

        //caterpillar texture
        private Texture2D _caterpillarSprite;

        //tree variable
        private Tree _tree;
        

        //tree texture
        private Texture2D _treeTexture;

        //tree list declaration
        private List<Tree> _treeList;

        //random number
        private Random _randomNumber= new Random();

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
            //list of tree intitialized
            _treeList = new List<Tree>();

            //random object
            _randomNumber = new Random();

            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //load caterpilar texture
            _caterpillarSprite = Content.Load<Texture2D>("Caterpillar");

            //initialize values for caterpillar
            _caterpillar = new Caterpillar(catterpillarX, catterpillarY, 5, _caterpillarSprite);

            //initialize values for tree
            _treeTexture = Content.Load<Texture2D>("tree");

            //initialize values for trees
            _tree = new Tree(_randomNumber.Next(200, 1720), _randomNumber.Next(200, 880), _treeTexture);

            _tree.getRectangle();
            _caterpillar.getRectangle();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //handle different screens
            base.Update(gameTime);
            switch (_state)
            {
                case GameState.TitleScreen:
                    UpdateTitleScreen(gameTime);
                    break;
                case GameState.MainScreen:
                    UpdateMainScreen(gameTime);
                    break;
                case GameState.EndScreen:
                    UpdateEndScreen(gameTime);
                    break;
            }

            _caterpillar.Update();

            _tree.Collision(_tree, _caterpillar);


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

        void UpdateTitleScreen(GameTime gameTime)
        {
            
        }
        void UpdateMainScreen(GameTime gameTime)
        {
            
        }
        void UpdateEndScreen(GameTime gameTime)
        {
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            _caterpillar.Draw(_spriteBatch);
            _tree.Draw(_spriteBatch);

            base.Draw(gameTime);
        }

        void DrawTitleScreen(GameTime gameTime)
        {
            
        }

        void DrawMainScreen(GameTime gameTime)
        {
           
        }

        void DrawEndScfreen(GameTime gameTime)
        {

        }
    }
}