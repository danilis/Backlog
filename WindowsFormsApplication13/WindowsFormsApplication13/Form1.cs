using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void programmerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.Story' table. You can move, or remove it, as needed.
            this.storyTableAdapter1.Fill(this.database1DataSet2.Story);
            // TODO: This line of code loads data into the 'database1DataSet.Task' table. You can move, or remove it, as needed.
            this.taskTableAdapter1.Fill(this.database1DataSet.Task);
           
            //Form1Window.InitializeComponent();
            
            //Thread.Sleep(3000);

            //Form1Window.Dispose();

            //Form1Window.progressBar1.Increment(10);

            /*
            Thread.Sleep(1000);
            progressBar1.Increment(20);
            Thread.Sleep(1000);
            progressBar1.Increment(10);
            Thread.Sleep(1000);
            progressBar1.Increment(50);
            Thread.Sleep(1000);
            progressBar1.Increment(10);
            */


            // TODO: This line of code loads data into the 'database1DataSet1.Task' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.database1DataSet1.Task);
            // TODO: This line of code loads data into the 'database1DataSet1.Sprint' table. You can move, or remove it, as needed.
            this.sprintTableAdapter.Fill(this.database1DataSet1.Sprint);
            // TODO: This line of code loads data into the 'database1DataSet1.Programmer' table. You can move, or remove it, as needed.
            this.programmerTableAdapter.Fill(this.database1DataSet1.Programmer);
            // TODO: This line of code loads data into the 'database1DataSet1.Story' table. You can move, or remove it, as needed.
            this.storyTableAdapter.Fill(this.database1DataSet1.Story);
            // TODO: This line of code loads data into the 'database1DataSet1.Programmer' table. You can move, or remove it, as needed.

        }



        //////////////////  Dima    //////////////////////////////////////////////

        private void SaveData()
        {
            StoryToDb();
            TaskToDB();
            RedrawGraph();
            //MessageBox.Show("Data saved to database");
        }

        private void TaskToDB()
        {
            if (!IfTaskGreedChanged())
                return;

            DataManager dm = new DataManager();
            MathManager mm = new MathManager();
            int col = 4;
            int rows = taskDataGridView.Rows.Count;
            string[] read = new string[4];
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    read[j] = taskDataGridView.Rows[i].Cells[j + 1].Value.ToString();
                }
                for (int j = 0; j < col; j++)
                {
                    if (j == 2)
                        continue; // description might be null
                    if (read[j] == null)
                        return;
                }
                int task_ID = Convert.ToInt32(taskDataGridView.Rows[i].Cells[0].Value.ToString());
                if (mm.isTask_Id_Exist(task_ID) >= 0)
                { // task already exist, therefore we need only to update
                    if (mm.isTask_Story_IDValid(Convert.ToInt32(read[0])) >= 0)
                    {
                        int ans = dm.TaskSetTaskStoryID(task_ID, Convert.ToInt32(read[0]));
                    }
                    else
                    {
                        MessageBox.Show("Invalid Story id at line:" + (i+1));
                        return;
                    }

                    if (mm.isTask_PriorityValid(Convert.ToInt32(read[1])) >= 0)
                    {
                        dm.TaskSetTaskPriority(task_ID, Convert.ToInt32(read[1]));
                    }
                    else
                    {
                        MessageBox.Show("Invalid Priority value at line:" + (i + 1));
                        return;
                    }
                    dm.TaskSetTaskDescription(task_ID, read[2]);
                    if (mm.isTask_Ovner_IdValid(Convert.ToInt32(read[3])) >= 0)
                    {
                        dm.TaskSetTaskOwner(task_ID, Convert.ToInt32(read[3]));
                    }
                    else
                    {
                        MessageBox.Show("Invalid Owner Id at line:" + (i+1));
                        return;
                    }
                }
                else
                {
                    int ans = dm.TaskAddNewTask(Convert.ToInt32(read[0]), Convert.ToInt32(read[1]), read[2],
                                                Convert.ToInt32(read[3]));
                    if (ans == -1)
                    {
                        MessageBox.Show("Error while creating new task");
                        return;
                    }
                }
            }
        }

        private void StoryToDb()
        {
            if (!IfStoryGreedChanged())
                return;
            DataManager dm = new DataManager();
            MathManager mm = new MathManager();
            int cols = 7;
            int rows = storyDataGridView.RowCount;
            string[] read = new string[cols];
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    read[j] = storyDataGridView.Rows[i].Cells[j + 1].Value.ToString();
                }
                for (int j = 0; j < cols; j++)
                {
                    if (j == 2 || j == 3)
                        continue; // description might be null
                    if (read[j] == null)
                        return;
                }
                int story_ID = Convert.ToInt32(storyDataGridView.Rows[i].Cells[0].Value.ToString());
                if (mm.isStory_Id_Exist(story_ID) >= 0)
                {
                    if(mm.isProgrammer_Id_Exist(Convert.ToInt32(read[0])) >= 0)
                    {
                        dm.StorySetOwnerID(story_ID, Convert.ToInt32(read[0]));
                    }
                    else
                    {
                        MessageBox.Show("Invalid story owner ID at line: "+ (i+1));
                        return;
                    }
                   // if (mm.isStory_current_Sprint_valid(DateTime.Parse(read[1])) >= 0)
                    //{
                        dm.StorySetCurrentSprint(story_ID, DateTime.Parse(read[1]));
                    //}
                    /*else
                    {
                        MessageBox.Show("Invalid date of story_current_sprint at line: " + (i + 1));
                        return;
                    }*/
                    dm.StorySetStoryDemoDes(story_ID, read[2]);
                    //dm.StorySetStoryDemoPic(story_ID);
                    dm.StorySetStoryDescription(story_ID, read[4]);
                    if (mm.isTask_PriorityValid(Convert.ToInt32(read[5])) >= 0)
                    {
                        dm.StorySetStoryPriority(story_ID, Convert.ToInt32(read[5]));
                    }
                    else
                    {
                        MessageBox.Show("Invalid priority value at line: " + (i + 1));
                        return;
                    }
                    dm.StorySetStoryWorkStatus(story_ID, Convert.ToInt32(read[6]));
                }
                else
                {
                    int ans = dm.StoryAddNewStory(Convert.ToInt32(read[0]), DateTime.Parse(read[1]), read[2], null, read[4],
                                                  Convert.ToInt32(read[5]), Convert.ToInt32(read[6]));
                    if (ans == -1)
                    {
                        MessageBox.Show("Error while creating new story");
                        return;
                    }
                }
            }
        }

        private bool IfStoryGreedChanged()
        {
            if (storyDataGridView.Rows.Count == 1)
                return false;

            return true;
        }

        private bool IfTaskGreedChanged()
        {
            if (taskDataGridView.Rows.Count == 1)
                return false;

            return true;
        }
        //////////////////  Dima    //////////////////////////////////////////////
        /// 
        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Programmer progWindow = new Programmer();
            progWindow.Show();
        }

        private void newSprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSprint NewSprintWindow = new NewSprint();
            NewSprintWindow.Show();
        }

        private void teamSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void storyBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void storyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.storyBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.database1DataSet1);
            SaveData();     // store data to DB
        }




    }
}
