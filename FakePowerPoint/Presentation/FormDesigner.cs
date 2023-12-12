using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FakePowerPoint.Properties;

namespace FakePowerPoint.Presentation
{
    public partial class Form1 : Form
    {
        ToolStripContainer _menu;

        // TODO: move these const strings to resources
        const string ABOUT_TEXT = "About";
        const string INFO_TEXT = "Info";
        const string ABOUT_MESSAGE = "Fake PowerPoint is a fake version of PowerPoint. ";
        const string NORMAL = "Normal";
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string SLIDES = "Slides";
        const string SLIDE = "Slide";
        const string SHAPES = "Shapes";

        ToolStripContainer _functionMenu;
        ToolStripButton _normalModeButton;
        ToolStripButton _lineButton;
        ToolStripButton _rectangleButton;
        ToolStripButton _ellipseButton;
        ToolStripButton _undoButton;
        ToolStripButton _redoButton;

        SplitContainer _splitContainerMain = new SplitContainer();

        GroupBox _groupBoxLeft = new GroupBox();
        Panel _slideButtonsPanel = new Panel();
        List<Button> _slideButtons = new List<Button>();

        GroupBox _groupBoxMiddle = new GroupBox();
        Panel _slidePanel = new Panel();

        GroupBox _groupBoxRight = new GroupBox();
        ComboBox _shapeSelector = new ComboBox();
        Button _addShapeButton = new Button();

        DataGridView _shapesDataGridView = new DataGridView();

        void ConstructLayout()
        {
            // the order matters, the later one overrides the former ones
            InitForm();
            InitializeShapeDataGridView();
            InitializeGroupBoxLeft();
            InitializeGroupBoxMiddle();
            InitializeGroupBoxRight();
            InitializeSplitContainerMain();
            InitializeFunctionMenu();
            InitializeMenu();
        }

        void InitForm()
        {
            Size = new Size(int.Parse(Resources.DEFAULT_WINDOW_WIDTH),int.Parse( Resources.DEFAULT_WINDOW_HEIGHT));
        }

        void InitializeMenu()
        {
            _menu = new ToolStripContainer();
            _menu.Parent = this;
            _menu.Dock = DockStyle.Top;
            _menu.AutoSize = true;

            var menuStrip = new MenuStrip(); // Create a MenuStrip control
            var infoMenuItem = new ToolStripMenuItem() { Text = INFO_TEXT };
            var aboutMenuItem = new ToolStripLabel { Text = ABOUT_TEXT };
            aboutMenuItem.Click += (sender, args) => MessageBox.Show(ABOUT_MESSAGE);
            infoMenuItem.DropDownItems.Add(aboutMenuItem);
            menuStrip.Items.Add(infoMenuItem); // Add the ToolStripMenuItem to the MenuStrip
            _menu.TopToolStripPanel.Controls.Add(menuStrip); // Add the MenuStrip to the container
        }

        void InitializeFunctionMenu()
        {
            _functionMenu = new ToolStripContainer();
            _functionMenu.Parent = this;
            _functionMenu.Dock = DockStyle.Top;
            _functionMenu.AutoSize = true;

            var functionMenu = new ToolStrip(); // Create a MenuStrip control

            InitializeToolStripButton(NORMAL, ref _normalModeButton);
            InitializeToolStripButton(LINE, ref _lineButton);
            InitializeToolStripButton(RECTANGLE, ref _rectangleButton);
            InitializeToolStripButton(ELLIPSE, ref _ellipseButton);
            InitializeToolStripButton(REDO, ref _redoButton);
            InitializeToolStripButton(UNDO, ref _undoButton);

            functionMenu.Items.Add(_undoButton); // Add the ToolStripMenuItem to the MenuStrip
            _undoButton.Enabled = false;
            functionMenu.Items.Add(_redoButton); // Add the ToolStripMenuItem to the MenuStrip
            _redoButton.Enabled = false;
            functionMenu.Items.Add(_normalModeButton); // Add the ToolStripMenuItem to the MenuStrip
            _normalModeButton.Checked = true;
            functionMenu.Items.Add(_lineButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_rectangleButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_ellipseButton); // Add the ToolStripMenuItem to the MenuStrip

            _functionMenu.TopToolStripPanel.Controls.Add(functionMenu); // Add the MenuStrip to the container
        }

        const string REDO = "Redo";

        const string UNDO = "Undo";

        void InitializeToolStripButton(string imageName, ref ToolStripButton button)
        {
            button = new ToolStripButton();
            var imageBytes = (byte[])Properties.Resources.ResourceManager.GetObject(imageName);
            button.Name = imageName;
            button.Image = Image.FromStream(new MemoryStream(imageBytes ?? throw new InvalidOperationException()));
            button.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            button.DisplayStyle = ToolStripItemDisplayStyle.Image;
        }

