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

namespace Enib
{
    namespace SurfaceLib
    {
        public class Sprite
        {
            private int _touchId = 0;
            private Vector2 _delta = Vector2.Zero;

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
                get
                {
                    if (_texture == null)
                        throw new Exception("Can not get size before LoadContent");
                    return _texture.Bounds; 
                }
            }

            /// <summary>
            /// Getter of the bounding rect
            /// </summary>
            public Rectangle BoundingRect
            {
                get { return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); ; }
            }

            /// <summary>
            /// Getter and setter of position
            /// </summary>
            public Vector2 Position
            {
                get { return _position; }
                set { _nextPosition = value; }
            }
            private Vector2 _position;
            private Vector2 _nextPosition;

            /// <summary>
            /// Getter and setter of speed
            /// </summary>
            public Vector2 Speed
            {
                get { return _speed; }
                set { _nextSpeed = value; }
            }
            private Vector2 _speed;
            private Vector2 _nextSpeed;


            /// <summary>
            /// Getter and setter of SpeedMax
            /// </summary>
            private float _speedMax;
            public float SpeedMax
            {
                get { return _speedMax; }
                set { _speedMax = value; }
            }

            public bool AsMove
            {
                get { return _asMove; }
            }
            private bool _asMove;

            private bool _swapEnabled;

            private string _assetName;

            /// <summary>
            /// Getter of name
            /// </summary>
            public string Name
            {
                get { return _name; }
            }
            private string _name;

            public Sprite(string name, string assetName)
            {
                _name = name;
                _assetName = assetName;
            }

            /// <summary>
            /// Sprite initialisation
            /// </summary>
            public virtual void Initialize(TouchTarget touchTarget, bool enableSwap = false)
            {
                _position = Vector2.Zero;
                _nextPosition = Vector2.Zero;
                _speedMax = 5;
                _speed = Vector2.Zero;
                _nextSpeed = Vector2.Zero;

                _asMove = false;
                _swapEnabled = enableSwap;

                _touchTarget = touchTarget;

                /*_touchTarget.TouchDown += new EventHandler<TouchEventArgs>(this.TouchedDown);
                _touchTarget.TouchMove += new EventHandler<TouchEventArgs>(this.TouchedMove);
                _touchTarget.TouchUp += new EventHandler<TouchEventArgs>(this.TouchedUp);*/
            }

            /// <summary>
            /// Load sprite texture
            /// </summary>
            /// <param name="content">Content Manager</param>
            /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
            public virtual void LoadContent(ContentManager content)
            {
                _texture = content.Load<Texture2D>(this._assetName);
            }

            /// <summary>
            /// Met à jour les variables du sprite
            /// </summary>
            /// <param name="gameTime">Le GameTime associé à la frame</param>
            public virtual void Update(GameTime gameTime)
            {
                _position = _nextPosition;
                
                if (_touchId != 0)
                    return;

                _speed = _nextSpeed;
                _nextPosition += _speed;

                /*if (_speed.Length() > _speedMax)
                {
                    _speed.Normalize();
                    _speed *= _speedMax;
                }
                else
                {
                    _speed *= 0;
                }*/
                //(float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }


            public bool TouchedUp(object sender, EventArgs e)
            {
                TouchEventArgs args = (TouchEventArgs)e;
                TouchPoint touch = args.TouchPoint;

                if (_touchId == touch.Id)
                {
                    _touchId = 0;
                    
                    _nextPosition = new Vector2(touch.CenterX - _delta.X, touch.CenterY - _delta.Y);
                    if (_swapEnabled)
                        _nextSpeed = _nextPosition - _position;

                    return true;
                }
                return false;
            }

            public bool TouchedDown(object sender, EventArgs e)
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
                    _asMove = false;
                    return true;
                }
                return false;
            }

            public bool TouchedMove(object sender, EventArgs e)
            {
                TouchEventArgs args = (TouchEventArgs)e;
                TouchPoint touch = args.TouchPoint;

                if (_touchId == touch.Id)
                {
                    _nextPosition = new Vector2(touch.CenterX - _delta.X, touch.CenterY - _delta.Y);
                    _speed = _nextPosition - _position;
                    if (_swapEnabled)                       
                        _nextSpeed = _nextPosition - _position;

                    _asMove = true;
                    return true;
                }
                return false;
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

            /// <summary>
            /// Compute intersection with an other Sprite
            /// </summary>
            /// <param name="s">Sprite to compute</param>
            public bool Intersect(Sprite s)
            {
                Rectangle rect = new Rectangle((int)s.Position.X, (int)s.Position.Y, s.Size.Width, s.Size.Height);
                return this.Intersect(rect);
            }

            /// <summary>
            /// Compute intersection with a rectangle
            /// </summary>
            /// <param name="s">Rectangle to compute</param>
            public bool Intersect(Rectangle r)
            {
                if (r.X > _position.X && r.X < _position.X + _texture.Width &&
                    r.Y > _position.Y && r.Y < _position.Y + _texture.Height)
                {
                    return true;
                }
                if (r.X + r.Width > _position.X && r.X + r.Width < _position.X + _texture.Width &&
                     r.Y > _position.Y && r.Y < _position.Y + _texture.Height)
                {
                    return true;
                }
                if (r.X + r.Width > _position.X && r.X + r.Width < _position.X + _texture.Width &&
                     r.Y + r.Height > _position.Y && r.Y + r.Height < _position.Y + _texture.Height)
                {
                    return true;
                }
                if (r.X > _position.X && r.X < _position.X + _texture.Width &&
                     r.Y + r.Height > _position.Y && r.Y + r.Height < _position.Y + _texture.Height)
                {
                    return true;
                }
                return false;
            }

            /*/// <summary>
            /// Compute intersection with an other Sprite
            /// </summary>
            /// <param name="s">Sprite to compute</param>
            public bool Intersect(Sprite s)
            {
                Rectangle rect = new Rectangle((int)s.Position.X, (int)s.Position.Y, s.Size.Width, s.Size.Height);
                return this.Intersect(rect);
            }

            /// <summary>
            /// Compute intersection with a rectangle
            /// </summary>
            /// <param name="s">Rectangle to compute</param>
            public bool Intersect(Rectangle r)
            {
                Rectangle rect = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);

                if (rect.Contains(r.X, r.Y))
                {
                    return true;
                }
                if (rect.Contains(r.X + r.Width, r.Y))
                {
                    return true;
                }
                if (rect.Contains(r.X + r.Width, r.Y + r.Height))
                {
                    return true;
                }
                if (rect.Contains(r.X, r.Y + r.Height))
                {
                    return true;
                }
                return false;
            }*/
        }
    }
}
