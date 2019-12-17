namespace BTL {
    partial class DoiMatKhau_Form {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau_Form));
            this.xacNhanBTN = new System.Windows.Forms.Button();
            this.mkCuTB = new System.Windows.Forms.TextBox();
            this.mkMoiTB = new System.Windows.Forms.TextBox();
            this.nhapLaiTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.huyBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xacNhanBTN
            // 
            this.xacNhanBTN.Location = new System.Drawing.Point(33, 237);
            this.xacNhanBTN.Name = "xacNhanBTN";
            this.xacNhanBTN.Size = new System.Drawing.Size(119, 34);
            this.xacNhanBTN.TabIndex = 0;
            this.xacNhanBTN.Text = "Xác Nhận";
            this.xacNhanBTN.UseVisualStyleBackColor = true;
            this.xacNhanBTN.Click += new System.EventHandler(this.xacNhanBTN_Click);
            // 
            // mkCuTB
            // 
            this.mkCuTB.Location = new System.Drawing.Point(151, 43);
            this.mkCuTB.Name = "mkCuTB";
            this.mkCuTB.Size = new System.Drawing.Size(224, 22);
            this.mkCuTB.TabIndex = 1;
            this.mkCuTB.UseSystemPasswordChar = true;
            // 
            // mkMoiTB
            // 
            this.mkMoiTB.Location = new System.Drawing.Point(151, 98);
            this.mkMoiTB.Name = "mkMoiTB";
            this.mkMoiTB.Size = new System.Drawing.Size(224, 22);
            this.mkMoiTB.TabIndex = 2;
            this.mkMoiTB.UseSystemPasswordChar = true;
            // 
            // nhapLaiTB
            // 
            this.nhapLaiTB.Location = new System.Drawing.Point(151, 155);
            this.nhapLaiTB.Name = "nhapLaiTB";
            this.nhapLaiTB.Size = new System.Drawing.Size(224, 22);
            this.nhapLaiTB.TabIndex = 3;
            this.nhapLaiTB.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mật khẩu hiện tại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nhập lại mật khẩu";
            // 
            // huyBTN
            // 
            this.huyBTN.Location = new System.Drawing.Point(207, 237);
            this.huyBTN.Name = "huyBTN";
            this.huyBTN.Size = new System.Drawing.Size(119, 34);
            this.huyBTN.TabIndex = 7;
            this.huyBTN.Text = "Huỷ";
            this.huyBTN.UseVisualStyleBackColor = true;
            this.huyBTN.Click += new System.EventHandler(this.huyBTN_Click);
            // 
            // DoiMatKhau_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 311);
            this.Controls.Add(this.huyBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nhapLaiTB);
            this.Controls.Add(this.mkMoiTB);
            this.Controls.Add(this.mkCuTB);
            this.Controls.Add(this.xacNhanBTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DoiMatKhau_Form";
            this.Text = "Đổi Mật Khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button xacNhanBTN;
        private System.Windows.Forms.TextBox mkCuTB;
        private System.Windows.Forms.TextBox mkMoiTB;
        private System.Windows.Forms.TextBox nhapLaiTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button huyBTN;
    }
}