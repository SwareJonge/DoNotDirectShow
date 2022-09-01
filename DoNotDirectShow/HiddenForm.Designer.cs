namespace DoNotDirectShow
{
    partial class HiddenForm
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
            this.ccPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ccPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // ccPreview
            // 
            this.ccPreview.Location = new System.Drawing.Point(0, 0);
            this.ccPreview.Name = "ccPreview";
            this.ccPreview.Size = new System.Drawing.Size(100, 50);
            this.ccPreview.TabIndex = 0;
            this.ccPreview.TabStop = false;
            // 
            // HiddenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 201);
            this.Controls.Add(this.ccPreview);
            this.Enabled = false;
            this.Name = "HiddenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HiddenForm_FormClosing);
            this.Load += new System.EventHandler(this.HiddenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ccPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox ccPreview;
    }
}