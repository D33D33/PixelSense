using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonJoliPortavion
{
    class Aircraft : Vehicule
    {
        private int _missiles;
        private bool _readyToFly;
        private Place _place;

        public Aircraft(int screenWidth, int screenHeight)
            : base(screenWidth, screenHeight)
        {
        }

    }
}
