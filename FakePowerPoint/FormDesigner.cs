using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FakePowerPoint.Properties;

namespace FakePowerPoint
{
    public partial class Form1 : Form
    {
        ToolStripContainer _menu;
        const string ABOUT_TEXT = "About";
        const string INFO_TEXT = "Info";
        const string ABOUT_MESSAGE = "Fake PowerPoint is a fake version of PowerPoint. ";

        ToolStripContainer _functionMenu;
        ToolStripButton _normalModeButton;
        ToolStripButton _lineButton;
        ToolStripButton _rectangleButton;
        ToolStripButton _ellipseButton;

        SplitContainer _splitContainerMain = new SplitContainer();

        GroupBox _groupBoxLeft = new GroupBox();
        GroupBox _groupBoxMiddle = new GroupBox();
        GroupBox _groupBoxRight = new GroupBox();

        void ConstructLayout()
        {
            InitializeWidgets();
        }

        void InitializeWidgets()
        {
            // the order matters, the later one will be on top
            InitializeGroupBoxLeft();
            InitializeGroupBoxMiddle();
            InitializeGroupBoxRight();
            InitializeSplitContainerMain();
            InitializeFunctionMenu();
            InitializeMenu();
        }

        private void InitializeMenu()
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

        private void InitializeFunctionMenu()
        {
            _functionMenu = new ToolStripContainer();
            _functionMenu.Parent = this;
            _functionMenu.Dock = DockStyle.Top;
            _functionMenu.AutoSize = true;

            var functionMenu = new ToolStrip(); // Create a MenuStrip control

            InitializeToolStripButton("Normal", ref _normalModeButton);
            InitializeToolStripButton("Line", ref _lineButton);
            InitializeToolStripButton("Rectangle", ref _rectangleButton);
            InitializeToolStripButton("Ellipse", ref _ellipseButton);

            functionMenu.Items.Add(_normalModeButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_lineButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_rectangleButton); // Add the ToolStripMenuItem to the MenuStrip
            functionMenu.Items.Add(_ellipseButton); // Add the ToolStripMenuItem to the MenuStrip

            _functionMenu.TopToolStripPanel.Controls.Add(functionMenu); // Add the MenuStrip to the container
        }

        private void InitializeToolStripButton(string imageName, ref ToolStripButton button)
        {
            button = new ToolStripButton();
            var imageBytes = (byte[])Properties.Resources.ResourceManager.GetObject(imageName);
            button.Image = Image.FromStream(new MemoryStream(imageBytes ?? throw new InvalidOperationException()));
            button.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            button.DisplayStyle = ToolStripItemDisplayStyle.Image;
        }

        void InitializeSplitContainerMain()
        {
            _splitContainerMain.Dock = DockStyle.Fill;
            _splitContainerMain.Orientation = Orientation.Vertical;

            // var splitContainerLeft = new SplitContainer();
            // splitContainerLeft.Orientation = Orientation.Horizontal;
            // splitContainerLeft.Dock = DockStyle.Fill;
            _splitContainerMain.Panel1.Controls.Add(_groupBoxLeft);
            // splitContainerLeft.Panel2.Controls.Add(_groupBoxMiddle);

            var splitContainerRight = new SplitContainer();
            splitContainerRight.Orientation = Orientation.Vertical;
            splitContainerRight.Dock = DockStyle.Fill;
            splitContainerRight.Panel1.Controls.Add(_groupBoxMiddle);
            splitContainerRight.Panel2.Controls.Add(_groupBoxRight);

            // _splitContainerMain.Panel1.Controls.Add(splitContainerLeft);
            _splitContainerMain.Panel2.Controls.Add(splitContainerRight);

            _splitContainerMain.Parent = this;
        }

        // Init Menus

        void InitializeGroupBoxLeft()
        {
            _groupBoxLeft.Dock = DockStyle.Fill;
            _groupBoxLeft.Text = "Left";
            _groupBoxLeft.ForeColor = Color.Purple;
        }

        void InitializeGroupBoxMiddle()
        {
            _groupBoxMiddle.Dock = DockStyle.Fill;
            _groupBoxMiddle.Text = "Middle";
            _groupBoxMiddle.ForeColor = Color.Yellow;
        }

        void InitializeGroupBoxRight()
        {
            _groupBoxRight.Dock = DockStyle.Fill;
            _groupBoxRight.Text = "Right";
            _groupBoxRight.ForeColor = Color.Blue;
        }
    }
}
