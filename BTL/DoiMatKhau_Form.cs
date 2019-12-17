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
    public partial class DoiMatKhau_Form : Form {
        SqlConnection connect;
        SqlCommand cmd;
        string query;
        string connectString = @"Data Source=LAPTOP-VNHKSCCG\SQLEXPRESS;Initial Catalog=CuaHangTapPham;Integrated Security=True";
        public DoiMatKhau_Form()
        {
            connect = new SqlConnection(connectString);
            InitializeComponent();
        }

        private void xacNhanBTN_Click(object sender, EventArgs e)
        {
            string passcu = mkCuTB.Text;
            string passmoi = mkMoiTB.Text;
            string xacnhan = nhapLaiTB.Text;
            if(passmoi == xacnhan && passmoi != "")
            {
                query = "exec sp_doiMK @maNV, @passCu, @passMoi";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add("@maNV", SqlDbType.TinyInt).Value = Login_Form.id;
                cmd.Parameters.Add("@passCu", SqlDbType.Char, 50).Value = passcu;
                cmd.Parameters.Add("@passMoi", SqlDbType.Char, 50).Value = passmoi;
                connect.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Dispose();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không khớp.");
            }
        }
        private void huyBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
