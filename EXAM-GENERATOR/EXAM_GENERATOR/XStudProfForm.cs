using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace EXAM_GENERATOR
{
    public partial class XStudProfForm : DevExpress.XtraEditors.XtraForm
    {
        UserSubClass z = new UserSubClass();
        string subjectId;
        public XStudProfForm()
        {
            InitializeComponent();
        }

        private void XStudProfForm_Load(object sender, EventArgs e)
        {
            lblfullname.Text = UserSubClass.Fullname;
            lbluser.Text = UserSubClass.Username;
            lblcourse.Text = UserSubClass.Course;
            lblsex.Text = UserSubClass.Gender;
            lblid.Text = UserSubClass.Id;
            lblschoolyear.Text = UserSubClass.Schoolyear;
            lblsem.Text = UserSubClass.Semester;
            Disp_COR();
            Disp_Curriculum();
            tbxscholyer.Focus();
           //StudProfile_view.Show();
        }

        private void XStudProfForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            verify();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxscholyer.Text)) { tbxscholyer.Focus(); return; }
            if (string.IsNullOrEmpty(tbxsem.Text)) { tbxsem.Focus(); return; }

            int[] selectedRows = gridView1.GetSelectedRows();  
            foreach (int rowHandle in selectedRows)  
            {
                if (rowHandle >= 0)
                {
                    UserSubClass.Subcode = gridView1.GetRowCellValue(rowHandle, gridColumn13).ToString();
                    UserSubClass.Subdescript = gridView1.GetRowCellValue(rowHandle, gridColumn14).ToString();
                    UserSubClass.Lec = gridView1.GetRowCellValue(rowHandle, gridColumn15).ToString();
                    UserSubClass.Lab = gridView1.GetRowCellValue(rowHandle, gridColumn16).ToString();
                    UserSubClass.Units = gridView1.GetRowCellValue(rowHandle, gridColumn17).ToString();
                    UserSubClass.Instructor = gridView1.GetRowCellValue(rowHandle, gridColumn18).ToString();
                    subjectId = gridView1.GetRowCellValue(rowHandle, gridColumn19).ToString();
                    UserSubClass.Primekey = Convert.ToInt32(subjectId);

                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                    SplashScreenManager.Default.SetWaitFormCaption("Adding subject...");
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(50);

                    }
                    SplashScreenManager.CloseForm();

                    bool isAdded = z.Add_Subject(UserSubClass.Primekey, UserSubClass.Subcode, UserSubClass.Subdescript, UserSubClass.Lec, UserSubClass.Lab, UserSubClass.Units, UserSubClass.Instructor, UserSubClass.Schoolyear, UserSubClass.Semester, UserSubClass.Fullname);

                }
                

            }
            DispAdd_sub();
            Disp_COR();
            Disp_Curriculum();
            XtraMessageBox.Show("Subject added ");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            XLoginForm z = new XLoginForm();
            z.Show();
        }

        private void verify()
        {
            if (string.IsNullOrEmpty(tbxscholyer.Text)) { tbxscholyer.Focus(); return; }
            if (string.IsNullOrEmpty(tbxsem.Text)) { tbxsem.Focus(); return; }

            Char c = '-';
            DateTime date = DateTime.Now;
            int d1 = Convert.ToInt32(date.Year);
            int d2 = Convert.ToInt32(date.Month);
            string[] schoolyear = Convert.ToString(tbxscholyer.Text).Split(c);
            int count = 0;
            foreach (string school in schoolyear)
            {
                int year = Convert.ToInt32(school);
                if ((year >= d1) && (count == 1))
                {
                    if ((string.Compare(Convert.ToString(tbxsem.Text), "2nd") == 0) && d2 < 6)
                    {
                        count++;
                    }
                    if ((string.Compare(Convert.ToString(tbxsem.Text), "1st") == 0) && d2 > 7)
                    {
                        count++;
                    }
                }
                else if ((year <= d1) && (count == 0))
                {
                    count++;
                }

            }
            if (count == 2)
            {

                add_subdtgv.Enabled = true;

                UserSubClass.Schoolyear = Convert.ToString(tbxscholyer.Text);
                UserSubClass.Semester = Convert.ToString(tbxsem.Text);
                UserSubClass z = new UserSubClass();
                bool verify = z.insScholYer(UserSubClass.Schoolyear, UserSubClass.Semester);
                if (!verify)
                {
                    XtraMessageBox.Show("ERROR OCCURED!");
                }
                else
                {
                    XtraMessageBox.Show("Verified!");
                    DispAdd_sub();
                }
            }
            else if (count != 2)
            {
                tbxscholyer.Text = "";

                add_subdtgv.Enabled = false;
                XtraMessageBox.Show("Unable to verify school year");
            }

        }

        DataTable data = new DataTable();
        public void DispAdd_sub()
        {
            data = UserSubClass.Get_AddedSub();
            add_subdtgv.DataSource = data;
        }

        DataTable data2 = new DataTable();
        public void Disp_COR()
        {
            data2 = UserSubClass.Get_COR();
            gridControl_COR.DataSource = data2;
        }

        DataTable data3 = new DataTable();
        public void Disp_Curriculum()
        {
            data3 = UserSubClass.Get_StudCurriculum();
            gridcontrol_curriculum.DataSource = data3;
        }
        
    }
}