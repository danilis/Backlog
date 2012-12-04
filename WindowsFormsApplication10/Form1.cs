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
    public partial class Form1 : Form
    {
        //Form2 ViewForm2 = new Form2();

        public Form1()
        {
            InitializeComponent();
            //ViewForm2.MdiParent = this;
        }

        private void dataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.mainView' table. You can move, or remove it, as needed.
            this.mainViewTableAdapter.Fill(this.database1DataSet.mainView);
            // TODO: This line of code loads data into the 'database1DataSet.mainView' table. You can move, or remove it, as needed.
            this.mainViewTableAdapter.Fill(this.database1DataSet.mainView);
            // TODO: This line of code loads data into the 'database1DataSet.Task' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.database1DataSet.Task);
            // TODO: This line of code loads data into the 'database1DataSet.Data' table. You can move, or remove it, as needed.
            this.dataTableAdapter.Fill(this.database1DataSet.Data);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void a1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2.Show();
            //ViewForm2.Show();
            new Form2().Show();
            
        }

        private void dataDataGridView_Click(object sender, EventArgs e)
        {
            
        }

        private void a2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void mainViewDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Window a = new Window();
            a.Show();
            a.RadioButton2.Checked = true;
        }



    }

    class numberOfNewCall
    {
    }
}
