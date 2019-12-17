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
    public partial class TaoDonHang_Form : Form {
        SqlConnection connect;
        SqlCommand cmd;
        DataTable table;
        SqlDataAdapter dataAdapter;
        string query;
        string connectString = @"Data Source=LAPTOP-VNHKSCCG\SQLEXPRESS;Initial Catalog=CuaHangTapPham;Integrated Security=True";

        public TaoDonHang_Form()
        {
            InitializeComponent();
            connect = new SqlConnection(connectString);
            UpdateMatHangView();
        }
        int getMaHang()
        {
            int index = matHangView.SelectedCells[0].RowIndex;
            DataGridViewRow row = matHangView.Rows[index];
            return Convert.ToInt32(row.Cells[0].Value);
        }
        string getTenHang()
        {
            int index = matHangView.SelectedCells[0].RowIndex;
            DataGridViewRow row = matHangView.Rows[index];
            return row.Cells[1].Value.ToString();
        }
        void ThemDonHang()
        {
            query = "exec sp_ThemDonHang @maNV";
            cmd = new SqlCommand(query, connect);
            try
            {
                cmd.Parameters.Add("@maNV", SqlDbType.TinyInt).Value = GiaoDien_UI.maNV;
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void LayDataChiTietDH()
        {
            DataTable table = new DataTable();
            query = "select * from func_dataChiTietDH(" + GiaoDien_UI.maDH +")";
            try
            {
                dataAdapter = new SqlDataAdapter(query, connect);
                dataAdapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    chiTietDHView.Rows.Add(row[0].ToString(),
                        row[1].ToString(), row[2].ToString());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void UpdateMatHangView(string query = "select maHang as N'Mã Hàng'," +
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
                throw;
            }
        }
        private void TaoDonHang_Form_Load(object sender, EventArgs e)
        {
            switch (GiaoDien_UI.donHangValue)
            {
                case 0:
                    taoBTN.Text = "Tạo Đơn";
                    this.Text = "Tạo Đơn Hàng";
                    break;
                case 1:
                    LayDataChiTietDH();
                    taoBTN.Text = "Sửa Đơn";
                    this.Text = "Sửa Đơn Hàng Mã: " + GiaoDien_UI.maDH;
                    break;
            }
        }
        private void taoBTN_Click(object sender, EventArgs e)
        {
            if (taoBTN.Text.Equals("Tạo Đơn"))
            {
                ThemDonHang();
                InsertVaoDatabase();
            }
            if (taoBTN.Text.Equals("Sửa Đơn"))
            {
                XoaChiTiet();
                InsertVaoDatabase();
            }
        }
        private void huyBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void themBTN_Click(object sender, EventArgs e)
        {
            chiTietDHView.Rows.Add(getMaHang(), getTenHang(), 1);
            matHangView.Rows.RemoveAt(matHangView.SelectedCells[0].RowIndex);
        }
        void InsertVaoDatabase()
        {
            chiTietDHView.Rows.Insert(0, new string[] {"1", "Data2", "1" });
            chiTietDHView.FirstDisplayedCell = chiTietDHView[0, 1];
            connect.Open();
            foreach (DataGridViewRow row in chiTietDHView.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    cmd = new SqlCommand(query, connect);
                    if (taoBTN.Text.Equals("Tạo Đơn"))
                    {
                        query = "exec sp_ThemChiTietDH @maH, @soL";
                        try
                        {
                            cmd.Parameters.Add("@maNV", SqlDbType.Int).Value = "1";

                            cmd.Parameters.Add("@maH", SqlDbType.Int).Value = row.Cells[0].Value;
                            cmd.Parameters.Add("@soL", SqlDbType.Int).Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                            //MessageBox.Show(ex.StackTrace);
                        }
                    }
                    else
                    {
                        query = "exec sp_SuaChiTietDH @maDH, @maH, @soLuong";
                        try
                        {
                            cmd.Parameters.Add("@maDH", SqlDbType.BigInt).Value = GiaoDien_UI.maDH;
                            cmd.Parameters.Add("@maH", SqlDbType.Int).Value = row.Cells[0].Value;
                            cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = row.Cells[2].Value;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    } 
                }
            }
            chiTietDHView.DataSource = null;
            MessageBox.Show("Thao tác thành công");
            connect.Close();
            this.Dispose();
        }
        void XoaChiTiet()
        {
            query = "exec sp_XoaChiTiet @maDH";
            connect.Open();
            cmd = new SqlCommand(query, connect);
            try
            {
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add("@maDH", SqlDbType.BigInt).Value = GiaoDien_UI.maDH;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connect.Close();
        }
        private void xoaBTN_Click(object sender, EventArgs e)
        {
            try
            {
                chiTietDHView.Rows.RemoveAt(chiTietDHView.SelectedCells[0].RowIndex);
            }
            catch (Exception){}
            UpdateMatHangView();
        }

        private void timKiemTB_TextChanged(object sender, EventArgs e)
        {
            if (timKiemTB.Text.Equals(""))
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
                                "where tenHang like N'%" + timKiemTB.Text + "%'";
                UpdateMatHangView(query);
            }
            //MessageBox.Show("Text");
        }

        private void timKiemTB_Enter(object sender, EventArgs e)
        {
            timKiemTB.Text = "";
        }
    }
}
