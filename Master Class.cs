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
    internal class Master_Class
    {
        protected Texture2D _sprite;

        //position x, y and movement speed
        protected int _positionX, _positionY, _movementSpeed;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            spriteBatch.Draw(_sprite, new Vector2(_positionX, _positionY), Color.White);
            spriteBatch.End();
        }
    }

}
