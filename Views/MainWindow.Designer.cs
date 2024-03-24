using FlagLearner.Helpers;

namespace FlagLearner.Views
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

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
            this.flagListView = new System.Windows.Forms.ListView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.lineFilterList = new System.Windows.Forms.CheckedListBox();
            this.colorFilterList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // flagListView
            // 
            this.flagListView.GridLines = true;
            this.flagListView.Location = new System.Drawing.Point(12, 149);
            this.flagListView.MultiSelect = false;
            this.flagListView.Name = "flagListView";
            this.flagListView.Size = new System.Drawing.Size(793, 332);
            this.flagListView.TabIndex = 0;
            this.flagListView.UseCompatibleStateImageBehavior = false;
            this.flagListView.SelectedIndexChanged += new System.EventHandler(this.flagListView_SelectedIndexChanged);
            this.flagListView.DoubleClick += new System.EventHandler(this.flagListView_DoubleClick);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceholderText = "Search";
            this.searchBox.Size = new System.Drawing.Size(264, 27);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
            // 
            // lineFilterList
            // 
            this.lineFilterList.CheckOnClick = true;
            this.lineFilterList.FormattingEnabled = true;
            this.lineFilterList.Location = new System.Drawing.Point(12, 54);
            this.lineFilterList.MultiColumn = true;
            this.lineFilterList.Name = "lineFilterList";
            this.lineFilterList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lineFilterList.Size = new System.Drawing.Size(788, 26);
            this.lineFilterList.TabIndex = 4;
            this.lineFilterList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lineFilterList_ItemCheck);
            this.lineFilterList.Click += new System.EventHandler(this.lineFilterList_Click);
            // 
            // colorFilterList
            // 
            this.colorFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorFilterList.FormattingEnabled = true;
            this.colorFilterList.HorizontalScrollbar = true;
            this.colorFilterList.Location = new System.Drawing.Point(12, 95);
            this.colorFilterList.MultiColumn = true;
            this.colorFilterList.Name = "colorFilterList";
            this.colorFilterList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.colorFilterList.Size = new System.Drawing.Size(788, 48);
            this.colorFilterList.TabIndex = 3;
            this.colorFilterList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.colorFilterList_ItemCheck);
            this.colorFilterList.Click += new System.EventHandler(this.colorFilterList_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 505);
            this.Controls.Add(this.lineFilterList);
            this.Controls.Add(this.colorFilterList);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.flagListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView flagListView;
        private TextBox searchBox;
        private CheckedListBox colorFilterList;
        private CheckedListBox lineFilterList;
    }
}