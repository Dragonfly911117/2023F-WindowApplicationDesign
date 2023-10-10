using System.Drawing;

namespace FakePowerPoint
{
  partial class Form1 : IShapeDrawer
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
      this.PaintGroup = new System.Windows.Forms.GroupBox();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.panel1 = new System.Windows.Forms.Panel();
      this.InfoGroup = new System.Windows.Forms.GroupBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.ButtonDeletingTheShape = new System.Windows.Forms.DataGridViewButtonColumn();
      this.ShapeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ShapeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ShapeSelect = new System.Windows.Forms.ComboBox();
      this.AddShape = new System.Windows.Forms.Button();
      this.SlidesGroup = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.InfoGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SlidesGroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // PaintGroup
      // 
      this.PaintGroup.ForeColor = System.Drawing.Color.White;
      this.PaintGroup.Location = new System.Drawing.Point(217, 13);
      this.PaintGroup.Name = "PaintGroup";
      this.PaintGroup.Size = new System.Drawing.Size(1358, 1052);
      this.PaintGroup.TabIndex = 3;
      this.PaintGroup.TabStop = false;
      this.PaintGroup.Text = "Paint";
      // 
      // miniToolStrip
      // 
      this.menuStrip.AutoSize = false;
      this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.menuStrip.Location = new System.Drawing.Point(6, 2);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.menuStrip.Size = new System.Drawing.Size(92, 19);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.TabStop = true;
      this.menuStrip.Visible = false;
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(200, 100);
      this.panel1.TabIndex = 0;
      // 
      // InfoGroup
      // 
      this.InfoGroup.Controls.Add(this.dataGridView1);
      this.InfoGroup.Controls.Add(this.ShapeSelect);
      this.InfoGroup.Controls.Add(this.AddShape);
      this.InfoGroup.ForeColor = System.Drawing.Color.Black;
      this.InfoGroup.Location = new System.Drawing.Point(1593, 13);
      this.InfoGroup.Name = "InfoGroup";
      this.InfoGroup.Size = new System.Drawing.Size(226, 1052);
      this.InfoGroup.TabIndex = 1;
      this.InfoGroup.TabStop = false;
      this.InfoGroup.Text = "Info";
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
      this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ButtonDeletingTheShape, this.ShapeName, this.ShapeInfo });
      this.dataGridView1.Location = new System.Drawing.Point(10, 99);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.ShowCellErrors = false;
      this.dataGridView1.ShowCellToolTips = false;
      this.dataGridView1.ShowEditingIcon = false;
      this.dataGridView1.Size = new System.Drawing.Size(204, 936);
      this.dataGridView1.TabIndex = 2;
      this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickOnShapeInfo);
      // 
      // ButtonDeletingTheShape
      // 
      this.ButtonDeletingTheShape.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ButtonDeletingTheShape.HeaderText = "Delete";
      this.ButtonDeletingTheShape.Name = "ButtonDeletingTheShape";
      this.ButtonDeletingTheShape.ReadOnly = true;
      this.ButtonDeletingTheShape.Text = "Delete";
      // 
      // ShapeName
      // 
      this.ShapeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ShapeName.HeaderText = "Shape";
      this.ShapeName.Name = "ShapeName";
      this.ShapeName.ReadOnly = true;
      // 
      // ShapeInfo
      // 
      this.ShapeInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ShapeInfo.HeaderText = "ShapeInfo";
      this.ShapeInfo.Name = "ShapeInfo";
      this.ShapeInfo.ReadOnly = true;
      // 
      // ShapeSelect
      // 
      this.ShapeSelect.FormattingEnabled = true;
      this.ShapeSelect.Location = new System.Drawing.Point(99, 51);
      this.ShapeSelect.Name = "ShapeSelect";
      this.ShapeSelect.Size = new System.Drawing.Size(116, 21);
      this.ShapeSelect.TabIndex = 1;
      // 
      // AddShape
      // 
      this.AddShape.ForeColor = System.Drawing.Color.Black;
      this.AddShape.Location = new System.Drawing.Point(10, 35);
      this.AddShape.Name = "AddShape";
      this.AddShape.Size = new System.Drawing.Size(74, 56);
      this.AddShape.TabIndex = 0;
      this.AddShape.Text = "Add";
      this.AddShape.UseVisualStyleBackColor = true;
      this.AddShape.Click += new System.EventHandler(this.AddShapeButtonClick);
      // 
      // SlidesGroup
      // 
      this.SlidesGroup.Controls.Add(this.button2);
      this.SlidesGroup.Controls.Add(this.button1);
      this.SlidesGroup.ForeColor = System.Drawing.Color.White;
      this.SlidesGroup.Location = new System.Drawing.Point(20, 12);
      this.SlidesGroup.Name = "SlidesGroup";
      this.SlidesGroup.Size = new System.Drawing.Size(177, 1053);
      this.SlidesGroup.TabIndex = 2;
      this.SlidesGroup.TabStop = false;
      this.SlidesGroup.Text = "Slides";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(15, 199);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(145, 102);
      this.button2.TabIndex = 1;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(15, 54);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(145, 102);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(1827, 1134);
      this.Controls.Add(this.PaintGroup);
      this.Controls.Add(this.SlidesGroup);
      this.Controls.Add(this.InfoGroup);
      this.Controls.Add(this.menuStrip);
      this.Location = new System.Drawing.Point(15, 15);
      this.Name = "Form1";
      this.InfoGroup.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.SlidesGroup.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.DataGridViewButtonColumn ButtonDeletingTheShape;
    private System.Windows.Forms.DataGridViewTextBoxColumn ShapeName;
    private System.Windows.Forms.DataGridViewTextBoxColumn ShapeInfo;

    private System.Windows.Forms.GroupBox PaintGroup;

    private System.Windows.Forms.GroupBox SlidesGroup;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.GroupBox InfoGroup;

    private System.Windows.Forms.ComboBox ShapeSelect;

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button AddShape;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.MenuStrip menuStrip;

    #endregion
  }
}