        // Init Menus
        void InitializeSplitContainerMain()
        {
            _splitContainerMain.Orientation = Orientation.Vertical;
            _splitContainerMain.SplitterDistance = _splitContainerMain.Width / 10;

            var splitContainerRight = new SplitContainer();
            splitContainerRight.Orientation = Orientation.Vertical;
            splitContainerRight.SplitterDistance = int.Parse(Resources.DEFAULT_SLIDE_WIDTH);
            splitContainerRight.Dock = DockStyle.Fill;
            splitContainerRight.Panel1.Controls.Add(_groupBoxMiddle);
            splitContainerRight.Panel2.Controls.Add(_groupBoxRight);
            splitContainerRight.SplitterMoved += (sender, args) =>
            {
                _slidePanel.Size = new Size(splitContainerRight.SplitterDistance, _slidePanel.Height);
            };

            _splitContainerMain.Panel1.Controls.Add(_groupBoxLeft);
            _splitContainerMain.Panel2.Controls.Add(splitContainerRight);

            GiveBirth(this, _splitContainerMain);
        }


        void InitializeGroupBoxLeft()
        {
            _groupBoxLeft.Dock = DockStyle.Fill;
            _groupBoxLeft.Text = SLIDES;
            _slideButtonsPanel.AutoScroll = true;
            _groupBoxLeft.Resize += (sender, args) =>
            {
                _slideButtonsPanel.Size = new Size(_groupBoxLeft.Width, _groupBoxLeft.Width * 9 / 16);
                _slideButtons.ForEach(button => button.Size = new Size(_groupBoxLeft.Width, _groupBoxLeft.Width * 9 / 16));
            };
            _slideButtons.Add(new Button());
            _slideButtons[0].Size = new Size(_groupBoxLeft.Width, _groupBoxLeft.Width * 9 / 16);
            _slideButtons[0].BackgroundImageLayout = ImageLayout.Stretch;

            // _slideButtons[0].FlatStyle = FlatStyle.Flat;
            // _slideButtons[0].FlatAppearance.BorderSize = 0;
            GiveBirth(_slideButtonsPanel, _slideButtons[0], DockStyle.None);

            GiveBirth(_groupBoxLeft, _slideButtonsPanel);
        }

        void InitializeGroupBoxMiddle()
        {
            // _groupBoxMiddle.BackColor = Color.DarkGray;
            _slidePanel.BackColor = Color.Black;
            GiveBirth(_groupBoxMiddle, _slidePanel, DockStyle.None);
            _slidePanel.Size = new Size(int.Parse(Resources.DEFAULT_SLIDE_WIDTH), int.Parse(Resources.DEFAULT_SLIDE_HEIGHT));
            _slidePanel.BackgroundImageLayout = ImageLayout.Stretch;
            _slidePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _groupBoxMiddle.Dock = DockStyle.Fill;
            _groupBoxMiddle.Text = SLIDE;
        }

        void InitializeGroupBoxRight()
        {
            _shapeSelector.DropDownStyle = ComboBoxStyle.DropDownList;

            _groupBoxRight.Dock = DockStyle.Fill;
            _groupBoxRight.Text = SHAPES;

            _shapeSelector.Dock = DockStyle.Fill;
            _addShapeButton.Text = Resources.Form1_InitializeGroupBoxRight_Add;
            _addShapeButton.ForeColor = Color.LightGray;
            _shapesDataGridView.Dock = DockStyle.Fill;

            var splitter = new SplitContainer();
            splitter.Dock = DockStyle.Fill;
            splitter.Orientation = Orientation.Vertical;
            splitter.Panel1.Controls.Add(_shapeSelector);
            splitter.Panel2.Controls.Add(_addShapeButton);
            splitter.SplitterDistance = splitter.Width * 4 / 5;

            var splitter2 = new SplitContainer();
            splitter2.Dock = DockStyle.Fill;
            splitter2.Orientation = Orientation.Horizontal;
            splitter2.Panel1.Controls.Add(splitter);
            splitter2.Panel2.Controls.Add(_shapesDataGridView);
            splitter2.Panel1MinSize = _addShapeButton.Height / 2;
            splitter2.SplitterDistance = splitter2.Panel1MinSize;


            _groupBoxRight.Controls.Add(splitter2);
        }

        void InitializeShapeDataGridView()
        {
            _presentationModel.BindShapeList(ref _shapesDataGridView);
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true
            };
            _shapesDataGridView.RowHeadersVisible = false;
            _shapesDataGridView.Columns.Insert(0, deleteButtonColumn);
            _shapesDataGridView.CellClick += (sender, args) =>
            {
                if (args.ColumnIndex == 0)
                {
                    _presentationModel.RemoveShape(args.RowIndex);
                }
            };
        }

        static void GiveBirth(Control parent, Control child, DockStyle dockStyle = DockStyle.Fill)
        {
            child.Dock = dockStyle;
            child.Parent = parent;
        }


    }
}
