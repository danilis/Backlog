using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    class Form1Tasks// : Form1
    {
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDescriptionDataGridViewTextBoxColumn2;
        private DataGridView TaskDataGridView;
        bool exists = false;
        private static Form1Tasks f1 = null;

        private Form1Tasks(DataGridView TaskDataGridView)
        {
            this.TaskDataGridView = TaskDataGridView;
            this.taskDescriptionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.DateTime start =Settings1.Default.startCurrentSprint;
            System.DateTime end = Settings1.Default.endCurrentSprint;
            int i = 0;
            while ((DateTime.Compare(start, end) !=0) && (i < 10))
            {
                this.taskDescriptionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();

                this.taskDescriptionDataGridViewTextBoxColumn2.DataPropertyName = start.ToString("dd.MM");
                this.taskDescriptionDataGridViewTextBoxColumn2.HeaderText = start.ToString("dd.MM");
                this.taskDescriptionDataGridViewTextBoxColumn2.Name = start.ToString("dd.MM");
                this.taskDescriptionDataGridViewTextBoxColumn2.Width = 40;

                TaskDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                  this.taskDescriptionDataGridViewTextBoxColumn2});

                start = start.AddDays(1);
                i++;
            }

            exists = true;
        }

        public static Form1Tasks getInstance(DataGridView TaskDataGridView)
        {
            if (f1 != null)
            {
                return f1;
            }
            else if (TaskDataGridView != null)
            {
                f1 = new Form1Tasks(TaskDataGridView);
                return f1;
            }
            else return null;
        }

        public void Form1TasksUpdate( System.DateTime start, System.DateTime end)
        {
            this.taskDescriptionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            int i = 0;
            while ((DateTime.Compare(start, end) != 0) && (i < 10))
            {
                this.taskDescriptionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();

                this.taskDescriptionDataGridViewTextBoxColumn2.DataPropertyName = start.ToString("dd.MM");
                this.taskDescriptionDataGridViewTextBoxColumn2.HeaderText = start.ToString("dd.MM");
                this.taskDescriptionDataGridViewTextBoxColumn2.Name = start.ToString("dd.MM");
                this.taskDescriptionDataGridViewTextBoxColumn2.Width = 40;

                TaskDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                  this.taskDescriptionDataGridViewTextBoxColumn2});

                start = start.AddDays(1);
                i++;
            }
        }

    }
}
