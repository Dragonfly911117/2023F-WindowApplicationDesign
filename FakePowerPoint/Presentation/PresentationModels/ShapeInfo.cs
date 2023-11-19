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
    public partial class PresentationModel
    {
        // Adds a new shape of specified type to the model.
        public void AddShape(ShapeType shapeType)
        {
            _model.AddShape(shapeType);
        }

        // Removes a shape at a specified index from the model.
        public void RemoveShape(int index)
        {
            _model.RemoveShape(index);
        }

        // Binds a DataGridView to the shapes in the model and adjusts its column sizing mode.
        public void BindDataGrid(DataGridView dataGridView)
        {
            dataGridView.DataSource = _model.Shapes;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Binds a ComboBox to the shape types and removes the "undefined" shape option.
        public void BindShapeSelect(ComboBox shapeSelect)
        {
            var temp = ((ShapeType[])Enum.GetValues(typeof(ShapeType))).ToList();
            temp.Remove(ShapeType.Selection); // remove the ability to select UNDEFINED shape
            shapeSelect.DataSource = temp;
        }
    }
}
