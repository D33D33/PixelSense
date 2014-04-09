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

namespace SurfaceAppTest
{
    class Bat
    {
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
            set { _position = value;
            Console.WriteLine(_prevPosition + " - " + _position);
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
            //set { _speed = value; }
        }
        private Vector2 _speed;

        private float _speedMax;
        public float SpeedMax
        {
            get { return _speedMax; }
            set { _speedMax = value; }
        }

        /// <summary>
        /// Bat initialisation
        /// </summary>
        public virtual void Initialize()
        {
            _position = Vector2.Zero;
            _prevPosition = Vector2.Zero;
            _direction = Vector2.Zero;
            _speedMax = 5;
            _speed = Vector2.Zero;
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
            _direction = _position - _prevPosition;

            
            if (_direction.Length() > 0)
            {
                _direction.Normalize();
                _speed = _direction * _speedMax; // (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                _speed *= 0;
            }

            //Console.WriteLine(_direction);
            _prevPosition = _position;
            //_position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// <summary>
        /// Handle inputs
        /// </summary>
        /// <param name="keyboardState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public virtual void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {}

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        /// <param name="gameTime">Le GameTime de la frame</param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
