using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication13
{
    class MathManager
    {
        //DataManager object - need for execute functions
        private DataManager dm = new DataManager();

        // This method is returns number of points, we have to create
        // for demonstrate linear graph - real progress
        public int getNumberOfDays()
        {
            // Have to check if the value is zero or negative
            int result = dm.SprintGetLengthWorkingDays();
            if (result < 0)
            {
                return 0;
            }
            return (result);
        }




        // This method is returns number active days ( active = working days, and not holidays and etc)
        public int getTotalHoursOfSprint()
        {
            // Have to check if the value is zero or negative
            int result = dm.SprintGetAllExpectedHours();
            if (result < 0)
                return 0;
            return (result);
        }

        /*
         * This function is updating the Estimated Graph points
         */
        public void updateEstimatedGraphPoints(System.Windows.Forms.DataVisualization.Charting.DataPoint[] expectedPoints)
        {
            int totalHours = getTotalHoursOfSprint();
            int totalDays = getNumberOfDays();
            Console.WriteLine("totalHours = {0}, totalDays = {1}", totalHours, totalDays);
            expectedPoints[0].SetValueXY(0,totalHours);
            expectedPoints[1].SetValueXY(totalDays, 0);
        }

        /*
         * This function is calculating and returns for specific programmer his risk
         * returns negative values if were error by getting values from DataManager
         */
        public float getProgrammerRisk(int id)
        {
            float result = 0;
            float expectedWorkHours = dm.ProgrammerGetEexpectedWorkHours(id);
            float performedHours = dm.WorkHoursGetProgrammerWorkHoursAll(id);
            int workingDaysInSprint = dm.SprintGetLengthWorkingDays();
            int workingDaysLeft = dm.SprintGetRemainWorkingDays();
            if (expectedWorkHours < 0 || performedHours < 0 || workingDaysInSprint <= 0 || workingDaysLeft <= 0)
            {
                return -1;
            }

            result = 1 / ((expectedWorkHours / workingDaysInSprint) / (((float)(expectedWorkHours - performedHours + 0.01))/workingDaysLeft));

            return result;
        }

        /*
         * This function is checking if programmer name contain only chatacters and one space at all
         */
        public bool isProgrammerNameValid(string Programmer_Name)
        {
            int one = 1;
            foreach (char c in Programmer_Name)
            {
                if (c == ' ')
                    one--;
                if (!Char.IsLetterOrDigit(c) && c != ' ' && one >= 0)
                    return false;
            }
            return true;
        }

        /*
         * This function is checking for validation of Programmer current work hours input
         * returns >=0 positive answer
         * -1 if Programmer_Current_Work_Hours negative values
         * -2 if Programmer_Current_Work_Hours > Programmer_Expected_Work_Hours
         */
        public int isProgrammerCurrentWorkHoursValid(float Programmer_Expected_Work_Hours, float Programmer_Current_Work_Hours)
        {
            if (Programmer_Current_Work_Hours < 0)
                return -1;
            if (Programmer_Current_Work_Hours > Programmer_Expected_Work_Hours)
                return -2;
            return 0;
        }

        /*
         * This function is checking for validation of Programmer expected work hours input
         * returns >=0 positive answer
         * -1 if Programmer_Expected_Work_Hours negative values
         * -2 if total Programmer_Expected_Work_Hours bigger than total hours for sprint
         */
        public int isProgrammerExpectedWorkHoursValid(float Programmer_Expected_Work_Hours)
        {
            if (Programmer_Expected_Work_Hours < 0)
                return -1;
            if (Programmer_Expected_Work_Hours*24 > dm.SprintGetRemainWorkingDays())
                return -2;
            return 0;
        }

        /*
          * This function is checking for validation of working hours of programmer per day
          * returns >=0 positive answer
          * -1 if Work_hours_Work_hours negative values 
          * -2 if Work_hours_Work_hours is bigger than 24 hours of day
          */
        public int isWork_hours_Work_hoursValid(int Work_hours_Work_hours)
        {
            if (Work_hours_Work_hours < 0)
                return -1;
            if (Work_hours_Work_hours > 24)
                return -2;
            return 0;
        }

        /*
         * This method is returns if Task_Priority has a valid value
         * 0 - if valid
         * negative (-1) if not
         */
        public int isTask_PriorityValid(int Task_Priority)
        {
            if (Task_Priority > 0 && Task_Priority < 11)
                return 0;
            return -1;
        }

        /*
         * Here i checking if Task_Story_ID is exist in table Story
         * returns:
         * 0 if exist
         * negative if not (-1)
         */
        public int isTask_Story_IDValid(int Task_Story_ID)
        {
            DateTime ans = dm.StoryGetCurrentSprintForStoryID(Task_Story_ID);
            if (ans.Equals(DateTime.MinValue))
                return -1; // not exist in DB
            return 0;
        }

        /*
         * This function is checking if Task_Ovner_Id is exist as programmer in DB
         * returns:
         * 0 if exist
         * negative (-1) if not
         */
        public int isTask_Ovner_IdValid(int Task_Ovner_Id)
        {
            string str = dm.ProgrammerGetName(Task_Ovner_Id);
            if (str == null)
                return -1;
            return 0;
        }


        /*
         * This function is checking if task_Id is exist as task in DB
         * returns:
         * 0 if exist
         * negative (-1) if not
         */
        public int isTask_Id_Exist(int task_ID)
        {
            /*string str = dm.TaskGetTaskDescription(task_ID);
            if (str == null)
                return -1;
            return 0;*/
            int result = dm.TaskGetTaskOwner(task_ID);
            if (result == -1)
                return -1;
            return 0;
        }


        public int isStory_Id_Exist(int story_ID)
        {
            /*string str = dm.TaskGetTaskDescription(task_ID);
            if (str == null)
                return -1;
            return 0;*/
            int result = dm.StoryGetOwnerID(story_ID);
            if (result == -1)
                return -1;
            return 0;
        }


        public int isProgrammer_Id_Exist(int Programmer_id)
        {
            string str = dm.ProgrammerGetName(Programmer_id);
            if (str == null)
                return -1;
            return 0;
            /*int result = dm.ProgrammerGetName(Programmer_id)
            if (result == -1)
                return -1;
            return 0;*/
        }


        public int isStory_current_Sprint_valid(DateTime day)
        {
            DateTime[] result = dm.SprintGetAllWorkingDays();
            if (result == null)
                return -1;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Equals(day))
                    return 0;
            }
            return -1;
            /*int result = dm.ProgrammerGetName(Programmer_id)
            if (result == -1)
                return -1;
            return 0;*/
        }






        /*
         * This method is updates points for real graph
         */
        public void updateRealGraphPoints(System.Windows.Forms.DataVisualization.Charting.DataPoint[] realPoints)
        {

            int totalHours = getTotalHoursOfSprint();
            if (totalHours == -1)
            {
                // An error occorupted or no hours were added
                return;
            }
            int dayIndex = 0;
            int totalDays = getNumberOfDays();
            float[] hoursPerDay = dm.WorkHoursGetAllSprintWorkHours();
            for (int i = 0; i < realPoints.Length; i++)
            {
                realPoints[i].SetValueXY(dayIndex,totalHours);
                if (dayIndex < totalDays)
                {
                    totalHours -= (int)hoursPerDay[dayIndex];
                    dayIndex++;
                }
                // decrease totalHours - hours for day with index = dayIndex
            }
        }
    }
}
