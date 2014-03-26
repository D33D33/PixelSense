using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tuto_fenetre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("J'ai une question pour toi",
                "message de ton ordi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
        }

        private void m_myTestButton_Click(object sender, EventArgs e)
        {
            m_myTestButton.Text = "ahahah t'es con!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Bien deviné!";
        }
    }
}
