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
            this.lvwCrashes = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperator = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFatalities = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwCrashes
            // 
            this.lvwCrashes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCrashes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colPlane,
            this.colReg,
            this.colOperator,
            this.colFatalities,
            this.colLocation,
            this.colFlag,
            this.colCategory});
            this.lvwCrashes.FullRowSelect = true;
            this.lvwCrashes.GridLines = true;
            this.lvwCrashes.Location = new System.Drawing.Point(8, 8);
            this.lvwCrashes.Margin = new System.Windows.Forms.Padding(2);
            this.lvwCrashes.MultiSelect = false;
            this.lvwCrashes.Name = "lvwCrashes";
            this.lvwCrashes.Size = new System.Drawing.Size(868, 435);
            this.lvwCrashes.TabIndex = 0;
            this.lvwCrashes.UseCompatibleStateImageBehavior = false;
            this.lvwCrashes.View = System.Windows.Forms.View.Details;
            this.lvwCrashes.Visible = false;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colPlane
            // 
            this.colPlane.Text = "Airplane Model";
            this.colPlane.Width = 200;
            // 
            // colReg
            // 
            this.colReg.Text = "Registration";
            this.colReg.Width = 90;
            // 
            // colOperator
            // 
            this.colOperator.Text = "Operator";
            this.colOperator.Width = 200;
            // 
            // colFatalities
            // 
            this.colFatalities.Text = "Fatalities";
            this.colFatalities.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 100;
            // 
            // colFlag
            // 
            this.colFlag.Text = "";
            this.colFlag.Width = 30;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Cat.";
            this.colCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCategory.Width = 50;
            // 
            // lblResults
            // 
            this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(9, 446);
            this.lblResults.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(96, 13);
            this.lblResults.TabIndex = 1;
            this.lblResults.Text = "Showing X Results";
            this.lblResults.Visible = false;
            // 
            // YearSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(887, 463);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lvwCrashes);
            this.Name = "YearSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.YearSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCrashes;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colPlane;
        private System.Windows.Forms.ColumnHeader colReg;
        private System.Windows.Forms.ColumnHeader colOperator;
        private System.Windows.Forms.ColumnHeader colFatalities;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colFlag;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.Label lblResults;
    }
}