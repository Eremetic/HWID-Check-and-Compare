namespace HWIDChecker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.MediumPurple;
            button2.FlatAppearance.BorderColor = Color.Purple;
            button2.FlatAppearance.BorderSize = 4;
            button2.FlatAppearance.MouseDownBackColor = Color.SlateGray;
            button2.FlatAppearance.MouseOverBackColor = Color.Crimson;
            button2.Font = new Font("Ruda", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(21, 243);
            button2.Name = "button2";
            button2.Size = new Size(257, 78);
            button2.TabIndex = 3;
            button2.Text = "Save HWID's";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseHover += button2_MouseHover;
            // 
            // button3
            // 
            button3.BackColor = Color.RoyalBlue;
            button3.FlatAppearance.BorderColor = Color.Purple;
            button3.FlatAppearance.BorderSize = 4;
            button3.FlatAppearance.MouseDownBackColor = Color.SlateGray;
            button3.FlatAppearance.MouseOverBackColor = Color.Crimson;
            button3.Font = new Font("Ruda", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(21, 394);
            button3.Name = "button3";
            button3.Size = new Size(257, 78);
            button3.TabIndex = 4;
            button3.Text = "Compare HWID'S";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.MouseHover += button3_MouseHover;
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.FlatAppearance.BorderColor = Color.Purple;
            button1.FlatAppearance.BorderSize = 4;
            button1.FlatAppearance.MouseDownBackColor = Color.SlateGray;
            button1.FlatAppearance.MouseOverBackColor = Color.Crimson;
            button1.Font = new Font("Ruda", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(21, 88);
            button1.Name = "button1";
            button1.Size = new Size(257, 78);
            button1.TabIndex = 5;
            button1.Text = "View HWID's";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(284, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(501, 501);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkMagenta;
            button4.FlatAppearance.BorderColor = Color.Purple;
            button4.FlatAppearance.BorderSize = 4;
            button4.FlatAppearance.MouseDownBackColor = Color.SlateGray;
            button4.FlatAppearance.MouseOverBackColor = Color.Crimson;
            button4.Font = new Font("Ruda", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(21, 523);
            button4.Name = "button4";
            button4.Size = new Size(257, 34);
            button4.TabIndex = 7;
            button4.Text = "Clear Unknown Devices";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ruda", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(91, 504);
            label2.Name = "label2";
            label2.Size = new Size(115, 16);
            label2.TabIndex = 8;
            label2.Text = "(REQUIRES ADMIN)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(848, 556);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(button2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "HWID Check";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button3;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button4;
        private Label label1;
        private Label label2;
    }
}
