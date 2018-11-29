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
            this.colOperator});
            this.lvwCrashes.FullRowSelect = true;
            this.lvwCrashes.Location = new System.Drawing.Point(12, 12);
            this.lvwCrashes.MultiSelect = false;
            this.lvwCrashes.Name = "lvwCrashes";
            this.lvwCrashes.Size = new System.Drawing.Size(926, 791);
            this.lvwCrashes.TabIndex = 0;
            this.lvwCrashes.UseCompatibleStateImageBehavior = false;
            this.lvwCrashes.View = System.Windows.Forms.View.Details;
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
            // YearSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(950, 815);
            this.Controls.Add(this.lvwCrashes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "YearSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.YearSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwCrashes;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colPlane;
        private System.Windows.Forms.ColumnHeader colReg;
        private System.Windows.Forms.ColumnHeader colOperator;
    }
}