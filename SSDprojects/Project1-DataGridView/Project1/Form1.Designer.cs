using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Project1
{
    partial class Form1
    {
        private IContainer components = null;
        private DataGridView dataGridView1;
        private Button button_SelectStock;
        private Button button_UpdateGrid;
        private DateTimePicker dateTimePicker_StartDate;
        private DateTimePicker dateTimePicker_EndDate;
        private OpenFileDialog openFileDialog_SelectStock;
        private Label label_StartDate;
        private Label label_EndDate;
        private BindingSource aCandlestickBindingSource;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;

        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_SelectStock = new System.Windows.Forms.Button();
            this.button_UpdateGrid = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog_SelectStock = new System.Windows.Forms.OpenFileDialog();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.label_EndDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.openDataGridViewTextBoxColumn,
            this.highDataGridViewTextBoxColumn,
            this.lowDataGridViewTextBoxColumn,
            this.closeDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aCandlestickBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(105, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(803, 164);
            this.dataGridView1.TabIndex = 0;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // openDataGridViewTextBoxColumn
            // 
            this.openDataGridViewTextBoxColumn.DataPropertyName = "open";
            this.openDataGridViewTextBoxColumn.HeaderText = "Open";
            this.openDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.openDataGridViewTextBoxColumn.Name = "openDataGridViewTextBoxColumn";
            this.openDataGridViewTextBoxColumn.Width = 125;
            // 
            // highDataGridViewTextBoxColumn
            // 
            this.highDataGridViewTextBoxColumn.DataPropertyName = "high";
            this.highDataGridViewTextBoxColumn.HeaderText = "High";
            this.highDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.highDataGridViewTextBoxColumn.Name = "highDataGridViewTextBoxColumn";
            this.highDataGridViewTextBoxColumn.Width = 125;
            // 
            // lowDataGridViewTextBoxColumn
            // 
            this.lowDataGridViewTextBoxColumn.DataPropertyName = "low";
            this.lowDataGridViewTextBoxColumn.HeaderText = "Low";
            this.lowDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lowDataGridViewTextBoxColumn.Name = "lowDataGridViewTextBoxColumn";
            this.lowDataGridViewTextBoxColumn.Width = 125;
            // 
            // closeDataGridViewTextBoxColumn
            // 
            this.closeDataGridViewTextBoxColumn.DataPropertyName = "close";
            this.closeDataGridViewTextBoxColumn.HeaderText = "Close";
            this.closeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.closeDataGridViewTextBoxColumn.Name = "closeDataGridViewTextBoxColumn";
            this.closeDataGridViewTextBoxColumn.Width = 125;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.Width = 125;
            // 
            // aCandlestickBindingSource
            // 
            this.aCandlestickBindingSource.DataSource = typeof(Project1.aCandlestick);
            // 
            // button_SelectStock
            // 
            this.button_SelectStock.Location = new System.Drawing.Point(383, 312);
            this.button_SelectStock.Name = "button_SelectStock";
            this.button_SelectStock.Size = new System.Drawing.Size(127, 48);
            this.button_SelectStock.TabIndex = 0;
            this.button_SelectStock.Text = "Select Stock";
            this.button_SelectStock.UseVisualStyleBackColor = true;
            this.button_SelectStock.Click += new System.EventHandler(this.button_SelectStock_Click);
            // 
            // button_UpdateGrid
            // 
            this.button_UpdateGrid.Location = new System.Drawing.Point(795, 310);
            this.button_UpdateGrid.Name = "button_UpdateGrid";
            this.button_UpdateGrid.Size = new System.Drawing.Size(127, 52);
            this.button_UpdateGrid.TabIndex = 6;
            this.button_UpdateGrid.Text = "Update";
            this.button_UpdateGrid.UseVisualStyleBackColor = true;
            this.button_UpdateGrid.Click += new System.EventHandler(this.button_UpdateGrid_Click);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(161, 323);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2021, 1, 28, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(582, 324);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_EndDate.TabIndex = 3;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2021, 2, 28, 0, 0, 0, 0);
            // 
            // openFileDialog_SelectStock
            // 
            this.openFileDialog_SelectStock.FileName = "ABBV_daily";
            this.openFileDialog_SelectStock.Filter = "All|*.csv|Yearly|*_yearly.csv|Monthly|*_monthly.csv|Weekly|*_weekly.csv|Daily|*_d" +
    "aily.csv";
            this.openFileDialog_SelectStock.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_SelectStock_FileOk);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Location = new System.Drawing.Point(102, 329);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(37, 16);
            this.label_StartDate.TabIndex = 4;
            this.label_StartDate.Text = "Start:";
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Location = new System.Drawing.Point(529, 328);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(34, 16);
            this.label_EndDate.TabIndex = 5;
            this.label_EndDate.Text = "End:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1046, 427);
            this.Controls.Add(this.button_UpdateGrid);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.button_SelectStock);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}