using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EXAM_GENERATOR
{
    public partial class XInstrProfForm : DevExpress.XtraEditors.XtraForm
    {
        public static string d1, d2, d3, d4, d5, d6;
        public static int d7;
        
        public XInstrProfForm()
        {
            InitializeComponent();
        }

        private void XInstrProfForm_Load(object sender, EventArgs e)
        {
            //InstProfile_view.Show();
            lblfullname.Text = UserSubClass.Fullname;
            lbluser.Text = UserSubClass.Username;
            lblcourse.Text = UserSubClass.Course;
            lblsex.Text = UserSubClass.Gender;
            lblid.Text = UserSubClass.Id;
            lblscholyer.Text = UserSubClass.Schoolyear;
            lblsem.Text = UserSubClass.Semester;
            Disp_CurrentSub();
            Curriculum_Disp();

            
            
            
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            verify();
        }

        private void tbxscholyer_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode) 
            {
                verify();
            }
        }

        private void tbxsem_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                verify();
            }
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
                tbxsubcode.Enabled = true;
                tbxsubject.Enabled = true;
                tbxlab.Enabled = true;
                tbxlec.Enabled = true;
                tbxunits.Enabled = true;
                createbtn.Enabled = true;
                updatebtn.Enabled = true;
                deletebtn.Enabled = true;
                tblcreate_sub.Enabled = true;

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
                }
            }
            else if (count != 2)
            {
                tbxscholyer.Text = "";
                tbxsubcode.Enabled = false;
                tbxsubject.Enabled = false;
                tbxlab.Enabled = false;
                tbxlec.Enabled = false;
                tbxunits.Enabled = false;
                createbtn.Enabled = false;
                updatebtn.Enabled = false;
                deletebtn.Enabled = false;
                tblcreate_sub.Enabled = false;
                XtraMessageBox.Show("Unable to verify school year");
            }
            tbxsubcode.Focus();
        }

        
        private void tbxunits_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxlec.Text) && !string.IsNullOrEmpty(tbxlab.Text))
            {
                int lab = Convert.ToInt32(tbxlab.Text);
                int lec = Convert.ToInt32(tbxlec.Text);
                string units = Convert.ToString(lab + lec);
                tbxunits.Text = units;
                

            }
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            create_sub();
            Disp_CurrentSub();
            Curriculum_Disp();
        }

        private void create_sub()
        {
            if (string.IsNullOrEmpty(tbxsubcode.Text)) {MessageBox.Show("Subject code field is empty."); tbxsubcode.Focus(); return; }
            if (string.IsNullOrEmpty(tbxsubject.Text)) {MessageBox.Show("Subject field is empty."); tbxsubject.Focus(); return; }
            if (string.IsNullOrEmpty(tbxlec.Text)) { MessageBox.Show("Lecture field is empty."); tbxlec.Focus(); return; }
            if (string.IsNullOrEmpty(tbxlab.Text)) { MessageBox.Show("Laboratory field is empty."); tbxlab.Focus(); return; }
            UserSubClass.Subcode = Convert.ToString(tbxsubcode.Text);
            UserSubClass.Subdescript = Convert.ToString(tbxsubject.Text);
            UserSubClass.Lec = Convert.ToString(tbxlec.Text);
            UserSubClass.Lab = Convert.ToString(tbxlab.Text);
            UserSubClass.Units = Convert.ToString(tbxunits.Text);


            UserSubClass z = new UserSubClass();
            bool iscreate = z.createSub(UserSubClass.Subcode,  UserSubClass.Subdescript, UserSubClass.Lec, UserSubClass.Lab, UserSubClass.Units, UserSubClass.Fullname, UserSubClass.Schoolyear, UserSubClass.Semester );
            
            
        }

        DataTable data = new DataTable();
        public void Disp_CurrentSub()
        {
            data = UserSubClass.Get_CurrentSub();
            tblcreate_sub.DataSource = data;
            Cor_tbl.DataSource = data;
           

        }

        DataTable Curriculum_data = new DataTable();
        public void Curriculum_Disp()
        {
            Curriculum_data = UserSubClass.Get_Curriculum();
            Curriculum_table.DataSource = Curriculum_data;
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            del_sub();
            Disp_CurrentSub();
            Curriculum_Disp();
        }

        public void del_sub()
        {
            if (string.IsNullOrEmpty(tbxsubcode.Text)) { MessageBox.Show("Subject code field is empty."); tbxsubcode.Focus(); return; }
            if (string.IsNullOrEmpty(tbxsubject.Text)) { MessageBox.Show("Subject field is empty."); tbxsubject.Focus(); return; }
            if (string.IsNullOrEmpty(tbxlec.Text)) { MessageBox.Show("Lecture field is empty."); tbxlec.Focus(); return; }
            if (string.IsNullOrEmpty(tbxlab.Text)) { MessageBox.Show("Laboratory field is empty."); tbxlab.Focus(); return; }

            UserSubClass z = new UserSubClass();
            bool isDeleted = z.Delete_sub(d1, UserSubClass.Fullname, UserSubClass.Schoolyear, UserSubClass.Semester);
            bool isDeleteStudsub = z.Delete_Studsub(Convert.ToInt32(d6));
            if(isDeleted && isDeleteStudsub)
            {
                XtraMessageBox.Show("Deleted!");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            update_sub();
            Disp_CurrentSub();
            Curriculum_Disp();
        }

        public void update_sub()
        {
            if (string.IsNullOrEmpty(tbxsubcode.Text)) { MessageBox.Show("Subject code field is empty."); tbxsubcode.Focus(); return; }
            if (string.IsNullOrEmpty(tbxsubject.Text)) { MessageBox.Show("Subject field is empty."); tbxsubject.Focus(); return; }
            if (string.IsNullOrEmpty(tbxlec.Text)) { MessageBox.Show("Lecture field is empty."); tbxlec.Focus(); return; }
            if (string.IsNullOrEmpty(tbxlab.Text)) { MessageBox.Show("Laboratory field is empty."); tbxlab.Focus(); return; }

            UserSubClass.Subcode = Convert.ToString(tbxsubcode.Text);
            UserSubClass.Subdescript = Convert.ToString(tbxsubject.Text);
            UserSubClass.Lec = Convert.ToString(tbxlec.Text);
            UserSubClass.Lab = Convert.ToString(tbxlab.Text);
            UserSubClass.Units = Convert.ToString(tbxunits.Text);
            d7 = Convert.ToInt32(d6);
            UserSubClass z = new UserSubClass();
            bool isUpdated = z.Update_sub(d7, UserSubClass.Fullname, UserSubClass.Schoolyear, UserSubClass.Semester);
            bool isUpdateStud = z.Update_StudSub(d7);
            if (isUpdated && isUpdateStud)
            {
                XtraMessageBox.Show("Updated!");
            }
            else
            {
                XtraMessageBox.Show("Error unable to update!");

            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            XLoginForm z = new XLoginForm();
            z.Show();
        }

        private void XInstrProfForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void view_subTbl_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (view_subTbl.SelectedRowsCount > 0)
            {
                d1 = view_subTbl.GetRowCellValue(view_subTbl.FocusedRowHandle, "subCode").ToString();
                d2 = view_subTbl.GetRowCellValue(view_subTbl.FocusedRowHandle, "subDescription").ToString();
                d3 = view_subTbl.GetRowCellValue(view_subTbl.FocusedRowHandle, "lec").ToString();
                d4 = view_subTbl.GetRowCellValue(view_subTbl.FocusedRowHandle, "lab").ToString();
                d5 = view_subTbl.GetRowCellValue(view_subTbl.FocusedRowHandle, "units").ToString();
                d6 = view_subTbl.GetRowCellValue(view_subTbl.FocusedRowHandle, "id").ToString();

                tbxsubcode.Text = d1;
                tbxsubject.Text = d2;
                tbxlec.Text = d3;
                tbxlab.Text = d4;
                tbxunits.Text = d5;
            }
        }

        

       

        

      
    }
}