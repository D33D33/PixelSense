using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonJoliPortavion
{
    public abstract class Vehicule : Sprite
    {        
        
        protected int _screenWidth;
        protected int _screenHeight;
        
        public Vehicule(int screenWidth, int screenHeight)
        {   
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public override void LoadContent(ContentManager content, string assetName)
        {
            base.LoadContent(content, assetName);
            Position = new Vector2(_screenWidth / 2 - Texture.Width/2, _screenHeight / 2 - Texture.Height / 2);
        }
    }
}
