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
    public partial class Info
    {
        // brief: Constructor
        public Info(Model model)
        {
            this._model = model;
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


        // brief: Bind the data grid to the model's shapes

        public void BindDataGrid(System.Windows.Forms.DataGridView dataGridView)
        {
            dataGridView.DataSource = _model.Shapes;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        // brief: Bind the shape select to the model's shapesInfo

        public void BindShapeSelect(ComboBox shapeSelect)
        {
            var temp = ShapeFactory.ShapeTypeDescriptions.Values.ToList();
            temp.RemoveAt(0); // remove the ability to select UNDEFINED shape
            shapeSelect.DataSource = temp;
        }


        private readonly Model _model;
    }
}
