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
    public partial class Login_Form : Form {
        public static short id { get; set; }
        SqlDataAdapter dataAdapter;
        SqlConnection connect;
        SqlCommand cmd;
        DataTable table;
        string connectString = @"Data Source=LAPTOP-VNHKSCCG\SQLEXPRESS;Initial Catalog=CuaHangTapPham;Integrated Security=True";
        public Login_Form()
        {
            InitializeComponent();
        }
        private void loginBTN_Click(object sender, EventArgs e)
        {
            try
            {
                connect = new SqlConnection(connectString);
                string query = "exec sp_Login @user, @password";
                cmd = new SqlCommand(query, connect);
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = userTB.Text;
                cmd.Parameters.Add("@password", SqlDbType.Char, 50).Value = passwordTB.Text;
                connect.Open();
                cmd.ExecuteNonQuery();
                dataAdapter = new SqlDataAdapter(cmd);
                table = new DataTable();
                dataAdapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    // Gán mã user cho form giao diện, hiển thị rồi đóng form đăng nhập
                    id = Convert.ToInt16(table.Rows[0][0]);
                    GiaoDien_UI ui = new GiaoDien_UI();
                    ui.Show(); 
                    this.Hide();
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại, vui lòng thử lại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
