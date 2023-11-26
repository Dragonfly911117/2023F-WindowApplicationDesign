using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint;
using Moq;
using NUnit.Framework;


namespace FakeUnitTest;

public class TestRectangle
{
    private ShapeFactory _shapeFactory;
    private FakeRandom _random;
    private List<int> _randomNumbers;
    private IShape _shape;
    
    [SetUp]
    public void Setup()
    {
        _shapeFactory = new RectangleFactory();
        _random = new FakeRandom();
        _randomNumbers = new List<int>();
        _shape = _shapeFactory.CreateShape(new List<int> { 1, 2, 3, 4 });
        for (var i = 0; i < 1024; i++)
        {
            _randomNumbers.Add(i);
        }

        _random.Reset();
    }

    [Test]
    public void TestRectangleHandleGetter()
    {
        var handles = _shape.Handles;
        Assert.AreEqual(8, handles.Count);
        Assert.AreEqual(1, handles[0].Coordinate.X);
        Assert.AreEqual(2, handles[0].Coordinate.Y);
        Assert.AreEqual(2, handles[1].Coordinate.X);
        Assert.AreEqual(2, handles[1].Coordinate.Y);
        Assert.AreEqual(3, handles[2].Coordinate.X);
        Assert.AreEqual(2, handles[2].Coordinate.Y);
        Assert.AreEqual(1, handles[3].Coordinate.X);
        Assert.AreEqual(3, handles[3].Coordinate.Y);
        Assert.AreEqual(3, handles[4].Coordinate.X);
        Assert.AreEqual(4, handles[4].Coordinate.Y);
        Assert.AreEqual(2, handles[5].Coordinate.X);
        Assert.AreEqual(4, handles[5].Coordinate.Y);
        Assert.AreEqual(1, handles[6].Coordinate.X);
        Assert.AreEqual(4, handles[6].Coordinate.Y);
        Assert.AreEqual(3, handles[7].Coordinate.X);
        Assert.AreEqual(3, handles[7].Coordinate.Y);

        // Check that the handles are not selected
        foreach (var handle in handles)
        {
            Assert.IsFalse(handle.Selected);
        }
    }

    [Test]
    public void TestRectangleHandleSetter()
    {
        var handles = _shape.Handles;
        var mockGraphics = new Mock<IGraphics>();
        foreach (var handle in handles)
        {
            handle.Selected = true;
            handle.Draw(mockGraphics.Object);
        }

        foreach (var handle in handles)
        {
            Assert.IsTrue(handle.Selected);
        }

        // assert if the  graphics.DrawEllipse(_pen, offse；tX, offsetY, squareSize, squareSize);
        //graphics.FillEllipse(_brush, offsetX, offsetY, squareSize, squareSize); are called
        mockGraphics.Verify(
            x => x.DrawEllipse(It.IsAny<Pen>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
            Times.Exactly(8));
        mockGraphics.Verify(
            x => x.FillEllipse(It.IsAny<Brush>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
            Times.Exactly(8));
    }
}
