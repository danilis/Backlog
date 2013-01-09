namespace WindowsFormsApplication13
{
    partial class Team_settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnProgramerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgrammerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingHouersPerDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPercentageWorkingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBuffer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsAuotoBuffer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProgramerID,
            this.ColumnProgrammerName,
            this.ColumnWorkingHouersPerDay,
            this.ColumnPercentageWorkingTime,
            this.ColumnBuffer,
            this.ColumnIsAuotoBuffer});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnProgramerID
            // 
            this.ColumnProgramerID.HeaderText = "ProgramerID";
            this.ColumnProgramerID.Name = "ColumnProgramerID";
            this.ColumnProgramerID.ReadOnly = true;
            this.ColumnProgramerID.Visible = false;
            // 
            // ColumnProgrammerName
            // 
            this.ColumnProgrammerName.HeaderText = "Name";
            this.ColumnProgrammerName.Name = "ColumnProgrammerName";
            this.ColumnProgrammerName.ReadOnly = true;
            // 
            // ColumnWorkingHouersPerDay
            // 
            this.ColumnWorkingHouersPerDay.HeaderText = "Houers Per Day";
            this.ColumnWorkingHouersPerDay.Name = "ColumnWorkingHouersPerDay";
            // 
            // ColumnPercentageWorkingTime
            // 
            this.ColumnPercentageWorkingTime.HeaderText = "Percentage Working Time";
            this.ColumnPercentageWorkingTime.Name = "ColumnPercentageWorkingTime";
            // 
            // ColumnBuffer
            // 
            this.ColumnBuffer.HeaderText = "Buffer";
            this.ColumnBuffer.Name = "ColumnBuffer";
            // 
            // ColumnIsAuotoBuffer
            // 
            this.ColumnIsAuotoBuffer.HeaderText = "Automatic Buffer";
            this.ColumnIsAuotoBuffer.Name = "ColumnIsAuotoBuffer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Team_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Team_settings";
            this.Text = "Team_settings";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgramerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgrammerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingHouersPerDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPercentageWorkingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBuffer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsAuotoBuffer;
        private System.Windows.Forms.Button button1;
    }
}