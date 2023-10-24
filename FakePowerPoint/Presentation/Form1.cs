using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class Form1 : Form
    {
        private const string REMOVE = "Remove";
        private readonly PresentationModel _presentationModel;
        // private Dictionary<ToolStripButton, int> buttonIndexes = new Dictionary<ToolStripButton, int>();

        public Form1(PresentationModel model)
        {
            _presentationModel = model;
            InitializeComponent();
            SetupPresentationModel();
            SetupPaintGroup();
            BindEventsToControls();
            SetupDataGrid();
            this.DataBindings.Add("Cursor", _presentationModel, "Cursor");
            this.DoubleBuffered = true;
        }

        private void BindEventsToControls()
        {
            foreach (Control control in this.Controls)
            {
                control.MouseDown += MouseDownOnForm;
                control.MouseMove += MouseMovingOnForm;
                control.MouseUp += MouseUpOnForm;
            }

            _presentationModel.Selected.ItemUpdated += List_OnItemUpdated;
        }

        private void SetupDataGrid()
        {
            var buttonColumn = new DataGridViewButtonColumn()
            {
                HeaderText = REMOVE, Text = REMOVE, UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);
        }

        private void SetupPaintGroup()
        {
            _presentationModel.SetPaintGroup(PaintGroup);
            PaintGroup.Paint += PaintBoardOnPaint;
        }

        private void SetupPresentationModel()
        {

            _presentationModel.BindShapeSelect(ShapeSelect);
        }

        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddShape((ShapeType)ShapeSelect.SelectedItem);
            PaintGroup.Invalidate();
        }

        private void PaintBoardOnPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.DrawEverything();
        }

        private void DeleteShape(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _presentationModel.RemoveShape(e.RowIndex);
                PaintGroup.Invalidate();
            }
        }

        private void DrawLineButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Line);
        }

        private void DrawRectButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Rectangle);
        }

        private void DrawEclipseButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Eclipse);
        }

        private void MouseDownOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDown(e);
        }

        private void MouseMovingOnForm(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            var pos = new Point(e.X + control.Location.X, e.Y + control.Location.Y);
            _presentationModel.MouseMove(e, pos);
        }

        private void MouseUpOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUp(e);
        }

        private void List_OnItemUpdated(int index, bool newValue)
        {
            var buttonList = toolStrip1.Items.OfType<ToolStripButton>().ToList();
            buttonList.ForEach(x => x.Checked = false);
            if (index >= 0)
            {
                buttonList[index].Checked = newValue;
            }
        }
    }
}
