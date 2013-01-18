using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication13
{
    public class Index
    {
        private int row;
        private int col;

        public Index(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int getColumn()
        {
            return col;
        }


        public int getRow()
        {
            return row;
        }

        public void setColumn(int col)
        {
            this.col = col;
        }

        public void setRow(int row)
        {
            this.row = row;
        }
    }
}
