namespace Practice01_HelloWorld
{
    partial class Form1
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
            this.IDLabel = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.studentDataGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).BeginInit();
            this.SuspendLayout();
            //
            // IDLabel
            //
            this.IDLabel.Location = new System.Drawing.Point(69, 43);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(163, 68);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "Student ID";
            //
            // IDTextBox
            //
            this.IDTextBox.Location = new System.Drawing.Point(53, 89);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(141, 22);
            this.IDTextBox.TabIndex = 1;
            //
            // addButton
            //
            this.addButton.Location = new System.Drawing.Point(91, 265);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 82);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add\r\nStudent";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            //
            // nameTextBox
            //
            this.nameTextBox.Location = new System.Drawing.Point(53, 190);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(141, 22);
            this.nameTextBox.TabIndex = 4;
            //
            // nameLabel
            //
            this.nameLabel.Location = new System.Drawing.Point(69, 144);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(163, 68);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Student Name";
            //
            // studentDataGridView
            //
            this.studentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.studentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.IDColumn, this.nameColumn });
            this.studentDataGridView.Location = new System.Drawing.Point(313, 61);
            this.studentDataGridView.Name = "studentDataGridView";
            this.studentDataGridView.RowTemplate.Height = 24;
            this.studentDataGridView.Size = new System.Drawing.Size(409, 305);
            this.studentDataGridView.TabIndex = 5;
            //
            // IDColumn
            //
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            //
            // nameColumn
            //
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.studentDataGridView);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.IDLabel);
            this.Name = "Form1";
            this.Text = "Hello World";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView studentDataGridView;

        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;

        private System.Windows.Forms.Button addButton;

        private System.Windows.Forms.TextBox IDTextBox;

        private System.Windows.Forms.Label IDLabel;

        #endregion
    }
}
