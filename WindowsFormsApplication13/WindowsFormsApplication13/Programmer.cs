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
    public partial class Programmer : Form
    {
        public Programmer()
        {
            InitializeComponent();
        }

        private void programmerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.programmerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);
            this.tableAdapterManager.ProgrammerTableAdapter.GetData();
            SaveData();
            //var a = database1DataSet1.GetChanges();
            //DataManager.update_programmer_name(3, "asd");

        }



        //////////////////  Dima    //////////////////////////////////////////////

        private void SaveData()
        {
            ProgrammerToDB();
            //MessageBox.Show("Data saved to database");
        }

        private void ProgrammerToDB()
        {
            if (!IfProgrammerGreedChanged())
                return;

            DataManager dm = new DataManager();
            MathManager mm = new MathManager();
            int col = 3;
            int rows = programmerDataGridView.Rows.Count;
            string[] read = new string[col];
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    read[j] = programmerDataGridView.Rows[i].Cells[j + 1].Value.ToString();
                }
                /*for (int j = 0; j < col; j++)
                {
                    if (j == 2)
                        continue; // description might be null
                    if (read[j] == null)
                        return;
                }*/
                int programmer_ID = Convert.ToInt32(programmerDataGridView.Rows[i].Cells[0].Value.ToString());
                if (mm.isProgrammer_Id_Exist(programmer_ID) >= 0)
                { // task already exist, therefore we need only to update
                    if (mm.isProgrammerNameValid(read[0]) == true)
                    {
                        dm.ProgrammerUpdateProgrammerName(programmer_ID, read[0]);
                    }
                    else
                    {
                        MessageBox.Show("Invalid programmer name at line:" + (i + 1));
                        return;
                    }

                    dm.ProgrammerUpdateProgrammerExpectedWorkHours(programmer_ID,Convert.ToDouble(read[1]));
                    dm.ProgrammerUpdateProgrammerCurrentWorkHours(programmer_ID, Convert.ToDouble(read[2]));
                }
                else
                {
                    int ans = dm.ProgrammerAddNewProgrammer(read[0], Convert.ToInt32(read[1]), Convert.ToInt32(read[2]));
                    if (ans == -1)
                    {
                        MessageBox.Show("Error adding new programmer");
                        return;
                    }
                }
            }    
        }

  
        private bool IfProgrammerGreedChanged()
        {
            if (programmerDataGridView.Rows.Count == 1)
                return false;

            return true;
        }
        //////////////////  Dima    //////////////////////////////////////////////

        private void Programmer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Programmer' table. You can move, or remove it, as needed.
            this.programmerTableAdapter.Fill(this.database1DataSet1.Programmer);

        }
    }
}
