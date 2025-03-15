using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            if(dt.Rows.Count > 0)
            {
                isValid = true; 
            }
            return isValid;
        }
    }
}
