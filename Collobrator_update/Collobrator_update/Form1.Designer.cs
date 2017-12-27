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
            this.button_update = new System.Windows.Forms.Button();
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
            this.seletFile = new System.Windows.Forms.Button();
            this.CcCommitFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.Log_info_Edit = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearCase_Branch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_update
            // 
            this.button_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_update.Location = new System.Drawing.Point(591, 470);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(106, 26);
            this.button_update.TabIndex = 0;
            this.button_update.Text = "Update Review";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button1_Click);
            // 
            // radio_NewReview
            // 
            this.radio_NewReview.AutoSize = true;
            this.radio_NewReview.Location = new System.Drawing.Point(24, 15);
            this.radio_NewReview.Name = "radio_NewReview";
            this.radio_NewReview.Size = new System.Drawing.Size(77, 16);
            this.radio_NewReview.TabIndex = 1;
            this.radio_NewReview.Text = "NewReview";
            this.radio_NewReview.UseVisualStyleBackColor = true;
            this.radio_NewReview.CheckedChanged += new System.EventHandler(this.radio_NewReview_CheckedChanged);
            // 
            // radio_OldReview
            // 
            this.radio_OldReview.AutoSize = true;
            this.radio_OldReview.Checked = true;
            this.radio_OldReview.Location = new System.Drawing.Point(162, 15);
            this.radio_OldReview.Name = "radio_OldReview";
            this.radio_OldReview.Size = new System.Drawing.Size(77, 16);
            this.radio_OldReview.TabIndex = 1;
            this.radio_OldReview.TabStop = true;
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
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "ClearCase Commit File";
            // 
            // ClearCaseFilePath
            // 
            this.ClearCaseFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearCaseFilePath.Location = new System.Drawing.Point(143, 69);
            this.ClearCaseFilePath.Name = "ClearCaseFilePath";
            this.ClearCaseFilePath.Size = new System.Drawing.Size(474, 21);
            this.ClearCaseFilePath.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(687, 254);
            this.dataGridView1.TabIndex = 6;
            // 
            // ClearCase_MapPath
            // 
            this.ClearCase_MapPath.Location = new System.Drawing.Point(143, 42);
            this.ClearCase_MapPath.Name = "ClearCase_MapPath";
            this.ClearCase_MapPath.Size = new System.Drawing.Size(133, 21);
            this.ClearCase_MapPath.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ClearCase Map Path";
            // 
            // ClearCase_ReviewID
            // 
            this.ClearCase_ReviewID.Location = new System.Drawing.Point(389, 13);
            this.ClearCase_ReviewID.MaxLength = 6;
            this.ClearCase_ReviewID.Name = "ClearCase_ReviewID";
            this.ClearCase_ReviewID.Size = new System.Drawing.Size(307, 21);
            this.ClearCase_ReviewID.TabIndex = 10;
            this.ClearCase_ReviewID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClearCase_ReviewID_KeyPress);
            // 
            // ClearCase_ReviewID_label
            // 
            this.ClearCase_ReviewID_label.AutoSize = true;
            this.ClearCase_ReviewID_label.Location = new System.Drawing.Point(324, 18);
            this.ClearCase_ReviewID_label.Name = "ClearCase_ReviewID_label";
            this.ClearCase_ReviewID_label.Size = new System.Drawing.Size(59, 12);
            this.ClearCase_ReviewID_label.TabIndex = 9;
            this.ClearCase_ReviewID_label.Text = "Review Id";
            // 
            // seletFile
            // 
            this.seletFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seletFile.Location = new System.Drawing.Point(623, 68);
            this.seletFile.Name = "seletFile";
            this.seletFile.Size = new System.Drawing.Size(73, 21);
            this.seletFile.TabIndex = 11;
            this.seletFile.Text = "...";
            this.seletFile.UseVisualStyleBackColor = true;
            this.seletFile.Click += new System.EventHandler(this.seletFile_Click);
            // 
            // CcCommitFileDlg
            // 
            this.CcCommitFileDlg.FileName = "Clear Case Commit File Dialog";
            // 
            // Log_info_Edit
            // 
            this.Log_info_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_info_Edit.Location = new System.Drawing.Point(10, 355);
            this.Log_info_Edit.Name = "Log_info_Edit";
            this.Log_info_Edit.Size = new System.Drawing.Size(686, 109);
            this.Log_info_Edit.TabIndex = 12;
            this.Log_info_Edit.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "ClearCase Branch";
            // 
            // ClearCase_Branch
            // 
            this.ClearCase_Branch.Location = new System.Drawing.Point(389, 41);
            this.ClearCase_Branch.Name = "ClearCase_Branch";
            this.ClearCase_Branch.Size = new System.Drawing.Size(307, 21);
            this.ClearCase_Branch.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 498);
            this.Controls.Add(this.ClearCase_Branch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Log_info_Edit);
            this.Controls.Add(this.seletFile);
            this.Controls.Add(this.ClearCase_ReviewID);
            this.Controls.Add(this.ClearCase_ReviewID_label);
            this.Controls.Add(this.ClearCase_MapPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ClearCaseFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_update);
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

        private System.Windows.Forms.Button button_update;
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
        private System.Windows.Forms.Button seletFile;
        private System.Windows.Forms.OpenFileDialog CcCommitFileDlg;
        private System.Windows.Forms.RichTextBox Log_info_Edit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClearCase_Branch;
    }
}

