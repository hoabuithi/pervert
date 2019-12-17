namespace BTL {
    partial class TaoDonHang_Form {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaoDonHang_Form));
            this.taoBTN = new System.Windows.Forms.Button();
            this.matHangView = new System.Windows.Forms.DataGridView();
            this.chiTietDHView = new System.Windows.Forms.DataGridView();
            this.maHangCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenHangCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.themBTN = new System.Windows.Forms.Button();
            this.xoaBTN = new System.Windows.Forms.Button();
            this.huyBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timKiemTB = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.matHangView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiTietDHView)).BeginInit();
            this.SuspendLayout();
            // 
            // taoBTN
            // 
            this.taoBTN.Location = new System.Drawing.Point(189, 370);
            this.taoBTN.Name = "taoBTN";
            this.taoBTN.Size = new System.Drawing.Size(103, 37);
            this.taoBTN.TabIndex = 0;
            this.taoBTN.Text = "Tạo";
            this.taoBTN.UseVisualStyleBackColor = true;
            this.taoBTN.Click += new System.EventHandler(this.taoBTN_Click);
            // 
            // matHangView
            // 
            this.matHangView.AllowUserToOrderColumns = true;
            this.matHangView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matHangView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.matHangView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.matHangView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matHangView.Location = new System.Drawing.Point(12, 57);
            this.matHangView.MultiSelect = false;
            this.matHangView.Name = "matHangView";
            this.matHangView.ReadOnly = true;
            this.matHangView.RowHeadersWidth = 51;
            this.matHangView.RowTemplate.Height = 24;
            this.matHangView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.matHangView.Size = new System.Drawing.Size(534, 307);
            this.matHangView.TabIndex = 24;
            // 
            // chiTietDHView
            // 
            this.chiTietDHView.AllowUserToOrderColumns = true;
            this.chiTietDHView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chiTietDHView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chiTietDHView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.chiTietDHView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chiTietDHView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHangCol,
            this.tenHangCol,
            this.soLuongCol});
            this.chiTietDHView.Location = new System.Drawing.Point(623, 57);
            this.chiTietDHView.MultiSelect = false;
            this.chiTietDHView.Name = "chiTietDHView";
            this.chiTietDHView.RowHeadersWidth = 51;
            this.chiTietDHView.RowTemplate.Height = 24;
            this.chiTietDHView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chiTietDHView.Size = new System.Drawing.Size(455, 303);
            this.chiTietDHView.TabIndex = 25;
            // 
            // maHangCol
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.maHangCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.maHangCol.HeaderText = "Mã Hàng";
            this.maHangCol.MinimumWidth = 6;
            this.maHangCol.Name = "maHangCol";
            this.maHangCol.ReadOnly = true;
            // 
            // tenHangCol
            // 
            this.tenHangCol.HeaderText = "Tên Hàng";
            this.tenHangCol.MinimumWidth = 6;
            this.tenHangCol.Name = "tenHangCol";
            this.tenHangCol.ReadOnly = true;
            // 
            // soLuongCol
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.soLuongCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.soLuongCol.HeaderText = "Nhập Số Lượng";
            this.soLuongCol.MinimumWidth = 6;
            this.soLuongCol.Name = "soLuongCol";
            // 
            // themBTN
            // 
            this.themBTN.FlatAppearance.BorderSize = 0;
            this.themBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themBTN.Image = ((System.Drawing.Image)(resources.GetObject("themBTN.Image")));
            this.themBTN.Location = new System.Drawing.Point(554, 112);
            this.themBTN.Name = "themBTN";
            this.themBTN.Size = new System.Drawing.Size(63, 66);
            this.themBTN.TabIndex = 28;
            this.themBTN.UseVisualStyleBackColor = true;
            this.themBTN.Click += new System.EventHandler(this.themBTN_Click);
            // 
            // xoaBTN
            // 
            this.xoaBTN.FlatAppearance.BorderSize = 0;
            this.xoaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xoaBTN.Image = ((System.Drawing.Image)(resources.GetObject("xoaBTN.Image")));
            this.xoaBTN.Location = new System.Drawing.Point(552, 213);
            this.xoaBTN.Name = "xoaBTN";
            this.xoaBTN.Size = new System.Drawing.Size(63, 65);
            this.xoaBTN.TabIndex = 29;
            this.xoaBTN.UseVisualStyleBackColor = true;
            this.xoaBTN.Click += new System.EventHandler(this.xoaBTN_Click);
            // 
            // huyBTN
            // 
            this.huyBTN.Location = new System.Drawing.Point(723, 370);
            this.huyBTN.Name = "huyBTN";
            this.huyBTN.Size = new System.Drawing.Size(103, 37);
            this.huyBTN.TabIndex = 30;
            this.huyBTN.Text = "Huỷ";
            this.huyBTN.UseVisualStyleBackColor = true;
            this.huyBTN.Click += new System.EventHandler(this.huyBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Mặt Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(620, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Chi Tiết";
            // 
            // timKiemTB
            // 
            this.timKiemTB.Location = new System.Drawing.Point(388, 29);
            this.timKiemTB.Name = "timKiemTB";
            this.timKiemTB.Size = new System.Drawing.Size(158, 22);
            this.timKiemTB.TabIndex = 33;
            this.toolTip1.SetToolTip(this.timKiemTB, "Nhập Tên Hàng");
            this.timKiemTB.TextChanged += new System.EventHandler(this.timKiemTB_TextChanged);
            this.timKiemTB.Enter += new System.EventHandler(this.timKiemTB_Enter);
            // 
            // TaoDonHang_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 419);
            this.Controls.Add(this.timKiemTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.huyBTN);
            this.Controls.Add(this.xoaBTN);
            this.Controls.Add(this.themBTN);
            this.Controls.Add(this.chiTietDHView);
            this.Controls.Add(this.matHangView);
            this.Controls.Add(this.taoBTN);
            this.Name = "TaoDonHang_Form";
            this.Text = "TaoDonHang_Form";
            this.Load += new System.EventHandler(this.TaoDonHang_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.matHangView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiTietDHView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button taoBTN;
        private System.Windows.Forms.DataGridView matHangView;
        private System.Windows.Forms.DataGridView chiTietDHView;
        private System.Windows.Forms.Button themBTN;
        private System.Windows.Forms.Button xoaBTN;
        private System.Windows.Forms.Button huyBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHangCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenHangCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongCol;
        private System.Windows.Forms.TextBox timKiemTB;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}