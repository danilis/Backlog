using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public partial class BugsReport : Form
    {
        public BugsReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Random a = new Random();
            int newW = a.Next(button1.Width, this.Width - button1.Width*2);
            int newH = a.Next(button1.Height, this.Height - button1.Height);
            this.button1.Location = new System.Drawing.Point(newH, newW);
        }
    }
}
