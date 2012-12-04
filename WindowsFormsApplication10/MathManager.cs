using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication10
{
    class MathManager
    {
        /* no need in main
        public int main()
        {
            int[] arr = { 1, 5, 7, 10, 13 };
            int max = find_max(arr);
            //MessageBox.Show("" + max);

            return 0;
        }
        */


        /***********************************************************
         *              Graph calculations
         */

        public int linear_calculation()
        {
            int ans = 0;

            return ans;
        }

        //
        public double progress_percent()
        {
            double ans = 0;

            return ans;
        }


        /***********************************************************
         *              Risk calculations
        */

        // calculating the project risk
        // return 0 if no risk ???
        // return -1 if not valid
        public double risk_calc()
        {
            double ans;
            double init_work_hours, sprint_days, left_work_hours, current_day;
            // get values from db

            /* still no data */
            init_work_hours = 1;
            sprint_days = 1;
            left_work_hours = 1;
            current_day = 1;
            /* still no data */

            ans = (init_work_hours / sprint_days) / (left_work_hours / current_day) + 0.01;
            return ans;
        }


        /*********************************************************
         *                  Progress calculations
        */
        //

        // calculate initial work hours of sprint
        public int work_to_be_done()
        {
            int ans = 0;

            return ans;
        }

        // calculate all worked hours
        public int work_done()
        {
            int ans = 0;

            return ans;
        }



        /****************************************************
         *                  Else
        */

        // return array with working spint days
        public int[] get_sprint_days()
        {
            int[] ans = {};
            // get sprint days from db


            return ans;
        }


        // gets array and returns max value
        // assuming that all array values is >= 0
        // if not valid returns -1
        public int find_max(int[] arr)
        {
            // if array is not valid
            if (arr == null || arr.Length <= 0)
            {
                return -1;
            }
            int ans = arr[0];
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] > ans)
                    ans = arr[i];
            }
            return ans;
        }

        // gets array and returns min value
        // assuming that all array values is >= 0
        // if not valid returns -1
        public int find_min(int[] arr)
        {
            // if array is not valid
            if (arr == null || arr.Length <= 0)
            {
                return -1;
            }
            int ans = arr[0];
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    return -1;  // not valid array
                if (arr[i] < ans)
                    ans = arr[i];
            }
            return ans;
        }

    }
}
