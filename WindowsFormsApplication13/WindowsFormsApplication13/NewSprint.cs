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
    public partial class NewSprint : Form
    {
        public NewSprint()
        {
            InitializeComponent();
        }

        private void dateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dateBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void NewSprint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Sprint' table. You can move, or remove it, as needed.
            this.sprintTableAdapter.Fill(this.database1DataSet1.Sprint);
            // TODO: This line of code loads data into the 'database1DataSet1.Date' table. You can move, or remove it, as needed.
            //this.dateTableAdapter.Fill(this.database1DataSet1.Date);

        }

        private void sprint_Finish_DayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            int rowCounter = 1;
            
            //dateDataGridView.Rows.Add("11/12/12","work");
            
            DataGridViewRow row = dateDataGridView.Rows[rowCounter - 1];
            
            //row.Cells[0].Value = sprint_Finish_DayDateTimePicker.Value.ToLongDateString();
            //row.Cells[1].Value = dataGridViewTextBoxColumn1.Items[0];
            //row.Cells[1].Value = 1;

            //dateDataGridView.BeginEdit(true);
            //dateDataGridView.EndEdit();


            //this.dateTableAdapter.Insert(1, sprint_Finish_DayDateTimePicker.Value.Date);
           // this.dateTableAdapter.Insert(2, sprint_Beginning_DayDateTimePicker.Value.Date);
            //this.dateTableAdapter.Insert(2, sprint_Finish_DayDateTimePicker.Value.Date);




            //DateTime start = sprint_Beginning_DayDateTimePicker.Value.Date;
            //DateTime end = sprint_Finish_DayDateTimePicker.Value.Date;

            ////for (int i = 0; (DateTime.Compare(start, end) != 0) || (i < 20); i++)
            ////{
            //this.dateTableAdapter.Insert(1, end.AddDays(0));
            //this.dateTableAdapter.Insert(1, start.AddDays(1));
            //this.dateTableAdapter.Insert(1, start.AddDays(2));
            //this.dateTableAdapter.Insert(1, start.AddDays(3));
            //}

            /*dateDataGridView.Update();

            this.sprintTableAdapter.Update(this.database1DataSet1.Sprint);//??

            this.dateTableAdapter.Update(this.database1DataSet1.Date);//??

            dateBindingNavigatorSaveItem_Click(sender, e);
            */

        }

        private void sprint_Beginning_DayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = sprint_Beginning_DayDateTimePicker.Value.Date;
            DateTime end = sprint_Finish_DayDateTimePicker.Value.Date;

            /*if (DateTime.Compare(start, end) != 0)
                MessageBox.Show("(DateTime.Compare(start, end) = " + (DateTime.Compare(start, end)));
            else
                MessageBox.Show("equals = " + (DateTime.Compare(start, end)));
            */
            try
            {
                for (int i = 0; (DateTime.Compare(start, end) != 0) && (i < 50); i++)
                {
                    this.dateTableAdapter.Insert(1, start.AddDays(i));
                }
            }
            catch(Exception)
            {
            }


            dateDataGridView.Update();

            dateBindingNavigatorSaveItem_Click(sender, e);

            this.sprintTableAdapter.Update(this.database1DataSet1.Sprint);//??

            this.dateTableAdapter.Update(this.database1DataSet1.Date);//??

            this.dateTableAdapter.Fill(this.database1DataSet1.Date);

            this.Update();

            //Properties.Settings.Default.;
        }
    }
}
