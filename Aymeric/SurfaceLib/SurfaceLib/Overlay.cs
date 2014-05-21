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
        public abstract class Overlay
        {
            protected Texture2D _dummyTexture;
            protected Rectangle _dummyRectangle;
            protected Color _colori;
            protected Game _game;

            public virtual Rectangle Rectangle
            {
                get { return _dummyRectangle; }
                set { _dummyRectangle = value; }
            }

            public Overlay(Rectangle rect, Color colori, Game game)
            {
                _dummyRectangle = rect;
                _colori = colori;
                _game = game;
            }

            public abstract void LoadContent();

            public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

            public abstract void GetSelection(LinkedList<Sprite> objects, LinkedList<Sprite> ioSelection);
        }
    }
}
