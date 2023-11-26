using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FakePowerPoint;
using Moq;
using NUnit.Framework;

namespace FakeUnitTest
{
    [TestFixture]
    public class TestModelWithRects
    {
        private Model _model;
        private FakeRandom _random;
        private List<int> _randomNumbers;
        private ShapeFactory _shapeFactory;

        [SetUp]
        public void Setup()
        {
            _model = new Model();
            _random = new FakeRandom();
            _randomNumbers = new List<int>();
            _shapeFactory = new RectangleFactory();

            for (var i = 0; i < 1024; i++)
            {
                _randomNumbers.Add(i);
            }

            _random.Reset();
        }

        [Test]
        public void GenerateRandomNumber()
        {
            var someUpperBound = 1024;
            for (var i = 0; i < someUpperBound; i++)
            {
                _randomNumbers.Add(i);
            }

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            for (var i = 0; i < someUpperBound; i++)
            {
                Assert.AreEqual(i, _model.GenerateRandomNumber(0, someUpperBound));
            }

            _random.Reset(_randomNumbers.Count + 1);
            Assert.AreEqual(0, _model.GenerateRandomNumber(0, someUpperBound));
        }

        [Test]
        public void CreateShape()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            var shape = _model.CreateShape(ShapeType.Rectangle);
            var coordinates = shape.GetCoordinates();
            Assert.AreEqual("(0, 1),\n(2, 3)", coordinates);
        }

        [Test]
        public void AddShape()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            _model.AddShape(ShapeType.Rectangle);
            var shape = _model.Shapes[0];
            var coordinates = shape.GetCoordinates();
            Assert.AreEqual("(0, 1),\n(2, 3)", coordinates);
        }

        [Test]
        public void RemoveShape()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            _model.AddShape(ShapeType.Rectangle);
            _model.RemoveShape(0);
            Assert.AreEqual(0, _model.Shapes.Count);
        }

        [Test]
        public void RemoveShapeIndexTooLow()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            _model.AddShape(ShapeType.Rectangle);
            _model.RemoveShape(-1);
            Assert.AreEqual(1, _model.Shapes.Count);
        }

        [Test]
        public void RemoveShapeIndexTooHigh()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            _model.AddShape(ShapeType.Rectangle);
            _model.RemoveShape(1);
            Assert.AreEqual(1, _model.Shapes.Count);
        }

        [Test]
        public void AddShapeWithCoordinates()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            _model.AddShape(ShapeType.Rectangle, new List<int> { 1, 2, 3, 4 });
            var shape = _model.Shapes[0];
            var coordinates = shape.GetCoordinates();
            Assert.AreEqual("(1, 2),\n(3, 4)", coordinates);
        }

        [Test]
        public void AddShapeWithCoordinatesTooMany()
        {
            _random.Reset();

            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            _model.AddShape(ShapeType.Rectangle, new List<int>
            {
                1,
                2,
                3,
                4,
                5
            });
            var shape = _model.Shapes[0];
            var coordinates = shape.GetCoordinates();
            Assert.AreEqual("(1, 2),\n(3, 4)", coordinates);
        }

        [Test]
        public void AddShapeWithAShape()
        {
            _random.SetRandomNumbers(_randomNumbers);
            _model.SetRandom(_random);

            var shape = _shapeFactory.CreateShape(new List<int> { 1, 2, 3, 4 });
            _model.AddShape(shape);
            var shape2 = _model.Shapes[0];
            var coordinates = shape2.GetCoordinates();
            Assert.AreEqual("(1, 2),\n(3, 4)", coordinates);
        }
    }
}
