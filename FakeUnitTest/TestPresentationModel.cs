using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint;
using NUnit.Framework;

namespace FakeUnitTest
{
    public class TestPresentationModel : PresentationModel
    {
        public TestPresentationModel()
            : base(new Model())
        {
        }

        private FakeCursor _cursor;

        [SetUp]
        public void SetUp()
        {
            Model = new Model();
            _cursor = new FakeCursor();
        }

        [Test]
        public void TestIsInsideRect()
        {
            // IsInsideRect(Point pos, int x1, int x2, int y1, int y2)
            Assert.IsTrue(IsInsideRect(new Point(0, 0), 0, 10, 0, 10));
            Assert.IsTrue(IsInsideRect(new Point(10, 10), 0, 10, 0, 10));
            Assert.IsTrue(IsInsideRect(new Point(5, 5), 0, 10, 0, 10));
            Assert.IsFalse(IsInsideRect(new Point(11, 11), 0, 10, 0, 10));
            Assert.IsFalse(IsInsideRect(new Point(-1, -1), 0, 10, 0, 10));
            Assert.IsFalse(IsInsideRect(new Point(5, 11), 0, 10, 0, 10));
            Assert.IsFalse(IsInsideRect(new Point(11, 5), 0, 10, 0, 10));
            Assert.IsFalse(IsInsideRect(new Point(-1, 5), 0, 10, 0, 10));
            Assert.IsFalse(IsInsideRect(new Point(5, -1), 0, 10, 0, 10));
        }
    }
}
