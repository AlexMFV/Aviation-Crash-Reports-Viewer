namespace ACIR
{
    partial class YearSearch
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
            this.lblResults = new System.Windows.Forms.Label();
            this.olvCrashes = new BrightIdeasSoftware.ObjectListView();
            this.olvDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvPlane = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRegistration = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvOperator = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFatalities = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLoc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvFlag = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLink = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvCrashes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResults
            // 
            this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(9, 419);
            this.lblResults.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(96, 13);
            this.lblResults.TabIndex = 1;
            this.lblResults.Text = "Showing X Results";
            this.lblResults.Visible = false;
            // 
            // olvCrashes
            // 
            this.olvCrashes.AllColumns.Add(this.olvDate);
            this.olvCrashes.AllColumns.Add(this.olvPlane);
            this.olvCrashes.AllColumns.Add(this.olvRegistration);
            this.olvCrashes.AllColumns.Add(this.olvOperator);
            this.olvCrashes.AllColumns.Add(this.olvFatalities);
            this.olvCrashes.AllColumns.Add(this.olvLoc);
            this.olvCrashes.AllColumns.Add(this.olvFlag);
            this.olvCrashes.AllColumns.Add(this.olvCategory);
            this.olvCrashes.AllColumns.Add(this.olvLink);
            this.olvCrashes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvCrashes.CellEditUseWholeCell = false;
            this.olvCrashes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvDate,
            this.olvPlane,
            this.olvRegistration,
            this.olvOperator,
            this.olvFatalities,
            this.olvLoc,
            this.olvFlag,
            this.olvCategory});
            this.olvCrashes.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvCrashes.FullRowSelect = true;
            this.olvCrashes.GridLines = true;
            this.olvCrashes.Location = new System.Drawing.Point(12, 12);
            this.olvCrashes.MultiSelect = false;
            this.olvCrashes.Name = "olvCrashes";
            this.olvCrashes.SelectAllOnControlA = false;
            this.olvCrashes.ShowGroups = false;
            this.olvCrashes.Size = new System.Drawing.Size(863, 404);
            this.olvCrashes.TabIndex = 2;
            this.olvCrashes.UseCompatibleStateImageBehavior = false;
            this.olvCrashes.View = System.Windows.Forms.View.Details;
            this.olvCrashes.DoubleClick += new System.EventHandler(this.olvCrashes_DoubleClick);
            // 
            // olvDate
            // 
            this.olvDate.AspectName = "Date";
            this.olvDate.Text = "Date";
            this.olvDate.Width = 100;
            // 
            // olvPlane
            // 
            this.olvPlane.AspectName = "Plane";
            this.olvPlane.Text = "Airplane Model";
            this.olvPlane.Width = 200;
            // 
            // olvRegistration
            // 
            this.olvRegistration.AspectName = "Reg";
            this.olvRegistration.Text = "Registration";
            this.olvRegistration.Width = 90;
            // 
            // olvOperator
            // 
            this.olvOperator.AspectName = "Operator";
            this.olvOperator.Text = "Operator";
            this.olvOperator.Width = 200;
            // 
            // olvFatalities
            // 
            this.olvFatalities.AspectName = "Fat";
            this.olvFatalities.Text = "Fatalities";
            this.olvFatalities.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvFatalities.Width = 50;
            // 
            // olvLoc
            // 
            this.olvLoc.AspectName = "Loc";
            this.olvLoc.Text = "Location";
            this.olvLoc.Width = 120;
            // 
            // olvFlag
            // 
            this.olvFlag.AspectName = "Img";
            this.olvFlag.Searchable = false;
            this.olvFlag.ShowTextInHeader = false;
            this.olvFlag.Text = "";
            this.olvFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvFlag.Width = 20;
            // 
            // olvCategory
            // 
            this.olvCategory.AspectName = "Cat";
            this.olvCategory.Text = "Cat.";
            this.olvCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvCategory.Width = 50;
            // 
            // olvLink
            // 
            this.olvLink.AspectName = "Link";
            this.olvLink.DisplayIndex = 8;
            this.olvLink.Hideable = false;
            this.olvLink.IsEditable = false;
            this.olvLink.IsVisible = false;
            this.olvLink.Text = "Link";
            // 
            // YearSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(887, 436);
            this.Controls.Add(this.olvCrashes);
            this.Controls.Add(this.lblResults);
            this.Name = "YearSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YearSearch_FormClosing);
            this.Load += new System.EventHandler(this.YearSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvCrashes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblResults;
        private BrightIdeasSoftware.ObjectListView olvCrashes;
        private BrightIdeasSoftware.OLVColumn olvDate;
        private BrightIdeasSoftware.OLVColumn olvPlane;
        private BrightIdeasSoftware.OLVColumn olvRegistration;
        private BrightIdeasSoftware.OLVColumn olvOperator;
        private BrightIdeasSoftware.OLVColumn olvFatalities;
        private BrightIdeasSoftware.OLVColumn olvLoc;
        private BrightIdeasSoftware.OLVColumn olvFlag;
        private BrightIdeasSoftware.OLVColumn olvCategory;
        private BrightIdeasSoftware.OLVColumn olvLink;
    }
}