using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint.Presentation.PM;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation
{
    public partial class Form1 : Form
    {
        PresentationModel _presentationModel;

        public Form1(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            ConstructLayout();
            BindThings();
            BindEventHandlers();
            Size = new Size(int.Parse(Resources.DEFAULT_WINDOW_WIDTH), int.Parse(Resources.DEFAULT_WINDOW_HEIGHT));
        }
    }
}
