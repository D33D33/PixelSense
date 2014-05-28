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
        public class Behaviour
        {
            int _screenWidth, _screenHeight;
            public Behaviour()
            {
            }
            public virtual void Update(LinkedList<Sprite> objects, LinkedList<Sprite> selection, LinkedList<MyTouchPoint> touchPoints)
            {

            }
        }
    }
}
