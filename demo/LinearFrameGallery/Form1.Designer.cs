namespace LinearFrameGallery
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
            this.baseUI1 = new NextUI.BaseUI.BaseUI();
            this.baseUI2 = new NextUI.BaseUI.BaseUI();
            this.baseUI3 = new NextUI.BaseUI.BaseUI();
            this.SuspendLayout();
            // 
            // baseUI1
            // 
            this.baseUI1.Interact = false;
            this.baseUI1.Location = new System.Drawing.Point(21, 11);
            this.baseUI1.Name = "baseUI1";
            this.baseUI1.Size = new System.Drawing.Size(542, 103);
            this.baseUI1.TabIndex = 0;
            // 
            // baseUI2
            // 
            this.baseUI2.Interact = false;
            this.baseUI2.Location = new System.Drawing.Point(21, 132);
            this.baseUI2.Name = "baseUI2";
            this.baseUI2.Size = new System.Drawing.Size(542, 103);
            this.baseUI2.TabIndex = 1;
            // 
            // baseUI3
            // 
            this.baseUI3.Interact = false;
            this.baseUI3.Location = new System.Drawing.Point(21, 253);
            this.baseUI3.Name = "baseUI3";
            this.baseUI3.Size = new System.Drawing.Size(542, 103);
            this.baseUI3.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 368);
            this.Controls.Add(this.baseUI3);
            this.Controls.Add(this.baseUI2);
            this.Controls.Add(this.baseUI1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NextUI.BaseUI.BaseUI baseUI1;
        private NextUI.BaseUI.BaseUI baseUI2;
        private NextUI.BaseUI.BaseUI baseUI3;
    }
}

