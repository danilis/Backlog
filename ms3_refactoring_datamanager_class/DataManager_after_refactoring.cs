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
            int maximumTablesSize = 0;
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




        private int intGetDataFromDataBase(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int queryRequest = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            sqlConnection.Close();
            return queryRequest;
        }


        private string stringGetDataFromDataBase(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return null;
            }
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string ans = reader.GetString(0);
            sqlConnection.Close();
            return ans;
        }


        public int updateAndInserRutin(string query)
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
            SqlCommand command = new SqlCommand(query, conn);
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
         **************************  Sprint  ************************************************************
         */

        public int SprintGetTableLength()
        {
            string query = "Select Count(*) From Sprint";
            return intGetDataFromDataBase(query);
        }
        
   
        // return Sprint length in days
        // if error return -1
        public int SprintGetLengthWorkingDays()
        {
            string query = "SELECT Count(*) FROM Date Where Date_Day_status = 1";
            return intGetDataFromDataBase(query); ;
        }

        //Anton
        //Ya ne ponyal 4to eto za funkciya
        // same as prev
        public int SprintGetLengthAllDays()
        {
            int ans = (int)Math.Floor((SprintGetEndingDay() - SprintGetBegginingDay()).TotalDays);
            return ans;
        }

        // return date
        public DateTime SprintGetBegginingDay()
        {
            DateTime sprintBeginingDay = DateTime.MinValue;
            DateTime today_date = DateTime.Today;
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return sprintBeginingDay;
            }
            string query = "SELECT * FROM Sprint";
            SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            DateTime end;
            while (reader.Read())
            {
                sprintBeginingDay = (DateTime)reader[0];
                end = (DateTime)reader[1];
                if ((end - today_date).TotalDays > 0)   // if sprint end > current day then return ans
                {   
                    break;
                }
            }
            reader.Close();
            sqlConnection.Close();
            return sprintBeginingDay;
        }


        // return array with sprint days that are in Date table
        // if day_d doesnt exist array[day_d] = -1
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string query = "SELECT Date_Day FROM Date";
            SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            int i = 0;
            while (reader.Read() && i < max_sprint_days)
            {
                //ans[i] = reader.GetDateTime(0);
                ans[i] = (DateTime) reader[0];
                i++;
            }
            reader.Close();
            sqlConnection.Close();
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string query = "SELECT Date_Day From Date Where Date_Day_status = 1";
            SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            i = 0;
            while (reader.Read() && i < max_sprint_days)
            {
                //ans[i] = reader.GetDateTime(0);
                ans[i] = (DateTime) reader[0];
                i++;
            }
            reader.Close();
            sqlConnection.Close();
            return ans;
        }
        // return last day of sprint
        // return null if error
        public DateTime SprintGetEndingDay()
        {
            DateTime ending = DateTime.MinValue;
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return ending;
            }
            DateTime begin = SprintGetBegginingDay();
            const string query = "SELECT Sprint_Finish_Day FROM Sprint Where Sprint_Beginning_Day = @date";
            SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
            sqlCom.Parameters.AddWithValue("@date", begin);
            SqlDataReader reader = sqlCom.ExecuteReader();
            reader.Read();
            ending = (DateTime) reader[0];
            reader.Close();
            sqlConnection.Close();
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
            int ans = (int) Math.Floor((ending - curr).TotalDays);    /// calculation
            return ans;
        }



        public int SprintGetRemainWorkingDays()
        {
            string query = "SELECT Count(*) FROM Date Where Date_Day > @curr_day and Date_Day_status = 1";
            return intGetDataFromDataBase(query);
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "SELECT Date_Day FROM Date Where Date_Day_status = 1";
            SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            int temp;
            while (reader.Read())
            {
                DateTime day = (DateTime) reader[0];
                if (day != DateTime.MinValue)
                {
                    temp = (int)WorkHoursGetAllWorkHoursForDay(day);
                    if (temp != -1)
                        ans += temp;
                }
                
            }
            sqlConnection.Close();
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            // how to differ between the sprints?
            // every time each programmer must be set to other expct_w_hours
            string query = "SELECT Programmer_Expected_Work_Hours FROM Programmer";
            SqlCommand sqlCom = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            //int[] answer;
            while (reader.Read())
            {
                if(reader[0] != null)
                    ans += Convert.ToInt32(reader[0].ToString());
                //ans += reader.GetInt32(0);
            }
            sqlConnection.Close();
            return ans;
        }

        // add new Sprint
        public int SprintAddNewSprint(DateTime start, DateTime end)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            if (start >= end)
                return -1;
            string query = "Insert Into Sprint (Sprint_Beginning_Day, Sprint_Finish_Day) values (@start, @end)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
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
            sqlConnection.Close();
            return 0;
        }


        /*************************************************************************************************
         **************************  Story  ************************************************************
         */

        // return number of stoies (size of sprint table)
        public int StoryGetStoryTableLength()
        {
            string query = "Select Count(*) From Story";
            return intGetDataFromDataBase(query); ;
        }

        public int StoryAddNewStory(int Story_Owner, DateTime Current_Sprint, string Story_Demo_DES, Image Story_Demo_PIC, string Story_Description, int Story_Priority, int Story_Work_Status)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string curr_sprint_date = Current_Sprint.ToString();
            // how to insert image to table ??????????????????????????????????
            string query = "Insert Into Story (Story_Owner, Story_Current_Sprint, Story_Demo_DES, Story_Demo_PIC, Story_Description, Story_Priority, Story_Work_Status) values (" + Story_Owner + ", @date, '" + Story_Demo_DES + "'," + null /* Story_Demo_PIC*/ + ", '" + Story_Description + "', " + Story_Priority + ", " + Story_Work_Status + ")";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@date", curr_sprint_date);
            //command.Parameters.AddWithValue("@picture", Story_Demo_PIC); // need to be checked
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return -1;
            }
            sqlConnection.Close();
            return 0;
        }

        public int StoryGetOwnerID(int story_ID)
        {
            string query = "Select Story_Owner From Story Where Story_ID = " + story_ID;
            return intGetDataFromDataBase(query);
        }

        public int StorySetOwnerID(int story_ID, int old_ID, int new_ID)
        {
            string query = "Update Story Set Story_Owner=" + new_ID + " Where Story_ID = " + story_ID + " and Story_Owner =" + old_ID;
            return updateAndInserRutin(query);
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
            string query = "Select Story_Current_Sprint From Story Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == false)
                return ans;
            ans = (DateTime) reader[0];
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
            string query = "Update Story Set Story_Current_Sprint=@day Where Story_ID = " + story_ID;
            SqlCommand command = new SqlCommand(query, conn);
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
            string query = "Select Story_Demo_DES From Story Where Story_ID = " + story_ID;
            return stringGetDataFromDataBase(query);
        }

        public int StorySetStoryDemoDes(int story_ID, string des)
        {
            string query = "Update Story Set Story_Demo_DES='" + des + "' Where Story_ID = " + story_ID;
            return updateAndInserRutin(query);
        }


        public string StoryGetStoryDemoPic()
        {
            return null;
        }

        public int StorySetStoryDemoPic()
        {
            return 0;
        }


        public string StoryGetStoryDescription(int story_ID)
        {
            string query = "Select Story_Description From Story Where Story_ID = " + story_ID;
            return stringGetDataFromDataBase(query);
        }

        public int StorySetStoryDescription(int story_ID, string des)
        {
            string query = "Update Story Set Story_Description='" + des + "' Where Story_ID = " + story_ID;
            return updateAndInserRutin(query);
        }

        public int StoryGetStoryPriority(int story_ID)
        {
            string query = "Select Story_Priority From Story Where Story_ID = " + story_ID;
            return intGetDataFromDataBase(query);
        }

        public int StorySetStoryPriority(int story_ID, int storyPriority)
        {
            string query = "Update Story Set Story_Description=" + storyPriority + " Where Story_ID = " + story_ID;
            return updateAndInserRutin(query);
        }

        public int StorySetStoryWorkStatus(int story_ID, int status)
        {
            string query = "Update Story Set Story_Work_Status=" + status + " Where Story_ID = " + story_ID;
            return updateAndInserRutin(query);
        }

        public int StoryGetStoryWorkStatus(int story_ID)
        {
            string query = "Select Story_Work_Status From Story Where Story_ID = " + story_ID;
            return intGetDataFromDataBase(query);
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
            string query = "Select Story_ID From Story Where Story_Owner = " + OwnerID;
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            int[] ans = new int[StoryGetStoryTableLength()];
            int i = 0;
            while (reader.Read() && i < StoryGetStoryTableLength())
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
            string query = "Select Count(*) From Task";
            return intGetDataFromDataBase(query);
        }

        // if not succeed return -1
        public int TaskAddNewTask(int Task_Story_ID, int Task_Priority, string Task_Description, int Task_Owner)
        {
            string query = "Insert into Task (Task_Story_ID, Task_Priority, Task_Description, Task_Ovner_Id) values (" + Task_Story_ID + ", " + Task_Priority + ", '" + Task_Description + "', " + Task_Owner + ")";
            return updateAndInserRutin(query);
        }

        public int TaskSetTaskStoryID(int task_ID, int story_ID)
        {
            string query = "Update Task Set Task_Story_ID=" + story_ID + " Where Task_ID = " + task_ID;
            return updateAndInserRutin(query);
        }

        public int TaskGetTaskStoryID(int task_ID)
        {
            string query = "Select Task_Story_ID From Task Where Task_ID = " + task_ID;
            return intGetDataFromDataBase(query);
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
            string query = "Update Task Set Task_Priority=" + priority + " Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(query, conn);
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
            string query = "Select Task_Priority From Task Where Task_ID = " + task_ID;
            return intGetDataFromDataBase(query);
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
            string query = "Update Task Set Task_Description='" + description + "' Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(query, conn);
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
            string query = "Select Task_Description From Task Where Task_ID = " + task_ID;
            return stringGetDataFromDataBase( query);
        }

        public int TaskSetTaskOwner(int task_ID, int owner_ID)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Update Task Set Task_Ovner_Id=" + owner_ID + " Where Task_ID = " + task_ID;
            SqlCommand command = new SqlCommand(query, sqlConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return -1;
            }
            sqlConnection.Close();
            return 0;
        }

        public int TaskGetTaskOwner(int task_ID)
        {
            string query = "Select Task_Ovner_Id From Task Where Task_ID = " + task_ID;
            return intGetDataFromDataBase(query);
        }

        
        /*************************************************************************************************
         **************************  Programmer  ************************************************************
         */

        public int ProgrammerGetProgrammerTableLength()
        {
            string query = "Select Count(*) From Programmer";
            return intGetDataFromDataBase(query);
        }
        
        public int[] ProgrammerGetAllProgrammers()
        {
            int[] ans = new int[ProgrammerGetProgrammerTableLength()];
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return null;
            }
            string query = "Select Programmer_id From Programmer";
            SqlDataReader reader;
            SqlCommand command = new SqlCommand(query, sqlConnection);
            reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read() && i < ProgrammerGetProgrammerTableLength())
            {
                ans[i] = Convert.ToInt32(reader[0].ToString());
                i++;
            }
            
            reader.Close();
            sqlConnection.Close();
            return ans;
        }

        // add new programmer to Programmer table
        public int ProgrammerAddNewProgrammer(string Programmer_Name, int Programmer_Expected_Work_Hours, int Programmer_Current_Work_Hours)
        {
            string query = "Insert Into Programmer (Programmer_Name, Programmer_Expected_Work_Hours, Programmer_Current_Work_Hours) values ( '" + Programmer_Name + "', " + Programmer_Expected_Work_Hours + ", " + Programmer_Current_Work_Hours + ")";
            return updateAndInserRutin(query);
        }


       

        // change expected work hours of programmer to what it gets
        public int ProgrammerUpdateProgrammerExpectedWorkHours(int Programmer_ID, float expected_hours)
        {
            string query = "Update Programmer Set Programmer_Expected_Work_Hours=" + expected_hours + " Where Programmer_id = " + Programmer_ID;
            return updateAndInserRutin(query);
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
        internal static int ProgrammerUpdateProgrammerName(int ID, string name)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Update Programmer Set Programmer_Name='" + name + "' Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(query, sqlConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            sqlConnection.Close();
            return 0;
        }

        // get programmer buffer
        // no test
        public float ProgrammerGetBuffer(int ID)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Select Programmer_Current_Work_Hours From Programmer Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            float ans = (float)reader.GetDouble(0);
            sqlConnection.Close();
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Select Programmer_Expected_Work_Hours From Programmer Where Programmer_id = " + ID;
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            float ans = (float) reader.GetDouble(0);
            sqlConnection.Close();
            return ans;
        }

        // get programmer name
        public string ProgrammerGetName(int ID)
        {
            string query = "Select Programmer_Name From Programmer Where Programmer_id = " + ID;
            return stringGetDataFromDataBase( query);
        }


        // return all programmers id that have such Name
        // test not working
        public int[] ProgrammerGetIDByName(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return null;
            }
            //count id's
            string query = "Select Count(*) From Programmer Where Programmer_Name like '" + name + "'";
            SqlCommand command = new SqlCommand(query, sqlConnection);
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
            query = "Select Programmer_id From Programmer Where Programmer_Name like '" + name + "'";
            command = new SqlCommand(query, sqlConnection);
            reader = command.ExecuteReader();
            int id;
            int i = 0;
            while (reader.Read() && i < num)
            {
                id = Convert.ToInt32(reader[0].ToString());
                ans[i] = id;
                i++;
            }
            sqlConnection.Close();
            return ans;
        }
        

        /*************************************************************************************************
         **************************  Date  ************************************************************
         */

        public int DateGetTableLength()
        {
            string query = "Select Count(*) From Date";
            return intGetDataFromDataBase(query);
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
            string query = "SELECT Date_Day_status FROM Date Where Date_Day = @day";
            return intGetDataFromDataBase(query);
        }

        // this function must update day status to parametr(status)
        public int DateUpdateDayStatus(DateTime up_day, int status)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand command;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Update Date Set Date_Day_status=" + status + " Where Date_Day = @date";
            command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@date", up_day); // need to be checked
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return -1;
            }
            sqlConnection.Close();
            return 0;
        }


        // add new day, gets day and status
        public int DateAddNewDay(DateTime day, int status)
        {

            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //string s_day = day.ToString();
            string query = "Insert Into Date (Date_Day_status, Date_Day) values (" + status + ", @date)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
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
            sqlConnection.Close();
            return 0;
        }

        /*************************************************************************************************
        **************************  Work hours  ************************************************************
        */

        public int WorkHoursGetWorkHoursTableLength()
        {
            string query = "Select Count(*) From Work_hours";
            return intGetDataFromDataBase(query); ;
        }

        public float WorkHoursGetProgrammerWorkHoursForToday(int P_ID)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            DateTime day = DateTime.Today;
            float ans = -1;
            SqlDataReader reader;
            string query = "Select Work_hours_Work_hours From Work_hours Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@day", day);
            reader = command.ExecuteReader();
            if(reader.Read())   // if there is data to read
                ans = (float) Convert.ToDouble(reader[0].ToString());
            reader.Close();
            sqlConnection.Close();
            return ans;
        }

        public float WorkHoursGetProgrammerWorkHoursForDay(int P_ID, DateTime day)
        {
            if (day == null || day > DateTime.Today)
            {
                // can't work in future
                return -1;
            }
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //DateTime day = DateTime.Today;
            float ans = -1;
            SqlDataReader reader;
            string query = "Select Work_hours_Work_hours From Work_hours Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@day", day);
            reader = command.ExecuteReader();
            if (reader.Read())   // if there is data to read
                ans = (float)Convert.ToDouble(reader[0].ToString());
            reader.Close();
            sqlConnection.Close();
            return ans;
        }

        public int WorkHoursSetProgrammerWorkHoursForToday(int P_ID, float hours)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            DateTime day = DateTime.Today;
            DateAddNewDay(day,1); // if already exist will return -1 -> ignore
            WorkHoursAddNewDayWorkHours(P_ID, day);
            string query = "Update Work_hours Set Work_hours_Work_hours=" + hours + " Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@day", day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            sqlConnection.Close();
            return 0;
        }

        public int WorkHoursAddNewDayWorkHours(int P_ID, DateTime day)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Insert Into Work_hours (Work_hours_Programmer_id, Work_hours__Date_Day, Work_hours_Work_hours) values (" + P_ID + ", @day, 0)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@day", day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
                return -1;
            }
            sqlConnection.Close();
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Update Work_hours Set Work_hours_Work_hours=" + hours + " Where Work_hours_Programmer_id = " + P_ID + " and Work_hours__Date_Day = @day";
            SqlCommand command = new SqlCommand(query, sqlConnection);
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
            sqlConnection.Close();
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
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            //DateTime day = DateTime.Today;
            float ans = 0;
            int flag = -1;
            SqlDataReader reader;
            string query = "Select Work_hours_Work_hours From Work_hours Where Work_hours_Programmer_id = " + P_ID;
            SqlCommand command = new SqlCommand(query, sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())   // if there is data to read
            {
                flag = 0;
                ans += (float)Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            sqlConnection.Close();
            if (flag == -1)
                return -1;
            return ans;
        }
        
        public float WorkHoursGetAllWorkHoursForToday()
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            DateTime day = DateTime.Today;
            float ans = 0;
            int flag = -1;
            SqlDataReader reader;
            string query = "Select Work_hours_Work_hours From Work_hours Where Work_hours__Date_Day = @date";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@date", day);
            reader = command.ExecuteReader();
            while (reader.Read())   // if there is data to read
            {
                flag = 0;
                ans += (float)Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            sqlConnection.Close();
            if (flag == -1)
                return -1;
            return ans;
        }

        public float WorkHoursGetAllWorkHoursForDay(DateTime day)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            float ans = 0;
            int flag = -1;
            SqlDataReader reader;
            string query = "Select Work_hours_Work_hours From Work_hours Where Work_hours__Date_Day = @date";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@date", day);
            reader = command.ExecuteReader();
            while (reader.Read())   // if there is data to read
            {
                flag = 0;
                ans += (float)Convert.ToDouble(reader[0].ToString());
            }
            reader.Close();
            sqlConnection.Close();
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
            string query = "Select Count(*) From Story_In_Sprint";
            return intGetDataFromDataBase(query); ;
        }

        public int StoryInSprintAddNewStoryInSprint(int storyID, DateTime sprint_day)
        {
            // check if valid storyID and sprint_day
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return -1;
            }
            string query = "Insert Into Story_In_Sprint values (" + storyID + ", @day)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@day", sprint_day);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return -1;
            }
            sqlConnection.Close();
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