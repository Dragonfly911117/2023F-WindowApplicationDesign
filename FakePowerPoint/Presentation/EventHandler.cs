using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint.Model.Enums;

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
            _presentationModel.Resize(_slidePanel.Size);
        }
    }
}
