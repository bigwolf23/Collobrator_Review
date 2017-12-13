namespace Collobrator_update
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.radio_NewReview = new System.Windows.Forms.RadioButton();
            this.radio_OldReview = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearCaseFilePath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClearCase_MapPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClearCase_ReviewID = new System.Windows.Forms.TextBox();
            this.ClearCase_ReviewID_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(591, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Update_Review";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radio_NewReview
            // 
            this.radio_NewReview.AutoSize = true;
            this.radio_NewReview.Checked = true;
            this.radio_NewReview.Location = new System.Drawing.Point(15, 15);
            this.radio_NewReview.Name = "radio_NewReview";
            this.radio_NewReview.Size = new System.Drawing.Size(77, 16);
            this.radio_NewReview.TabIndex = 1;
            this.radio_NewReview.TabStop = true;
            this.radio_NewReview.Text = "NewReview";
            this.radio_NewReview.UseVisualStyleBackColor = true;
            this.radio_NewReview.CheckedChanged += new System.EventHandler(this.radio_NewReview_CheckedChanged);
            // 
            // radio_OldReview
            // 
            this.radio_OldReview.AutoSize = true;
            this.radio_OldReview.Location = new System.Drawing.Point(154, 15);
            this.radio_OldReview.Name = "radio_OldReview";
            this.radio_OldReview.Size = new System.Drawing.Size(77, 16);
            this.radio_OldReview.TabIndex = 1;
            this.radio_OldReview.Text = "OldReview";
            this.radio_OldReview.UseVisualStyleBackColor = true;
            this.radio_OldReview.CheckedChanged += new System.EventHandler(this.radio_OldReview_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_OldReview);
            this.groupBox1.Controls.Add(this.radio_NewReview);
            this.groupBox1.Location = new System.Drawing.Point(10, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 37);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Review_mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "ClearCase_CommitFile";
            // 
            // ClearCaseFilePath
            // 
            this.ClearCaseFilePath.Location = new System.Drawing.Point(143, 69);
            this.ClearCaseFilePath.Name = "ClearCaseFilePath";
            this.ClearCaseFilePath.Size = new System.Drawing.Size(554, 21);
            this.ClearCaseFilePath.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(687, 262);
            this.dataGridView1.TabIndex = 6;
            // 
            // ClearCase_MapPath
            // 
            this.ClearCase_MapPath.Location = new System.Drawing.Point(143, 42);
            this.ClearCase_MapPath.Name = "ClearCase_MapPath";
            this.ClearCase_MapPath.Size = new System.Drawing.Size(232, 21);
            this.ClearCase_MapPath.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ClearCase_MapPath";
            // 
            // ClearCase_ReviewID
            // 
            this.ClearCase_ReviewID.Location = new System.Drawing.Point(512, 41);
            this.ClearCase_ReviewID.MaxLength = 6;
            this.ClearCase_ReviewID.Name = "ClearCase_ReviewID";
            this.ClearCase_ReviewID.Size = new System.Drawing.Size(185, 21);
            this.ClearCase_ReviewID.TabIndex = 10;
            this.ClearCase_ReviewID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClearCase_ReviewID_KeyPress);
            // 
            // ClearCase_ReviewID_label
            // 
            this.ClearCase_ReviewID_label.AutoSize = true;
            this.ClearCase_ReviewID_label.Location = new System.Drawing.Point(382, 43);
            this.ClearCase_ReviewID_label.Name = "ClearCase_ReviewID_label";
            this.ClearCase_ReviewID_label.Size = new System.Drawing.Size(113, 12);
            this.ClearCase_ReviewID_label.TabIndex = 9;
            this.ClearCase_ReviewID_label.Text = "ClearCase_ReviewId";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 391);
            this.Controls.Add(this.ClearCase_ReviewID);
            this.Controls.Add(this.ClearCase_ReviewID_label);
            this.Controls.Add(this.ClearCase_MapPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ClearCaseFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Review_Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RadioButton radio_NewReview;
        private System.Windows.Forms.RadioButton radio_OldReview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ClearCaseFilePath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox ClearCase_MapPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClearCase_ReviewID;
        private System.Windows.Forms.Label ClearCase_ReviewID_label;
    }
}

