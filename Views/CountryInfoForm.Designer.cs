namespace FlagLearner.Views
{
    partial class CountryInfoForm
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
            this.flagPictureBox = new System.Windows.Forms.PictureBox();
            this.CountryInfoPropertyGridView = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.flagPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flagPictureBox
            // 
            this.flagPictureBox.Location = new System.Drawing.Point(563, 12);
            this.flagPictureBox.Name = "flagPictureBox";
            this.flagPictureBox.Size = new System.Drawing.Size(463, 234);
            this.flagPictureBox.TabIndex = 0;
            this.flagPictureBox.TabStop = false;
            // 
            // CountryInfoPropertyGridView
            // 
            this.CountryInfoPropertyGridView.DisabledItemForeColor = System.Drawing.SystemColors.ControlText;
            this.CountryInfoPropertyGridView.Location = new System.Drawing.Point(12, 12);
            this.CountryInfoPropertyGridView.Name = "CountryInfoPropertyGridView";
            this.CountryInfoPropertyGridView.Size = new System.Drawing.Size(545, 426);
            this.CountryInfoPropertyGridView.TabIndex = 1;
            this.CountryInfoPropertyGridView.ToolbarVisible = false;
            // 
            // CountryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 450);
            this.Controls.Add(this.CountryInfoPropertyGridView);
            this.Controls.Add(this.flagPictureBox);
            this.Name = "CountryInfoForm";
            this.Text = "CountryInfoForm";
            this.Load += new System.EventHandler(this.CountryInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flagPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox flagPictureBox;
        private PropertyGrid CountryInfoPropertyGridView;
    }
}