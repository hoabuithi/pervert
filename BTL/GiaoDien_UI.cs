using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL {
    public partial class GiaoDien_UI : Form {
        DataTable table;
        SqlDataAdapter dataAdapter;
        SqlConnection connect;
        SqlCommand cmd;
        string query;
        string connectString = @"Data Source=LAPTOP-VNHKSCCG\SQLEXPRESS;Initial Catalog=CuaHangTapPham;Integrated Security=True";
        public static int hangValue { get; set; }
        public static int maHang { get; set; }
        public static int donHangValue { get; set; }
        public static int maNV = Login_Form.id;
        public static int maDH { get; set; }
        public GiaoDien_UI()
        {
            connect = new SqlConnection(connectString);
            InitializeComponent();
            if(Login_Form.id == 1)
            {
                thongKeGBox.Visible = true;
            }
            UpdateDonHangView();
            UpdateMatHangView();
            UpdateNhanVienView();
        }

// Nhập data vào các bảng (update)
        void UpdateDonHangView(string query = 
                                "Select maDH as N'Mã Đơn Hàng'," +
                                      " ngayTao as N'Ngày Tạo'," +
                                      " hoTen as N'Nhân Viên Phụ Trách' " +
                                "From view_DonHang")
        {
            table = new DataTable();
            try
            {
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                donHangView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void UpdateChiTietDHView()
        {
            int a = getMaDH();
            table = new DataTable();
            query = "exec sp_ChiTietDH " + getMaDH();
            try
            {
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                chiTietDHView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void UpdateNhanVienView()
        {
            try
            {
                table = new DataTable();
                query = "select * from view_NhanVien where manv = " + Login_Form.id;
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                nv_maNVLabel.Text = table.Rows[0][0].ToString();
                nv_hoTenTB.Text = table.Rows[0][1].ToString();
                nv_phoneTB.Text = table.Rows[0][2].ToString();
                nv_idLabel.Text = table.Rows[0][3].ToString();
                nv_diaChiTB.Text = table.Rows[0][4].ToString();
                nv_ngaySinhTB.Text = table.Rows[0][5].ToString();
                if (Convert.ToInt32(table.Rows[0][6]) == 1)
                    nv_namRBTN.Select();
                else nv_nuRBTN.Select();
                nv_luongLabel.Text = table.Rows[0][7].ToString();
                nv_chucVuLabel.Text = table.Rows[0][8].ToString();
                nv_usernameLabel.Text = table.Rows[0][9].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void UpdateMatHangView(string query = 
                                "select maHang as N'Mã Hàng'," +
                                      " tenHang as N'Tên Hàng'," +
                                      " soLuong as N'Số Lượng'," +
                                      " giaBan as N'Giá Niêm Yết'," +
                                      " tenLoai as N'Phân Loại'" +
                                "from view_MatHang")
        {
            table = new DataTable();
            try
            {
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                matHangView.DataSource = table;
            }
            catch (Exception)
            {

            }
        }

/// <summary> Mặt Hàng View
    /// Thêm, xoá, sửa, cập nhật
    /// Tìm kiếm theo tên mặt hàng
/// </summary>
        int getMaHang()
        {
            int index = matHangView.SelectedCells[0].RowIndex;
            DataGridViewRow row = matHangView.Rows[index];
            return Convert.ToInt32(row.Cells[0].Value);
        }
        private void mh_createBTN_Click(object sender, EventArgs e)
        {
            hangValue = 0;
            TaoMatHang_Form form = new TaoMatHang_Form();
            form.Show();
        }
        private void mh_editBTN_Click(object sender, EventArgs e)
        {
            hangValue = 1;
            maHang = getMaHang();
            TaoMatHang_Form form = new TaoMatHang_Form();
            form.Show();
        }
        private void mh_deleteBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xoá mặt hàng này?", "Xoá", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.OK:
                    XoaMatHang();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        void XoaMatHang()
        {
            query = "delete from MatHang where maHang = @ID";
            cmd = new SqlCommand(query, connect);
            connect.Open();
            try
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = getMaHang();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            connect.Close();
            UpdateMatHangView();
        }
        private void mh_searchTB_TextChanged(object sender, EventArgs e)
        {
            if (mh_searchTB.Text.Equals(""))
            {
                UpdateMatHangView();
            }
            else
            {
                query = "select maHang as N'Mã Hàng'," +
                                      " tenHang as N'Tên Hàng'," +
                                      " soLuong as N'Số Lượng'," +
                                      " giaBan as N'Giá Niêm Yết'," +
                                      " tenLoai as N'Phân Loại' " +
                                "from view_MatHang " +
                                "where tenHang like N'%" + mh_searchTB.Text + "%'";
                UpdateMatHangView(query);
            }
        }
        private void mh_searchTB_Click(object sender, EventArgs e)
        {
            mh_searchTB.Text = "";
        }
        private void mh_refreshBTN_Click(object sender, EventArgs e)
        {
            UpdateMatHangView();
        }

/// <summary>Thống Kê View
    /// Thống kê tổng hợp
/// </summary>
        private void mh_startBTN_Click(object sender, EventArgs e)
        {
            table = new DataTable();
            switch (mh_thongKeCB.Text)
            {
                case "Top 10 mặt hàng bán chạy nhất":
                    query = "select * from view_topHangBanChay order by [Số lượng đã bán] desc";
                    break;
                case "Mặt hàng chưa có người mua":
                    query = "select * from view_matHangChuaAiMua";
                    break;
                case "Tổng số đơn hàng theo tháng":
                    query = "select * from view_tongDHTheoThang";
                    break;
                case "Lãi gộp từng tháng":
                    query = "select * from view_laiGopHangThang";
                    break;
                case "Doanh thu từng tháng":
                    query = "select * from view_doanhThuHangThang";
                    break;
            }
            try
            {
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                thongKeView.DataSource = table;
                thongBaoKhongCoData(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void thongBaoKhongCoData(DataTable table)
        {
            try
            {
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }


/// <summary> Đơn Hàng View
    /// Thêm, xoá , sửa, cập nhật
    /// Tìm kiếm theo mã
    /// Tính tổng tiền, tiền thừa
/// </summary>
        private void dh_createBTN_Click(object sender, EventArgs e)
        {
            donHangValue = 0;
            TaoDonHang_Form form = new TaoDonHang_Form();
            try
            {
                form.Show();
            }
            catch (Exception)
            {
                //throw;
            }

        }
        private void dh_editBTN_Click(object sender, EventArgs e)
        {
            donHangValue = 1;
            maDH = getMaDH();
            TaoDonHang_Form form = new TaoDonHang_Form();
            form.Show();
        }
        private void dh_deleteBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xoá đơn hàng này?", "Xoá", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.OK:
                    XoaDonHang();
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        void XoaDonHang()
        {
            query = "delete from DonHang where maDH = @ma";
            cmd = new SqlCommand(query, connect);
            connect.Open();
            try
            {
                cmd.Parameters.Add("@ma", SqlDbType.Int).Value = getMaDH();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            connect.Close();
            UpdateDonHangView();
            chiTietDHView.DataSource = null;
        }
        int getMaDH()
        {
            int index = donHangView.SelectedCells[0].RowIndex;
            DataGridViewRow row = donHangView.Rows[index];
            try
            {
                return Convert.ToInt32(row.Cells[0].Value);
            }
            catch (InvalidCastException) { }
            return 0;
        }
        private void dh_refreshBTN_Click(object sender, EventArgs e)
        {
            UpdateDonHangView();
            chiTietDHView.DataSource = null;
            dh_tongLabel.Text = "";
        }
        int HienThiThanhTien()
        {
            try
            {
                table = new DataTable();
                query = "select dbo.func_thanhTien(" + getMaDH() + ")";
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                dh_tongLabel.Text = table.Rows[0][0].ToString() + " VNĐ";
                return Convert.ToInt32(table.Rows[0][0].ToString());
            }
            catch (Exception)
            {
            }
            return -1;
        }
        private void donHangView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateChiTietDHView();
            HienThiThanhTien();
        }
        private void dh_tienKhachDuaTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int soTien = Convert.ToInt32(dh_tienKhachDuaTB.Text);
                table = new DataTable();
                query = "select dbo.func_tinhTienThua(" +
                            getMaDH() + ", " +
                            soTien + ") ";
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                int tienThua = Convert.ToInt32(table.Rows[0][0]);
                if (soTien < HienThiThanhTien())
                {
                    dh_traLaiLabel.Text = "Còn Thiếu: ";
                    dh_tienThuaLabel.Text = (tienThua).ToString() + " VNĐ";
                }
                else
                {
                    dh_traLaiLabel.Text = "Trả lại: ";
                    dh_tienThuaLabel.Text = (tienThua * -1).ToString() + " VNĐ";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void dh_searchTB_TextChanged(object sender, EventArgs e)
        {
            if (dh_searchTB.Text.Equals(""))
            {
                UpdateDonHangView();
            }
            else
            {
                query = "Select maDH as N'Mã Đơn Hàng'," +
                          " ngayTao as N'Ngày Tạo'," +
                          " hoTen as N'Nhân Viên Phụ Trách' " +
                    "From view_DonHang " +
                    "Where maDH = " + dh_searchTB.Text;
                UpdateDonHangView(query);
            }
        }
        private void dh_searchTB_Click(object sender, EventArgs e)
        {
            dh_searchTB.Text = "";
        }

/// <summary> Nhân Viên View
    /// Sửa thông tin
    /// Đổi mật khẩu
/// </summary>
        private void nv_suaBTN_Click(object sender, EventArgs e)
        {
            if(nv_suaBTN.Text.Equals("Sửa Thông Tin"))
            {
                choPhepSuaNV(true);
                nv_suaBTN.Text = "Lưu Thông Tin";
            }
            else
            {
                suaThongTinNhanVien();
                nv_suaBTN.Text = "Sửa Thông Tin";
                UpdateNhanVienView();
                choPhepSuaNV(false);
            }
        }
        void suaThongTinNhanVien()
        {
            string hoTen = nv_hoTenTB.Text;
            string ngaySinh = nv_ngaySinhTB.Text;
            string phone = nv_phoneTB.Text;
            string diaChi = nv_diaChiTB.Text;
            short gTinh;
            if (nv_namRBTN.Checked) gTinh = 1;
            else gTinh = 0;
            query = "exec sp_doiTTNhanVien @maNV, " +
                                          "@hoTen, " +
			                              "@phone, " +
			                              "@diaChi, " +
			                              "@ngaySinh," +
                                          "@gTinh";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add("@maNV", SqlDbType.TinyInt).Value = Login_Form.id;
            cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 50).Value = hoTen;
            cmd.Parameters.Add("@phone", SqlDbType.Char, 15).Value = phone;
            cmd.Parameters.Add("@diaChi", SqlDbType.NVarChar, 200).Value = diaChi;
            cmd.Parameters.Add("@gTinh", SqlDbType.Bit).Value = gTinh;
            cmd.Parameters.Add("@ngaySinh", SqlDbType.Date).Value = ngaySinh;
            connect.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            connect.Close();
        }
        void choPhepSuaNV(bool ok)
        {
            nv_phoneTB.ReadOnly = !ok;
            nv_nuRBTN.Enabled = ok;
            nv_namRBTN.Enabled = ok;
            nv_ngaySinhTB.ReadOnly = !ok;
            nv_hoTenTB.ReadOnly = !ok;
            nv_diaChiTB.ReadOnly = !ok;
        }
        private void nv_doiPassBTN_Click(object sender, EventArgs e)
        {
            DoiMatKhau_Form doiPass = new DoiMatKhau_Form();
            doiPass.Show();
        }
// Đóng Form
        private void GiaoDien_UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            connect.Close();
            Dispose();
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                this.mh_refreshBTN.PerformClick();
                this.dh_refreshBTN.PerformClick();
            }
        }
    }
}
