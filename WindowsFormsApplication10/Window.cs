using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            //TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            //F/orm1 f1 = new Form1();
            new Form1().TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;


            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           // Form1 f1 = new Form1();
            new Form1().TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            new Form1().Label1.Text = "Done";
        }
    }
}
