namespace ACIR
{
    partial class Main
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblDataAge = new System.Windows.Forms.Label();
            this.btnSearchYear = new System.Windows.Forms.Button();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.nupYear = new System.Windows.Forms.NumericUpDown();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 136);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(25, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Info";
            // 
            // lblDataAge
            // 
            this.lblDataAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDataAge.AutoSize = true;
            this.lblDataAge.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataAge.Location = new System.Drawing.Point(8, 9);
            this.lblDataAge.Name = "lblDataAge";
            this.lblDataAge.Size = new System.Drawing.Size(34, 13);
            this.lblDataAge.TabIndex = 1;
            this.lblDataAge.Text = "Info";
            this.lblDataAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchYear
            // 
            this.btnSearchYear.Location = new System.Drawing.Point(191, 59);
            this.btnSearchYear.Name = "btnSearchYear";
            this.btnSearchYear.Size = new System.Drawing.Size(96, 23);
            this.btnSearchYear.TabIndex = 2;
            this.btnSearchYear.Text = "Search by Year";
            this.btnSearchYear.UseVisualStyleBackColor = true;
            this.btnSearchYear.Click += new System.EventHandler(this.btnSearchYear_Click);
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(131, 106);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(106, 23);
            this.btnSearchAll.TabIndex = 3;
            this.btnSearchAll.Text = "All Occurrences";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            // 
            // nupYear
            // 
            this.nupYear.Location = new System.Drawing.Point(106, 61);
            this.nupYear.Name = "nupYear";
            this.nupYear.Size = new System.Drawing.Size(79, 20);
            this.nupYear.TabIndex = 4;
            this.nupYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(177, 88);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(16, 13);
            this.lblOr.TabIndex = 5;
            this.lblOr.Text = "or";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(72, 63);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 6;
            this.lblYear.Text = "Year:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(371, 166);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.nupYear);
            this.Controls.Add(this.btnSearchAll);
            this.Controls.Add(this.btnSearchYear);
            this.Controls.Add(this.lblDataAge);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aviation Crash Reports";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblDataAge;
        private System.Windows.Forms.Button btnSearchYear;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.NumericUpDown nupYear;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblYear;
    }
}

