using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LoginApp
{
    public class Confirmation
    {
        
        public static DialogResult Confirm()
        {
            var confirmResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                return DialogResult.Yes;
            }
            else
            {
                return DialogResult.No;
            }
        }
    }
}
