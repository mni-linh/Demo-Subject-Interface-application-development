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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void mnManageFacult_Click(object sender, EventArgs e)
        {
            pnlManageFaculty.Visible = true;
            pnlManageStudent.Visible = false;
            pnlManageTeacher.Visible = false;
            pnlManageSubject.Visible = false;
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, name, address, status FROM Faculty", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageFaculty.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageFaculty.Items.Add(item);
                }
            }
            lvManageFaculty.Size = new Size(lvManageFaculty.Size.Width, lvManageFaculty.Items.Count * 27);
            con.Close();

        }

        private void mnManageStudent_Click(object sender, EventArgs e)
        {
            pnlManageFaculty.Visible = false;
            pnlManageStudent.Visible = true;
            pnlManageTeacher.Visible = false;
            pnlManageSubject.Visible = false;
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Student.id) as ItemNo, Student.id, fullname, date_of_birth, Student.address, Faculty.id, Student.status FROM Student, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageStudent.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        } else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageStudent.Items.Add(item);
                }
            }
            lvManageStudent.Size = new Size(lvManageStudent.Size.Width, lvManageStudent.Items.Count * 27);
            con.Close();
        }

        private void mnManageTeacher_Click(object sender, EventArgs e)
        {
            pnlManageFaculty.Visible = false;
            pnlManageStudent.Visible = false;
            pnlManageSubject.Visible = false;
            pnlManageTeacher.Visible = true;
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Teacher.id) as ItemNo, Teacher.id, fullname, date_of_birth, Teacher.address, Faculty.id, day_start, Teacher.status FROM Teacher, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageTeacher.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageTeacher.Items.Add(item);
                }
            }
            lvManageTeacher.Size = new Size(lvManageTeacher.Size.Width, lvManageTeacher.Items.Count * 27);
            con.Close();
        }

        private void mnManageSubject_Click(object sender, EventArgs e)
        {
            pnlManageFaculty.Visible = false;
            pnlManageStudent.Visible = false;
            pnlManageSubject.Visible = true;
            pnlManageTeacher.Visible = false;
            getAllNameSubject_type();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY s.id) as ItemNo, s.id, s.name, course_credit, st.name, semester, id_faculty, s.status FROM Subject s INNER JOIN Subject_type st ON s.id_subject_type = st.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageSubject.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageSubject.Items.Add(item);
                }
            }
            lvManageSubject.Size = new Size(lvManageSubject.Size.Width, lvManageSubject.Items.Count * 27);
            con.Close();
        }

        private void lvManageSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY s.id) as ItemNo, s.id, s.name, course_credit, st.name, semester, id_faculty, s.status FROM Subject s INNER JOIN Subject_type st ON s.id_subject_type = st.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (lvManageSubject.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvManageSubject.SelectedItems[0];
                    tbIdSubject.Text = item.SubItems[1].Text;
                    tbNameSubject.Text = item.SubItems[2].Text;
                    tbCourseCredit.Text = item.SubItems[3].Text;
                    cbSubjectType.Text = item.SubItems[4].Text;
                    tbSemester.Text = item.SubItems[5].Text;
                    tbIdFacultySubject.Text = item.SubItems[6].Text;
                    cbStatusSubject.Text = item.SubItems[7].Text;                   
                }
                else
                {
                    tbIdSubject.Text = string.Empty;
                    tbNameSubject.Text = string.Empty;
                    tbCourseCredit.Text = string.Empty;
                    cbSubjectType.Text = string.Empty;
                    tbSemester.Text = string.Empty;
                    tbIdFacultySubject.Text = string.Empty;
                    cbStatusSubject.Text = "True";
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

        private void getAllNameSubject_type()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT name FROM Subject_type", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbSubjectType.DisplayMember = "name";
            cbSubjectType.DataSource = dt;

            con.Close();
        }

        public int getIdFromNameSubject_type(string name)
        {
            Int32 id = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string queryStr = @"SELECT id FROM Subject_type WHERE name LIKE N'{0}'";
            queryStr = string.Format(queryStr, name);
            SqlCommand cmd = new SqlCommand(queryStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            id = Convert.ToInt32(cmd.ExecuteScalar());
            
            return (int)id;
        }
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            string queryString = @"INSERT INTO Subject
                                 VALUES('" + tbIdSubject.Text + "', N'{0}','" + tbCourseCredit.Text + "','" + tbSemester.Text + "','" + getIdFromNameSubject_type(cbSubjectType.Text) + "','" + tbIdFacultySubject.Text + "', 'True')";
            queryString = string.Format(queryString, tbNameSubject.Text);
            ExcuteNonQuery(queryString);
            lvManageSubject.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY s.id) as ItemNo, s.id, s.name, course_credit, st.name, semester, id_faculty, s.status FROM Subject s INNER JOIN Subject_type st ON s.id_subject_type = st.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageSubject.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageSubject.Items.Add(item);
                }
            }
            lvManageSubject.Size = new Size(lvManageSubject.Size.Width, lvManageSubject.Items.Count * 27);
            con.Close();
        }

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            string queryString = @"UPDATE Subject SET name = N'{0}', course_credit = '"+tbCourseCredit.Text+"', semester = '"+tbSemester.Text+"', id_subject_type = '"+getIdFromNameSubject_type(cbSubjectType.Text)+"', id_faculty = '"+tbIdFacultySubject.Text+"', status = '"+cbStatusSubject.Text+ "' WHERE id = '" + tbIdSubject.Text + "'";
            queryString = string.Format(queryString, tbNameSubject.Text);
            ExcuteNonQuery(queryString);
            lvManageSubject.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY s.id) as ItemNo, s.id, s.name, course_credit, st.name, semester, id_faculty, s.status FROM Subject s INNER JOIN Subject_type st ON s.id_subject_type = st.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageSubject.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageSubject.Items.Add(item);
                }
            }
            lvManageSubject.Size = new Size(lvManageSubject.Size.Width, lvManageSubject.Items.Count * 27);
            con.Close();
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (lvManageSubject.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa");
                return;
            }
            string queryString = @"DELETE FROM Subject
                    WHERE id = '" + tbIdSubject.Text + "'";
            ExcuteNonQuery(queryString);
            lvManageSubject.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY s.id) as ItemNo, s.id, s.name, course_credit, st.name, semester, id_faculty, s.status FROM Subject s INNER JOIN Subject_type st ON s.id_subject_type = st.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageSubject.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageSubject.Items.Add(item);
                }
            }
            lvManageSubject.Size = new Size(lvManageSubject.Size.Width, lvManageSubject.Items.Count * 27);
            con.Close();
        }

        private void lvManageFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, name, address, status FROM Faculty", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (lvManageFaculty.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvManageFaculty.SelectedItems[0];
                    tbIdFaculty.Text = item.SubItems[1].Text;
                    tbNameFaculty.Text = item.SubItems[2].Text;
                    tbAddressFaculty.Text = item.SubItems[3].Text;
                    cbStatusFaculty.Text = item.SubItems[4].Text;
                }
                else
                {
                    tbIdFaculty.Text = string.Empty;
                    tbNameFaculty.Text = string.Empty;
                    tbAddressFaculty.Text = string.Empty;
                    cbStatusFaculty.Text = "True";
                }
            }
        }

        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            string queryString = @"INSERT INTO Faculty
                                 VALUES(N'{0}', N'{1}', N'{2}', 'True')";
            queryString = string.Format(queryString, tbIdFaculty.Text, tbNameFaculty.Text, tbAddressFaculty.Text);
            ExcuteNonQuery(queryString);
            lvManageFaculty.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, name, address, status FROM Faculty", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageFaculty.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageFaculty.Items.Add(item);
                }
            }
            lvManageFaculty.Size = new Size(lvManageFaculty.Size.Width, lvManageFaculty.Items.Count * 27);
            con.Close();
        }

        private void btnUpdateFaculty_Click(object sender, EventArgs e)
        {
            string queryString = @"UPDATE Faculty SET name = N'{0}', address = N'{1}', status = '" + cbStatusFaculty.Text + "' WHERE id LIKE N'{2}'";
            queryString = string.Format(queryString, tbNameFaculty.Text, tbAddressFaculty.Text, tbIdFaculty.Text);
            ExcuteNonQuery(queryString);
            lvManageFaculty.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, name, address, status FROM Faculty", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageFaculty.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageFaculty.Items.Add(item);
                }
            }
            lvManageFaculty.Size = new Size(lvManageFaculty.Size.Width, lvManageFaculty.Items.Count * 27);
            con.Close();
        }

        private void btnDeleteFaculty_Click(object sender, EventArgs e)
        {
            if (lvManageFaculty.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa");
                return;
            }
            string queryString = @"DELETE FROM Faculty
                    WHERE id LIKE N'{0}'";
            queryString = string.Format(queryString, tbIdFaculty.Text);
            ExcuteNonQuery(queryString);
            lvManageFaculty.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, name, address, status FROM Faculty", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageFaculty.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageFaculty.Items.Add(item);
                }
            }
            lvManageFaculty.Size = new Size(lvManageFaculty.Size.Width, lvManageFaculty.Items.Count * 27);
            con.Close();
        }

        private void lvManageStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, fullname, date_of_birth, address, id_faculty, status FROM Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (lvManageStudent.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvManageStudent.SelectedItems[0];
                    tbIdStudent.Text = item.SubItems[1].Text;
                    tbNameStudent.Text = item.SubItems[2].Text;
                    tbDoBStudent.Text = item.SubItems[3].Text;
                    tbAddressStudent.Text = item.SubItems[4].Text;
                    tbIdFacultyStudent.Text = item.SubItems[5].Text;
                    cbStatusStudent.Text = item.SubItems[6].Text;
                }
                else
                {
                    tbIdSubject.Text = string.Empty;
                    tbNameStudent.Text = string.Empty;
                    tbDoBStudent.Text = string.Empty; 
                    tbAddressStudent.Text = string.Empty; 
                    tbIdFacultyStudent.Text = string.Empty; 
                    cbStatusStudent.Text = "True";
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string queryString = @"INSERT INTO Student
                                 VALUES(N'{0}', '123456', N'{1}', '{2}', N'{3}', N'{4}', 'True')";
            queryString = string.Format(queryString, tbIdStudent.Text, tbNameStudent.Text, Convert.ToDateTime(tbDoBStudent.Text).ToString("yyyy-MM-dd"), tbAddressStudent.Text, tbIdFacultyStudent.Text);
            ExcuteNonQuery(queryString);
            lvManageStudent.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Student.id) as ItemNo, Student.id, fullname, date_of_birth, Student.address, Faculty.id, Student.status FROM Student, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageStudent.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageStudent.Items.Add(item);
                }
            }
            lvManageStudent.Size = new Size(lvManageStudent.Size.Width, lvManageStudent.Items.Count * 27);
            con.Close();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            string queryString = @"UPDATE Student SET fullname = N'{0}', date_of_birth = '{1}', address = N'{2}', id_faculty = N'{3}', status = '" + cbStatusStudent.Text + "' WHERE id LIKE N'{4}'";
            queryString = string.Format(queryString, tbNameStudent.Text, Convert.ToDateTime(tbDoBStudent.Text).ToString("yyyy-MM-dd"), tbAddressStudent.Text, tbIdFacultyStudent.Text, tbIdStudent.Text);
            ExcuteNonQuery(queryString);
            lvManageStudent.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Student.id) as ItemNo, Student.id, fullname, date_of_birth, Student.address, Faculty.id, Student.status FROM Student, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageStudent.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageStudent.Items.Add(item);
                }
            }
            lvManageStudent.Size = new Size(lvManageStudent.Size.Width, lvManageStudent.Items.Count * 27);
            con.Close();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (lvManageStudent.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa");
                return;
            }
            string queryString = @"DELETE FROM Student
                    WHERE id LIKE N'{0}'";
            queryString = string.Format(queryString, tbIdStudent.Text);
            ExcuteNonQuery(queryString);
            lvManageStudent.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Student.id) as ItemNo, Student.id, fullname, date_of_birth, Student.address, Faculty.id, Student.status FROM Student, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageStudent.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageStudent.Items.Add(item);
                }
            }
            lvManageStudent.Size = new Size(lvManageStudent.Size.Width, lvManageStudent.Items.Count * 27);
            con.Close();
        }

        private void lvManageTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id, fullname, date_of_birth, address, id_faculty, day_start, status FROM Teacher", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (lvManageTeacher.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvManageTeacher.SelectedItems[0];
                    tbIdTeacher.Text = item.SubItems[1].Text;
                    tbNameTeacher.Text = item.SubItems[2].Text;
                    tbDoBTeacher.Text = item.SubItems[3].Text;
                    tbAddressTeacher.Text = item.SubItems[4].Text;
                    tbDayStart.Text = item.SubItems[6].Text;
                    tbFacultyTeacher.Text = item.SubItems[5].Text;
                    cbStatusTeacher.Text = item.SubItems[7].Text;
                }
                else
                {
                    tbIdSubject.Text = string.Empty;
                    tbNameStudent.Text = string.Empty;
                    tbDoBStudent.Text = string.Empty;
                    tbAddressStudent.Text = string.Empty;
                    tbDayStart.Text = string.Empty;
                    tbIdFacultyStudent.Text = string.Empty;
                    cbStatusStudent.Text = "True";
                }
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            string queryString = @"INSERT INTO Teacher
                                 VALUES(N'{0}', '123456', N'{1}', '{2}', N'{3}', '{4}', N'{5}', 'True')";
            queryString = string.Format(queryString, tbIdTeacher.Text, tbNameTeacher.Text, Convert.ToDateTime(tbDoBTeacher.Text).ToString("yyyy-MM-dd"), tbAddressTeacher.Text, Convert.ToDateTime(tbDayStart.Text).ToString("yyyy-MM-dd"), tbFacultyTeacher.Text);
            ExcuteNonQuery(queryString);
            lvManageTeacher.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Teacher.id) as ItemNo, Teacher.id, fullname, date_of_birth, Teacher.address, Faculty.id, day_start, Teacher.status FROM Teacher, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageTeacher.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageTeacher.Items.Add(item);
                }
            }
            lvManageTeacher.Size = new Size(lvManageTeacher.Size.Width, lvManageTeacher.Items.Count * 27);
            con.Close();
        }

        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            string queryString = @"UPDATE Teacher SET fullname = N'{0}', date_of_birth = '{1}', address = N'{2}', id_faculty = N'{3}', day_start = '{4}', status = '" + cbStatusFaculty.Text + "' WHERE id LIKE N'{5}'";
            queryString = string.Format(queryString, tbNameTeacher.Text, Convert.ToDateTime(tbDoBTeacher.Text).ToString("yyyy-MM-dd"), tbAddressTeacher.Text, tbFacultyTeacher.Text, Convert.ToDateTime(tbDayStart.Text).ToString("yyyy-MM-dd"), tbIdTeacher.Text);
            ExcuteNonQuery(queryString);
            lvManageTeacher.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Teacher.id) as ItemNo, Teacher.id, fullname, date_of_birth, Teacher.address, Faculty.id, day_start, Teacher.status FROM Teacher, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageTeacher.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageTeacher.Items.Add(item);
                }
            }
            lvManageTeacher.Size = new Size(lvManageTeacher.Size.Width, lvManageTeacher.Items.Count * 27);
            con.Close();
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (lvManageTeacher.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa");
                return;
            }
            string queryString = @"DELETE FROM Teacher
                    WHERE id LIKE N'{0}'";
            queryString = string.Format(queryString, tbIdTeacher.Text);
            ExcuteNonQuery(queryString);
            lvManageTeacher.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY Teacher.id) as ItemNo, Teacher.id, fullname, date_of_birth, Teacher.address, Faculty.id, day_start, Teacher.status FROM Teacher, Faculty WHERE id_faculty = Faculty.id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (lvManageTeacher.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageTeacher.Items.Add(item);
                }
            }
            lvManageTeacher.Size = new Size(lvManageTeacher.Size.Width, lvManageTeacher.Items.Count * 27);
            con.Close();
        }

        private void mnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnFilterTeacher_Click(object sender, EventArgs e)
        {
            lvManageTeacher.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id as MSGV, fullname as HoTen, date_of_birth, address, id_faculty as MaKhoa, day_start, status FROM Teacher t WHERE id = '"+tbIdTeacherFilter.Text+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManageTeacher.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageTeacher.Items.Add(item);
                }
            }
            lvManageTeacher.Size = new Size(lvManageTeacher.Size.Width, lvManageTeacher.Items.Count * 54);
            con.Close();
        }

        private void btnIdFilterStudent_Click(object sender, EventArgs e)
        {
            lvManageStudent.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, id as MSSV, fullname as HoTen, date_of_birth, address, id_faculty as MaKhoa, status FROM Student WHERE id = '" + tbIdStudentFilter.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManageStudent.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is DateTime)
                        {
                            item.SubItems.Add(Convert.ToDateTime(row[i]).ToString("d"));
                        }
                        else
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                    }
                    lvManageStudent.Items.Add(item);
                }
            }
            lvManageStudent.Size = new Size(lvManageStudent.Size.Width, lvManageStudent.Items.Count * 54);
            con.Close();
        }

        private void btnIdFacultyFilter_Click(object sender, EventArgs e)
        {
            lvManageFaculty.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, Faculty.* FROM Faculty WHERE id = '" + tbIdFacultyFilter.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManageFaculty.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageFaculty.Items.Add(item);
                }
            }
            lvManageFaculty.Size = new Size(lvManageFaculty.Size.Width, lvManageFaculty.Items.Count * 54);
            con.Close();
        }

        private void btnIdSubjectFilter_Click(object sender, EventArgs e)
        {
            lvManageSubject.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["mdManageStudyResults"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT row_number() OVER(ORDER BY id) as ItemNo, Subject.* FROM Subject WHERE id = '" + tbIdSubjectFilter.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (lvManageSubject.Items.Count == 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.Font = new Font(item.Font, FontStyle.Regular);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    lvManageSubject.Items.Add(item);
                }
            }
            lvManageSubject.Size = new Size(lvManageSubject.Size.Width, lvManageSubject.Items.Count * 54);
            con.Close();
        }
    }
}
