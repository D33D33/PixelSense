using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Microsoft.Surface.Core;

namespace SurfaceAppTest
{
    class Sprite
    {
        private int _touchId = 0;
        private Vector2 _delta = new Vector2(0, 0);
        /// <summary>
        /// Getter and setter of touchTarget
        /// </summary>
        public TouchTarget TouchTarget
        {
            get { return _touchTarget; }
            set { _touchTarget = value; }
        }
        private TouchTarget _touchTarget;

        /// <summary>
        /// Getter and of weight
        /// </summary>
        public float Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        private float _weight = 0;

        /// <summary>
        /// Getter and of texture
        /// </summary>
        public Texture2D Texture
        {
            get { return _texture; }
        }
        private Texture2D _texture;

        /// <summary>
        /// Getter of size
        /// </summary>
        public Rectangle Size
        {
            get { return _texture.Bounds; }
        }

        /// <summary>
        /// Getter and setter of position
        /// </summary>
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }
        private Vector2 _position;
        private Vector2 _prevPosition;

        /// <summary>
        /// Getter and setter of direction
        /// </summary>
        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        private Vector2 _direction;

        /// <summary>
        /// Getter and setter of speed
        /// </summary>
        public Vector2 Speed
        {
            get { return _speed; }
            set { _nextSpeed = value; Console.WriteLine(_speed); }
        }
        private Vector2 _speed;
        private Vector2 _nextSpeed;

        private float _speedMax;
        public float SpeedMax
        {
            get { return _speedMax; }
            set { _speedMax = value; }
        }

        /// <summary>
        /// Bat initialisation
        /// </summary>
        public virtual void Initialize(TouchTarget touchTarget)
        {
            _position = Vector2.Zero;
            _prevPosition = Vector2.Zero;
            _direction = Vector2.Zero;
            _speedMax = 5;
            _speed = Vector2.Zero;

            _touchTarget = touchTarget;

            _touchTarget.TouchDown += new EventHandler<TouchEventArgs>(this.TouchedDown);
            _touchTarget.TouchMove += new EventHandler<TouchEventArgs>(this.TouchedMove);
            _touchTarget.TouchUp += new EventHandler<TouchEventArgs>(this.TouchedUp);
        }

        /// <summary>
        /// Load bat texture
        /// </summary>
        /// <param name="content">Content Manager</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Met à jour les variables du sprite
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public virtual void Update(GameTime gameTime)
        {
            _prevPosition = _position;

            if (_touchId != 0 || Weight != 0)
                return;

            _speed = _nextSpeed;
            _position += _speed;
            /*_speed = _position - _prevPosition;// (float)(gameTime.ElapsedGameTime.TotalMilliseconds * 1000);
            _direction = _position - _prevPosition;


            if (_direction.Length() > 0)
            {
                _direction.Normalize();
                // _speed = _direction * _speedMax; // (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                _speed *= 0;
            }*/


            //Console.WriteLine(_speed);

            //Console.WriteLine(_direction);
            _prevPosition = _position;
            //_position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        }


        public void TouchedUp(object sender, EventArgs e)
        {
            TouchEventArgs args = (TouchEventArgs)e;
            TouchPoint touch = args.TouchPoint;

            if (_touchId == touch.Id)
            {
                Position = new Vector2(touch.CenterX - _delta.X, touch.CenterY - _delta.Y);
                _speed = _position - _prevPosition;
            }

            if (_touchId == touch.Id)
            {
                _touchId = 0;
            }
        }

        public void TouchedDown(object sender, EventArgs e)
        {
            TouchEventArgs args = (TouchEventArgs)e;
            TouchPoint touch = args.TouchPoint;

            float x = touch.CenterX;
            float y = touch.CenterY;
            if (x > Position.X && x < Position.X + Size.Width &&
                y > Position.Y && y < Position.Y + Size.Height)
            {
                _touchId = touch.Id;
                _delta = new Vector2(x - Position.X, y - Position.Y);
            }
        }

        public void TouchedMove(object sender, EventArgs e)
        {
            TouchEventArgs args = (TouchEventArgs)e;
            TouchPoint touch = args.TouchPoint;

            if (_touchId == touch.Id)
            {
                Position = new Vector2(touch.CenterX - _delta.X, touch.CenterY - _delta.Y);
                _speed = _position - _prevPosition;
            }
        }


        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        /// <param name="gameTime">Le GameTime de la frame</param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public bool Intersect(Sprite s)
        {
            if (s.Position.X > _position.X && s.Position.X < _position.X + _texture.Width &&
                s.Position.Y > _position.Y && s.Position.Y < _position.Y + _texture.Height)
            {
                return true;
            }
            if (s.Position.X + s.Size.Width > _position.X && s.Position.X + s.Size.Width < _position.X + _texture.Width &&
                 s.Position.Y > _position.Y && s.Position.Y < _position.Y + _texture.Height)
            {
                return true;
            }
            if (s.Position.X + s.Size.Width > _position.X && s.Position.X + s.Size.Width < _position.X + _texture.Width &&
                 s.Position.Y + s.Size.Height > _position.Y && s.Position.Y + s.Size.Height < _position.Y + _texture.Height)
            {
                return true;
            }
            if (s.Position.X > _position.X && s.Position.X < _position.X + _texture.Width &&
                 s.Position.Y + s.Size.Height > _position.Y && s.Position.Y + s.Size.Height < _position.Y + _texture.Height)
            {
                return true;
            }

            return false;
        }
    }
}
