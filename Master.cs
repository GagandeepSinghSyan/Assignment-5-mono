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
    internal class Master
    {
        //declartion for sprite
        protected Texture2D _sprite;

        //position x, y and movement speed
        protected int _positionX, _positionY, _movementSpeed, _endtime;

        public Rectangle getRectangle()
        {
            return new Rectangle(_positionX, _positionY, _sprite.Width, _sprite.Height);
        }
    }
}
