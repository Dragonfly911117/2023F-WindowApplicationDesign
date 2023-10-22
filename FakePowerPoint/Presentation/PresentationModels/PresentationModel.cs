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

    public class PresentationModel
    {
        public PresentationModel(Model model)
        {
            this._model = model;
        }

        public void SetPaintGroup(System.Windows.Forms.GroupBox paintGroup)
        {
            _drawer.SetPaintGroup(paintGroup);
        }


        // brief: Add a shape to the data grid
        public void AddShape(string shapeType)
        {
            _model.AddShape(shapeType);
        }

        // brief: Remove a shape from the paint region
        public void RemoveShape(int index)
        {
            _model.RemoveShape(index);
        }

        public void BindDataGrid(DataGridView dataGridView)
        {
            dataGridView.DataSource = _model.Shapes;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private readonly Model _model;

        private readonly ShapeDrawer _drawer = new ShapeDrawer();


        public void BindShapeSelect(ComboBox shapeSelect)
        {
            var temp = ShapeFactory.ShapeTypeDescriptions.Values.ToList();
            temp.RemoveAt(0); // remove the ability to select UNDEFINED shape
            shapeSelect.DataSource = temp;
        }

        public void DrawEverything()
        {
            _drawer.DrawEverything(_model.Shapes);
        }
    }
}
