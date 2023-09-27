namespace HomeWork01_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox = new System.Windows.Forms.TextBox();
            this.ButtonClearEntry = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonPlus = new System.Windows.Forms.Button();
            this.Button9 = new System.Windows.Forms.Button();
            this.Button8 = new System.Windows.Forms.Button();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.ButtonMinus = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.ButtonDot = new System.Windows.Forms.Button();
            this.Button0 = new System.Windows.Forms.Button();
            this.ButtonDivision = new System.Windows.Forms.Button();
            this.ButtonEqual = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ButtonMultiply = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextBox.Location = new System.Drawing.Point(66, 91);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.ReadOnly = true;
            this.TextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox.Size = new System.Drawing.Size(396, 132);
            this.TextBox.TabIndex = 0;
            this.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BTN_CE
            // 
            this.ButtonClearEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonClearEntry.Location = new System.Drawing.Point(255, 294);
            this.ButtonClearEntry.Name = "ButtonClearEntry";
            this.ButtonClearEntry.Size = new System.Drawing.Size(69, 71);
            this.ButtonClearEntry.TabIndex = 1;
            this.ButtonClearEntry.Text = "CE";
            this.ButtonClearEntry.UseVisualStyleBackColor = true;
            this.ButtonClearEntry.Click += new System.EventHandler(this.ButtonClearEntryClick);
            // 
            // BTN_C
            // 
            this.ButtonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonClear.Location = new System.Drawing.Point(374, 294);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(69, 71);
            this.ButtonClear.TabIndex = 2;
            this.ButtonClear.Text = "C";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // BTN_plus
            // 
            this.ButtonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonPlus.Location = new System.Drawing.Point(374, 403);
            this.ButtonPlus.Name = "ButtonPlus";
            this.ButtonPlus.Size = new System.Drawing.Size(69, 71);
            this.ButtonPlus.TabIndex = 4;
            this.ButtonPlus.Text = "+";
            this.ButtonPlus.UseVisualStyleBackColor = true;
            this.ButtonPlus.Click += new System.EventHandler(this.ButtonPlusClick);
            // 
            // BTN_9
            // 
            this.Button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button9.Location = new System.Drawing.Point(255, 403);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(69, 71);
            this.Button9.TabIndex = 3;
            this.Button9.Text = "9";
            this.Button9.UseVisualStyleBackColor = true;
            this.Button9.Click += new System.EventHandler(this.Button9Click);
            // 
            // BTN_8
            // 
            this.Button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button8.Location = new System.Drawing.Point(141, 403);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(69, 71);
            this.Button8.TabIndex = 6;
            this.Button8.Text = "8";
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(this.Button8Click);
            // 
            // BTN_7
            // 
            this.Button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button7.Location = new System.Drawing.Point(33, 403);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(69, 71);
            this.Button7.TabIndex = 5;
            this.Button7.Text = "7";
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Click += new System.EventHandler(this.Button7Click);
            // 
            // BTN_5
            // 
            this.Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button5.Location = new System.Drawing.Point(141, 522);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(69, 71);
            this.Button5.TabIndex = 10;
            this.Button5.Text = "5";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5Click);
            // 
            // BTN_4
            // 
            this.Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button4.Location = new System.Drawing.Point(33, 522);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(69, 71);
            this.Button4.TabIndex = 9;
            this.Button4.Text = "4";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // BTN_minus
            // 
            this.ButtonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonMinus.Location = new System.Drawing.Point(374, 522);
            this.ButtonMinus.Name = "ButtonMinus";
            this.ButtonMinus.Size = new System.Drawing.Size(69, 71);
            this.ButtonMinus.TabIndex = 8;
            this.ButtonMinus.Text = "-";
            this.ButtonMinus.UseVisualStyleBackColor = true;
            this.ButtonMinus.Click += new System.EventHandler(this.ButtonMinusClick);
            // 
            // BTN_6
            // 
            this.Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button6.Location = new System.Drawing.Point(255, 522);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(69, 71);
            this.Button6.TabIndex = 7;
            this.Button6.Text = "6";
            this.Button6.UseVisualStyleBackColor = true;
            this.Button6.Click += new System.EventHandler(this.Button6Click);
            // 
            // BTN_dot
            // 
            this.ButtonDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ButtonDot.Location = new System.Drawing.Point(141, 769);
            this.ButtonDot.Name = "ButtonDot";
            this.ButtonDot.Size = new System.Drawing.Size(69, 71);
            this.ButtonDot.TabIndex = 18;
            this.ButtonDot.Text = ".";
            this.ButtonDot.UseVisualStyleBackColor = true;
            this.ButtonDot.Click += new System.EventHandler(this.ButtonDotClick);
            // 
            // BTN_0
            // 
            this.Button0.Location = new System.Drawing.Point(33, 769);
            this.Button0.Name = "Button0";
            this.Button0.Size = new System.Drawing.Size(69, 71);
            this.Button0.TabIndex = 17;
            this.Button0.Text = "0";
            this.Button0.UseVisualStyleBackColor = true;
            this.Button0.Click += new System.EventHandler(this.Button0Click);
            // 
            // BTN_div
            // 
            this.ButtonDivision.Location = new System.Drawing.Point(374, 769);
            this.ButtonDivision.Name = "ButtonDivision";
            this.ButtonDivision.Size = new System.Drawing.Size(69, 71);
            this.ButtonDivision.TabIndex = 16;
            this.ButtonDivision.Text = "/";
            this.ButtonDivision.UseVisualStyleBackColor = true;
            this.ButtonDivision.Click += new System.EventHandler(this.ButtonDivisionClick);
            // 
            // BTN_EQ
            // 
            this.ButtonEqual.Location = new System.Drawing.Point(255, 769);
            this.ButtonEqual.Name = "ButtonEqual";
            this.ButtonEqual.Size = new System.Drawing.Size(69, 71);
            this.ButtonEqual.TabIndex = 15;
            this.ButtonEqual.Text = "=";
            this.ButtonEqual.UseVisualStyleBackColor = true;
            this.ButtonEqual.Click += new System.EventHandler(this.ButtonEqualClick);
            // 
            // BTN_2
            // 
            this.Button2.Location = new System.Drawing.Point(141, 649);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(69, 71);
            this.Button2.TabIndex = 14;
            this.Button2.Text = "2";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // BTN_1
            // 
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Button1.Location = new System.Drawing.Point(33, 649);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(69, 71);
            this.Button1.TabIndex = 13;
            this.Button1.Text = "1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // BTN_mult
            // 
            this.ButtonMultiply.Location = new System.Drawing.Point(374, 649);
            this.ButtonMultiply.Name = "ButtonMultiply";
            this.ButtonMultiply.Size = new System.Drawing.Size(69, 71);
            this.ButtonMultiply.TabIndex = 12;
            this.ButtonMultiply.Text = "X";
            this.ButtonMultiply.UseVisualStyleBackColor = true;
            this.ButtonMultiply.Click += new System.EventHandler(this.ButtonMultiplyClick);
            // 
            // BTN_3
            // 
            this.Button3.Location = new System.Drawing.Point(255, 649);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(69, 71);
            this.Button3.TabIndex = 11;
            this.Button3.Text = "3";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(510, 937);
            this.Controls.Add(this.ButtonDot);
            this.Controls.Add(this.Button0);
            this.Controls.Add(this.ButtonDivision);
            this.Controls.Add(this.ButtonEqual);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ButtonMultiply);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.ButtonMinus);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.Button8);
            this.Controls.Add(this.Button7);
            this.Controls.Add(this.ButtonPlus);
            this.Controls.Add(this.Button9);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonClearEntry);
            this.Controls.Add(this.TextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button ButtonDivision;

        private System.Windows.Forms.Button ButtonMultiply;

        private System.Windows.Forms.Button ButtonClearEntry;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonPlus;
        private System.Windows.Forms.Button Button9;
        private System.Windows.Forms.Button Button8;
        private System.Windows.Forms.Button Button7;
        private System.Windows.Forms.Button Button5;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.Button ButtonMinus;
        private System.Windows.Forms.Button Button6;
        private System.Windows.Forms.Button ButtonDot;
        private System.Windows.Forms.Button Button0;
        private System.Windows.Forms.Button ButtonEqual;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button3;

        private System.Windows.Forms.TextBox TextBox;

        #endregion
    }
    public enum CharacterMap
    {
        Zero = '0',
        One = '1',
        Two = '2',
        Three = '3',
        Four = '4',
        Five = '5',
        Six = '6',
        Seven = '7',
        Eight = '8',
        Nine = '9',
        Dot = '.',

        // and +, -, X, /, =
        Plus = '+',
        Minus = '-',
        Multiply = 'X',
        Divide = '/',
        Equal = '=',

    }
}
