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
    public partial class XSignupForm : DevExpress.XtraEditors.XtraForm
    {
        UserSubClass z = new UserSubClass();
        public XSignupForm()
        {
            InitializeComponent();
        }

        private void XSignupForm_Load(object sender, EventArgs e)
        {
            //passwrdTbx.Properties.PasswordChar = '*';
            firstNametbx.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNametbx.Text)) { lblWarning.Text = "First Name field is empty."; firstNametbx.Focus(); return; }
            if (string.IsNullOrEmpty(lastNametbx.Text)) { lblWarning.Text = "Last Name field is empty."; lastNametbx.Focus(); return; }
            //if (string.IsNullOrEmpty(miTbx.Text)) { lblWarning.Text = "Middle Initial field is empty."; miTbx.Focus(); return; }
            if (string.IsNullOrEmpty(sexTbx.Text)) { lblWarning.Text = "Sex field is empty."; sexTbx.Focus(); return; }
            if (string.IsNullOrEmpty(userNameTbx.Text)) { lblWarning.Text = "Username field is empty."; userNameTbx.Focus(); return; }
            if (string.IsNullOrEmpty(passwrdTbx.Text)) { lblWarning.Text = "Password field is empty."; passwrdTbx.Focus(); return; }
            if (string.IsNullOrEmpty(courseCbx.Text)) { lblWarning.Text = "Course field is empty."; courseCbx.Focus(); return; }
            if (string.IsNullOrEmpty(idTbx.Text)) { lblWarning.Text = "ID field is empty."; idTbx.Focus(); return; }
            if(studRbtn.Checked == true && string.IsNullOrEmpty(yrsecCbx.Text)) { lblWarning.Text = "Year and Section field is empty."; yrsecCbx.Focus(); return; }
            if (string.IsNullOrEmpty(schoolyeartbx.Text)) { lblWarning.Text = "School year field is empty."; schoolyeartbx.Focus(); return; }
            if (string.IsNullOrEmpty(semestertbx.Text)) { lblWarning.Text = "Semester field is empty."; semestertbx.Focus(); return; }
            
          //  if ((instructRbtn || studRbtn) == 1)
          //  {
           //     lblWarning.Text = "Specify your account .";
            //    return;
           // }
            if (!string.IsNullOrEmpty(miTbx.Text))
            {
                UserSubClass.Fullname = string.Copy(string.Concat(firstNametbx.Text, " ", miTbx.Text, ". ", lastNametbx.Text));
            }
            else if (string.IsNullOrEmpty(miTbx.Text))
            {
                UserSubClass.Fullname = string.Copy(string.Concat(firstNametbx.Text, " ", lastNametbx.Text));
            }
           
             UserSubClass.Gender = sexTbx.Text;
            UserSubClass.Username = userNameTbx.Text;
            UserSubClass.Passcode = z.Encrypt(Convert.ToString(passwrdTbx.Text));
            UserSubClass.Course = courseCbx.Text;
            UserSubClass.Id = idTbx.Text;
            UserSubClass.Schoolyear = schoolyeartbx.Text;
            UserSubClass.Semester = semestertbx.Text;
            if (studRbtn.Checked == true)
            {
                UserSubClass.Member = string.Copy("STUDENT");
                UserSubClass.Course = string.Concat(courseCbx.Text, " ", yrsecCbx.Text);
            }
            else
            {
                UserSubClass.Member = string.Copy("INSTRUCTOR");
                UserSubClass.year_sec = string.Copy("None");
            }
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Creating Account..");
            for (int i = 0; i < 100; i++ )
            {
                Thread.Sleep(50);

            }
            SplashScreenManager.CloseForm();
            bool isDuplicate = z.Add(UserSubClass.Fullname, UserSubClass.Gender, UserSubClass.Username, UserSubClass.Passcode, UserSubClass.Course, UserSubClass.Member, UserSubClass.Id, UserSubClass.Schoolyear, UserSubClass.Semester);
            if (isDuplicate) { lblWarning.Text = "Account already exist"; }
            else
            {
                XtraMessageBox.Show("Account created!");
            }

        }

        private void XSignupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            XLoginForm a = new XLoginForm();
            a.Show();
        }

        private void instructRbtn_CheckedChanged(object sender, EventArgs e)
        {
            yrsecCbx.Visible = false;
            yrsecLbl.Visible = false;
        }

        private void studRbtn_CheckedChanged(object sender, EventArgs e)
        {
            yrsecCbx.Visible = true;
            yrsecLbl.Visible = true;
        }

        private void showPassBx_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassBx.Checked == true)
            {
                passwrdTbx.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                passwrdTbx.Properties.UseSystemPasswordChar = true;
            }
        }
    }
}