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
    internal class Tree : Master
    {

        private Texture2D _tree; 
        public Tree(int x, int y, int killtime, Texture2D tree)
        {
            _positionX = x;
            _positionY = y;
            _killtime = killtime;
            _tree = tree;
        }


        public void Update()
        {
            _killtime--; // decreases kill time

        }
        public int GetKillTime() { return _killtime; }
        public bool Died() { return _killtime <= 0; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_tree, new Vector2(_positionX, _positionY), null, Color.White, 0, new Vector2(1, 1), new Vector2(1f, 1f), SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
