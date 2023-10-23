using System;
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

            _presentationModel.BindShapeSelect(ShapeSelect);

            var buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = REMOVE;
            buttonColumn.Text = REMOVE;
            buttonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);

            PaintGroup.MouseDown += MouseDownOn;
            PaintGroup.MouseMove += MouseMoving;
            PaintGroup.MouseUp += MouseUpOn;

            DataBindings.Add("Cursor", _presentationModel, "Cursor");
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
            if (e.ColumnIndex == 0)
            {
                _presentationModel.RemoveShape(e.RowIndex);
                PaintGroup.Invalidate();
            }
        }

        private const string REMOVE = "Remove";


        private readonly PresentationModel _presentationModel;

        private void DrawLineButtonClicked(object sender, EventArgs e)
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

        private void MouseDownOn(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDownOnPanel(e);
        }

        private void MouseMoving(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseMovingOnPanel(e);
        }

        private void MouseUpOn(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUpOnPanel(e);
        }
    }
}
