namespace WillisRubicsCube
{
    partial class MainForm
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
            this.ButtonCubeRight = new System.Windows.Forms.Button();
            this.ButtonCubeLeft = new System.Windows.Forms.Button();
            this.ButtonCubeDown = new System.Windows.Forms.Button();
            this.ButtonCubeUp = new System.Windows.Forms.Button();
            this.ButtonCubeCCW = new System.Windows.Forms.Button();
            this.ButtonCubeCW = new System.Windows.Forms.Button();
            this.ButtonScramble = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cubeFaceDisplay2 = new WillisRubicsCube.RubicsCubeControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.historyControl1 = new WillisRubicsCube.HistoryControl();
            this.textBoxPercentSolved = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonRedo = new System.Windows.Forms.Button();
            this.ButtonUndo = new System.Windows.Forms.Button();
            this.ButtonSolve = new System.Windows.Forms.Button();
            this.cubeFaceDisplay1 = new WillisRubicsCube.RubicsCubeControl();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCubeRight
            // 
            this.ButtonCubeRight.Enabled = false;
            this.ButtonCubeRight.Location = new System.Drawing.Point(205, 286);
            this.ButtonCubeRight.Name = "ButtonCubeRight";
            this.ButtonCubeRight.Size = new System.Drawing.Size(75, 23);
            this.ButtonCubeRight.TabIndex = 15;
            this.ButtonCubeRight.Text = "Right";
            this.ButtonCubeRight.UseVisualStyleBackColor = true;
            this.ButtonCubeRight.Click += new System.EventHandler(this.ButtonCubeRight_Click);
            // 
            // ButtonCubeLeft
            // 
            this.ButtonCubeLeft.Enabled = false;
            this.ButtonCubeLeft.Location = new System.Drawing.Point(124, 286);
            this.ButtonCubeLeft.Name = "ButtonCubeLeft";
            this.ButtonCubeLeft.Size = new System.Drawing.Size(75, 23);
            this.ButtonCubeLeft.TabIndex = 16;
            this.ButtonCubeLeft.Text = "Left";
            this.ButtonCubeLeft.UseVisualStyleBackColor = true;
            this.ButtonCubeLeft.Click += new System.EventHandler(this.ButtonCubeLeft_Click);
            // 
            // ButtonCubeDown
            // 
            this.ButtonCubeDown.Enabled = false;
            this.ButtonCubeDown.Location = new System.Drawing.Point(165, 315);
            this.ButtonCubeDown.Name = "ButtonCubeDown";
            this.ButtonCubeDown.Size = new System.Drawing.Size(75, 23);
            this.ButtonCubeDown.TabIndex = 18;
            this.ButtonCubeDown.Text = "Down";
            this.ButtonCubeDown.UseVisualStyleBackColor = true;
            this.ButtonCubeDown.Click += new System.EventHandler(this.ButtonCubeDown_Click);
            // 
            // ButtonCubeUp
            // 
            this.ButtonCubeUp.Enabled = false;
            this.ButtonCubeUp.Location = new System.Drawing.Point(165, 257);
            this.ButtonCubeUp.Name = "ButtonCubeUp";
            this.ButtonCubeUp.Size = new System.Drawing.Size(75, 23);
            this.ButtonCubeUp.TabIndex = 17;
            this.ButtonCubeUp.Text = "Up";
            this.ButtonCubeUp.UseVisualStyleBackColor = true;
            this.ButtonCubeUp.Click += new System.EventHandler(this.ButtonCubeUp_Click);
            // 
            // ButtonCubeCCW
            // 
            this.ButtonCubeCCW.Enabled = false;
            this.ButtonCubeCCW.Location = new System.Drawing.Point(246, 257);
            this.ButtonCubeCCW.Name = "ButtonCubeCCW";
            this.ButtonCubeCCW.Size = new System.Drawing.Size(75, 23);
            this.ButtonCubeCCW.TabIndex = 20;
            this.ButtonCubeCCW.Text = "AntiClockwise";
            this.ButtonCubeCCW.UseVisualStyleBackColor = true;
            this.ButtonCubeCCW.Click += new System.EventHandler(this.ButtonCubeCCW_Click);
            // 
            // ButtonCubeCW
            // 
            this.ButtonCubeCW.Enabled = false;
            this.ButtonCubeCW.Location = new System.Drawing.Point(84, 257);
            this.ButtonCubeCW.Name = "ButtonCubeCW";
            this.ButtonCubeCW.Size = new System.Drawing.Size(75, 23);
            this.ButtonCubeCW.TabIndex = 19;
            this.ButtonCubeCW.Text = "Clockwise";
            this.ButtonCubeCW.UseVisualStyleBackColor = true;
            this.ButtonCubeCW.Click += new System.EventHandler(this.ButtonCubeCW_Click);
            // 
            // ButtonScramble
            // 
            this.ButtonScramble.Location = new System.Drawing.Point(234, 404);
            this.ButtonScramble.Name = "ButtonScramble";
            this.ButtonScramble.Size = new System.Drawing.Size(75, 23);
            this.ButtonScramble.TabIndex = 21;
            this.ButtonScramble.Text = "Scramble";
            this.ButtonScramble.UseVisualStyleBackColor = true;
            this.ButtonScramble.Click += new System.EventHandler(this.ButtonScramble_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(108, 407);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 22;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Number of Moves";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cubeFaceDisplay2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1032, 615);
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.TabIndex = 24;
            // 
            // cubeFaceDisplay2
            // 
            this.cubeFaceDisplay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeFaceDisplay2.Location = new System.Drawing.Point(0, 0);
            this.cubeFaceDisplay2.Name = "cubeFaceDisplay2";
            this.cubeFaceDisplay2.Size = new System.Drawing.Size(344, 615);
            this.cubeFaceDisplay2.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.historyControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBoxPercentSolved);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonClear);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonRedo);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonUndo);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonSolve);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonCubeCW);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonCubeDown);
            this.splitContainer2.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonCubeCCW);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonScramble);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonCubeRight);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonCubeUp);
            this.splitContainer2.Panel2.Controls.Add(this.ButtonCubeLeft);
            this.splitContainer2.Size = new System.Drawing.Size(684, 615);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 24;
            // 
            // historyControl1
            // 
            this.historyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyControl1.Location = new System.Drawing.Point(0, 0);
            this.historyControl1.Name = "historyControl1";
            this.historyControl1.Size = new System.Drawing.Size(228, 615);
            this.historyControl1.TabIndex = 0;
            // 
            // textBoxPercentSolved
            // 
            this.textBoxPercentSolved.Location = new System.Drawing.Point(114, 486);
            this.textBoxPercentSolved.Name = "textBoxPercentSolved";
            this.textBoxPercentSolved.ReadOnly = true;
            this.textBoxPercentSolved.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxPercentSolved.Size = new System.Drawing.Size(100, 20);
            this.textBoxPercentSolved.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Percent Solved";
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(267, 148);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 26;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonRedo
            // 
            this.ButtonRedo.Location = new System.Drawing.Point(315, 119);
            this.ButtonRedo.Name = "ButtonRedo";
            this.ButtonRedo.Size = new System.Drawing.Size(75, 23);
            this.ButtonRedo.TabIndex = 25;
            this.ButtonRedo.Text = "Redo";
            this.ButtonRedo.UseVisualStyleBackColor = true;
            this.ButtonRedo.Click += new System.EventHandler(this.ButtonRedo_Click);
            // 
            // ButtonUndo
            // 
            this.ButtonUndo.Location = new System.Drawing.Point(234, 119);
            this.ButtonUndo.Name = "ButtonUndo";
            this.ButtonUndo.Size = new System.Drawing.Size(75, 23);
            this.ButtonUndo.TabIndex = 2;
            this.ButtonUndo.Text = "Undo";
            this.ButtonUndo.UseVisualStyleBackColor = true;
            this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // ButtonSolve
            // 
            this.ButtonSolve.Location = new System.Drawing.Point(234, 433);
            this.ButtonSolve.Name = "ButtonSolve";
            this.ButtonSolve.Size = new System.Drawing.Size(75, 23);
            this.ButtonSolve.TabIndex = 24;
            this.ButtonSolve.Text = "Solve";
            this.ButtonSolve.UseVisualStyleBackColor = true;
            this.ButtonSolve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // cubeFaceDisplay1
            // 
            this.cubeFaceDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeFaceDisplay1.Location = new System.Drawing.Point(0, 0);
            this.cubeFaceDisplay1.Name = "cubeFaceDisplay1";
            this.cubeFaceDisplay1.Size = new System.Drawing.Size(344, 615);
            this.cubeFaceDisplay1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 615);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RubicsCubeControl cubeFaceDisplay1;
        private System.Windows.Forms.Button ButtonCubeRight;
        private System.Windows.Forms.Button ButtonCubeLeft;
        private System.Windows.Forms.Button ButtonCubeDown;
        private System.Windows.Forms.Button ButtonCubeUp;
        private System.Windows.Forms.Button ButtonCubeCCW;
        private System.Windows.Forms.Button ButtonCubeCW;
        private System.Windows.Forms.Button ButtonScramble;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button ButtonSolve;
        private System.Windows.Forms.Button ButtonUndo;
        private HistoryControl historyControl1;
        private System.Windows.Forms.Button ButtonRedo;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.TextBox textBoxPercentSolved;
        private System.Windows.Forms.Label label2;
        private RubicsCubeControl cubeFaceDisplay2;
    }
}

