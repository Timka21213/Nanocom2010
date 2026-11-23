namespace DemoSpeedoPanel
{
    partial class PanelForm
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
            this.SuspendLayout();
            // 
            // baseUI1
            // 
            this.baseUI1.BackColor = System.Drawing.Color.Black;
            this.baseUI1.Interact = false;
            this.baseUI1.Location = new System.Drawing.Point(23, 25);
            this.baseUI1.Name = "baseUI1";
            this.baseUI1.Size = new System.Drawing.Size(680, 351);
            this.baseUI1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 409);
            this.Controls.Add(this.baseUI1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NextUI.BaseUI.BaseUI baseUI1;
    }
}

