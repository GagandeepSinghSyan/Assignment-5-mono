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
    enum CaterPillarState
    {
        idle,
        moving,
        transform
    }
    internal class Caterpillar: Master_Class
    {
        //flip sprite when required
        private SpriteEffects _flipLeft;

        //atrributes:-
        
        //lifespan bar to make on top

        public Caterpillar(int positionX, int positionY,int caterpillarSpeed, Texture2D caterpillarSprite)
        {
            _positionX = positionX;
            _positionY = positionY;
            _movementSpeed = caterpillarSpeed;
            _sprite = caterpillarSprite;
        }

        //key input
        public void Update()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _positionY += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _positionY -= 5;
            }
            
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _positionX += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _positionX -= 5;
            }
        }
        
    }
}
