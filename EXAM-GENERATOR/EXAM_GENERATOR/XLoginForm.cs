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
using FlyoutDialogExample;

namespace EXAM_GENERATOR
{
    public partial class XLoginForm : DevExpress.XtraEditors.XtraForm
    {
        UserSubClass z = new UserSubClass();
        public XLoginForm()
        {
            InitializeComponent();
            
        }

        private void signinProcess()
        {
            lblWarning.Visible = false;

            if (string.IsNullOrEmpty(usernameTbx.Text)) { lblWarning.Text = "Username field is empty."; usernameTbx.Focus(); return; }
            if (string.IsNullOrEmpty(passCodeTbx.Text)) { lblWarning.Text = "Password field is empty."; passCodeTbx.Focus(); return; }


            string User_name = usernameTbx.Text;
            string Pass_code = z.Encrypt(Convert.ToString( passCodeTbx.Text));

            bool log = z.login(User_name, Pass_code);
            if (log == true)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Signing in..");
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);

                }
                SplashScreenManager.CloseForm();
                UserSubClass.Username = User_name;
                UserSubClass.Passcode = Pass_code;
                this.Hide();
                if (string.Compare(UserSubClass.Member, "INSTRUCTOR") == 0)
                {
                    XInstrProfForm i = new XInstrProfForm();
                    i.Show();
                }
                else
                {
                    XStudProfForm s = new XStudProfForm();
                    s.Show();
                }
            }
            else if (log == false)
            {

                lblWarning.Text = "INVALID USERNAME/PASSWORD";
                lblWarning.Visible = true;
                usernameTbx.Text = "";
                passCodeTbx.Text = "";
            }



        }
    
        private void showBtn_Click_1(object sender, EventArgs e)
        {
            showBtn.Visible = false;
            hideBtn.Visible = true;
            passCodeTbx.Properties.UseSystemPasswordChar = false;
            if (!string.IsNullOrEmpty(passCodeTbx.Text))
            {
                passCodeTbx.Focus();
            }
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
              hideBtn.Visible = false;
              showBtn.Visible = true;
              passCodeTbx.Properties.UseSystemPasswordChar = true;
              if (!string.IsNullOrEmpty(passCodeTbx.Text))
              {
                  passCodeTbx.Focus();
              }
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            this.Hide();
            XSignupForm a = new XSignupForm();
            a.Show();
        }

        private void XLoginForm_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
            }
            CheckTheConnection();  
            
        }

        public void CheckTheConnection()
        {
            
            bool isCheck = z.check_conn();
            if (isCheck)
            {
                simpleButton1.Visible = false;
                hyperlinkLabelControl1.Visible = false;
                usernameTbx.Enabled = false;
                passCodeTbx.Enabled = false;
                statusLbl.Visible = true;
                
            }
            else
            {
                statusLbl.Text = string.Concat("Status: Connected to ", Properties.Settings.Default.MyConnectionString);
            
                 statusLbl.Visible = true;
                simpleButton1.Visible = true;
                usernameTbx.Enabled = true;
                passCodeTbx.Enabled = true;
                hyperlinkLabelControl1.Visible = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            signinProcess();
        }

        private void usernameTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode) 
            {
                signinProcess();
            }
        }

        private void passCodeTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                signinProcess();
            }
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                capslock_label.Visible = true;

            }
            else
            {
                capslock_label.Visible = false;
            }
        }

        private void statusLbl_Click(object sender, EventArgs e)
        {
            CustomFlyoutDialog.ShowForm(this, null, new MyConnection());
        }

        private void XLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}