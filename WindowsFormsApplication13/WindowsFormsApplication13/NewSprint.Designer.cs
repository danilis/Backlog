namespace WindowsFormsApplication13
{
    partial class NewSprint
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label sprint_Beginning_DayLabel;
            System.Windows.Forms.Label sprint_Finish_DayLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSprint));
            this.database1DataSet1 = new WindowsFormsApplication13.Database1DataSet1();
            this.dateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTableAdapter = new WindowsFormsApplication13.Database1DataSet1TableAdapters.DateTableAdapter();
            this.tableAdapterManager = new WindowsFormsApplication13.Database1DataSet1TableAdapters.TableAdapterManager();
            this.dateBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dateBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dateDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sprintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sprintTableAdapter = new WindowsFormsApplication13.Database1DataSet1TableAdapters.SprintTableAdapter();
            this.sprint_Beginning_DayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.sprint_Finish_DayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            sprint_Beginning_DayLabel = new System.Windows.Forms.Label();
            sprint_Finish_DayLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBindingNavigator)).BeginInit();
            this.dateBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprintBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sprint_Beginning_DayLabel
            // 
            sprint_Beginning_DayLabel.AutoSize = true;
            sprint_Beginning_DayLabel.Location = new System.Drawing.Point(11, 19);
            sprint_Beginning_DayLabel.Name = "sprint_Beginning_DayLabel";
            sprint_Beginning_DayLabel.Size = new System.Drawing.Size(109, 13);
            sprint_Beginning_DayLabel.TabIndex = 8;
            sprint_Beginning_DayLabel.Text = "Sprint Beginning Day:";
            // 
            // sprint_Finish_DayLabel
            // 
            sprint_Finish_DayLabel.AutoSize = true;
            sprint_Finish_DayLabel.Location = new System.Drawing.Point(11, 45);
            sprint_Finish_DayLabel.Name = "sprint_Finish_DayLabel";
            sprint_Finish_DayLabel.Size = new System.Drawing.Size(89, 13);
            sprint_Finish_DayLabel.TabIndex = 10;
            sprint_Finish_DayLabel.Text = "Sprint Finish Day:";
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateBindingSource
            // 
            this.dateBindingSource.DataMember = "Date";
            this.dateBindingSource.DataSource = this.database1DataSet1;
            // 
            // dateTableAdapter
            // 
            this.dateTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DateTableAdapter = this.dateTableAdapter;
            this.tableAdapterManager.Programmer1TableAdapter = null;
            this.tableAdapterManager.ProgrammerTableAdapter = null;
            this.tableAdapterManager.SprintTableAdapter = null;
            this.tableAdapterManager.Story_In_SprintTableAdapter = null;
            this.tableAdapterManager.StoryTableAdapter = null;
            this.tableAdapterManager.TaskTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApplication13.Database1DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.Work_hoursTableAdapter = null;
            // 
            // dateBindingNavigator
            // 
            this.dateBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dateBindingNavigator.BindingSource = this.dateBindingSource;
            this.dateBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dateBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dateBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dateBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.dateBindingNavigatorSaveItem});
            this.dateBindingNavigator.Location = new System.Drawing.Point(0, 515);
            this.dateBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dateBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dateBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dateBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dateBindingNavigator.Name = "dateBindingNavigator";
            this.dateBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dateBindingNavigator.Size = new System.Drawing.Size(382, 25);
            this.dateBindingNavigator.TabIndex = 6;
            this.dateBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dateBindingNavigatorSaveItem
            // 
            this.dateBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dateBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dateBindingNavigatorSaveItem.Image")));
            this.dateBindingNavigatorSaveItem.Name = "dateBindingNavigatorSaveItem";
            this.dateBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.dateBindingNavigatorSaveItem.Text = "Save Data";
            this.dateBindingNavigatorSaveItem.Click += new System.EventHandler(this.dateBindingNavigatorSaveItem_Click);
            // 
            // dateDataGridView
            // 
            this.dateDataGridView.AutoGenerateColumns = false;
            this.dateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1});
            this.dateDataGridView.DataSource = this.dateBindingSource;
            this.dateDataGridView.Location = new System.Drawing.Point(0, 85);
            this.dateDataGridView.Name = "dateDataGridView";
            this.dateDataGridView.Size = new System.Drawing.Size(382, 450);
            this.dateDataGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Date_Day";
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Date_Day";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date_Day_status";
            this.dataGridViewTextBoxColumn1.HeaderText = "Date_Day_status";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // sprintBindingSource
            // 
            this.sprintBindingSource.DataMember = "Sprint";
            this.sprintBindingSource.DataSource = this.database1DataSet1;
            // 
            // sprintTableAdapter
            // 
            this.sprintTableAdapter.ClearBeforeFill = true;
            // 
            // sprint_Beginning_DayDateTimePicker
            // 
            this.sprint_Beginning_DayDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sprintBindingSource, "Sprint_Beginning_Day", true));
            this.sprint_Beginning_DayDateTimePicker.Location = new System.Drawing.Point(126, 19);
            this.sprint_Beginning_DayDateTimePicker.Name = "sprint_Beginning_DayDateTimePicker";
            this.sprint_Beginning_DayDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.sprint_Beginning_DayDateTimePicker.TabIndex = 9;
            this.sprint_Beginning_DayDateTimePicker.ValueChanged += new System.EventHandler(this.sprint_Beginning_DayDateTimePicker_ValueChanged);
            // 
            // sprint_Finish_DayDateTimePicker
            // 
            this.sprint_Finish_DayDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sprintBindingSource, "Sprint_Finish_Day", true));
            this.sprint_Finish_DayDateTimePicker.Location = new System.Drawing.Point(126, 45);
            this.sprint_Finish_DayDateTimePicker.Name = "sprint_Finish_DayDateTimePicker";
            this.sprint_Finish_DayDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.sprint_Finish_DayDateTimePicker.TabIndex = 11;
            this.sprint_Finish_DayDateTimePicker.ValueChanged += new System.EventHandler(this.sprint_Finish_DayDateTimePicker_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(sprint_Beginning_DayLabel);
            this.Controls.Add(this.sprint_Beginning_DayDateTimePicker);
            this.Controls.Add(sprint_Finish_DayLabel);
            this.Controls.Add(this.sprint_Finish_DayDateTimePicker);
            this.Controls.Add(this.dateDataGridView);
            this.Controls.Add(this.dateBindingNavigator);
            this.HelpButton = true;
            this.Location = global::WindowsFormsApplication13.Properties.Settings.Default.mid;
            this.Name = "NewSprint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "NewSprint";
            this.Load += new System.EventHandler(this.NewSprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBindingNavigator)).EndInit();
            this.dateBindingNavigator.ResumeLayout(false);
            this.dateBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprintBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource dateBindingSource;
        private Database1DataSet1TableAdapters.DateTableAdapter dateTableAdapter;
        private Database1DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator dateBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton dateBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dateDataGridView;
        private System.Windows.Forms.BindingSource sprintBindingSource;
        private Database1DataSet1TableAdapters.SprintTableAdapter sprintTableAdapter;
        private System.Windows.Forms.DateTimePicker sprint_Beginning_DayDateTimePicker;
        private System.Windows.Forms.DateTimePicker sprint_Finish_DayDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button1;
    }
}