using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice01_HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void addButton_Click(object sender, EventArgs e)
        {
            // check if IDTextBox is empty
            if (IDTextBox.Text == "" && nameTextBox.Text == "")
            {
                MessageBox.Show("Please enter your ID and Name.");
                return;
            } else if (IDTextBox.Text == "")
            {
                MessageBox.Show("Please enter your ID.");
                return;
            } else if (nameTextBox.Text == "")
            {
                MessageBox.Show("Please enter your Name.");
                return;
            }

            MessageBox.Show("Hello," + IDTextBox.Text + " " + nameTextBox.Text + "!");
            studentDataGridView.Rows.Add(IDTextBox.Text, nameTextBox.Text);
            IDTextBox.Text = "";
            nameTextBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentDataGridView.Rows.Add("001", "John");
        }
    }
}
