using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class Form1 : Form
    {
        // Constant value used for remove string
        private const string REMOVE = "Remove";
        // Readonly field to hold the reference of the presentation model
        private readonly PresentationModel _presentationModel;

        // Form constructor with a model parameter
        public Form1(PresentationModel model)
        {
            _presentationModel = model;
            InitializeComponent();
            // Set up the software components
            BindShapeSelectToPresentationModel();
            ConfigurePaintGroupForPainting();
            BindEventsToControls();
            ConfigureDataGridView();
            this.DoubleBuffered = true;
        }

        // Method to bind mouse events to all controls on the form
        private void BindEventsToControls()
        {
            foreach (Control control in this.Controls)
            {
                control.MouseDown += MouseDownOnForm;
                control.MouseMove += MouseMovingOnForm;
                control.MouseUp += MouseUpOnForm;
            }

            // Bind event to track changes in Selected list of PresentationModel
            _presentationModel.Selected.ItemUpdated += OnSelectionUpdated;
        }

        // Setup the DataGrid with remove button and bind it to the model
        private void ConfigureDataGridView()
        {
            var buttonColumn = new DataGridViewButtonColumn()
            {
                HeaderText = REMOVE, Text = REMOVE, UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);
        }

        // Prepare the PaintGroup for painting operation
        private void ConfigurePaintGroupForPainting()
        {
            _presentationModel.SetPaintGroup(PaintGroup);
            PaintGroup.Paint += PaintBoardOnPaint;
        }

        // Set up the presentation model with ShapeSelect object
        private void BindShapeSelectToPresentationModel()
        {
            _presentationModel.BindShapeSelect(ShapeSelect);
        }

        // Event fired when the AddShape button is clicked
        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddShape((ShapeType)ShapeSelect.SelectedItem);
            PaintGroup.Invalidate();
        }

        // Event that fires to redraw all shapes on the paint board
        private void PaintBoardOnPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.DrawEverything();
        }

        // Handling removal of shapes from the DataGridView and UI
        private void DeleteShape(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // checking if delete button was clicked/tapped
            {
                _presentationModel.RemoveShape(e.RowIndex);
                PaintGroup.Invalidate();
            }
        }

        // Shape button click event handlers
        private void DrawLineButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Line);
        }

        // Shape button click event handlers
        private void DrawRectButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Rectangle);
        }

        // Shape button click event handlers
        private void DrawEclipseButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Eclipse);
        }

        // Handlers for mouse events translating them to the model
        private void MouseDownOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDown(e);
        }

        // Handlers for mouse events translating them to the model
        private void MouseMovingOnForm(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            var pos = new Point(e.X + control.Location.X, e.Y + control.Location.Y); // calculate exact position of the mouse pointer
            _presentationModel.MouseMove(e, pos);
        }

        // Handlers for mouse events translating them to the model
        private void MouseUpOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUp(e);
        }

        // Method invoked when an item has been updated in Selected list
        private void OnSelectionUpdated(int index, bool newValue)
        {
            var buttonList = toolStrip1.Items.OfType<ToolStripButton>().ToList(); // get all the buttons
            buttonList.ForEach(x => x.Checked = false);
            if (index >= 0)
            {
                buttonList[index].Checked = newValue;
            }
        }
    }
}
