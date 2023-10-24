using System.Drawing;
using System.Windows.Forms;

namespace FakePowerPoint
{
  partial class Form1 : Form
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.PaintGroup = new System.Windows.Forms.GroupBox();
      this.miniToolStrip = new System.Windows.Forms.MenuStrip();
      this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.InfoGroup = new System.Windows.Forms.GroupBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.ShapeSelect = new System.Windows.Forms.ComboBox();
      this.AddShape = new System.Windows.Forms.Button();
      this.SlidesGroup = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.drawLineButton = new System.Windows.Forms.ToolStripButton();
      this.drawRectBoutton = new System.Windows.Forms.ToolStripButton();
      this.drawEclipseButton = new System.Windows.Forms.ToolStripButton();
      this.miniToolStrip.SuspendLayout();
      this.InfoGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SlidesGroup.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // PaintGroup
      // 
      this.PaintGroup.ForeColor = System.Drawing.Color.White;
      this.PaintGroup.Location = new System.Drawing.Point(217, 54);
      this.PaintGroup.Name = "PaintGroup";
      this.PaintGroup.Size = new System.Drawing.Size(1358, 1011);
      this.PaintGroup.TabIndex = 3;
      this.PaintGroup.TabStop = false;
      this.PaintGroup.Text = "Paint";
      // 
      // miniToolStrip
      // 
      this.miniToolStrip.AutoSize = false;
      this.miniToolStrip.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.miniToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.infoToolStripMenuItem });
      this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
      this.miniToolStrip.Name = "miniToolStrip";
      this.miniToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.miniToolStrip.Size = new System.Drawing.Size(1827, 26);
      this.miniToolStrip.TabIndex = 0;
      this.miniToolStrip.TabStop = true;
      // 
      // infoToolStripMenuItem
      // 
      this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.aboutToolStripMenuItem });
      this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
      this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
      this.infoToolStripMenuItem.Text = "Info";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
      this.aboutToolStripMenuItem.Text = "About";
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
      this.InfoGroup.ForeColor = System.Drawing.Color.White;
      this.InfoGroup.Location = new System.Drawing.Point(1593, 54);
      this.InfoGroup.Name = "InfoGroup";
      this.InfoGroup.Size = new System.Drawing.Size(226, 1011);
      this.InfoGroup.TabIndex = 1;
      this.InfoGroup.TabStop = false;
      this.InfoGroup.Text = "Info";
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
      this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.GridColor = System.Drawing.Color.Black;
      this.dataGridView1.Location = new System.Drawing.Point(10, 99);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
      this.dataGridView1.ShowCellErrors = false;
      this.dataGridView1.ShowCellToolTips = false;
      this.dataGridView1.ShowEditingIcon = false;
      this.dataGridView1.Size = new System.Drawing.Size(204, 936);
      this.dataGridView1.TabIndex = 2;
      this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteShape);
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
      this.SlidesGroup.Location = new System.Drawing.Point(20, 54);
      this.SlidesGroup.Name = "SlidesGroup";
      this.SlidesGroup.Size = new System.Drawing.Size(177, 1011);
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
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.drawLineButton, this.drawRectBoutton, this.drawEclipseButton });
      this.toolStrip1.Location = new System.Drawing.Point(0, 26);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1827, 25);
      this.toolStrip1.TabIndex = 4;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DrawLineButtonClicked);
      // 
      // drawLineButton
      // 
      this.drawLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.drawLineButton.Image = ((System.Drawing.Image)(resources.GetObject("drawLineButton.Image")));
      this.drawLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.drawLineButton.Name = "drawLineButton";
      this.drawLineButton.Size = new System.Drawing.Size(23, 22);
      this.drawLineButton.Text = "Line";
      // 
      // drawRectBoutton
      // 
      this.drawRectBoutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.drawRectBoutton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectBoutton.Image")));
      this.drawRectBoutton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.drawRectBoutton.Name = "drawRectBoutton";
      this.drawRectBoutton.Size = new System.Drawing.Size(23, 22);
      this.drawRectBoutton.Text = "Rect";
      this.drawRectBoutton.Click += new System.EventHandler(this.DrawRectButtonClicked);
      // 
      // drawEclipseButton
      // 
      this.drawEclipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.drawEclipseButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEclipseButton.Image")));
      this.drawEclipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.drawEclipseButton.Name = "drawEclipseButton";
      this.drawEclipseButton.Size = new System.Drawing.Size(23, 22);
      this.drawEclipseButton.Text = "Eclipse";
      this.drawEclipseButton.Click += new System.EventHandler(this.DrawEclipseButtonClicked);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(1827, 1134);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.PaintGroup);
      this.Controls.Add(this.SlidesGroup);
      this.Controls.Add(this.InfoGroup);
      this.Controls.Add(this.miniToolStrip);
      this.Location = new System.Drawing.Point(15, 15);
      this.Name = "Form1";
      this.miniToolStrip.ResumeLayout(false);
      this.miniToolStrip.PerformLayout();
      this.InfoGroup.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.SlidesGroup.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private System.Windows.Forms.ToolStripButton drawLineButton;
    private System.Windows.Forms.ToolStripButton drawRectBoutton;
    private System.Windows.Forms.ToolStripButton drawEclipseButton;

    private System.Windows.Forms.ToolStrip toolStrip1;


    private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.GroupBox PaintGroup;

    private System.Windows.Forms.GroupBox SlidesGroup;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.GroupBox InfoGroup;

    private System.Windows.Forms.ComboBox ShapeSelect;

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button AddShape;

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.MenuStrip miniToolStrip;

    #endregion
  }
}

