using System;
using System.Collections.Generic;
using System.Drawing;
using FakePowerPoint;
using Moq;
using NUnit.Framework;
using Rectangle = System.Drawing.Rectangle;
using BadRectangle = FakePowerPoint.Rectangle;

namespace FakeUnitTest
{
    public class TestRectangle
    {
        private ShapeFactory _shapeFactory;
        private FakeRandom _random;
        private List<int> _randomNumbers;
        private BadRectangle _shape;
        private Mock<IGraphics> _mockGraphics;

        [SetUp]
        public void Setup()
        {
            _shapeFactory = new RectangleFactory();
            _random = new FakeRandom();
            _randomNumbers = new List<int>();
            _shape = (BadRectangle)_shapeFactory.CreateShape(new List<int> { 1, 2, 3, 4 });
            _mockGraphics = new Mock<IGraphics>();
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

            foreach (var handle in handles)
            {
                handle.Selected = true;
                handle.Draw(_mockGraphics.Object);
            }

            foreach (var handle in handles)
            {
                Assert.IsTrue(handle.Selected);
            }

            // assert if the  graphics.DrawEllipse(_pen, offse；tX, offsetY, squareSize, squareSize);
            //graphics.FillEllipse(_brush, offsetX, offsetY, squareSize, squareSize); are called
            _mockGraphics.Verify(
                x => x.DrawEllipse(It.IsAny<Pen>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()),
                Times.Exactly(8));
            _mockGraphics.Verify(
                x => x.FillEllipse(It.IsAny<Brush>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()), Times.Exactly(8));
        }


        [Test]
        public void TestRectangleDrawHandle()
        {
            _shape.DrawHandle(_mockGraphics.Object);
            _mockGraphics.Verify(
                x => x.FillEllipse(It.IsAny<Brush>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()), Times.Exactly(8));
        }

        [Test]
        public void TestWithCoordinateInordered()
        {
            _shape = (BadRectangle)_shapeFactory.CreateShape(new List<int> { 3, 4, 1, 2 });
            Assert.AreEqual(1, _shape.Coordinates[0].X);
            Assert.AreEqual(2, _shape.Coordinates[0].Y);
            Assert.AreEqual(3, _shape.Coordinates[1].X);
            Assert.AreEqual(4, _shape.Coordinates[1].Y);
        }

        [Test]
        public void TestRectangleDrawnWhileSelected()
        {
            _shape.Selected = true;
            _shape.Draw(_mockGraphics.Object, 1);
            _mockGraphics.Verify(x => x.DrawRectangle(It.IsAny<Pen>(), It.IsAny<Rectangle>()), Times.Once);
            _mockGraphics.Verify(
                x => x.FillEllipse(It.IsAny<Brush>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<int>()), Times.Exactly(8));
        }

        [Test]
        public void TestRectangleProperties()
        {
            Assert.AreEqual(ShapeType.Rectangle, _shape.ShapeType);
            Assert.AreEqual(1, _shape.Coordinates[0].X);
            Assert.AreEqual(2, _shape.Coordinates[0].Y);
            Assert.AreEqual(3, _shape.Coordinates[1].X);
            Assert.AreEqual(4, _shape.Coordinates[1].Y);
            Assert.AreEqual("(1, 2),\n(3, 4)", _shape.GetCoordinates());

            // Check _width getter

            // Check Color getter and setter
            Assert.AreEqual(Color.FromArgb(255, 132, 120, 222), _shape.Color);
            _shape.Color = Color.FromArgb(255, 132, 120, 112);
            Assert.AreEqual(Color.FromArgb(255, 132, 120, 112), _shape.Color);

            // Check Selected getter and setter
            Assert.IsFalse(_shape.Selected);
            _shape.Selected = true;
            Assert.IsTrue(_shape.Selected);

            // Check Coordinates getter and setter
            Assert.AreEqual(1, _shape.Coordinates[0].X);
            Assert.AreEqual(2, _shape.Coordinates[0].Y);
            Assert.AreEqual(3, _shape.Coordinates[1].X);
            Assert.AreEqual(4, _shape.Coordinates[1].Y);

            // Check ShapeType getter and setter
            Assert.AreEqual(ShapeType.Rectangle, _shape.ShapeType);
            // re-setting the shape type raises an exception
            Assert.Throws<InvalidOperationException>(() => _shape.ShapeType = ShapeType.Eclipse);
        }

        [Test]
        public void TestIsPointOnShape()
        {
            // there's a tolerance of 5 pixels for the selection
            Assert.IsTrue(_shape.IsPointOnShape(new Point(1, 2)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(3, 4)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(2, 3)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(2, 2)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(2, 4)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(1, 3)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(3, 3)));
            Assert.IsTrue(_shape.IsPointOnShape(new Point(2, 3)));

            Assert.IsFalse(_shape.IsPointOnShape(new Point(40, 5)));
            Assert.IsFalse(_shape.IsPointOnShape(new Point(2, 10)));
            Assert.IsFalse(_shape.IsPointOnShape(new Point(2, 50)));
            Assert.IsFalse(_shape.IsPointOnShape(new Point(0, 30)));
            Assert.IsFalse(_shape.IsPointOnShape(new Point(400, 3)));
        }
    }
}
