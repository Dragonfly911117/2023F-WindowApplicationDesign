using System.Drawing;
using FakePowerPoint;
using Moq;
using NUnit.Framework;
using Rectangle = System.Drawing.Rectangle;

namespace FakeUnitTest{

public class TestGraphics
{
    private FakeGraphics _fakeGraphics;

    [SetUp]
    public void Setup()
    {
        _fakeGraphics = new FakeGraphics();
    }

    [Test]
    public void TestDrawRectangle()
    {
        var pen = new Pen(Color.Black);
        var rectangle = new Rectangle(0, 0, 0, 0);
        _fakeGraphics.DrawRectangle(pen, rectangle);
        Assert.AreEqual(pen, _fakeGraphics.NotPen);
        Assert.AreEqual(rectangle, _fakeGraphics.NotRectangle);
    }

    [Test]
    public void TestDrawEllipse()
    {
        var pen = new Pen(Color.Black);
        var rectangle = new Rectangle(0, 0, 0, 0);
        _fakeGraphics.DrawEllipse(pen, rectangle);
        Assert.AreEqual(pen, _fakeGraphics.NotPen);
        Assert.AreEqual(rectangle, _fakeGraphics.NotRectangle);

        _fakeGraphics.DrawEllipse(pen, 1, 1, 1, 1);
        Assert.AreEqual(pen, _fakeGraphics.NotPen);
        Assert.AreEqual(1, _fakeGraphics.X);
        Assert.AreEqual(1, _fakeGraphics.Y);
        Assert.AreEqual(1, _fakeGraphics.Width);
        Assert.AreEqual(1, _fakeGraphics.Height);
    }

    [Test]
    public void TestDrawLine()
    {
        var pen = new Pen(Color.Black);
        _fakeGraphics.DrawLine(pen, 0, 0, 0, 0);
        Assert.AreEqual(pen, _fakeGraphics.NotPen);
        Assert.AreEqual(0, _fakeGraphics.X1);
        Assert.AreEqual(0, _fakeGraphics.Y1);
        Assert.AreEqual(0, _fakeGraphics.X2);
        Assert.AreEqual(0, _fakeGraphics.Y2);
    }

    [Test]
    public void TestFillEllipse()
    {
        var brush = new SolidBrush(Color.Black);
        _fakeGraphics.FillEllipse(brush, 0, 0, 0, 0);
        Assert.AreEqual(brush, _fakeGraphics.Brush);
        Assert.AreEqual(0, _fakeGraphics.X);
        Assert.AreEqual(0, _fakeGraphics.Y);
        Assert.AreEqual(0, _fakeGraphics.Width);
        Assert.AreEqual(0, _fakeGraphics.Height);
    }

    [Test]
    public void TestClear()
    {
        var color = Color.Black;
        _fakeGraphics.Clear(color);
        Assert.AreEqual(color, _fakeGraphics.Color);
    }

    [Test]
    public void TestDrawRectangleWithMock()
    {
        var mockGraphics = new Mock<IGraphics>();
        var pen = new Pen(Color.Black);
        var rectangle = new Rectangle(0, 0, 0, 0);
        mockGraphics.Setup(x => x.DrawRectangle(pen, rectangle));
        mockGraphics.Object.DrawRectangle(pen, rectangle);
        mockGraphics.Verify(x => x.DrawRectangle(pen, rectangle), Times.Once);
    }

    [Test]
    public void TestDrawEllipseWithMock()
    {
        var mockGraphics = new Mock<IGraphics>();
        var pen = new Pen(Color.Black);
        var rectangle = new Rectangle(0, 0, 0, 0);
        mockGraphics.Setup(x => x.DrawEllipse(pen, rectangle));
        mockGraphics.Object.DrawEllipse(pen, rectangle);
        mockGraphics.Verify(x => x.DrawEllipse(pen, rectangle), Times.Once);
    }

    [Test]
    public void TestDrawLineWithMock()
    {
        var mockGraphics = new Mock<IGraphics>();
        var pen = new Pen(Color.Black);
        mockGraphics.Setup(x => x.DrawLine(pen, 0, 0, 0, 0));
        mockGraphics.Object.DrawLine(pen, 0, 0, 0, 0);
        mockGraphics.Verify(x => x.DrawLine(pen, 0, 0, 0, 0), Times.Once);
    }

    [Test]
    public void TestFillEllipseWithMock()
    {
        var mockGraphics = new Mock<IGraphics>();
        var brush = new SolidBrush(Color.Black);
        mockGraphics.Setup(x => x.FillEllipse(brush, 0, 0, 0, 0));
        mockGraphics.Object.FillEllipse(brush, 0, 0, 0, 0);
        mockGraphics.Verify(x => x.FillEllipse(brush, 0, 0, 0, 0), Times.Once);
    }
}
}
