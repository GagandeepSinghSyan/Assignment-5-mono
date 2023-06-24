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

        //sprite attribute
        private Texture2D _tree; 

        //constructor
        public Tree(int x, int y, Texture2D tree)
        {
            _positionX = x;
            _positionY = y;
            _tree = tree;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            spriteBatch.Draw(_tree, new Vector2(_positionX, _positionY), null, Color.White, 0, new Vector2(1, 1), new Vector2(4f, 4f), SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
