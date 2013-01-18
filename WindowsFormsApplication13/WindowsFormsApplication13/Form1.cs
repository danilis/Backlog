using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;





namespace WindowsFormsApplication13
{
    
    public partial class Form1 : Form
    {
        private int comboload = 0;

        public Form1()
        {
            InitializeComponent();
            Form1Tasks Ftasks = Form1Tasks.getInstance(TaskDataGridView);//new Form1Tasks(TaskDataGridView);
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
            isLoaded = true;
        }



        //////////////////  Dima    //////////////////////////////////////////////

        private void SaveData()
        {
            StoryToDb();
            TaskToDB();
            //RedrawGraph();
            //MessageBox.Show("Data saved to database");
        }

        private void TaskToDB()
        {
            if (!IfTaskGreedChanged())
                return;

            DataManager dm = new DataManager();
            MathManager mm = new MathManager();
            //int col = 4;
            //int rows = taskDataGridView.Rows.Count;
            //int col;
            int rows;

            if (Convert.ToInt32(updatedTaskIndexes.Count.ToString()) == 0) // no changes were found, there fore no need to save any data
                return;
            
            //string[] read = new string[4];

            
            for(int i = 0; i < Convert.ToInt32(updatedTaskIndexes.Count.ToString()); i++)
                {
                    rows = updatedTaskIndexes.ElementAt(i).getRow();
                    int task_ID = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[1].Value.ToString());
                    if (mm.isTask_Id_Exist(task_ID) >= 0)
                    { //     task already exist, therefore we need only to update
                        int storyId = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[0].Value.ToString());
                        if (mm.isTask_Story_IDValid(storyId) >= 0)
                        {
                            int ans = dm.TaskSetTaskStoryID(task_ID, storyId);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Story id at line:" + (rows + 1));
                            updatedTaskIndexes.RemoveAt(i);
                            return;
                        }

                        int priority = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[2].Value.ToString());
                        if (mm.isTask_PriorityValid(priority) >= 0)
                        {
                            dm.TaskSetTaskPriority(task_ID, priority);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Priority value at line:" + (rows + 1));
                            updatedTaskIndexes.RemoveAt(i);
                            return;
                        }

                        string descriptions = taskDataGridView.Rows[rows].Cells[5].Value.ToString();
                        dm.TaskSetTaskDescription(task_ID, descriptions);

