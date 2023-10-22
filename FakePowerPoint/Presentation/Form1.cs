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
    public interface IShapeDrawer
    {
        // brief: Draw a rectangle on the paint region
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle);

        // brief: Draw a line on the paint region
        void DrawLine(Color color, List<Tuple<int, int>> coordinates);
        // And so on for other shapes
    }

    public partial class Form1 : Form, IShapeDrawer
    {
        // brief: Constructor
        public Form1(Model model)
        {
            _model = model;
            InitializeComponent();
            PaintGroup.Paint += PaintBoardOnPaint;
            ShapeSelect.DataSource = _model.ShapeTypes;
        }

        // brief: Draw a rectangle on the paint region
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var formGraphics = PaintGroup.CreateGraphics();
            formGraphics.DrawRectangle(myPen, rectangle);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        // brief: Draw a line on the paint region
        public void DrawLine(Color color, List<Tuple<int, int>> coordinates)
        {
            var myPen = new Pen(color, PEN_WIDTH);
            var formGraphics = PaintGroup.CreateGraphics();
            formGraphics.DrawLine(myPen, coordinates[0].Item1, coordinates[0].Item2, coordinates[1].Item1,
                coordinates[1].Item2);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        // brief: Draw a circle on the paint region
        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _model.AddShape(ShapeSelect.Text);
            AddShapeToDataGrid(_model.Shapes.Last());
            PaintGroup.Invalidate();
        }

        // brief: Draw a circle on the paint region
        private void PaintBoardOnPaint(object sender, PaintEventArgs e)
        {
            foreach (var shape in _model.Shapes)
            {
                shape.Item3.Draw(this);
            }
        }

        // brief: Remove a shape from the paint region
        private void ClickOnShapeInfo(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _model.RemoveShape(e.RowIndex);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                PaintGroup.Invalidate();
            }
        }

        // brief: Add a shape to the data grid
        private void AddShapeToDataGrid(Tuple<string, string, IShape> shape)
        {
            dataGridView1.Rows.Add(REMOVE, shape.Item1, shape.Item2);
        }

        private readonly Model _model;
        private const string REMOVE = "Remove";
        private const int PEN_WIDTH = 5;
    }
}
