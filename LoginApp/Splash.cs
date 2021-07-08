using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Splash : Form
    {
        
        public Splash()
        {
            InitializeComponent();
        }

        Timer tmr;
        private void Splash_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            //hide this form
            this.Hide();
        }
    }
}
