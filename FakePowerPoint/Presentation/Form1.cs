using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class Form1 : Form
    {
        // brief: Constructor
        public Form1(PresentationModel model)
        {
            _presentationModel = model;
            InitializeComponent();
            _presentationModel.SetPaintGroup(PaintGroup);
            PaintGroup.Paint += PaintBoardOnPaint;
            ShapeSelect.DataSource = _presentationModel.ShapeTypes;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Text = "刪除";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(0, buttonColumn);
            dataGridView1.CellContentClick += DeleteShape;
            dataGridView1.ForeColor = Color.Black;
            _presentationModel.BindDataGrid(dataGridView1);
            // dataGridView1.Columns[1].Visible = false; // hide the color column
        }

        // brief: Draw a circle on the paint region
        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddShape(ShapeSelect.Text);
            PaintGroup.Invalidate();
        }

        // brief: Draw a circle on the paint region
        private void PaintBoardOnPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.DrawEverything();
        }

        // brief: Remove a shape from the paint region
        private void DeleteShape(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.RemoveShape(e.RowIndex);
            PaintGroup.Invalidate();
        }


        private readonly PresentationModel _presentationModel;
    }
}
