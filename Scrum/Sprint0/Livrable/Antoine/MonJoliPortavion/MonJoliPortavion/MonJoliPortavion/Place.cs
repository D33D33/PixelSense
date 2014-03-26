using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonJoliPortavion
{
    abstract class Place : Sprite
    {
        private bool _used;
        public abstract void ShowAction();
        public abstract void PerformAction();

    }
}
