namespace MissionPlanner.Log
{
    partial class PosDownLoadCurrent
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelBytes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 22);
            this.progressBar1.TabIndex = 18;
            // 
            // labelBytes
            // 
            this.labelBytes.AutoSize = true;
            this.labelBytes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelBytes.Location = new System.Drawing.Point(246, 5);
            this.labelBytes.Margin = new System.Windows.Forms.Padding(5);
            this.labelBytes.Name = "labelBytes";
            this.labelBytes.Size = new System.Drawing.Size(41, 12);
            this.labelBytes.TabIndex = 19;
            this.labelBytes.Text = "label3";
            // 
            // PosDownLoadCurrent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 22);
            this.Controls.Add(this.labelBytes);
            this.Controls.Add(this.progressBar1);
            this.Name = "PosDownLoadCurrent";
            this.Text = "下载POS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelBytes;
    }
}