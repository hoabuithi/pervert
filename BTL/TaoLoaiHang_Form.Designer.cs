namespace BTL {
    partial class TaoLoaiHang_Form {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tenLoaiTB = new System.Windows.Forms.TextBox();
            this.taoBTN = new System.Windows.Forms.Button();
            this.huyBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Loại";
            // 
            // tenLoaiTB
            // 
            this.tenLoaiTB.Location = new System.Drawing.Point(98, 29);
            this.tenLoaiTB.Name = "tenLoaiTB";
            this.tenLoaiTB.Size = new System.Drawing.Size(201, 22);
            this.tenLoaiTB.TabIndex = 1;
            // 
            // taoBTN
            // 
            this.taoBTN.Location = new System.Drawing.Point(15, 74);
            this.taoBTN.Name = "taoBTN";
            this.taoBTN.Size = new System.Drawing.Size(104, 33);
            this.taoBTN.TabIndex = 2;
            this.taoBTN.Text = "Tạo";
            this.taoBTN.UseVisualStyleBackColor = true;
            this.taoBTN.Click += new System.EventHandler(this.taoBTN_Click);
            // 
            // huyBTN
            // 
            this.huyBTN.Location = new System.Drawing.Point(195, 74);
            this.huyBTN.Name = "huyBTN";
            this.huyBTN.Size = new System.Drawing.Size(104, 33);
            this.huyBTN.TabIndex = 3;
            this.huyBTN.Text = "Huỷ";
            this.huyBTN.UseVisualStyleBackColor = true;
            this.huyBTN.Click += new System.EventHandler(this.huyBTN_Click);
            // 
            // TaoLoaiHang_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 129);
            this.Controls.Add(this.huyBTN);
            this.Controls.Add(this.taoBTN);
            this.Controls.Add(this.tenLoaiTB);
            this.Controls.Add(this.label1);
            this.Name = "TaoLoaiHang_Form";
            this.Text = "TaoLoaiHang_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tenLoaiTB;
        private System.Windows.Forms.Button taoBTN;
        private System.Windows.Forms.Button huyBTN;
    }
}