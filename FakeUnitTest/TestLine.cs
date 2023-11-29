using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint;
using Moq;
using NUnit.Framework;
using Rectangle = System.Drawing.Rectangle;
using BadEclipse = FakePowerPoint.Eclipse;

namespace FakeUnitTest;

public class TestLine
{
    private ShapeFactory _shapeFactory;
    private FakeRandom _random;
    private Line _shape;
    private Mock<IGraphics> _mockGraphics;

    [SetUp]
    public void Setup()
    {
        _shapeFactory = new LineFactory();
        _random = new FakeRandom();
        _shape = (Line)_shapeFactory.CreateShape(new List<int> { 1, 2, 3, 4 });
        _mockGraphics = new Mock<IGraphics>();

        _random.Reset();
    }

    [Test]
    public void TestLineHandleGetter()
    {
        var handles = _shape.Handles;
        Assert.AreEqual(3, handles.Count);
        // new Handle(new Point(x1, y1)),
        // new Handle(new Point((x1 + x2) / 2, (y1 + y2) / 2)),
        // new Handle(new Point(x2, y2))
        Assert.AreEqual(1, handles[0].Coordinate.X);
        Assert.AreEqual(2, handles[0].Coordinate.Y);
        Assert.AreEqual(2, handles[1].Coordinate.X);
        Assert.AreEqual(3, handles[1].Coordinate.Y);
        Assert.AreEqual(3, handles[2].Coordinate.X);
        Assert.AreEqual(4, handles[2].Coordinate.Y);

        // Check that the handles are not selected
        foreach (var handle in handles)
        {
            Assert.IsFalse(handle.Selected);
        }
    }

    [Test]
    public void TestLineDraw()
    {
        _shape.Draw(_mockGraphics.Object, 1);
        _mockGraphics.Verify(x => x.DrawLine(It.IsAny<Pen>(), 1, 2, 3, 4), Times.Once);
    }

    [Test]
    public void TestLineDrawnWhileSelected()
    {
        _shape.Selected = true;
        _shape.Draw(_mockGraphics.Object, 1);
        _mockGraphics.Verify(x => x.DrawLine(It.IsAny<Pen>(), 1, 2, 3, 4), Times.Once);
        _mockGraphics.Verify(
            x => x.DrawEllipse(It.IsAny<Pen>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
            Times.Exactly(3));
        _mockGraphics.Verify(
            x => x.FillEllipse(It.IsAny<Brush>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
            Times.Exactly(3));
    }

    [Test]
    public void TestLineHandleSetter()
    {
        var handles = _shape.Handles;

        foreach (var handle in handles)
        {
            handle.Selected = true;
            handle.Draw(_mockGraphics.Object);
        }

        foreach (var handle in handles)
        {
            Assert.IsTrue(handle.Selected);
        }

        _mockGraphics.Verify(
            x => x.DrawEllipse(It.IsAny<Pen>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
            Times.Exactly(3));
        _mockGraphics.Verify(
            x => x.FillEllipse(It.IsAny<Brush>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
            Times.Exactly(3));
    }

    [Test]
    public void TestShapeType()
    {
        Assert.AreEqual(ShapeType.Line, _shape.ShapeType);
        // assert exception
        Assert.Throws<InvalidOperationException>(() => _shape.ShapeType = ShapeType.Rectangle);
    }

    [Test]
    public void TestLineGetCoordinates()
    {
        Assert.AreEqual("(1, 2),\n(3, 4)", _shape.GetCoordinates());
    }

    [Test]
    public void TestLineColor()
    {
        Assert.AreEqual(Color.FromArgb(255, 123, 0, 33), _shape.Color);
        _shape.Color = Color.Red;
        Assert.AreEqual(Color.Red, _shape.Color);
    }

    [Test]
    public void TestLineIsPointInside()
    {
        Assert.IsTrue(_shape.IsPointOnShape(new Point(2, 3)));
        Assert.IsFalse(_shape.IsPointOnShape(new Point(1, 10)));
        Assert.IsFalse(_shape.IsPointOnShape(new Point(10, 1)));
        Assert.IsFalse(_shape.IsPointOnShape(new Point(100, 10)));
    }
}
