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

using Enib.SurfaceLib;

namespace Enib
{
    namespace SurfaceLib
    {
        public class Manager
        {
            private LinkedList<Sprite> _objects = new LinkedList<Sprite>();
            private LinkedList<Sprite> _selectedObjects = new LinkedList<Sprite>();
            bool _multiSelection = false;

            /// <summary>
            /// Selection getter
            /// </summary>
            public LinkedList<Sprite> SelectedObjects
            {
                get { return _selectedObjects; }
            }

            /// <summary>
            /// Manager initialisation
            /// </summary>
            public virtual void Initialize(TouchTarget touchTarget, bool multiSelection = false)
            {
                _multiSelection = multiSelection;
            }

            public void register(Sprite s)
            {
                s.Manager = this;
                _objects.AddLast(s);
            }

            /// <summary>
            /// Met à jour les variables des sprites
            /// </summary>
            /// <param name="gameTime">Le GameTime associé à la frame</param>
            public void Update(GameTime gameTime)
            {
                foreach (Sprite obj in _objects)
                {
                    obj.Update(gameTime);
                }
            }

            /// <summary>
            /// Dessine les sprites en utilisant ses attributs et le spritebatch donné
            /// </summary>
            /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
            /// <param name="gameTime">Le GameTime de la frame</param>
            public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
            {
                foreach (Sprite obj in _objects)
                {
                    obj.Draw(spriteBatch, gameTime);
                }

                foreach (Sprite obj in _selectedObjects)
                {
                    Rectangle rect = new Rectangle((int)obj.Position.X, (int)obj.Position.Y, obj.Size.Width, obj.Size.Height);
                    spriteBatch.Draw(obj.Texture, rect, Microsoft.Xna.Framework.Color.Orange);
                }
            }

            public void TouchedSpriteEvent(Sprite s)
            {
                if (_selectedObjects.Contains(s))
                    _selectedObjects.Remove(s);
                else
                {
                    if (!_multiSelection)
                    {
                        _selectedObjects.Clear();
                    }
                    _selectedObjects.AddLast(s);
                }
            }
        }
    }
}
