using System.Windows.Forms;
using FakePowerPoint.Presentation.PM;

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
        }
    }
}
