namespace ClientPrZad3
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.saveMtrxBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.multMtrxBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pathMxB = new System.Windows.Forms.TextBox();
            this.browseMxB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pathMxA = new System.Windows.Forms.TextBox();
            this.browseMxA = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fractalColoring = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fractalThreads = new System.Windows.Forms.TextBox();
            this.fractalHeight = new System.Windows.Forms.TextBox();
            this.fractalWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveFractalBtn = new System.Windows.Forms.Button();
            this.genFractalBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(684, 258);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.saveMtrxBtn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.multMtrxBtn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pathMxB);
            this.tabPage1.Controls.Add(this.browseMxB);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pathMxA);
            this.tabPage1.Controls.Add(this.browseMxA);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Matrix";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveMtrxBtn
            // 
            this.saveMtrxBtn.Enabled = false;
            this.saveMtrxBtn.Location = new System.Drawing.Point(422, 45);
            this.saveMtrxBtn.Name = "saveMtrxBtn";
            this.saveMtrxBtn.Size = new System.Drawing.Size(100, 49);
            this.saveMtrxBtn.TabIndex = 9;
            this.saveMtrxBtn.Text = "Save";
            this.saveMtrxBtn.UseVisualStyleBackColor = true;
            this.saveMtrxBtn.Click += new System.EventHandler(this.saveMtrxBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Matrix multiplication";
            // 
            // multMtrxBtn
            // 
            this.multMtrxBtn.Enabled = false;
            this.multMtrxBtn.Location = new System.Drawing.Point(316, 45);
            this.multMtrxBtn.Name = "multMtrxBtn";
            this.multMtrxBtn.Size = new System.Drawing.Size(100, 49);
            this.multMtrxBtn.TabIndex = 7;
            this.multMtrxBtn.Text = "Compute";
            this.multMtrxBtn.UseVisualStyleBackColor = true;
            this.multMtrxBtn.Click += new System.EventHandler(this.multMtrxBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Matrix B";
            // 
            // pathMxB
            // 
            this.pathMxB.Location = new System.Drawing.Point(70, 74);
            this.pathMxB.Name = "pathMxB";
            this.pathMxB.ReadOnly = true;
            this.pathMxB.Size = new System.Drawing.Size(153, 20);
            this.pathMxB.TabIndex = 5;
            // 
            // browseMxB
            // 
            this.browseMxB.Location = new System.Drawing.Point(229, 73);
            this.browseMxB.Name = "browseMxB";
            this.browseMxB.Size = new System.Drawing.Size(81, 23);
            this.browseMxB.TabIndex = 4;
            this.browseMxB.Text = "Browse...";
            this.browseMxB.UseVisualStyleBackColor = true;
            this.browseMxB.Click += new System.EventHandler(this.browseMxB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Matrix A";
            // 
            // pathMxA
            // 
            this.pathMxA.Location = new System.Drawing.Point(70, 45);
            this.pathMxA.Name = "pathMxA";
            this.pathMxA.ReadOnly = true;
            this.pathMxA.Size = new System.Drawing.Size(153, 20);
            this.pathMxA.TabIndex = 2;
            // 
            // browseMxA
            // 
            this.browseMxA.Location = new System.Drawing.Point(229, 44);
            this.browseMxA.Name = "browseMxA";
            this.browseMxA.Size = new System.Drawing.Size(81, 23);
            this.browseMxA.TabIndex = 0;
            this.browseMxA.Text = "Browse...";
            this.browseMxA.UseVisualStyleBackColor = true;
            this.browseMxA.Click += new System.EventHandler(this.browseMxA_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fractalColoring);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.fractalThreads);
            this.tabPage2.Controls.Add(this.fractalHeight);
            this.tabPage2.Controls.Add(this.fractalWidth);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.saveFractalBtn);
            this.tabPage2.Controls.Add(this.genFractalBtn);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mandelbrot";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fractalColoring
            // 
            this.fractalColoring.FormattingEnabled = true;
            this.fractalColoring.Items.AddRange(new object[] {
            "threads",
            "cores"});
            this.fractalColoring.Location = new System.Drawing.Point(199, 47);
            this.fractalColoring.Name = "fractalColoring";
            this.fractalColoring.Size = new System.Drawing.Size(91, 21);
            this.fractalColoring.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(148, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Coloring";
            // 
            // fractalThreads
            // 
            this.fractalThreads.Location = new System.Drawing.Point(69, 104);
            this.fractalThreads.Name = "fractalThreads";
            this.fractalThreads.Size = new System.Drawing.Size(61, 20);
            this.fractalThreads.TabIndex = 19;
            // 
            // fractalHeight
            // 
            this.fractalHeight.Location = new System.Drawing.Point(69, 76);
            this.fractalHeight.Name = "fractalHeight";
            this.fractalHeight.Size = new System.Drawing.Size(61, 20);
            this.fractalHeight.TabIndex = 18;
            // 
            // fractalWidth
            // 
            this.fractalWidth.Location = new System.Drawing.Point(69, 47);
            this.fractalWidth.Name = "fractalWidth";
            this.fractalWidth.Size = new System.Drawing.Size(61, 20);
            this.fractalWidth.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Threads";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Width";
            // 
            // saveFractalBtn
            // 
            this.saveFractalBtn.Enabled = false;
            this.saveFractalBtn.Location = new System.Drawing.Point(422, 45);
            this.saveFractalBtn.Name = "saveFractalBtn";
            this.saveFractalBtn.Size = new System.Drawing.Size(100, 49);
            this.saveFractalBtn.TabIndex = 13;
            this.saveFractalBtn.Text = "Save";
            this.saveFractalBtn.UseVisualStyleBackColor = true;
            this.saveFractalBtn.Click += new System.EventHandler(this.saveFractalBtn_Click);
            // 
            // genFractalBtn
            // 
            this.genFractalBtn.Location = new System.Drawing.Point(316, 45);
            this.genFractalBtn.Name = "genFractalBtn";
            this.genFractalBtn.Size = new System.Drawing.Size(100, 49);
            this.genFractalBtn.TabIndex = 12;
            this.genFractalBtn.Text = "Generate";
            this.genFractalBtn.UseVisualStyleBackColor = true;
            this.genFractalBtn.Click += new System.EventHandler(this.genFractalBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mandelbrot generation";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 256);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "PR Zad3 Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveMtrxBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button multMtrxBtn;
        private System.Windows.Forms.TextBox pathMxB;
        private System.Windows.Forms.Button browseMxB;
        private System.Windows.Forms.TextBox pathMxA;
        private System.Windows.Forms.Button browseMxA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button genFractalBtn;
        private System.Windows.Forms.Button saveFractalBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fractalThreads;
        private System.Windows.Forms.TextBox fractalHeight;
        private System.Windows.Forms.TextBox fractalWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox fractalColoring;
        private System.Windows.Forms.Label label8;
    }
}

