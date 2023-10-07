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
        }

        public void DrawRectangle(Color color, System.Drawing.Rectangle rectangle)
        {
            var myPen = new System.Drawing.Pen(color);
            var formGraphics = this.CreateGraphics();
            formGraphics.DrawRectangle(myPen, rectangle);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        public void DrawLine(Color color, List<Tuple<int, int>> coordinates)
        {
            var myPen = new System.Drawing.Pen(color);
            var formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(myPen, coordinates[0].Item1, coordinates[0].Item2,
                coordinates[1].Item1, coordinates[1].Item2);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private Model _model;
    }
}
