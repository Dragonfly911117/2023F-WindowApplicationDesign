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
    public partial class Form1 : Form
    {
        public Form1(Control control)
        {
            _control = control;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _graphics = CreateGraphics();
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            _control.DrawAll(ref _graphics);
        }

        private Graphics _graphics;
        private Control _control;
    }
}
