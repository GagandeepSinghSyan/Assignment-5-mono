using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_5_mono
{
    internal class Flower : Master
    {

        private int _flowerX, _flowerY, _flowerKilltime;
        private Color _color;
        private Texture2D _flowerSprite;
        private Random rng;
        private int _timer = 60;


        public Flower(int flowerX, int flowerY, int flowerKilltime, Texture2D flowerSprite)
        {
            _flowerX = flowerX;
            _flowerY = flowerY;
            _flowerKilltime = flowerKilltime;
            _flowerSprite = flowerSprite;
            rng = new Random();
            _color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
        }


        public void Update()
        {
            _killtime--; // decreases kill time
            _timer--;  // timer for color change
            if (_timer == 0) //code for color change
            {
                _color = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
                _timer = 60;
            }
        }
        public int GetKillTime() { return _killtime; }
        public bool Died() { return _killtime <= 0; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_flowerSprite, new Vector2(_flowerX, _flowerY), null, _color, 0, new Vector2(1, 1), new Vector2(1f,1f), SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
