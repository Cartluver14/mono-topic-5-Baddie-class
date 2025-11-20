using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace mono_topic_5_Baddie_class
{
    public class Ghost
    {
        private List<Texture2D> _Textures;
        private Vector2 _speed;
        private Rectangle _location;
        private int _textureIndex;
        private SpriteEffects _direction;
        private float _anamationspeed;
        private float _seconds;


       

        public Ghost(List<Texture2D> textures, Vector2 speed, Rectangle location)
        {
            _Textures = textures;
            _speed = speed;
            _location = location;
            _textureIndex = 0;
            _direction = SpriteEffects.None;

            _seconds = 0;
            _anamationspeed = 0.2f;



        }



        public void Update(GameTime gameTime, MouseState mouseState)
        {
            _speed = Vector2.Zero;

            if (mouseState.X < _location.X)
            {
                _direction = SpriteEffects.FlipHorizontally;
                _speed.X = -1;
            }
            else if (mouseState.X > _location.X)
            {
                _direction = SpriteEffects.None;
                _speed.X = 1;
            }
           



            if (mouseState.Y < _location.Y)
            {
                _speed.Y = -1;
            }
            else if (mouseState.Y > _location.Y)
            {
                _speed.Y = 1;

            }
            

            if (mouseState.LeftButton == ButtonState.Released)
            {
                _speed = Vector2.Zero;
                _textureIndex = 0;
                _seconds = 0;
            }
            else if(_speed != Vector2.Zero)
            {

                _seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_seconds > _anamationspeed)
                {
                    _seconds = 0;
                    _textureIndex++;
                    if (_textureIndex > 8)
                        _textureIndex = 1;
                    
                }

            }
            _location.Offset(_speed);

           
        }




        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Textures[_textureIndex], _location, null, Color.White, 0f, Vector2.Zero, _direction, 1f);
        }



      
    }
}

