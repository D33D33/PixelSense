using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace MonJoliPortavion.Resources
{
    public class AircraftCarrier : Vehicule
    {
        private List<Aircraft> _aircrafts = new List<Aircraft>();
        private AircraftCarrierWindow AirCarrierWindow = new AircraftCarrierWindow();
        private int Tester;
        


        public AircraftCarrier(int screenWidth, int screenHeight)
            : base(screenWidth, screenHeight)
        { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HideMessage();

          
        }


        public override void Touched(object sender, EventArgs e)
        {

           
            showMessage();
       }

        public void showMessage()
        {
           AirCarrierWindow.ShowDialog();
            
        }

        public override void TouchedMove(object sender, EventArgs e)
        {
            HideMessage();
        }

        public void HideMessage()
        {
            //AirCarrierWindow.Visible = false;
            //this.AirCarrierWindow.Close();
        }

        
     /*   public void showMessageTest()
        {
            Tester++;
            if (Tester == 15) 
            {
                this.AirCarrierWindow.ShowDialog();
            }
        }*/
    }
}
