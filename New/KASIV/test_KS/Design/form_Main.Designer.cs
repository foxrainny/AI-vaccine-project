using ShadowPanel;
using System.Drawing;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.shadowPanel1 = new ShadowPanel.ShadowPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_searchtime = new System.Windows.Forms.Label();
            this.label_fileindex = new System.Windows.Forms.Label();
            this.list_View = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.top_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.shadowPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_Panel
            // 
            this.top_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.top_Panel.Controls.Add(this.pictureBox1);
            this.top_Panel.Controls.Add(this.button_Search);
            this.top_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_Panel.Location = new System.Drawing.Point(0, 0);
            this.top_Panel.Name = "top_Panel";
            this.top_Panel.Size = new System.Drawing.Size(984, 90);
            this.top_Panel.TabIndex = 0;
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
            this.button_Search.Text = "검사";
            this.button_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // shadowPanel1
            // 
            this.shadowPanel1.BorderColor = System.Drawing.Color.Empty;
            this.shadowPanel1.Controls.Add(this.panel1);
            this.shadowPanel1.Controls.Add(this.list_View);
            this.shadowPanel1.Location = new System.Drawing.Point(12, 96);
            this.shadowPanel1.Name = "shadowPanel1";
            this.shadowPanel1.PanelColor = System.Drawing.Color.Empty;
            this.shadowPanel1.Size = new System.Drawing.Size(960, 453);
            this.shadowPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_searchtime);
            this.panel1.Controls.Add(this.label_fileindex);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 52);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(372, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(197, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "파 일 리 스 트";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_searchtime
            // 
            this.label_searchtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_searchtime.Location = new System.Drawing.Point(10, 8);
            this.label_searchtime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label_searchtime.Name = "label_searchtime";
            this.label_searchtime.Padding = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.label_searchtime.Size = new System.Drawing.Size(288, 35);
            this.label_searchtime.TabIndex = 1;
            this.label_searchtime.Text = "검색 시간 :";
            this.label_searchtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_fileindex
            // 
            this.label_fileindex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_fileindex.Location = new System.Drawing.Point(664, 8);
            this.label_fileindex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label_fileindex.Name = "label_fileindex";
            this.label_fileindex.Padding = new System.Windows.Forms.Padding(0, 2, 3, 0);
            this.label_fileindex.Size = new System.Drawing.Size(285, 35);
            this.label_fileindex.TabIndex = 2;
            this.label_fileindex.Text = "파일 갯수 :";
            this.label_fileindex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // list_View
            // 
            this.list_View.GridLines = true;
            this.list_View.HideSelection = false;
            this.list_View.Location = new System.Drawing.Point(9, 58);
            this.list_View.Name = "list_View";
            this.list_View.Size = new System.Drawing.Size(940, 380);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_Panel;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ListView list_View;
        private ShadowPanel.ShadowPanel shadowPanel1;
        private System.Windows.Forms.FolderBrowserDialog folderBD;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_searchtime;
        private System.Windows.Forms.Label label_fileindex;
        private System.Windows.Forms.Label label1;
    }
}

