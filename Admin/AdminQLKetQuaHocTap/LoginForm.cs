using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminQLKetQuaHocTap
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT username, password FROM Admin WHERE username = '"+tbUsr.Text+"' AND password = '"+tbPwd.Text+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                adminForm.Show();
            } else
            {
                tbUsr.Text = "";
                tbPwd.Text = "";
                MessageBox.Show("Đăng nhập thất bại vui lòng kiểm tra lại tài khoản và mật khẩu");
            }
            con.Close();
        }
    }
}
