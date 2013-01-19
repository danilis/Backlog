using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public class DataManager
    {
        // string connection to Database
        static string CONNECTION_STRING = Settings1.Default.connection_string; //@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\NATAN\Desktop\WindowsFormsApplication13\WindowsFormsApplication13\WindowsFormsApplication13\Database1.mdf;Integrated Security=True;User Instance=True";


        /*************************************************************************************************
         **************************  General  ************************************************************
         */

        public int GeneralGetMaximumTablesSize()
        {
            
            //change name to more readable
            int ans = 0;
            if (SprintGetTableLength() > maximumTablesSize)
                maximumTablesSize = SprintGetTableLength();
            if (TaskGetTaskTableLength() > maximumTablesSize)
                maximumTablesSize = TaskGetTaskTableLength();
            if (StoryGetStoryTableLength() > maximumTablesSize)
                maximumTablesSize = StoryGetStoryTableLength();
            if (ProgrammerGetProgrammerTableLength() > maximumTablesSize)
                maximumTablesSize = ProgrammerGetProgrammerTableLength();
            if (WorkHoursGetWorkHoursTableLength() > maximumTablesSize)
                maximumTablesSize = WorkHoursGetWorkHoursTableLength();
            if (StoryInSprintGetStoryInSprintTableLength() > maximumTablesSize)
                maximumTablesSize = StoryInSprintGetStoryInSprintTableLength();
            return maximumTablesSize;
        }

        /*************************************************************************************************
         **************************  Sprint  ************************************************************
         */


        //create new method for repetitive code 
        private int executeQuery(string query){
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int ans = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }
        
        
        
        
        public int SprintGetTableLength()
        {
            
            string query = "Select Count(*) From Sprint";
            return executeQuery(query);
            
        }


        // return Sprint length in days
        // if error return -1
        public int SprintGetLengthWorkingDays()
        {
            int ans = -1;
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return ans;
            }
            string qStr = "SELECT Count(*) FROM Date Where Date_Day_status = 1";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            SqlDataReader reader = sqlCom.ExecuteReader();
            if (reader.Read() == false)
                return 0;
            ans = reader.GetInt32(0);
            conn.Close();
            return ans;
        }

        // same as prev
        public int SprintGetLengthAllDays()
        {
            int ans = (int)Math.Floor((SprintGetEndingDay() - SprintGetBegginingDay()).TotalDays);
            return ans;
        }

        // return current sprint beggining day
        public DateTime SprintGetBegginingDay()
        {
            DateTime ans = DateTime.MinValue;
            DateTime today_date = DateTime.Today;
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return ans;
            }
            string qStr = "SELECT * FROM Sprint";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            SqlDataReader reader = sqlCom.ExecuteReader();
            DateTime end;
            while (reader.Read())
            {
                ans = (DateTime)reader[0];
                end = (DateTime)reader[1];
                if ((end - today_date).TotalDays > 0)   // if sprint end > current day then return ans
                {
                    break;
                }
            }
            reader.Close();
            conn.Close();
            return ans;
        }


        // return array with sprint days that are in Date table
        // if day_d doesnt exist array[day_d] = date.minvalue
        // return null if exception
        public DateTime[] SprintGetAllDays()
        {
            int max_sprint_days = DateGetTableLength();
            DateTime[] ans = new DateTime[max_sprint_days];
            int i = 0;
            for (; i < max_sprint_days; i++)
            {
                ans[i] = DateTime.MinValue;    // no day
            }
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string qStr = "SELECT Date_Day FROM Date";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            SqlDataReader reader = sqlCom.ExecuteReader();
            i = 0;
            while (reader.Read() && i < max_sprint_days)
            {
                //ans[i] = reader.GetDateTime(0);
                ans[i] = (DateTime)reader[0];
                i++;
            }
            reader.Close();
            conn.Close();
            return ans;
        }

        // return array of working days
        public DateTime[] SprintGetAllWorkingDays()
        {
            int max_sprint_days = SprintGetLengthWorkingDays();
            DateTime[] ans = new DateTime[max_sprint_days];
            int i = 0;
            for (; i < max_sprint_days; i++)
            {
                ans[i] = DateTime.MinValue;    // no day
            }
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string qStr = "SELECT Date_Day From Date Where Date_Day_status = 1";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            SqlDataReader reader = sqlCom.ExecuteReader();
            i = 0;
            while (reader.Read() && i < max_sprint_days)
            {
                //ans[i] = reader.GetDateTime(0);
                ans[i] = (DateTime)reader[0];
                i++;
            }
            reader.Close();
            conn.Close();
            return ans;
        }

        // return last day of current sprint
        // return null if error
        public DateTime SprintGetEndingDay()
        {
            DateTime ending = DateTime.MinValue;
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return ending;
            }
            DateTime begin = SprintGetBegginingDay();
            const string qStr = "SELECT Sprint_Finish_Day FROM Sprint Where Sprint_Beginning_Day = @date";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            sqlCom.Parameters.AddWithValue("@date", begin);
            SqlDataReader reader = sqlCom.ExecuteReader();
            reader.Read();
            //ending =  reader.GetDateTime(0);
            ending = (DateTime)reader[0];
            reader.Close();
            conn.Close();
            return ending;
        }

        // get number of days to sprint end
        // get ending day from sprint and get current day from date
        public int SprintGetRemainDays()
        {
            DateTime ending = SprintGetEndingDay();
            DateTime curr = DateGetCurrentDay();
            if (ending == DateTime.MinValue || curr == DateTime.MinValue)
                return -1;
            int ans = (int)Math.Floor((ending - curr).TotalDays);    /// calculation
            return ans;
        }


        //use created method
        public int SprintGetRemainWorkingDays()
        {
            DateTime ending = SprintGetEndingDay();
            DateTime curr = DateGetCurrentDay();
            if (ending == DateTime.MinValue || curr == DateTime.MinValue)
                return -1;
            string query = "SELECT Count(*) FROM Date Where Date_Day > @curr_day and Date_Day_status = 1";
            return executeQuery(query);
        }

        // return number of days passed from sprint beginnig
        public int SprintGetPassedAllDays()
        {
            int len = SprintGetLengthAllDays();
            int rem = SprintGetRemainDays();
            int ans = len - rem;
            return ans;
        }

        // return number of days passed from sprint beginnig
        public int SprintGetPassedWorkingDays()
        {
            int ans = SprintGetLengthWorkingDays() - SprintGetRemainWorkingDays();
            return ans;
        }

        // retun number of done hours
        public int SprintGetNumberOfWorkHours()
        {
            int ans = 0;
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string qStr = "SELECT Date_Day FROM Date Where Date_Day_status = 1";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            SqlDataReader reader = sqlCom.ExecuteReader();
            int temp;
            while (reader.Read())
            {
                //DateTime day = reader.GetDateTime(0);
                DateTime day = (DateTime)reader[0];
                if (day != DateTime.MinValue)
                {
                    temp = (int)WorkHoursGetAllWorkHoursForDay(day);
                    if (temp != -1)
                        ans += temp;
                }

            }
            conn.Close();
            return ans;
        }

        // return hours to finish sprint
        public int SprintGetAllRemainHours()
        {
            int all_hours = SprintGetAllExpectedHours();
            int worked_hours = SprintGetNumberOfWorkHours();
            if (all_hours == -1 || worked_hours == -1)
                return -1;
            return all_hours - worked_hours;     // all - current
        }

        // get expected work hours in sprint
        public int SprintGetAllExpectedHours()
        {
            int ans = 0;
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string qStr = "SELECT Programmer_Expected_Work_Hours FROM Programmer";
            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            SqlDataReader reader = sqlCom.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0] != null)
                    ans += Convert.ToInt32(reader[0].ToString());
                //ans += reader.GetInt32(0);
            }
            conn.Close();
            return ans;
        }

        // add new Sprint
        public int SprintAddNewSprint(DateTime start, DateTime end)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            if (start >= end)
                return -1;
            string str = "Insert Into Sprint (Sprint_Beginning_Day, Sprint_Finish_Day) values (@start, @end)";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@start", start);
            command.Parameters.AddWithValue("@end", end);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }


        /*************************************************************************************************
         **************************  Story  ************************************************************
         */

        // return number of stoies (size of sprint table)
        public int StoryGetStoryTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Count(*) From Story";
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == false)
                return 0;
            int ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }

        public int StoryAddNewStory(int Story_Owner, DateTime Current_Sprint, string Story_Demo_DES, Image Story_Demo_PIC, string Story_Description, int Story_Priority, int Story_Work_Status)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string curr_sprint_date = Current_Sprint.ToString();
            //string str = "Insert Into Story (Story_Owner, Story_Current_Sprint, Story_Demo_DES, Story_Demo_PIC, Story_Description, Story_Priority, Story_Work_Status) values (" + Story_Owner + ", @date, '" + Story_Demo_DES + "'," +null /* Story_Demo_PIC*/ + ", '" + Story_Description + "', " + Story_Priority + ", " + Story_Work_Status + ")";
            string str = "Insert Into Story (Story_Owner, Story_Current_Sprint, Story_Demo_DES, Story_Description, Story_Priority, Story_Work_Status) Values (" + Story_Owner + ", @date, '" + Story_Demo_DES + "', '" + Story_Description + "', " + Story_Priority + ", " + Story_Work_Status + ")";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@date", Current_Sprint);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            //StoryInSprintAddNewStoryInSprint(IDataGridColumnStyleEditingNotificationService, curr_sprint_date);
            return 0;
        }

        public int StoryGetOwnerID(int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Story_Owner From Story Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == false)
                return -1;
            int ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }

        public int StorySetOwnerID(int story_ID, int old_ID, int new_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Owner) values(" + new_ID + ") Where Story_ID = " + old_ID;
            string str = "Update Story Set Story_Owner=" + new_ID + " Where Story_ID = " + story_ID + " and Story_Owner =" + old_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int StorySetOwnerID(int story_ID, int new_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Owner) values(" + new_ID + ") Where Story_ID = " + old_ID;
            string str = "Update Story Set Story_Owner=" + new_ID + " Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            return 0;
        }


        public DateTime StoryGetCurrentSprint()
        {
            return SprintGetBegginingDay();
        }

        public DateTime StoryGetCurrentSprintForStoryID(int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            DateTime ans = DateTime.MinValue;
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return ans;
            }
            string str = "Select Story_Current_Sprint From Story Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == false)
                return ans;
            ans = (DateTime)reader[0];
            conn.Close();
            return ans;
        }

        public int StorySetCurrentSprint(int story_ID, DateTime day)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Current_Sprint) values(@day) Where Story_ID = " + story_ID;
            string str = "Update Story Set Story_Current_Sprint=@day Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public string StoryGetStoryDemoDes(int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string str = "Select Story_Demo_DES From Story Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string ans = reader[0].ToString();
            conn.Close();
            return ans;
        }

        public int StorySetStoryDemoDes(int story_ID, string des)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Demo_DES) values('" + des + "') Where Story_ID = " + story_ID;
            string str = "Update Story Set Story_Demo_DES='" + des + "' Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }



        public int StorySetStoryDemoPic(int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Demo_DES) values('" + des + "') Where Story_ID = " + story_ID;
            string str = "Update Story Set Story_Demo_PIC='" + null + "' Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }


        public string StoryGetStoryDescription(int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string str = "Select Story_Description From Story Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string ans = reader[0].ToString();
            conn.Close();
            return ans;
        }

        public int StorySetStoryDescription(int story_ID, string des)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Description) values('" + des + "') Where Story_ID = " + story_ID;
            string str = "Update Story Set Story_Description='" + des + "' Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }
    
    
        //use created method
        public int StoryGetStoryPriority(int story_ID)
        {
            string query = "Select Story_Priority From Story Where Story_ID = " + story_ID;
            return executeQuery(query;
        }

        public int StorySetStoryPriority(int story_ID, int priority)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story(Story_Description) values(" + priority + ") Where Story_ID = " + story_ID;
            string str = "Update Story Set Story_Description=" + priority + " Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int StorySetStoryWorkStatus(int story_ID, int status)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Story (Story_Work_Status) values(" + status + ") Where Story_ID = " + story_ID;
            string str = "Update Story Set Story_Work_Status=" + status + " Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int StoryGetStoryWorkStatus(int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Story_Work_Status From Story Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }

        public int[] StoryGetStoriesIDForStoryOwner(int OwnerID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }

            string str = "Select Count(*) From Story Where Story_Owner = " + OwnerID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int len = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            str = "Select Story_ID From Story Where Story_Owner = " + OwnerID;
            command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            int[] ans = new int[len];
            int i = 0;
            while (reader.Read() && i < len)
            {
                ans[i] = Convert.ToInt32(reader[0].ToString());
            }
            conn.Close();
            return ans;
        }


        /*************************************************************************************************
         **************************  Task  ************************************************************
         */

        public int TaskGetTaskTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            int ans;
            string str;
            SqlDataReader reader;
            str = "Select Count(*) From Task";
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            reader.Read();
            ans = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        // if not succeed return -1
        public int TaskAddNewTask(int Task_Story_ID, int Task_Priority, string Task_Description, int Task_Owner)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Insert into Task (Task_Story_ID, Task_Priority, Task_Description, Task_Ovner_Id) values (" + Task_Story_ID + ", " + Task_Priority + ", '" + Task_Description + "', " + Task_Owner + ")";
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int TaskSetTaskStoryID(int task_ID, int story_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Task (Task_Story_ID) values(" + story_ID + ") Where Task_ID = " + task_ID;
            string str = "Update Task Set Task_Story_ID=" + story_ID + " Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int TaskGetTaskStoryID(int task_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Task_Story_ID From Task Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }

        public int TaskSetTaskPriority(int task_ID, int priority)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Task (Task_Priority) values(" + priority + ") Where Task_ID = " + task_ID;
            string str = "Update Task Set Task_Priority=" + priority + " Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int TaskGetTaskPriority(int task_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Task_Priority From Task Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }

        public int TaskSetTaskDescription(int task_ID, string description)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Task (Task_Description) values('" + description + "') Where Task_ID = " + task_ID;
            string str = "Update Task Set Task_Description='" + description + "' Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public string TaskGetTaskDescription(int task_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string str = "Select Task_Description From Task Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string ans = reader[0].ToString();
            conn.Close();
            return ans;
        }

        public int TaskSetTaskOwner(int task_ID, int owner_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Task (Task_Ovner) values(" + owner_ID + ") Where Task_ID = " + task_ID;
            string str = "Update Task Set Task_Ovner_Id=" + owner_ID + " Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int TaskGetTaskOwner(int task_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Task_Ovner_Id From Task Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                int ans = Convert.ToInt32(reader[0].ToString());
                conn.Close();
                return ans;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        /*************************************************************************************************
         **************************  Programmer  ************************************************************
         */

        public int ProgrammerGetProgrammerTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            int ans;
            string str;
            SqlDataReader reader;
            str = "Select Count(*) From Programmer";
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            reader.Read();
            ans = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        public int[] ProgrammerGetAllProgrammers()
        {
            int[] ans = new int[ProgrammerGetProgrammerTableLength()];
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string str;
            SqlDataReader reader;
            str = "Select Programmer_id From Programmer";
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read() && i < ProgrammerGetProgrammerTableLength())
            {
                ans[i] = Convert.ToInt32(reader[0].ToString());
                i++;
            }

            reader.Close();
            conn.Close();
            return ans;
        }

        // add new programmer to Programmer table
        public int ProgrammerAddNewProgrammer(string Programmer_Name, int Programmer_Expected_Work_Hours, int Programmer_Current_Work_Hours)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Insert Into Programmer (Programmer_Name, Programmer_Expected_Work_Hours, Programmer_Current_Work_Hours) values ( '" + Programmer_Name + "', " + Programmer_Expected_Work_Hours + ", " + Programmer_Current_Work_Hours + ")";

            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }


        // this function is private because only Work_hours table must use it
        // gets Programmer_ID and work hours for current day
        // add hours to total Programmer_Current_Work_Hours
        /*
        private int ProgrammerAddProgrammerWorkHours(int Programmer_ID, int hours)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            int curr_hours;
            string str;
            SqlDataReader reader;
            str = "Select Programmer_Current_Work_Hours from Programmer Where Programmer_id = " + Programmer_ID;
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            reader.Read();
            //curr_hours = Convert.ToInt32(reader[0].ToString()); // get current hours from programmer == ID
            curr_hours = reader.GetInt32(0);
            curr_hours += hours;
            reader.Close();
            str = "Update Programmer Set Programmer_Current_Work_Hours = " + curr_hours + " Where Programmer_id = " + Programmer_ID;
            command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }
        */

        // change expected work hours of programmer to what it gets
        public int ProgrammerUpdateProgrammerExpectedWorkHours(int Programmer_ID, float expected_hours)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Programmer (Programmer_Expected_Work_Hours) values ( " + expected_hours + ") Where Programmer_id = " + Programmer_ID;
            string str = "Update Programmer Set Programmer_Expected_Work_Hours=" + expected_hours + " Where Programmer_id = " + Programmer_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int ProgrammerUpdateProgrammerExpectedWorkHours(int Programmer_ID, double expected_hours)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Programmer (Programmer_Expected_Work_Hours) values ( " + expected_hours + ") Where Programmer_id = " + Programmer_ID;
            string str = "Update Programmer Set Programmer_Expected_Work_Hours=" + expected_hours + " Where Programmer_id = " + Programmer_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }



        public int ProgrammerUpdateProgrammerCurrentWorkHours(int Programmer_ID, double current_work_hours)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Programmer (Programmer_Expected_Work_Hours) values ( " + expected_hours + ") Where Programmer_id = " + Programmer_ID;
            string str = "Update Programmer Set Programmer_Current_Work_Hours=" + current_work_hours + " Where Programmer_id = " + Programmer_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }
       public int ProgrammerUpdateProgrammerName(int Programmer_ID, string name)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Programmer (Programmer_Expected_Work_Hours) values ( " + expected_hours + ") Where Programmer_id = " + Programmer_ID;
            string str = "Update Programmer Set Programmer_Name=" + name + " Where Programmer_id = " + Programmer_ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }

        // adds to expected work hours of programmer to what gets
        public int add_programmer_expected_work_hours(int Programmer_ID, float hours)
        {
            float expct = ProgrammerGetEexpectedWorkHours(Programmer_ID);
            if (expct == -1)
                expct = 0;
            expct += hours;
            ProgrammerUpdateProgrammerExpectedWorkHours(Programmer_ID, expct);
            return 0;
        }


        // change programmer name
       /* internal static int ProgrammerUpdateProgrammerName(int ID, string name)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Programmer (Programmer_Name) values( '" + name + "') Where Programmer_id = " + ID;
            string str = "Update Programmer Set Programmer_Name='" + name + "' Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(str, conn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            conn.Close();
            return 0;
        }*/

        // get programmer buffer
        // no test
        public float ProgrammerGetBuffer(int ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Programmer_Current_Work_Hours From Programmer Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            float ans = (float)reader.GetDouble(0);
            conn.Close();
            return ans;
        }

        // get programmer current work hours
        public float ProgrammerGetCurrentWorkHours(int ID)
        {
            return WorkHoursGetProgrammerWorkHoursAll(ID);
        }

        // get programmer expected work hours
        public float ProgrammerGetEexpectedWorkHours(int ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Programmer_Expected_Work_Hours From Programmer Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            float ans = (float)reader.GetDouble(0);
            conn.Close();
            return ans;
        }

        // get programmer name
        public string ProgrammerGetName(int ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string str = "Select Programmer_Name From Programmer Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                string ans = reader.GetString(0);
                conn.Close();
                return ans;
            }
            //string ans = reader[0].ToString();
            
            catch (Exception)
            {
                return null;
            }
        }

        /*
        public int ProgrammerGetTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Select Count(*) From Programmer";
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }
        */

        // return all programmers id that have such Name
        // test not working
        public int[] ProgrammerGetIDByName(string name)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return null;
            }
            //count id's
            string str = "Select Count(*) From Programmer Where Programmer_Name like '" + name + "'";
            SqlCommand command = new SqlCommand(str, conn);
            SqlDataReader reader = command.ExecuteReader();
            int num;
            if (reader.Read() == false)
                return null;
            num = Convert.ToInt32(reader[0].ToString());
            if (num == 0)
                return null;
            int[] ans = new int[num];
            reader.Close();
            // get id's
            str = "Select Programmer_id From Programmer Where Programmer_Name like '" + name + "'";
            command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            int id;
            int i = 0;
            while (reader.Read() && i < num)
            {
                id = Convert.ToInt32(reader[0].ToString());
                ans[i] = id;
                i++;
            }
            // ans = reader(0).toString();
            conn.Close();
            return ans;
        }


        /*************************************************************************************************
         **************************  Date  ************************************************************
         */

        public int DateGetTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            int ans;
            string str;
            SqlDataReader reader;
            str = "Select Count(*) From Date";
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            reader.Read();
            ans = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        // gets current day from system
        public DateTime DateGetCurrentDay()
        {
            DateTime curr = DateTime.Today;
            return curr;
        }

        // return day status(int) or -1 if error
        public int DateGetDayStatus(DateTime day)
        {
            int ans = -1;
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return ans;
            }
            string qStr = "SELECT Date_Day_status FROM Date Where Date_Day = @day";

            SqlCommand sqlCom = new SqlCommand(qStr, conn);
            sqlCom.Parameters.AddWithValue("@day", day);
            SqlDataReader reader = sqlCom.ExecuteReader();
            if (reader.Read() == false)
                return -1;
            ans = Convert.ToInt32(reader[0].ToString());
            conn.Close();
            return ans;
        }

        // this function must update day status to parametr(status)
        public int DateUpdateDayStatus(DateTime up_day, int status)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            SqlCommand command;
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str;
            //string day_to_up = up_day.ToString();
            //str = "Insert Into Date (Date_Day_status) values( "+ status + ") Where Date_Day = @date";
            str = "Update Date Set Date_Day_status=" + status + " Where Date_Day = @date";
            command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@date", up_day); // need to be checked
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        // add new day, gets day
        /*      add new not working day
        public int DateAddNewDay(DateTime day)
        {
            int status = 0;
            // check status
            DateAddNewDay(day, status);
            return 0;
        }
        */

        // add new day, gets day and status
        public int DateAddNewDay(DateTime day, int status)
        {

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string s_day = day.ToString();
            string str = "Insert Into Date (Date_Day_status, Date_Day) values (" + status + ", @date)";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@date", day);// pizdec ia ebal etot sql, otkuda ia znaiu c#???
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(""+ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        /*************************************************************************************************
        **************************  Work hours  ************************************************************
        */

        public int WorkHoursGetWorkHoursTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            int ans;
            string str;
            SqlDataReader reader;
            str = "Select Count(*) From Work_hours";
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            reader.Read();
            ans = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        public float WorkHoursGetProgrammerWorkHoursForToday(int P_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            DateTime day = DateTime.Today;
            float ans = -1;
            string str;
            SqlDataReader reader;
            str = "Select Work_hours_Work_hours From Work_hours Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", day);
            reader = command.ExecuteReader();
            if (reader.Read())   // if there is data to read
                ans = (float)Convert.ToDouble(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        public float WorkHoursGetProgrammerWorkHoursForDay(int P_ID, DateTime day)
        {
            /*
            if (day == null || day > DateTime.Today)
            {
                // can't work in future
                return -1;
            }
            */
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //DateTime day = DateTime.Today;
            float ans = -1;
            string str;
            SqlDataReader reader;
            str = "Select Work_hours_Work_hours From Work_hours Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", day);
            reader = command.ExecuteReader();
            if (reader.Read())   // if there is data to read
                ans = (float)Convert.ToDouble(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        public int WorkHoursSetProgrammerWorkHoursForToday(int P_ID, float hours)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            DateTime day = DateTime.Today;
            DateAddNewDay(day, 1); // if already exist will return -1 -> ignore
            WorkHoursAddNewDayWorkHours(P_ID, day);
            //string str = "Insert Into Work_hours (Work_hours_Work_hours) values (" + hours + ") Where Work_hours_Programmer_id = "+ P_ID +" and Work_hours__Date_Day = @day";
            string str = "Update Work_hours Set Work_hours_Work_hours=" + hours + " Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(""+ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int WorkHoursAddNewDayWorkHours(int P_ID, DateTime day)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Insert Into Work_hours (Work_hours_Programmer_id, Work_hours__Date_Day, Work_hours_Work_hours) values (" + P_ID + ", @day, 0)";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(""+ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int WorkHoursAddNewToDayWorkHours(int P_ID)
        {
            DateTime day = DateTime.Today;
            return WorkHoursAddNewDayWorkHours(P_ID, day);
        }

        public int WorkHoursSetProgrammerWorkHoursForDay(int P_ID, float hours, DateTime day)
        {
            if (day == null || day > DateTime.Today)
            {
                // can't work in future
                return -1;
            }
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string str = "Insert Into Work_hours (Work_hours_Work_hours) values (" + hours + ") Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            string str = "Update Work_hours Set Work_hours_Work_hours=" + hours + " Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(""+ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int WorkHoursAddProgrammerWorkHoursForToday(int P_ID, float hours)
        {
            DateTime day = DateGetCurrentDay();
            WorkHoursAddProgrammerWorkHoursForDay(P_ID, hours, day);
            return 0;
        }

        public int WorkHoursAddProgrammerWorkHoursForDay(int P_ID, float hours, DateTime day)
        {
            float get_h = WorkHoursGetProgrammerWorkHoursForDay(P_ID, day);
            if (get_h == -1)
                return -1;
            float ans = get_h + hours;
            WorkHoursSetProgrammerWorkHoursForDay(P_ID, ans, day);
            return 0;
        }

        public float WorkHoursGetProgrammerWorkHoursAll(int P_ID)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //DateTime day = DateTime.Today;
            float ans = 0;
            int flag = -1;
            string str;
            SqlDataReader reader;
            str = "Select Work_hours_Work_hours From Work_hours Where Work_hours_Programmer_id = " + P_ID;
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            while (reader.Read())   // if there is data to read
            {
                flag = 0;
                ans += (float)Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
            if (flag == -1)
                return -1;
            return ans;
        }

        public float WorkHoursGetAllWorkHoursForToday()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            DateTime day = DateTime.Today;
            float ans = 0;
            int flag = -1;
            string str;
            SqlDataReader reader;
            str = "Select Work_hours_Work_hours From Work_hours Where Work_hours__Date_Day = @date";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@date", day);
            reader = command.ExecuteReader();
            while (reader.Read())   // if there is data to read
            {
                flag = 0;
                ans += (float)Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
            if (flag == -1)
                return -1;
            return ans;
        }

        public float WorkHoursGetAllWorkHoursForDay(DateTime day)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            float ans = 0;
            int flag = -1;
            string str;
            SqlDataReader reader;
            str = "Select Work_hours_Work_hours From Work_hours Where Work_hours__Date_Day = @date";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@date", day);
            reader = command.ExecuteReader();
            while (reader.Read())   // if there is data to read
            {
                flag = 0;
                ans += (float)Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
            if (flag == -1)
                return -1;
            return ans;
        }

        public float[] WorkHoursGetAllSprintWorkHours()
        {
            int num = SprintGetLengthWorkingDays();
            float[] ans = new float[num];
            DateTime[] days = SprintGetAllWorkingDays();
            for (int i = 0; i < num; i++)
            {
                ans[i] = WorkHoursGetAllWorkHoursForDay(days[i]);
            }
            return ans;
        }


        /*************************************************************************************************
        **************************  Story In Sprint  ************************************************************
        */

        public int StoryInSprintGetStoryInSprintTableLength()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            int ans;
            string str;
            SqlDataReader reader;
            str = "Select Count(*) From Story_In_Sprint";
            SqlCommand command = new SqlCommand(str, conn);
            reader = command.ExecuteReader();
            reader.Read();
            ans = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            conn.Close();
            return ans;
        }

        public int StoryInSprintAddNewStoryInSprint(int storyID, DateTime sprint_day)
        {
            // check if valid storyID and sprint_day
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string str = "Insert Into Story_In_Sprint values (" + storyID + ", @day)";
            SqlCommand command = new SqlCommand(str, conn);
            command.Parameters.AddWithValue("@day", sprint_day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                return -1;
            }
            conn.Close();
            return 0;
        }

        public int StoryInSprintTransferStoryToOtherSprint(int story_ID, DateTime day)
        {
            // check if day is sprint beggining day
            // delete row from database where story_ID && day
            // add new storyinsprint
            return 0;
        }

    }
}
