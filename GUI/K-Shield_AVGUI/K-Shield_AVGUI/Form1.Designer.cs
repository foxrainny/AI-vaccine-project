namespace K_Shield_AVGUI
{
    partial class Main_Form
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
            this.file_button = new System.Windows.Forms.Button();
            this.scan_button = new System.Windows.Forms.Button();
            this.result_button = new System.Windows.Forms.Button();
            this.openFileDig = new System.Windows.Forms.OpenFileDialog();
            this.testBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // file_button
            // 
            this.file_button.Location = new System.Drawing.Point(28, 33);
            this.file_button.Name = "file_button";
            this.file_button.Size = new System.Drawing.Size(75, 23);
            this.file_button.TabIndex = 0;
            this.file_button.Text = "폴더 선택";
            this.file_button.UseVisualStyleBackColor = true;
            this.file_button.Click += new System.EventHandler(this.file_button_Click);
            // 
            // scan_button
            // 
            this.scan_button.Location = new System.Drawing.Point(175, 33);
            this.scan_button.Name = "scan_button";
            this.scan_button.Size = new System.Drawing.Size(75, 23);
            this.scan_button.TabIndex = 1;
            this.scan_button.Text = "스캔";
            this.scan_button.UseVisualStyleBackColor = true;
            // 
            // result_button
            // 
            this.result_button.Location = new System.Drawing.Point(95, 82);
            this.result_button.Name = "result_button";
            this.result_button.Size = new System.Drawing.Size(75, 23);
            this.result_button.TabIndex = 2;
            this.result_button.Text = "결과 보기";
            this.result_button.UseVisualStyleBackColor = true;
            // 
            // openFileDig
            // 
            this.openFileDig.FileName = "파일버튼";
            // 
            // testBox
            // 
            this.testBox.Location = new System.Drawing.Point(42, 150);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(100, 21);
            this.testBox.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(42, 210);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(530, 187);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 510);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.testBox);
            this.Controls.Add(this.result_button);
            this.Controls.Add(this.scan_button);
            this.Controls.Add(this.file_button);
            this.Name = "Main_Form";
            this.Text = "KSAIV";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button file_button;
        private System.Windows.Forms.Button scan_button;
        private System.Windows.Forms.Button result_button;
        private System.Windows.Forms.OpenFileDialog openFileDig;
        private System.Windows.Forms.TextBox testBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}

