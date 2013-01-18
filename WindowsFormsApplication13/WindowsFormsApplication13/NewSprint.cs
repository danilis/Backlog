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

        private System.Windows.Forms.DataGridViewTextBoxColumn taskDescriptionDataGridViewTextBoxColumn2;
        private const int MAX_DAYS_IN_SPRINT = 500;

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
            DataManager dm = new DataManager();

            DateTime start = sprint_Beginning_DayDateTimePicker.Value.Date;
            DateTime end = sprint_Finish_DayDateTimePicker.Value.Date;

            MessageBox.Show(start.ToString("dd.MM.yy\n") + end.ToString("dd.MM.yy\n"));

            Settings1.Default.startCurrentSprint = start;
            Settings1.Default.endCurrentSprint = end;

            Form1Tasks Ftasks = Form1Tasks.getInstance(null);

            long comRes = end.Ticks -  start.Ticks;
            if ( comRes <= 0)
            {
                MessageBox.Show("start date mast be before the end date");
                throw new Exception();
            }

            try
            {
                // add to sprint table
                if (dm.SprintAddNewSprint(start, end) == -1)
                    throw new Exception();

                this.sprintTableAdapter.Update(this.database1DataSet1.Sprint);

                this.sprintTableAdapter.Fill(this.database1DataSet1.Sprint);

                Ftasks.Form1TasksUpdate(start, end);
            }
            catch
            {
                MessageBox.Show("exeption this.sprintTableAdapter.Insert(start, end);");
            }
            string str = "";
            

            try
            {
                for (int i = 0; (DateTime.Compare(start.AddDays(i), end) != 0) && (i < MAX_DAYS_IN_SPRINT); i++)
                {
                    this.dateTableAdapter.Insert(1, start.AddDays(i));

                    str += (start.ToString("dd.MM.YY")+ "was add\n");

                    dateDataGridView.Update();

                    dateBindingNavigatorSaveItem_Click(sender, e);

                    

                    this.dateTableAdapter.Update(this.database1DataSet1.Date);

                    this.dateTableAdapter.Fill(this.database1DataSet1.Date);

                    this.Update();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("exeption " + str);
            }


            dateDataGridView.Update();

            dateBindingNavigatorSaveItem_Click(sender, e);

            this.sprintTableAdapter.Update(this.database1DataSet1.Sprint);//??

            this.dateTableAdapter.Update(this.database1DataSet1.Date);//??

            this.dateTableAdapter.Fill(this.database1DataSet1.Date);

            this.Update();

            //DataManager dm = new DataManager();

            dm.SprintAddNewSprint(start, end);

            //Properties.Settings.Default.;*/
        }
    }
}
