using System;
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

        SplitContainer _splitContainerMain = new SplitContainer();

        GroupBox _groupBoxLeft = new GroupBox();

        GroupBox _groupBoxMiddle = new GroupBox();
        Panel _slidePanel = new Panel();

        GroupBox _groupBoxRight = new GroupBox();
        ComboBox _shapeSelector = new ComboBox();
        Button _addShapeButton = new Button();

        DataGridView _shapesDataGridView = new DataGridView();

        void ConstructLayout()
        {
            // the order matters, the later one overrides the former ones
            InitializeGroupBoxLeft();
            InitializeGroupBoxMiddle();
            InitializeGroupBoxRight();
            InitializeSplitContainerMain();
            InitializeFunctionMenu();
            InitializeMenu();
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

            functionMenu.Items.Add(_normalModeButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_lineButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_rectangleButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_ellipseButton); // Add the ToolStripMenuItem to the MenuStrip

            _functionMenu.TopToolStripPanel.Controls.Add(functionMenu); // Add the MenuStrip to the container
        }

        void InitializeToolStripButton(string imageName, ref ToolStripButton button)
        {
            button = new ToolStripButton();
            var imageBytes = (byte[])Properties.Resources.ResourceManager.GetObject(imageName);
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
            splitContainerRight.SplitterDistance = splitContainerRight.Width * 4 / 5;
            splitContainerRight.Dock = DockStyle.Fill;
            splitContainerRight.Panel1.Controls.Add(_groupBoxMiddle);
            splitContainerRight.Panel2.Controls.Add(_groupBoxRight);

            _splitContainerMain.Panel1.Controls.Add(_groupBoxLeft);
            _splitContainerMain.Panel2.Controls.Add(splitContainerRight);

            GiveBirth(this, _splitContainerMain);
        }


        void InitializeGroupBoxLeft()
        {
            _groupBoxLeft.Dock = DockStyle.Fill;
            _groupBoxLeft.Text = SLIDES;
        }

        void InitializeGroupBoxMiddle()
        {
            GiveBirth(_groupBoxMiddle, _slidePanel);
            _slidePanel.BackgroundImageLayout = ImageLayout.Stretch;
            _groupBoxMiddle.Dock = DockStyle.Fill;
            _groupBoxMiddle.Text = SLIDE;
        }

        void InitializeGroupBoxRight()
        {
            _groupBoxRight.Dock = DockStyle.Fill;
            _groupBoxRight.Text = SHAPES;

            _shapeSelector.Dock = DockStyle.Fill;
            _addShapeButton.Text = Resources.Form1_InitializeGroupBoxRight_Add;
            _addShapeButton.ForeColor = Color.LightGray;
            _shapesDataGridView.Dock = DockStyle.Fill;

            var splitter = new SplitContainer();
            splitter.Dock = DockStyle.Fill;
            splitter.Orientation = Orientation.Vertical;
            splitter.SplitterDistance = splitter.Width * 4 / 5;
            splitter.Panel1.Controls.Add(_shapeSelector);
            splitter.Panel2.Controls.Add(_addShapeButton);

            var splitter2 = new SplitContainer();
            splitter2.Dock = DockStyle.Fill;
            splitter2.Orientation = Orientation.Horizontal;
            splitter2.SplitterDistance = _groupBoxRight.Height / 20;
            splitter2.Panel1.Controls.Add(splitter);
            splitter2.Panel2.Controls.Add(_shapesDataGridView);

            _groupBoxRight.Controls.Add(splitter2);
        }

        static void GiveBirth(Control parent, Control child, DockStyle dockStyle = DockStyle.Fill)
        {
            child.Dock = dockStyle;
            child.Parent = parent;
        }
    }
}
