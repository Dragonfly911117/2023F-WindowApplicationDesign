using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint;
using NUnit.Framework;

namespace FakeUnitTest
{
    public class TestPresentationModel : PresentationModel
    {
        public TestPresentationModel(Model model)
            : base(model)
        {
        }

        [SetUp]
        public void SetUp()
        {

        }
    }
}
