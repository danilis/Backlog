using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication10
{
    class DataManager
    {

        private void PrintValues(Database1DataSet myTable)
        {
            foreach (DataRow myRow in myTable.Rows)
            {
                // Для каждой ячейки (столбца) в строке...   
                foreach (DataColumn myCol in myTable.Columns)
                {
                    // Выдать на консоль ее значение! 
                    Console.WriteLine(myRow[myCol]);
                }
            }
        }


        public int get_all_work_hours()
        {

            return 0;
        }

        // connect to database
        private void db_connect()
        {
                        
        }

        // connect to database
        private void db_disconnect()
        {

        }
    }
}
