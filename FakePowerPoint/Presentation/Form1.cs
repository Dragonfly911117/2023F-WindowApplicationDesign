using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        this.DoubleBuffered = true;
            _presentationModel.SetPaintGroup(PaintGroup);
            PaintGroup.Paint += PaintBoardOnPaint;

            _presentationModel.BindShapeSelect(ShapeSelect);

            var buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = REMOVE;
            buttonColumn.Text = REMOVE;
            buttonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);

            foreach (Control control in this.Controls) // every control on the form's mouse event
            {
                control.MouseDown += MouseDownOnForm;
                control.MouseMove += MouseMovingOnForm;
                control.MouseUp += MouseUpOnForm;
            }

            _presentationModel.Selected.ItemUpdated += List_OnItemUpdated;

            this.DataBindings.Add("Cursor", _presentationModel, "Cursor");
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

        private void MouseDownOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDown(e);
        }

        private void MouseMovingOnForm(object sender, MouseEventArgs e)
        { Control control = sender as Control;
            var pos = new Point(e.X + control.Location.X, e.Y + control.Location.Y);
            _presentationModel.MouseMove(e, pos);
        }

        private void MouseUpOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUp(e);
        }

        private Dictionary<ToolStripButton, int> buttonIndexes = new Dictionary<ToolStripButton, int>();

        private void List_OnItemUpdated(int index, bool newValue)
        {
            // Find button by its index
            toolStrip1.Items.OfType<ToolStripButton>().ToList().ForEach(x => x.Checked = false);
            // Update Checkbox
            if (index >= 0)
            {
                var button = toolStrip1.Items.OfType<ToolStripButton>().ToList()[index];
                button.Checked = newValue;
            }
        }
    }
}
