using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_5_mono
{
    internal class Flower : Master
    {

        private int _killtime;
        private Random _rng;
        private float _scale;
        private Color _color;
        private Random rng;
        private int _timer = 60;



        public Flower(int x, int y, int killtime, Texture2D tree)
        {
            _positionX = x;
            _positionY = y;
            _killtime = killtime;
            _scale = 0.1f;
            _sprite = tree;
            rng = new Random();
            _color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
        }


        public void Update()
        {
            // decreases kill time
            _killtime--;

            // timer for color change
            _timer--;

            //code for color change
            if (_timer == 0) 
            {
                _timer = 60;
            }
        }
        public int GetKillTime() { return _killtime; }
        public bool Died() { return _killtime <= 0; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_sprite, new Vector2(_positionX, _positionY), null, Color.White, 0, new Vector2(1, 1), new Vector2(_sprite.Width, _sprite.Height), SpriteEffects.None, 0);
            spriteBatch.End();
        }

         public int GetPositionX() { return _positionX; }
         public int GetPositionY() { return _positionY; }

        void Collision()
        {
            if (_butterfly.getRectangle().Intersects(_newFlower.getRectangle()))
            {
                //destroy specfic flower - to do
            }
        }
        
    }
}
