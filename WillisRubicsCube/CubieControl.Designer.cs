namespace WillisRubicsCube
{
    partial class CubieControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonCubie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonCubie
            // 
            this.ButtonCubie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCubie.Location = new System.Drawing.Point(0, 0);
            this.ButtonCubie.Name = "ButtonCubie";
            this.ButtonCubie.Size = new System.Drawing.Size(23, 23);
            this.ButtonCubie.TabIndex = 56;
            this.ButtonCubie.UseVisualStyleBackColor = true;
            // 
            // CubieControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonCubie);
            this.Name = "CubieControl";
            this.Size = new System.Drawing.Size(23, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonCubie;
    }
}
