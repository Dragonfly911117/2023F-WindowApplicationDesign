using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// Form1 class to handle user interactions
namespace FakePowerPoint
{
    public partial class Form1 : Form
    {
        // Constants and fields
        private const string REMOVE = "Remove";
        private readonly PresentationModel _presentationModel;

        // Constructor
        public Form1(PresentationModel model)
        {
            _presentationModel = model;
            InitializeComponent();
            Initialize();
        }

        // Initialization method for the form
        private void Initialize()
        {
            BindShapeSelectToPresentationModel();
            BindPaintGroupBox();
            BindEventsToControls();
            BindDataGridViewColumns();
            AttachKeyDownEventHandler(this);
        }

        // Binds ShapeSelect control events to PresentationModel
        private void BindShapeSelectToPresentationModel()
        {
            _presentationModel.BindShapeSelect(ShapeSelect);
        }

        // Sets the paint group and binds slide background to a button
        private void BindPaintGroupBox()
        {
            _presentationModel.SetPaintGroup(PaintGroup);
            _presentationModel.BindSlideBackground(button1);
        }

        // Binds mouse events to controls and subscribes to selection updates
        private void BindEventsToControls()
        {
            foreach (Control control in Controls)
            {
                control.MouseDown += MouseDownOnForm;
                control.MouseMove += MouseMovingOnForm;
                control.MouseUp += MouseUpOnForm;
            }
            _presentationModel.Selected.ItemUpdated += UpdateSelection;
        }

        // Binds DataGridView columns and events
        private void BindDataGridViewColumns()
        {
            var buttonColumn = new DataGridViewButtonColumn()
            {
                HeaderText = REMOVE,
                Text = REMOVE,
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);
        }

        // Attaches KeyDown event handler to the form and its child controls
        private void AttachKeyDownEventHandler(Control control)
        {
            control.KeyDown += HandleKeyDown;
            foreach (Control childControl in control.Controls)
            {
                AttachKeyDownEventHandler(childControl);
            }
        }

        // Mouse down event handling translating to the model
        private void MouseDownOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDown(e);
        }

        // Mouse move event handling translating to the model
        private void MouseMovingOnForm(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                var pos = new Point(e.X + control.Location.X, e.Y + control.Location.Y);
                _presentationModel.MouseMove(e, pos);
            }
        }

        // Mouse up event handling translating to the model
        private void MouseUpOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUp(e);
        }

        // Button click events for shape drawing
        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddShape((ShapeType)ShapeSelect.SelectedItem);
            _presentationModel.DrawEverything();
        }

        // Button click events for shape drawing
        private void DeleteShape(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _presentationModel.RemoveShape(e.RowIndex);
                _presentationModel.DrawEverything();
            }
        }

        // Button click events for shape drawing
        private void HandleNormalModeButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Undefined);
        }

        // Button click events for shape drawing
        private void HandleDrawLineButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Line);
        }

        // Button click events for shape drawing
        private void HandleDrawRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Rectangle);
        }

        // Button click events for shape drawing
        private void HandleDrawEclipseButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Eclipse);
        }

        // Method to update the selection state of toolbar buttons
        private void UpdateSelection(int index, bool newValue)
        {
            var buttonList = toolStrip1.Items.OfType<ToolStripButton>().ToList();
            buttonList.ForEach(x => x.Checked = false);
            if (index >= 0)
            {
                buttonList[index].Checked = newValue;
            }
        }

        // KeyDown event handling translating to the model
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.KeyDown(e.KeyCode);
        }
    }
}
