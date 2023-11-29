using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint;
using NUnit.Framework;

namespace FakeUnitTest;

public class TestPresentationModel
{
    private PresentationModel _presentationModel;
    private Model _model;
    private FakeGraphics _fakeGraphics;
    private FakeRandom _fakeRandom;
    private FakeCursor _fakeCursor;

    [SetUp]
    public void Setup()
    {
        _fakeRandom = new FakeRandom();
        _fakeCursor = new FakeCursor();
        _fakeGraphics = new FakeGraphics();
        _model = new Model();
        _model.SetRandom(_fakeRandom);
        _presentationModel = new PresentationModel(_model);
        var groupBox = new GroupBox();
        groupBox.Width = 100;
        groupBox.Height = 100;
        _presentationModel.SetPaintGroup(groupBox);
    }


    [Test]
    public void TestMouseDown()
    {
        // outside of the paint group

        _presentationModel.MouseMove(new);
        _presentationModel.MouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

        // inside of the paint group
        pos = new Point(227, 57);
        _presentationModel.MouseMove(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0), pos);
        _presentationModel.MouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
    }

}
