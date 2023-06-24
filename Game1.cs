using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
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

        private int _treeX, _treeY;

        private int _textY = 50, _textX = 600;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //butterfly variable
        private Butterfly _butterfly;

        private List<Flower> _flowers;

        //tree variables
        private List<Tree> _trees;

        //tree texture
        private Texture2D _treeTexture;
        private SpriteFont GameFont;
        private Flower _newFlower;
        //
        private Texture2D _flowerSprite;
        private bool spacebarDown = false;

        //butterfly texture
        private Texture2D _butterflySprite;

        //random number
        private Random _randomNumber = new Random();

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

            //tree list
            _trees = new List<Tree>();

            //flower list
            _flowers = new List<Flower>();

            //load caterpilar texture
            _butterflySprite = Content.Load<Texture2D>("butterfly");

            //constructor for butterfly
            _butterfly = new Butterfly(_randomNumber.Next(50, 1820), _randomNumber.Next(800, 1000), 5, _butterflySprite);

            //load tree texture
            _treeTexture = Content.Load<Texture2D>("tree");


            _flowerSprite = Content.Load<Texture2D>("Blue");

            for (int i = 0; i <= 10; i++)
            {
                //constructor trees
                Tree new_tree = new Tree(_treeX, _treeY, _treeTexture);
                _trees.Add(new_tree);

                _treeX += 200;
                _treeY = _randomNumber.Next(100,700 );
               
            }

           GameFont = Content.Load<SpriteFont>("GameFont");

        }
                
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _butterfly.Update();

            //removing flowers - backup here
            for (int i = 0; i < _flowers.Count; i++)
            {
                _flowers[i].Update();
                if (_flowers[i].GetKillTime() < 0)
                {
                    _flowers.RemoveAt(i);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !spacebarDown)
            {
                spacebarDown = true;
                _newFlower = new Flower(_randomNumber.Next(0, 1920), _randomNumber.Next(0, 1080), 2400, _flowerSprite);
                _flowers.Add(_newFlower);
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spacebarDown = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Green);

            foreach (Tree tree in _trees)
            {
                tree.Draw(_spriteBatch);
            }

            foreach (Flower flower in _flowers)
            {
                flower.Draw(_spriteBatch);
            }

            //draw butterfly
            _butterfly.Draw(_spriteBatch);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(GameFont, "Press Space to Add Flower and W A S D is movement for butterfly.", new Vector2(_textX, _textY), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}