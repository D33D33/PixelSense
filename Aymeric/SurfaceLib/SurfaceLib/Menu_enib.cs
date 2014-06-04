using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enib.SurfaceLib;
using Microsoft.Xna.Framework;
using Microsoft.Surface.Core;

namespace Enib
{
    namespace SurfaceLib
    {
        public class Menu_enib
        {
            public Sprite _caller;
            public List<Sprite> _sprites = new List<Sprite>();
         
        
            public Menu_enib(Sprite c)
            {
                this._caller = c;
            }

            /// <summary>
            /// Setter of _caller
            /// </summary>
            /// <param name="caller">Le sprite attaché au menu</param>
            public void setCaller(Sprite caller)
            {
                this._caller = caller;
            }

            /// <summary>
            /// Ajoute des choix au menu
            /// </summary>
            /// <param name="sprite">sprite à ajouter comme choix du menu</param>
            public void addSprite(Sprite sprite)
            {
                _sprites.Add(sprite);
                foreach (Sprite e in _sprites)
                {
                    e.setMenuPart();
                    e.Dragable = false;
                    e.MenuCaller = this;
                }
            }

            /// <summary>
            /// Dispose le menu correctement
            /// </summary>
            public void Dispose()
            {
                int last_position_x = (int)_caller.Position.X +(int)_caller.Texture.Width / 4;
                int last_position = (int)_caller.Position.Y; //+ (int)_caller.Texture.Height/4;
                int last_heigth = (int)_sprites.First().Size.Height;

                foreach (Sprite e in _sprites)
                {
                    e.Position = new Vector2(last_position_x, last_position + last_heigth);
                    last_position = (int)e.Position.Y;
                    last_heigth = e.Size.Height;
                }                
            }

            /// <summary>
            /// Cache le menu 
            /// </summary>
            public void Hide()
            {
                foreach (Sprite e in _sprites)
                {
                    e.Position = new Vector2(-100, -100);
                }

            }

            /// <summary>
            /// Affiche le menu 
            /// </summary>
            public void Show()
            {
                this.Dispose();
            }
        }
    }
}