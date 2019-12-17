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
    public partial class TaoLoaiHang_Form : Form {
        SqlCommand cmd;
        SqlConnection connect;
        string query;
        string connectString = @"Data Source=LAPTOP-VNHKSCCG\SQLEXPRESS;Initial Catalog=CuaHangTapPham;Integrated Security=True";
        public TaoLoaiHang_Form()
        {
            connect = new SqlConnection(connectString);
            InitializeComponent();
        }

        private void huyBTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void taoBTN_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO LoaiHang VALUES (@ten)";
            cmd = new SqlCommand(query, connect);
            try
            {
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 30).Value = tenLoaiTB.Text;
                connect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                this.Dispose();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
