using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonJoliPortavion.Resources;

namespace MonJoliPortavion
{
    public partial class AircraftCarrierWindow : Form
    {

        public AircraftCarrierWindow()
        {
            InitializeComponent();
         
        }

        private void AircraftCarrierWindow_Load(object sender, EventArgs e)
        {

        }

        private void currentAction_Click(object sender, EventArgs e)
        {
            if (currentAction.Text == "Sail")
            {
                currentAction.Text = "Moor";
            }
            else 
                currentAction.Text = "Sail";
        }

        private void AttackAction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No target",
               "Action Impossible",
               MessageBoxButtons.RetryCancel,
               MessageBoxIcon.Exclamation);
        }

        protected virtual void OnFormClosed(FormClosedEventArgs e)
    {
        this.Hide();
    }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
