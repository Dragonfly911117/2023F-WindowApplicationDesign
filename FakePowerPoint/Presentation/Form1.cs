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
        public Form1(Info model)
        {
            _presentationModel = model;
            InitializeComponent();
            _presentationModel.SetPaintGroup(PaintGroup);
            PaintGroup.Paint += PaintBoardOnPaint;

            _presentationModel.BindShapeSelect(ShapeSelect);

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = REMOVE;
            buttonColumn.Text = REMOVE;
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);
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
            if (sender is Info dataGridView && e.ColumnIndex == 0)
            {
                _presentationModel.RemoveShape(e.RowIndex);
                PaintGroup.Invalidate();
            }
        }

        private const String REMOVE = "Remove";


        private readonly Info _presentationModel;

        private void DrawLineButtonClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _presentationModel.DrawLineButtonClicked();
        }

        private void DrawRectButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawRectButtonClicked();
        }

        private void DrawEclipseButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawEclipseButtonClicked();
        }
    }
}
