using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace EXAM_GENERATOR
{
    class UserSubClass
    {
        public static string Fullname { get; set; }
        public static string Gender { get; set; }
        public static string Username { get; set; }
        public static string Passcode { get; set; }
        public static string Course { get; set; }
        public static string Member { get; set; }
        public static string Id { get; set; }
        public static string year_sec { get; set; }
        public static string Schoolyear { get; set; }
        public static string Semester { get; set; }
        public static string Lec { get; set; }
        public static string Lab { get; set; }
        public static string Units { get; set; }
        public static string Subcode { get; set; }
        public static string Subdescript { get; set; }
        public static string Instructor { get; set; }
        public static int Primekey { get; set; }
        public static string TempConnection { get; set; }

        public static bool GetIsSuccessfull = false;
        public static string GetErrorMessage = string.Empty;

        private static string ConnectionString()
        {
            //string temp = "Server = localhost; Database = user; Uid = root; Pwd = admin; Port = 3306;";
            return Properties.Settings.Default.MyConnectionString;
        }
        //--------------------Add Subject for Student------------------------------------------
        public bool Add_Subject(int id, string Subcode, string Subdescript, string Lec, string Lab, string Units, string Instructor, string Schoolyear, string Semester, string fullname)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO addsubject (subCode, subDescription, lec, lab, unit, instructor, schoolyear, semester, studentName, subId) VALUES (?_subCode, ?_subDescription, ?_lec, ?_lab, ?_unit, ?_instructor, ?_schoolyear, ?_semester, ?_studentName, ?_subId);", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_subCode", Subcode));
                    cmd.Parameters.Add(new MySqlParameter("_subDescription", Subdescript));
                    cmd.Parameters.Add(new MySqlParameter("_lec", Lec));
                    cmd.Parameters.Add(new MySqlParameter("_lab", Lab));
                    cmd.Parameters.Add(new MySqlParameter("_unit", Units));
                    cmd.Parameters.Add(new MySqlParameter("_instructor", Instructor));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    cmd.Parameters.Add(new MySqlParameter("_studentName", Fullname));
                    cmd.Parameters.Add(new MySqlParameter("_subId", id));
                    int temp = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //-------------Check Connection--------------------------
        public bool check_conn()
        {
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(ConnectionString()))
                {
                    MySqlDataAdapter mydapter = new MySqlDataAdapter();
                    mydapter.SelectCommand = new MySqlCommand("select * account;", myConn);
                    MySqlCommandBuilder commBuilder = new MySqlCommandBuilder(mydapter);
                    myConn.Open();
                    DataSet ds = new DataSet();
                    myConn.Close();

                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        //------------Test Connection----------------------------
        public bool test_conn()
        {
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(TempConnection))
                {
                    MySqlDataAdapter mydapter = new MySqlDataAdapter();
                    mydapter.SelectCommand = new MySqlCommand("select * account;", myConn);
                    MySqlCommandBuilder commBuilder = new MySqlCommandBuilder(mydapter);
                    myConn.Open();
                    DataSet ds = new DataSet();
                    myConn.Close();

                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        //-----------DataTables--------------------
        public static DataTable Get_AddedSub()
        {
            DataSet dt = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, subCode, subDescription, lec, lab, units, instructor FROM createsubject WHERE  schoolyear = ?_schoolyear AND semester = ?_semester ;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetIsSuccessfull = true;
                    GetErrorMessage = string.Empty;
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

        public static DataTable Get_Curriculum()
        {
            DataSet dt = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT subCode, subDescription, lec, lab, units, schoolyear, semester FROM createsubject WHERE instructor = ?_instructor;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_instructor", Fullname));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetIsSuccessfull = true;
                    GetErrorMessage = string.Empty;
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

        public static DataTable Get_CurrentSub()
        {
            DataSet dt = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, subCode, subDescription, lec, lab, units, schoolyear, semester FROM createsubject WHERE instructor = ?_instructor AND schoolyear = ?_schoolyear AND semester = ?_semester  ;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_instructor", Fullname));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetIsSuccessfull = true;
                    GetErrorMessage = string.Empty;
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

        public static DataTable Get_COR()
        {
            DataSet dt = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT  subCode, subDescription, lec, lab, unit, instructor FROM addsubject WHERE studentName = ?_studentName AND schoolyear = ?_schoolyear AND semester = ?_semester  ;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_studentName", Fullname));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetIsSuccessfull = true;
                    GetErrorMessage = string.Empty;
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }

        public static DataTable Get_StudCurriculum()
        {
            DataSet dt = new DataSet();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT  subCode, subDescription, lec, lab, unit, instructor, schoolyear, semester  FROM addsubject WHERE studentName = ?_studentName;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_studentName", Fullname));
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();
                    GetIsSuccessfull = true;
                    GetErrorMessage = string.Empty;
                    return dt.Tables[0];
                }
            }
            catch (Exception ex)
            {
                GetIsSuccessfull = false;
                GetErrorMessage = ex.Message + "\nFunction : Get";
                return null;
            }
        }
        //----------------------Create Subject for Instructor-----------------------------------
        public bool createSub(string Code, string Subject, string Lec, string Lab, string Units, string Instructor, string Schoolyear, string Semester)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO createsubject (subCode, subDescription, lec, lab, units, instructor, schoolyear, semester) VALUES (?_subCode, ?_subDescription, ?_lec, ?_lab, ?_units, ?_instructor, ?_schoolyear, ?_semester);", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_subCode", Code));
                    cmd.Parameters.Add(new MySqlParameter("_subDescription", Subject));
                    cmd.Parameters.Add(new MySqlParameter("_lec", Lec));
                    cmd.Parameters.Add(new MySqlParameter("_lab", Lab));
                    cmd.Parameters.Add(new MySqlParameter("_units", Units));
                    cmd.Parameters.Add(new MySqlParameter("_instructor", Instructor));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    int temp = cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
        //----------------------Update the School Year in User---------------------------------
        public bool insScholYer(string Schoolyear, string Semester)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE account SET schoolyear = ?_schoolyear, semester = ?_semester WHERE id = ?_id;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_id", Id));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //----------------------Creae Account--------------------------------------------------
        public bool Add (string Fullname, string Gender, string Username, string Passcode, string Course, string Member, string Id, string Schoolyear, string Semester )
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO account (fullname, gender, username, passcode, course, id, member, schoolyear, semester) VALUES (?_fullname, ?_gender, ?_username, ?_passcode, ?_course, ?_id, ?_member, ?_schoolyear, ?_semester);", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_fullname", Fullname));
                    cmd.Parameters.Add(new MySqlParameter("_gender", Gender));
                    cmd.Parameters.Add(new MySqlParameter("_username", Username));
                    cmd.Parameters.Add(new MySqlParameter("_passcode", Passcode));
                    cmd.Parameters.Add(new MySqlParameter("_course", Course));
                    cmd.Parameters.Add(new MySqlParameter("_id", Id));
                    cmd.Parameters.Add(new MySqlParameter("_member", Member));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    
                    int temp = cmd.ExecuteNonQuery();
                    con.Close();
                    return false;
                }
            }
            catch
            {
                return true;
            }
            
        }
        //----------------------Login Account-------------------------------------------------
        public bool login(string Username, string Passcode)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {

                    MySqlCommand cmd = new MySqlCommand("SELECT primekey, fullname, gender, course, id, member, schoolyear, semester FROM account WHERE username = ?_username AND passcode = ?_passcode ;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_username", Username));
                    cmd.Parameters.Add(new MySqlParameter("_passcode", Passcode));
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    GetIsSuccessfull = false;
                    while (reader.Read())
                    {
                        Primekey = reader.GetInt32("primekey");
                        Fullname = reader.GetString("fullname");
                        Gender = reader.GetString("gender");
                        Course = reader.GetString("course");
                        Id = reader.GetString("id");
                        Member = reader.GetString("member");
                        Schoolyear = reader.GetString("schoolyear");
                        Semester = reader.GetString("semester");
                        GetIsSuccessfull = true;
                    }
                    con.Close();
                }

                return GetIsSuccessfull;
            }
            catch
            {

                return GetIsSuccessfull;
            }

        }
        //----------------------Delete Subject for Student-------------------------------------
        public bool Delete_Studsub(int Id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM addsubject WHERE subID = ?_subId ;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_subId", Id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch
            {

                return false;
            }
        }
        //----------------------Delete Subject for Instructor----------------------------------
        public bool Delete_sub(string Code, string Instructor, string Schoolyear, string Semester)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM createsubject WHERE subCode = ?_subCode AND instructor = ?_instructor AND schoolyear = ?_schoolyear AND semester = ?_semester;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_subCode", Code));
                    cmd.Parameters.Add(new MySqlParameter("_instructor", Instructor));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch
            {

                return false;
            }
        }
        //----------------------Update Subject for Student-------------------------------------
        public bool Update_StudSub(int Id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE addsubject SET subCode = ?_subCode, subDescription = ?_subDescription, lec = ?_lec, lab = ?_lab, unit = ?_unit WHERE subId = ?_subId ", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_subCode", Subcode));
                    cmd.Parameters.Add(new MySqlParameter("_subDescription", Subdescript));
                    cmd.Parameters.Add(new MySqlParameter("_lec", Lec));
                    cmd.Parameters.Add(new MySqlParameter("_lab", Lab));
                    cmd.Parameters.Add(new MySqlParameter("_unit", Units));
                    cmd.Parameters.Add(new MySqlParameter("_subId", Id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch
            {

                return false;
            }
        }
        //----------------------Update Subject for Instructor----------------------------------
        public bool Update_sub(int Id, string Instructor, string Schoolyear, string Semester)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString()))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE createsubject SET subCode = ?_subCode, subDescription = ?_subDescription, lec = ?_lec, lab = ?_lab, units = ?_units WHERE id = ?_id AND instructor  = ?_instructor AND schoolyear  = ?_schoolyear AND semester  = ?_semester;", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("_subCode", Subcode));
                    cmd.Parameters.Add(new MySqlParameter("_subDescription", Subdescript));
                    cmd.Parameters.Add(new MySqlParameter("_lec", Lec));
                    cmd.Parameters.Add(new MySqlParameter("_lab", Lab));
                    cmd.Parameters.Add(new MySqlParameter("_units", Units));
                    cmd.Parameters.Add(new MySqlParameter("_id", Id));
                    cmd.Parameters.Add(new MySqlParameter("_instructor", Instructor));
                    cmd.Parameters.Add(new MySqlParameter("_schoolyear", Schoolyear));
                    cmd.Parameters.Add(new MySqlParameter("_semester", Semester));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;

            }
            catch
            {

                return false;
            }
        }

        //----------------------ENCRYPTION----------------------------------------------------
        private string determine(int length, string info)
        {
            for (int i = length; i < 36; i++)
            {
                info = info + " ";
            }
            return info;
        }
        public int[] chartonum(string info)
        {
            string newInfo = determine(info.Length, info);
            var temp = newInfo.ToCharArray();
            int[] arr = new int[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                arr[i] = Convert.ToInt32(temp[i]);
            }
            return (arr);
        }

        public string Encrypt(string theText)
        {
            int[] info = chartonum(theText);

            string encrypted = "";
            double row = Math.Sqrt(info.Length);
            int rowcol = (int)row;


            int m = rowcol, n = rowcol, p = rowcol, q = rowcol, c, d, k;
            float sum = 0;

            float[,] first = new float[rowcol, rowcol];
            int a = 0;
            for (int i = 0; i < rowcol; i++)
            {
                for (int j = 0; j < rowcol; j++)
                {
                    first[i, j] = info[a];
                    a++;
                }
            }

            float[,] second = new float[6, 6] { { 2, 4, 6, 4, 3, 2 },
                                                { 0,-4, 3,-2, 3, 1 },
                                                { 6, 4, 7, 6, 2, 4 },
                                                { 0, 9, 4, 5, 1, 3 },
                                                { 7, 8, 3,-3,-5, 2 },
                                                { 4, 2, 3, 1, 4, 4 }
                                              };
            float[,] multiply = new float[m, n];

            for (c = 0; c < m; c++)
            {
                for (d = 0; d < q; d++)
                {
                    for (k = 0; k < p; k++)
                    {
                        sum = sum + (float)(first[c, k] * second[k, d]);
                    }
                    multiply[c, d] = sum;
                    sum = 0;
                }
            }

            //output
            for (c = 0; c < m; c++)
            {
                for (d = 0; d < q; d++)
                {
                    string temp = dectohex((int)multiply[c, d]);
                    encrypted = encrypted + temp + "O";
                }
            }
            return encrypted;
        }
        private string dectohex(int decimalNumber)
        {
            int quotient = decimalNumber;
            int temp;
            char temp1;
            string info = "";
            while (quotient != 0)
            {
                temp = quotient % 16;
                if (temp < 10)
                    temp = temp + 48;
                else
                    temp = temp + 55;
                temp1 = Convert.ToChar(temp);
                info = info + Convert.ToString(temp1);
                quotient = quotient / 16;
            }
            char[] charArray = info.ToCharArray();
            Array.Reverse(charArray);
            info = new string(charArray);

            return info;
        }
        //--------------------------------------------------------------
        public string Decrypt(string info)
        {
            string data = "";
            string decrypted = "";
            var temp = info.ToCharArray();
            double count = 0;
            for (int i = 0; i < info.Length; i++)
            {
                if (temp[i] == 'O')
                {
                    count++;
                }
            }
            count = Math.Sqrt(count);
            double[,] first = new double[(int)count, (int)count];
            int p = 0, q = 0;
            int rowcolcount = 0;
            for (int i = 0; i < info.Length - 1; i++)
            {
                if (temp[i] != 'O')
                {
                    data = data + temp[i];
                    if (temp[i + 1] == 'O')
                    {
                        rowcolcount++;
                        //float msg = bintodec(data);
                        int msg = int.Parse(data, System.Globalization.NumberStyles.HexNumber);
                        first[p, q] = msg;
                        data = "";
                        if (rowcolcount == count)
                        {
                            rowcolcount = 0;
                            p++;
                            q = 0;
                        }
                        else
                        {
                            q++;
                        }
                    }
                }
            }



            int rowcol = (int)count;
            double[,] second = new double[6, 6] { { 0.175680, -0.196381, -0.004311, -0.217032, 0.032229,  0.112225 },
                                                  { 0.180242, -0.115032, -0.151070, -0.001554, 0.036489,  0.072628 },
                                                  { 0.069570,  0.185855,  0.036239,  0.033883, 0.043005, -0.164403 },
                                                  {-0.058142, -0.091925,  0.145506,  0.000501,-0.076287,- 0.055686 },
                                                  { 0.349707, -0.169515, -0.219137, -0.149566,-0.035988,  0.216831 },
                                                  {-0.653150,  0.307002,  0.235427,  0.341837,-0.027668,  0.021854 }
                                                };
            //multiply
            double[,] multiply = new double[6, 6];
            double sum = 0;
            long m = 6, c, d, k;
            p = 6; q = 6;
            for (c = 0; c < m; c++)
            {
                for (d = 0; d < q; d++)
                {
                    for (k = 0; k < p; k++)
                    {
                        sum = sum + (first[c, k] * second[k, d]);
                    }
                    multiply[c, d] = (int)(sum + 0.01);
                    sum = 0;
                }
            }

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (multiply[i, j] != 32)
                        decrypted = decrypted + Convert.ToString((char)multiply[i, j]);
                }
            return decrypted;
        }

         }
}
