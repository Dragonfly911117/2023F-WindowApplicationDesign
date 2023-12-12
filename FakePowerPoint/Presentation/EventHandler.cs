using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FakePowerPoint.Model.Enums;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation
{
    public partial class Form1
    {
        void BindEventHandlers()
        {
            _addShapeButton.Click += HandleAddShapeButtonClicked;
            Paint += HandleRepaint;
            _presentationModel.PropertyChanged += ModelPropertyChanged;
            _undoButton.Click += HandleUndoButtonClicked;
            _redoButton.Click += HandleRedoButtonClicked;
            _slidePanel.Resize += HandlePanelResize;
            _slidePanel.MouseDown += HandleMouseDown;
            _slidePanel.MouseUp += HandleMouseUp;
            _slidePanel.MouseMove += HandleMouseMove;
            _presentationModel.Selected.ItemUpdated += HandleSelectedUpdated;
            _presentationModel.Dos.ItemUpdated += HandleDosUpdated;
            _normalModeButton.Click += HandleFunctionButtonClicked;
            _lineButton.Click += HandleFunctionButtonClicked;
            _rectangleButton.Click += HandleFunctionButtonClicked;
            _ellipseButton.Click += HandleFunctionButtonClicked;
        }

        void HandleAddShapeButtonClicked(object sender, EventArgs e)
        {
            if (_shapeSelector.SelectedItem == null) return;
            _presentationModel.AddShape((ShapeType)_shapeSelector.SelectedItem);
        }

        void HandleRepaint(object sender, EventArgs e)
        {
            _presentationModel.Repaint();
        }

        void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_presentationModel.SlideBitmap):
                    // _slidePanel.BackgroundImage?.Dispose();
                    _slidePanel.BackgroundImage = _presentationModel.SlideBitmap;
                    _slidePanel.Invalidate();
                    _slideButtons[0].BackgroundImage = _presentationModel.SlideBitmap; // hard  coded
                    _slideButtons[0].Invalidate();
                    break;
                case nameof(_presentationModel.Cursor):
                    _slidePanel.Cursor = _presentationModel.Cursor;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        void HandleUndoButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.Undo();
            _slidePanel.Invalidate();
        }

        void HandleRedoButtonClicked(object sender, EventArgs e)
        {
            _presentationModel.Redo();
            _slidePanel.Invalidate();
        }

        void HandlePanelResize(object sender, EventArgs e)
        {
            _slidePanel.Size = _presentationModel.NormalizeSize(_slidePanel.Size);
            _presentationModel.Resize(_slidePanel.Bounds);
        }

        void HandleMouseDown(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleMouseDown(e.Location);
        }

        void HandleMouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleMouseUp(e.Location);
        }

        void HandleMouseMove(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleMouseMove(e.Location);
        }

        void HandleDosUpdated(int index, bool newValue)
        {
            var functionButtons = new ToolStripButton[] { _undoButton, _redoButton };
                functionButtons[index].Enabled = newValue;
        }

        void HandleSelectedUpdated(int index, bool newValue)
        {
            var functionButtons =
                new ToolStripButton[] { _normalModeButton, _lineButton, _rectangleButton, _ellipseButton };
            functionButtons[index].Checked = newValue;
        }
        void HandleFunctionButtonClicked(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            var index = -1;
            switch (button.Name)
            {
                case NORMAL:
                    index = 0;
                    break;
                case LINE:
                    index = 1;
                    break;
                case RECTANGLE:
                    index = 2;
                    break;
                case ELLIPSE:
                    index = 3;
                    break;
            }
            _presentationModel.UpdateSelected(index);

        }
    }
}
