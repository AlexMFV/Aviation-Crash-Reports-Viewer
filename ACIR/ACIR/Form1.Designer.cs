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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblDataAge = new System.Windows.Forms.Label();
            this.btnSearchYear = new System.Windows.Forms.Button();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.nupYear = new System.Windows.Forms.NumericUpDown();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.lblOcc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblIndividual = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLock = new System.Windows.Forms.Button();
            this.lblUseDB = new System.Windows.Forms.Label();
            this.switchDB = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.btnSyncInc = new System.Windows.Forms.Button();
            this.btnSyncInd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupYear)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // btnSync
            // 
            this.btnSync.Enabled = false;
            this.btnSync.Location = new System.Drawing.Point(412, 12);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(96, 23);
            this.btnSync.TabIndex = 7;
            this.btnSync.Text = "Sync Everything";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lblOcc
            // 
            this.lblOcc.AutoSize = true;
            this.lblOcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcc.Location = new System.Drawing.Point(12, 18);
            this.lblOcc.Name = "lblOcc";
            this.lblOcc.Size = new System.Drawing.Size(52, 13);
            this.lblOcc.TabIndex = 0;
            this.lblOcc.Text = "Incidents:";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ACIR.Properties.Resources.settings;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(334, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(374, 166);
            this.shapeContainer1.TabIndex = 9;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 376;
            this.lineShape1.X2 = 376;
            this.lineShape1.Y1 = 6;
            this.lineShape1.Y2 = 158;
            // 
            // lblIndividual
            // 
            this.lblIndividual.AutoSize = true;
            this.lblIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndividual.Location = new System.Drawing.Point(10, 35);
            this.lblIndividual.Name = "lblIndividual";
            this.lblIndividual.Size = new System.Drawing.Size(55, 13);
            this.lblIndividual.TabIndex = 10;
            this.lblIndividual.Text = "Individual:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOcc);
            this.groupBox1.Controls.Add(this.lblIndividual);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(391, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 57);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Updated Since:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Aprox. 15 min";
            // 
            // btnLock
            // 
            this.btnLock.BackgroundImage = global::ACIR.Properties.Resources._lock;
            this.btnLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLock.Location = new System.Drawing.Point(384, 13);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(22, 22);
            this.btnLock.TabIndex = 13;
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLock_MouseClick);
            // 
            // lblUseDB
            // 
            this.lblUseDB.AutoSize = true;
            this.lblUseDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseDB.Location = new System.Drawing.Point(430, 87);
            this.lblUseDB.Name = "lblUseDB";
            this.lblUseDB.Size = new System.Drawing.Size(74, 13);
            this.lblUseDB.TabIndex = 14;
            this.lblUseDB.Text = "Use Database";
            // 
            // switchDB
            // 
            this.switchDB.BackColor = System.Drawing.Color.Transparent;
            this.switchDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("switchDB.BackgroundImage")));
            this.switchDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.switchDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchDB.Location = new System.Drawing.Point(507, 83);
            this.switchDB.Name = "switchDB";
            this.switchDB.OffColor = System.Drawing.Color.Gray;
            this.switchDB.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.switchDB.Size = new System.Drawing.Size(35, 20);
            this.switchDB.TabIndex = 17;
            this.switchDB.Value = false;
            this.switchDB.OnValueChange += new System.EventHandler(this.switchDB_OnValueChange);
            // 
            // btnSyncInc
            // 
            this.btnSyncInc.Location = new System.Drawing.Point(406, 41);
            this.btnSyncInc.Name = "btnSyncInc";
            this.btnSyncInc.Size = new System.Drawing.Size(73, 35);
            this.btnSyncInc.TabIndex = 18;
            this.btnSyncInc.Text = "Force Sync Incidents";
            this.btnSyncInc.UseVisualStyleBackColor = true;
            this.btnSyncInc.Click += new System.EventHandler(this.btnSyncInc_Click);
            // 
            // btnSyncInd
            // 
            this.btnSyncInd.Location = new System.Drawing.Point(495, 41);
            this.btnSyncInd.Name = "btnSyncInd";
            this.btnSyncInd.Size = new System.Drawing.Size(69, 35);
            this.btnSyncInd.TabIndex = 19;
            this.btnSyncInd.Text = "Force Sync Individuals";
            this.btnSyncInd.UseVisualStyleBackColor = true;
            this.btnSyncInd.Click += new System.EventHandler(this.btnSyncInd_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.btnSearchYear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(374, 166);
            this.Controls.Add(this.btnSyncInd);
            this.Controls.Add(this.btnSyncInc);
            this.Controls.Add(this.switchDB);
            this.Controls.Add(this.lblUseDB);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.nupYear);
            this.Controls.Add(this.btnSearchAll);
            this.Controls.Add(this.btnSearchYear);
            this.Controls.Add(this.lblDataAge);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aviation Crash Reports";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label lblOcc;
        private System.Windows.Forms.Button button1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label lblIndividual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Label lblUseDB;
        private Bunifu.Framework.UI.BunifuiOSSwitch switchDB;
        private System.Windows.Forms.Button btnSyncInc;
        private System.Windows.Forms.Button btnSyncInd;
    }
}

