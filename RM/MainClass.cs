using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM
{
    internal class MainClass
    {
        public static readonly string con_string = "Data Source=LAPTOP-REF0F8RT\\SQLEXPRESS\r\n; Initial Catalog=RM;Persist Security Info=True; User ID=sa; Password=huynhtrongnguyen739904 ";
        public static SqlConnection con = new SqlConnection(con_string);

        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;
            string qry = "SELECT * FROM users WHERE username = @user AND upass = @pass";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["uName"].ToString();
            }
            return isValid;
        }
        // create property for username
        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
        //method for opearation
        public static int SQl(string qry, Hashtable ht)
        {
            int res = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            return res;
        }

        //for loading data from database
        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();

                }
                gv.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }
    }
 
}
