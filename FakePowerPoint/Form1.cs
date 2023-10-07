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
        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle);

        void DrawLine(Color color, List<Tuple<int, int>> coordinates);
        // And so on for other shapes
    }

    public partial class Form1 : Form, IShapeDrawer
    {
        public Form1(Model model)
        {
            _model = model;
            InitializeComponent();
            PaintGroup.Paint += PaintGroup_Paint;
            ShapeSelect.DataSource = _model.ShapeTypes;
        }

        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle)
        {
            var myPen = new System.Drawing.Pen(color, 5);
            var formGraphics = this.PaintGroup.CreateGraphics();
            formGraphics.DrawRectangle(myPen, rectangle);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        public void DrawLine(Color color, List<Tuple<int, int>> coordinates)
        {
            var myPen = new System.Drawing.Pen(color, 5);
            var formGraphics = PaintGroup.CreateGraphics();
            formGraphics.DrawLine(myPen, coordinates[0].Item1, coordinates[0].Item2, coordinates[1].Item1,
                coordinates[1].Item2);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private Model _model;

        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            _model.AddShape(ShapeSelect.Text);
            AddShapeToDataGrid(_model.Shapes.Last());
            PaintGroup.Invalidate();
        }

        private void PaintGroup_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in _model.Shapes)
            {
                shape.Item3.Draw(this);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _model.RemoveShape(e.RowIndex);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                PaintGroup.Invalidate();
            }
        }

        private void AddShapeToDataGrid(Tuple<String, String, IShape> shape)
        {
            dataGridView1.Rows.Add(Remove, shape.Item1, shape.Item2);
        }

        private const string Remove = "Remove";
    }
}
