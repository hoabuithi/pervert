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
    public partial class TaoMatHang_Form : Form {
        SqlConnection connect;
        SqlDataAdapter dataAdapter;
        SqlCommand cmd;
        string query;
        string connectString = @"Data Source=LAPTOP-VNHKSCCG\SQLEXPRESS;Initial Catalog=CuaHangTapPham;Integrated Security=True";
        public TaoMatHang_Form()
        {
            connect = new SqlConnection(connectString);
            InitializeComponent();
        }
        void UpdateComboBox()
        {
            DataSet dataSet = new DataSet();
            query = "Select * From dbo.LoaiHang";
            dataAdapter = new SqlDataAdapter(query, connect);
            dataAdapter.Fill(dataSet, "LoaiHang");

            loaiCB.DisplayMember = "tenLoai";
            loaiCB.ValueMember = "maLoai";
            loaiCB.DataSource = dataSet.Tables["LoaiHang"];
        }

        private void huyBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void taoMoiBTN_Click(object sender, EventArgs e)
        {
            switch (taoMoiBTN.Text)
            {
                case "Tạo Hàng":
                    query = "exec sp_ThemMatHang @tenHang, @soLuong, " +
                                                "@giaBan, @giaNhap, @maLoai";
                    ThaoTac(query);
                    break;
                case "Sửa Hàng":
                    query = "exec sp_SuaMatHang @maHang, @tenHang, @soLuong, @giaBan," +
                                              " @giaNhap, @maLoai";
                    ThaoTac(query);
                    break;
            }
        }
        void ThaoTac(string query)
        {
            cmd = new SqlCommand(query, connect);
            try
            {
                cmd.Parameters.Add("@maHang", SqlDbType.Int).Value = GiaoDien_UI.maHang;
                cmd.Parameters.Add("@tenHang", SqlDbType.NVarChar, 100).Value = tenHangTB.Text;
                cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = int.Parse(sluongTB.Text);
                cmd.Parameters.Add("@giaBan", SqlDbType.BigInt).Value = int.Parse(giaBanTB.Text);
                cmd.Parameters.Add("@giaNhap", SqlDbType.BigInt).Value = int.Parse(giaNhapTB.Text);
                cmd.Parameters.Add("@maLoai", SqlDbType.TinyInt).Value = int.Parse(loaiCB.SelectedValue.ToString().Replace(" ", string.Empty));
                connect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thao tác thành công");
                connect.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void LayDataDeSua()
        {
            DataTable table = new DataTable();
            query = "Select tenHang, soLuong, giaBan, giaNhap, tenLoai " +
                    "From view_MatHang " +
                    "Where maHang = " + GiaoDien_UI.maHang;
            dataAdapter = new SqlDataAdapter(query, connect);
            dataAdapter.Fill(table);

            tenHangTB.Text = table.Rows[0][0].ToString();
            sluongTB.Text = table.Rows[0][1].ToString();
            giaBanTB.Text = table.Rows[0][2].ToString();
            giaNhapTB.Text = table.Rows[0][3].ToString();
            loaiCB.Text = table.Rows[0][4].ToString();
        }
        private void taoLoaiHangLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TaoLoaiHang_Form form = new TaoLoaiHang_Form();
            form.Show();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateComboBox();
        }
        private void TaoMatHang_Form_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
            switch (GiaoDien_UI.hangValue)
            {
                case 0:
                    taoMoiBTN.Text = "Tạo Hàng";
                    this.Text = "Tạo Mặt Hàng";
                    break;
                case 1:
                    taoMoiBTN.Text = "Sửa Hàng";
                    this.Text = "Sửa Mặt Hàng";
                    LayDataDeSua();
                    break;
            }
        }
    }
}
