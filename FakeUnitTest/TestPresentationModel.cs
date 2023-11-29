using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint;
using NUnit.Framework;

namespace FakeUnitTest;

public class TestPM
{
    private readonly PresentationModel _presentationModel;
    private readonly Model _model;
    private readonly FakeGraphics _fakeGraphics;
    private readonly FakeRandom _fakeRandom;

    public TestPM()
    {
        _fakeRandom = new FakeRandom();
        _fakeGraphics = new FakeGraphics();
        _model = new Model(_fakeRandom);
        _presentationModel = new PresentationModel(_model);
    }

    [Fact]
    public void TestMouseDown()
    {
        _presentationModel.MouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        Assert.Equal(ShapeType.Selection, _model.Shapes[0].ShapeType);
        Assert.Equal(1, _model.Shapes.Count);
    }

    [Fact]
    public void TestMouseMove()
    {
        _presentationModel.MouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        _presentationModel.MouseMove(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0), new Point(0, 0));
        Assert.Equal(ShapeType.Selection, _model.Shapes[0].ShapeType);
        Assert.Equal(1, _model.Shapes.Count);
    }

    [Fact]
    public void TestMouseUp()
    {
        _presentationModel.MouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        _presentationModel.MouseUp(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        Assert.Equal(ShapeType.Selection, _model.Shapes[0].ShapeType);
        Assert.Equal(1, _model.Shapes.Count);
    }

}