                        int ownerId = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[3].Value.ToString());
                        if (mm.isTask_Ovner_IdValid(ownerId) >= 0)
                        {
                            dm.TaskSetTaskOwner(task_ID, ownerId);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Owner Id at line:" + (rows + 1));
                            updatedTaskIndexes.RemoveAt(i);
                            return;
                        }
                    }
                    else
                    {
                        int storyId = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[0].Value.ToString());
                        int priority = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[2].Value.ToString());
                        string descriptions = taskDataGridView.Rows[rows].Cells[5].Value.ToString();
                        int ownerId = Convert.ToInt32(taskDataGridView.Rows[rows].Cells[3].Value.ToString());

                        int ans = dm.TaskAddNewTask(storyId, priority, descriptions,
                                                    ownerId);

                        MessageBox.Show("Added");
                        if (ans == -1)
                        {
                            MessageBox.Show("Error while creating new task");
                            updatedTaskIndexes.RemoveAt(i);
                            return;
                        }
                    }
            }
            int size = Convert.ToInt32(updatedTaskIndexes.Count.ToString());
            for (int i = 0; i < size; i++)
            {
                updatedTaskIndexes.RemoveAt(0);
            }
        }

        private void StoryToDb()
        {
            //systemId = storydataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["SystemId"].Value.ToString();
            string id = storyDataGridView.Rows[0].Cells[0].Value.ToString();
            
            if (!IfStoryGreedChanged())
                return;
            DataManager dm = new DataManager();
            MathManager mm = new MathManager();

            int rows;

            if (Convert.ToInt32(updatedStoryIndexes.Count.ToString()) == 0) // no changes were found, there fore no need to save any data
                return;
            
            //string[] read = new string[4];

            
            for(int i = 0; i < Convert.ToInt32(updatedStoryIndexes.Count.ToString()); i++)
                {
                    rows = updatedStoryIndexes.ElementAt(i).getRow();
                    //MessageBox.Show("6: " + storyDataGridView.Rows[rows].Cells[6].Value.ToString() + "1: " + storyDataGridView.Rows[rows].Cells[1].Value.ToString());
                    int story_ID = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[0].Value.ToString());
                    if (mm.isStory_Id_Exist(story_ID) >= 0)
                    {
                        int programmerID = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[2].Value.ToString());
                        if (mm.isProgrammer_Id_Exist(Convert.ToInt32(programmerID)) >= 0)
                        {
                            dm.StorySetOwnerID(story_ID, programmerID);
                        }
                        else
                        {
                            MessageBox.Show("Invalid story owner ID at line: " + (rows + 1));
                            return;
                        }
                        // if (mm.isStory_current_Sprint_valid(DateTime.Parse(read[1])) >= 0)
                        //{
                        dm.StorySetCurrentSprint(story_ID, DateTime.Parse(storyDataGridView.Rows[rows].Cells[3].Value.ToString()));
                        //}
                        /*else
                        {
                            MessageBox.Show("Invalid date of story_current_sprint at line: " + (i + 1));
                            return;
                        }*/
                        //dm.StorySetStoryDemoDes(story_ID, storyDataGridView.Rows[rows].Cells[4].Value.ToString());
                        //dm.StorySetStoryDemoPic(story_ID);
                        dm.StorySetStoryDescription(story_ID, storyDataGridView.Rows[rows].Cells[6].Value.ToString());
                        //MessageBox.Show("Passed here");
                        int priority = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[1].Value.ToString());
                        if (mm.isTask_PriorityValid(priority) >= 0)
                        {
                            dm.StorySetStoryPriority(story_ID, priority);
                        }
                        else
                        {
                            MessageBox.Show("Invalid priority value at line: " + (rows + 1));
                            return;
                        }
                        int workStatus = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[7].Value.ToString());
                        dm.StorySetStoryWorkStatus(story_ID, workStatus);
                    }
                    else
                    {
                        int workStatus = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[7].Value.ToString());
                        int priority = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[1].Value.ToString());
                        
                        int programmerID = Convert.ToInt32(storyDataGridView.Rows[rows].Cells[2].Value.ToString());

                        int ans = dm.StoryAddNewStory(programmerID, DateTime.Parse(storyDataGridView.Rows[rows].Cells[3].Value.ToString()), storyDataGridView.Rows[rows].Cells[4].Value.ToString(), null, storyDataGridView.Rows[rows].Cells[6].Value.ToString(),
                                                     priority, workStatus);
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
            TeamSettings NewTeamSettingsWindow = new TeamSettings();
            NewTeamSettingsWindow.Show();
        }

        private void storyBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (comboload == 0)
            {
                DataManager dManager = new DataManager();
                //(storyDataGridView[2, e.RowIndex] as DataGridViewComboBoxCell).d = dManager.ProgrammerGetAllProgrammers;
                SqlConnection conn = new SqlConnection(Settings1.Default.connection_string);
                string q = "Select Programmer_id From Programmer";
                SqlDataAdapter da = new SqlDataAdapter(q, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                q = "Select Story_ID From Story";
                SqlDataAdapter da2 = new SqlDataAdapter(q, conn);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                for (int i2 = 0; i2 < dt2.Rows.Count; i2++)
                {
                    //(storyDataGridView[2, e.RowIndex] as DataGridViewComboBoxCell).DataSource = dt;
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        (storyDataGridView[2, i2] as DataGridViewComboBoxCell).Items.Add(
                            dt.Rows[i1]["Programmer_id"]);
                        MessageBox.Show("dt.Rows[i1][Programmer_id] " + dt.Rows[i1]["Programmer_id"]);
                    }
                }

                //(storyDataGridView[2, e.RowIndex] as DataGridViewComboBoxCell).DataSource = dt;
                (storyDataGridView[2, e.RowIndex] as DataGridViewComboBoxCell).Items.Add(dt.Rows[0]["Programmer_id"]);
                comboload = 1;
            }
            */
           
        }

        private void storyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.storyBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.database1DataSet1);
            SaveData();     // store data to DB
        }

        private void bugsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugsReport progWindow = new BugsReport();
            progWindow.Show();
        }


        private void DataGridView1_TaskCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoaded == true)
            {
                Index ind = new Index(Convert.ToInt32(e.RowIndex.ToString()),Convert.ToInt32(e.ColumnIndex.ToString()));
                for (int i = 0; i < updatedTaskIndexes.Count(); i++)
                {
                    if (updatedTaskIndexes.ElementAt(i).getRow() == ind.getRow())
                        return;
                }
                //MessageBox.Show("adding point");
                updatedTaskIndexes.Add(ind);
            }
        }




        private void DataGridView1_StoryCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoaded == true)
            {
                Index ind = new Index(Convert.ToInt32(e.RowIndex.ToString()), Convert.ToInt32(e.ColumnIndex.ToString()));
                for (int i = 0; i < updatedStoryIndexes.Count(); i++)
                {
                    if (updatedStoryIndexes.ElementAt(i).getRow() == ind.getRow())
                        return;
                }
                updatedStoryIndexes.Add(ind);
            }
        }


        private void DataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Update the balance column whenever rows are deleted.
            //UpdateBalance();
        }
		
		private void taskDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                var str = taskDataGridView[e.ColumnIndex, e.RowIndex].Value as string; ;

                //MessageBox.Show("str = " + str);

                DataManager dm = new DataManager();

                DateTime date = Settings1.Default.startCurrentSprint;

                var ownerStr = Convert.ToInt32(taskDataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[3].Value.ToString());//taskDataGridView[taskDataGridView.Columns[3].Index, e.RowIndex].Value;

                int owner = ((int)ownerStr);

                dm.WorkHoursAddProgrammerWorkHoursForDay(owner, int.Parse(str), date.AddDays(e.ColumnIndex - 6));

            }
            catch
            {
                //MessageBox.Show("str = null");
            }

        }


    }
}
