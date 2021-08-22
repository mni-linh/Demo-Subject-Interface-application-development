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
using System.Timers;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;
using System.Windows.Data;

namespace PhatTrienUngDungGiaoDien
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void mnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void mnInOfAcc_Click(object sender, EventArgs e)
        {
            pnlInOfAcc.Visible = true;
            pnlTranscript.Visible = false;
            pnlPointManage.Visible = false;
        }
        
        private void mnTranscript_Click(object sender, EventArgs e)
        {
            pnlTranscript.Visible = true;
            pnlInOfAcc.Visible = false;
            pnlPointManage.Visible = false;
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, sb.id, sb.name as HocPhan, sr.attendance as DChuyenCan, sr.midterm_score as DGiuaKi, sr.endterm_score as DCuoiKi, sr.average_score as DTB FROM Student s INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id WHERE s.id = '" + lblIdText.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvStudyResults.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvStudyResults.Items.Add(item);
                }
            }
            Average_final();
            con.Close();
            lvStudyResults.Size = new Size(lvStudyResults.Size.Width, lvStudyResults.Items.Count * 27);
            lblAvgScore.Location = new Point(11, lvStudyResults.Size.Height + 60);
            tbFinalAvgScore.Location = new Point(198, lvStudyResults.Size.Height + 60);
            lblHocLuc.Location = new Point(11, lvStudyResults.Size.Height + 90);
            tbHocLuc.Location = new Point(198, lvStudyResults.Size.Height + 90);
        }

        private void mnPointManage_Click(object sender, EventArgs e)
        {
            pnlPointManage.Visible = true;
            pnlInOfAcc.Visible = false;
            pnlTranscript.Visible = false;
            getAllIdSubject();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id INNER JOIN Assignment a ON sb.id = a.id_subject INNER JOIN Teacher t ON a.id_teacher = t.id WHERE t.id = '" + lblIdText.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManagerScore.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManagerScore.Items.Add(item);
                }
            }
            lvManagerScore.Size = new Size(lvManagerScore.Size.Width, lvManagerScore.Items.Count * 27);
            con.Close();
        }
        
        private void lvManagerScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB, sr.attendance as DChuyenCan, sr.midterm_score as DGiuaKi, sr.endterm_score as DCuoiKi FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (lvManagerScore.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvManagerScore.SelectedItems[0];
                    if (item.SubItems[1].Text.Equals(dr.Field<string>("MSSV").ToString()) && item.SubItems[4].Text.Equals(dr.Field<string>("MaHP").ToString()))
                    {
                        tbMSSV.Text = item.SubItems[1].Text;
                        tbName.Text = item.SubItems[2].Text;
                        tbIdFaculty.Text = item.SubItems[3].Text;
                        tbIdSubject.Text = item.SubItems[4].Text;
                        tbNameSubject.Text = item.SubItems[5].Text;
                        tbAvg.Text = item.SubItems[6].Text;
                        tbAttendance.Text = dr.Field<double>("DChuyenCan").ToString();
                        tbMidtermScore.Text = dr.Field<double>("DGiuaKi").ToString();
                        tbEndtermScore.Text = dr.Field<double>("DCuoiKi").ToString();
                    }
                }
                else
                {
                    tbMSSV.Text = string.Empty;
                    tbName.Text = string.Empty;
                    tbIdFaculty.Text = string.Empty;
                    tbIdSubject.Text = string.Empty;
                    tbNameSubject.Text = string.Empty;
                    tbAttendance.Text = string.Empty;
                    tbMidtermScore.Text = string.Empty;
                    tbEndtermScore.Text = string.Empty;
                    tbAvg.Text = string.Empty;
                }
            }
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvManagerScore.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa");
                return;
            }
            string queryString = @"DELETE FROM Study_result
                    WHERE id_subject = '"+ tbIdSubject.Text + "' AND id_student = '"+ tbMSSV.Text + "'";
            ExcuteNonQuery(queryString);
            lvManagerScore.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id INNER JOIN Assignment a ON sb.id = a.id_subject INNER JOIN Teacher t ON a.id_teacher = t.id WHERE t.id = '" + lblIdText.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManagerScore.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManagerScore.Items.Add(item);
                }
            }
            lvManagerScore.Size = new Size(lvManagerScore.Size.Width, lvManagerScore.Items.Count * 27);
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            average_result();
            string queryString = @"UPDATE Study_result SET average_score = {0}, attendance = {1}, midterm_score = {2}, endterm_score = {3} WHERE id_subject = '" + tbIdSubject.Text + "' AND id_student = '" + tbMSSV.Text + "'";
            queryString = string.Format(queryString, Convert.ToDouble(tbAvg.Text), Convert.ToDouble(tbAttendance.Text), Convert.ToDouble(tbMidtermScore.Text), Convert.ToDouble(tbEndtermScore.Text));
            ExcuteNonQuery(queryString);
            lvManagerScore.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id INNER JOIN Assignment a ON sb.id = a.id_subject INNER JOIN Teacher t ON a.id_teacher = t.id WHERE t.id = '" + lblIdText.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManagerScore.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManagerScore.Items.Add(item);
                }
            }
            lvManagerScore.Size = new Size(lvManagerScore.Size.Width, lvManagerScore.Items.Count * 27);
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string queryString = @"INSERT INTO Study_result
                                 VALUES('" + tbIdSubject.Text + "'," + tbMSSV.Text + ",'" + tbAttendance.Text + "','" + tbMidtermScore.Text + "','" + tbEndtermScore.Text + "', '"+tbAvg.Text+"')";
            ExcuteNonQuery(queryString);
            lvManagerScore.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id INNER JOIN Assignment a ON sb.id = a.id_subject INNER JOIN Teacher t ON a.id_teacher = t.id WHERE t.id = '" + lblIdText.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManagerScore.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManagerScore.Items.Add(item);
                }
            }
            lvManagerScore.Size = new Size(lvManagerScore.Size.Width, lvManagerScore.Items.Count * 27);
            con.Close();
        }

        private void average_result()
        {
            tbAvg.Text = (Convert.ToDouble(tbAttendance.Text) * 10 / 100 + Convert.ToDouble(tbMidtermScore.Text) * 40 / 100 + Convert.ToDouble(tbEndtermScore.Text) * 50 / 100).ToString();
        }

        private void getAllIdSubject()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT s.id as MaHP FROM Subject s INNER JOIN Assignment a ON s.id = a.id_subject INNER JOIN Teacher t ON a.id_teacher = t.id WHERE t.id = '" + lblIdText.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataTable newDt = new DataTable();
            newDt.Columns.Add("MaHP");
            newDt.Rows.Add();
            newDt.Rows[0]["MaHP"] = "All";
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                newDt.Rows.Add();
                newDt.Rows[i + 1]["MaHP"] = dt.Rows[i][0].ToString();
            }
            cbIdSubject.DisplayMember = "MaHP";
            cbIdSubject.DataSource = newDt;
            

            con.Close();
        }

        private void Average_final()
        {
            double avg = 0;
            for (int i = 0; i < lvStudyResults.Items.Count; i++)
            {
                avg += Convert.ToDouble(lvStudyResults.Items[i].SubItems[6].Text.ToString()) / lvStudyResults.Items.Count;
            }
            if (avg < 4)
            { tbHocLuc.Text = "Kém"; }
            else if (avg > 4 && avg < 4.9) { tbHocLuc.Text = "Yếu"; }
            else if (avg > 5 && avg < 5.4) { tbHocLuc.Text = "Trung bình yếu"; }
            else if (avg > 5.5 && avg < 6.4) { tbHocLuc.Text = "Trung bình"; }
            else if (avg > 6.5 && avg < 6.9) { tbHocLuc.Text = "Trung bình khá"; }
            else if (avg > 7 && avg < 7.9) { tbHocLuc.Text = "Khá"; }
            else if (avg > 8 && avg < 8.4) { tbHocLuc.Text = "Khá giỏi"; }
            else { tbHocLuc.Text = "Giỏi"; }
            tbFinalAvgScore.Text = Math.Round(Convert.ToDecimal(avg),1).ToString();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            lvManagerScore.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            
            string sl = this.cbIdSubject.GetItemText(this.cbIdSubject.SelectedItem);
            if (sl.Equals("All"))
            {
                cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id INNER JOIN Assignment a ON sb.id = a.id_subject INNER JOIN Teacher t ON a.id_teacher = t.id WHERE t.id = '" + lblIdText.Text + "'", con);
            } else
            {
                if (tbMSSVFilter.Text != "")
                {
                    cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id WHERE sb.id = '" + sl + "' AND s.id = '" + tbMSSVFilter.Text + "'", con);
                }
                else
                {
                    cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY sb.name) as ItemNo, s.id as MSSV, s.fullname as HoTen, f.id as MaKhoa, sb.id as MaHP, sb.name as HocPhan, sr.average_score as DTB FROM Student s INNER JOIN Faculty f ON s.id_faculty = f.id INNER JOIN Study_result sr ON s.id = sr.id_student INNER JOIN Subject sb ON sr.id_subject = sb.id WHERE sb.id = '" + sl + "'", con);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManagerScore.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManagerScore.Items.Add(item);
                }
            }
            lvManagerScore.Size = new Size(lvManagerScore.Size.Width, lvManagerScore.Items.Count * 54);
            con.Close();
        }

        private void mnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.Show();
        }

    }
        
}
