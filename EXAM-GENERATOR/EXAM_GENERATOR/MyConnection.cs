using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EXAM_GENERATOR
{
    public partial class MyConnection : DevExpress.XtraEditors.XtraUserControl
    {
        public MyConnection()
        {
            InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassBx.Checked == true)
            {
                txtPassword.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.Properties.UseSystemPasswordChar = true;
            }
        }

        private void txtDatabase_Enter(object sender, EventArgs e)
        {
            txtDatabase.DropDownStyle = ComboBoxStyle.DropDownList;

            MySqlConnection con = new MySqlConnection("Server = " + txtServerName.Text + "; Uid = " + txtUsername.Text + "; Pwd = " + txtPassword.Text + "; Port = " + txtPort.Text + ";");
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "show databases";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                        row += reader.GetValue(i).ToString();
                    txtDatabase.Items.Add(row);
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Number.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            UserSubClass.TempConnection = string.Concat("Server = ",txtServerName.Text,"; Database = ",txtDatabase.Text,"; Uid = ",txtUsername.Text,"; Pwd = ",txtPassword.Text,"; Port = ",txtPort.Text,";");
            //Properties.Settings.Default.MyConnectionString = UserSubClass.TempConnection;
            UserSubClass z = new UserSubClass();
            bool isTestSuccess = z.test_conn();
            if (!isTestSuccess)
            {
                conn_statusLbl.Text = "Connection Successful";
                conn_statusLbl.Visible = true;
                SaveBtn.Enabled = true;
            }
            else
            {
                conn_statusLbl.Text = "Connection Error!";
                conn_statusLbl.Visible = true;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MyConnectionString = UserSubClass.TempConnection;
            Properties.Settings.Default.Save();
            XtraMessageBox.Show("Connection Save!");
            Application.Restart();
        }

    }
}
