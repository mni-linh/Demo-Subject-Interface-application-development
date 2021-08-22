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

namespace PhatTrienUngDungGiaoDien
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnCheckOldPwd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string usr = LoginForm.usr;
            string pwd = tbOldPwd.Text;
            if (LoginForm.numLogin == 1)
            {
                cmd = new SqlCommand("SELECT Student.id as accId, password FROM Student WHERE Student.id = '" + usr + "'AND password='" + pwd + "'", con);            
            }
            else if (LoginForm.numLogin == 2)
            {
                cmd = new SqlCommand("SELECT Teacher.id as accId, password FROM Teacher WHERE Teacher.id = '" + usr + "'and password='" + pwd + "'", con);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Đúng mật khẩu");
                pnlChangePwd.Visible = true;
                btnCheckOldPwd.Hide();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
            }
            dr.Close();
            con.Close();
        }

        public void ExcuteNonQuery(string commandText)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            string queryStr;
            if (tbNewPwd.Text.Equals(tbNewPwdConfirm.Text))
            {
                if (LoginForm.numLogin == 1)
                {
                    queryStr = @"UPDATE Student SET password = '" + tbNewPwd.Text + "' WHERE id = '"+ LoginForm.usr +"'";
                }
                else
                {
                    queryStr = @"UPDATE Teacher SET password = '" + tbNewPwd.Text + "' WHERE id = '" + LoginForm.usr + "'";
                }
                ExcuteNonQuery(queryStr);
                MessageBox.Show("Đổi mật khẩu thành công");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mật khẩu và mật khẩu xác nhận không trùng khớp");
            }
        }
    }
}
