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
        public void AddShape(ShapeType shapeType)
        {
            _model.AddShape(shapeType);
        }

        public void RemoveShape(int index)
        {
            _model.RemoveShape(index);
        }

        public void BindDataGrid(DataGridView dataGridView)
        {
            dataGridView.DataSource = _model.Shapes;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void BindShapeSelect(ComboBox shapeSelect)
        {
            var temp = ((ShapeType[])Enum.GetValues(typeof(ShapeType))).ToList();
            temp.Remove(ShapeType.Undefined); // remove the ability to select UNDEFINED shape
            shapeSelect.DataSource = temp;
        }
    }
}
