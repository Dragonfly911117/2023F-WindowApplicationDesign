using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FakePowerPoint
{
    public partial class Form1 : Form
    {
        private const string REMOVE = "Remove";
        private readonly PresentationModel _presentationModel;

        public Form1(PresentationModel model)
        {
            _presentationModel = model;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            BindShapeSelectToPresentationModel();
            BindPaintGroupBox();
            BindEventsToControls();
            BindDataGridViewColumns();
            AttachKeyDownEventHandler(this);
        }

        private void BindShapeSelectToPresentationModel()
        {
            _presentationModel.BindShapeSelect(ShapeSelect);
        }

        private void BindPaintGroupBox()
        {
            _presentationModel.SetPaintGroup(PaintGroup);
            _presentationModel.BindSlideBackground(button1);
        }

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

        private void BindDataGridViewColumns()
        {
            var buttonColumn = new DataGridViewButtonColumn()
            {
                HeaderText = REMOVE, Text = REMOVE, UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(0, buttonColumn);
            _presentationModel.BindDataGrid(dataGridView1);
        }

        private void AttachKeyDownEventHandler(Control control)
        {
            control.KeyDown += HandleKeyDown;
            foreach (Control childControl in control.Controls)
            {
                AttachKeyDownEventHandler(childControl);
            }
        }

        // Mouse events translating to the model
        private void MouseDownOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDown(e);
        }

        private void MouseMovingOnForm(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                var pos = new Point(e.X + control.Location.X, e.Y + control.Location.Y);
                _presentationModel.MouseMove(e, pos);
            }
        }

        private void MouseUpOnForm(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUp(e);
        }

        // Button click events
        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddShape((ShapeType)ShapeSelect.SelectedItem);
            _presentationModel.DrawEverything();
        }

        private void DeleteShape(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _presentationModel.RemoveShape(e.RowIndex);
                _presentationModel.DrawEverything();
            }
        }

        private void HandleNormalModeButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Undefined);
        }

        private void HandleDrawLineButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Line);
        }

        private void HandleDrawRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Rectangle);
        }

        private void HandleDrawEclipseButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.DrawShapeButtonClicked(ShapeType.Eclipse);
        }

        // Other methods
        private void UpdateSelection(int index, bool newValue)
        {
            var buttonList = toolStrip1.Items.OfType<ToolStripButton>().ToList();
            buttonList.ForEach(x => x.Checked = false);
            if (index >= 0)
            {
                buttonList[index].Checked = newValue;
            }
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.KeyDown(e.KeyCode);
        }
    }
}
