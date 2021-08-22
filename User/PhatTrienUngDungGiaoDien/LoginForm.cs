using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace PhatTrienUngDungGiaoDien
{
    public partial class LoginForm : Form
    {
        internal static string usr;
        internal static string pwd;
        internal static int numLogin;
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            MainForm mainForm = new MainForm();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
           
            con.Open();
            usr = tbUsr.Text;
            pwd = tbPwd.Text;
            if (rbStudent.Checked)
            {
                numLogin = 1;
                cmd = new SqlCommand("SELECT Student.id as accId, password, fullname, date_of_birth, Student.address as accAddress, Faculty.name as nameFaculty FROM Student, Faculty WHERE id_faculty = Faculty.id AND Student.id = '" + usr + "'AND password='" + pwd + "'", con);
                mainForm.mnPointManage.Visible = false;
            } else if (rbTeacher.Checked)
            {
                numLogin = 2;
                cmd = new SqlCommand("SELECT Teacher.id as accId, password, fullname, date_of_birth, Teacher.address as accAddress, Faculty.name as nameFaculty FROM Teacher, Faculty WHERE id_faculty = Faculty.id AND Teacher.id = '" + usr + "'and password='" + pwd + "'", con);
                mainForm.mnTranscript.Visible = false;
            }
            if (numLogin == 1 || numLogin == 2)
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    foreach (DataRow dr in dt.Rows)
                    {
                        mainForm.lblIdText.Text = dr["accId"].ToString();
                        mainForm.lblNameText.Text = dr["fullname"].ToString();
                        mainForm.lblDOBText.Text = Convert.ToDateTime(dr["date_of_birth"]).ToString("d");
                        mainForm.lblAddressText.Text = dr["accAddress"].ToString();
                        mainForm.lblFacultyText.Text = dr["nameFaculty"].ToString();
                    }
                    mainForm.Show();
                }
                else
                {
                    tbUsr.Text = "";
                    tbPwd.Text = "";
                    MessageBox.Show("Đăng nhập thất bại vui lòng kiểm tra lại tài khoản và mật khẩu");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng đăng nhập");
            }

        }
    }
}
