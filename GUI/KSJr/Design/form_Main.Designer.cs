namespace KSJr
{
    partial class form_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Main));
            this.top_Panel = new System.Windows.Forms.Panel();
            this.button_Scan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Result = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_test = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.shadowPanel1 = new ShadowPanel.ShadowPanel();
            this.now_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.list_View = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.top_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.shadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_Panel
            // 
            this.top_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.top_Panel.Controls.Add(this.button_Scan);
            this.top_Panel.Controls.Add(this.pictureBox1);
            this.top_Panel.Controls.Add(this.button_Result);
            this.top_Panel.Controls.Add(this.button_Search);
            this.top_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_Panel.Location = new System.Drawing.Point(0, 0);
            this.top_Panel.Name = "top_Panel";
            this.top_Panel.Size = new System.Drawing.Size(984, 90);
            this.top_Panel.TabIndex = 0;
            // 
            // button_Scan
            // 
            this.button_Scan.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Scan.FlatAppearance.BorderSize = 0;
            this.button_Scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Scan.ForeColor = System.Drawing.Color.White;
            this.button_Scan.Location = new System.Drawing.Point(134, 0);
            this.button_Scan.Name = "button_Scan";
            this.button_Scan.Size = new System.Drawing.Size(134, 90);
            this.button_Scan.TabIndex = 5;
            this.button_Scan.Text = "검사하기";
            this.button_Scan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Scan.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KSJr.Properties.Resources.캡처;
            this.pictureBox1.Location = new System.Drawing.Point(351, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 64);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button_Result
            // 
            this.button_Result.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Result.FlatAppearance.BorderSize = 0;
            this.button_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Result.ForeColor = System.Drawing.Color.White;
            this.button_Result.Location = new System.Drawing.Point(850, 0);
            this.button_Result.Name = "button_Result";
            this.button_Result.Size = new System.Drawing.Size(134, 90);
            this.button_Result.TabIndex = 3;
            this.button_Result.Text = "치료하기";
            this.button_Result.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Result.UseVisualStyleBackColor = true;
            this.button_Result.Click += new System.EventHandler(this.button_result_Click);
            // 
            // button_Search
            // 
            this.button_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Search.FlatAppearance.BorderSize = 0;
            this.button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Search.ForeColor = System.Drawing.Color.White;
            this.button_Search.Location = new System.Drawing.Point(0, 0);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(134, 90);
            this.button_Search.TabIndex = 0;
            this.button_Search.Text = "폴더검색";
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // textBox_test
            // 
            this.textBox_test.Location = new System.Drawing.Point(821, 32);
            this.textBox_test.Name = "textBox_test";
            this.textBox_test.Size = new System.Drawing.Size(100, 26);
            this.textBox_test.TabIndex = 2;
            this.textBox_test.Text = "테스트용";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(711, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "테스트용";
            // 
            // shadowPanel1
            // 
            this.shadowPanel1.BorderColor = System.Drawing.Color.Empty;
            this.shadowPanel1.Controls.Add(this.label1);
            this.shadowPanel1.Controls.Add(this.textBox_test);
            this.shadowPanel1.Controls.Add(this.now_label);
            this.shadowPanel1.Controls.Add(this.label2);
            this.shadowPanel1.Controls.Add(this.list_View);
            this.shadowPanel1.Location = new System.Drawing.Point(12, 96);
            this.shadowPanel1.Name = "shadowPanel1";
            this.shadowPanel1.PanelColor = System.Drawing.Color.Empty;
            this.shadowPanel1.Size = new System.Drawing.Size(960, 453);
            this.shadowPanel1.TabIndex = 1;
            // 
            // now_label
            // 
            this.now_label.Location = new System.Drawing.Point(20, 36);
            this.now_label.Name = "now_label";
            this.now_label.Size = new System.Drawing.Size(82, 19);
            this.now_label.TabIndex = 2;
            this.now_label.Text = "스캔시간 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "파일 리스트";
            // 
            // list_View
            // 
            this.list_View.GridLines = true;
            this.list_View.HideSelection = false;
            this.list_View.Location = new System.Drawing.Point(9, 88);
            this.list_View.Name = "list_View";
            this.list_View.Size = new System.Drawing.Size(940, 350);
            this.list_View.TabIndex = 0;
            this.list_View.UseCompatibleStateImageBehavior = false;
            this.list_View.View = System.Windows.Forms.View.Details;
            // 
            // form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.shadowPanel1);
            this.Controls.Add(this.top_Panel);
            this.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K S A I V";
            this.top_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.shadowPanel1.ResumeLayout(false);
            this.shadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_Panel;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView list_View;
        private System.Windows.Forms.Label now_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_test;
        private System.Windows.Forms.Button button_Result;
        private ShadowPanel.ShadowPanel shadowPanel1;
        private System.Windows.Forms.FolderBrowserDialog folderBD;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Scan;
    }
}

