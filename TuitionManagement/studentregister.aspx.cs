using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuitionManagement
{
    public partial class studentregister : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //singup button
        protected void Register_Click(object sender, EventArgs e)
        {
            if (checkStudentExist())
            {
                Response.Write("<script>alert('Username Already Used');</script>");
            }
            else
            {
              signupNewUser();
            }
            
        }

        //user defined method
        bool checkStudentExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from student_reg where s_username='" + TextBox11.Text.Trim()+"';", con);
                
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void signupNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO student_reg(icnumber," +
                "fullname,dateofbirth,gender,contact_no,email," +
                "parent_name,p_contact_no,p_icnumber,full_address,s_username,s_status,s_pass" +
                "values (@icnumber," +
                "@fullname,@dateofbirth,@gender,@contact_no,@email," +
                "@parent_name,@p_contact_no,@p_icnumber,@full_address,@s_username,@s_status,@s_pass)", con);

                cmd.Parameters.AddWithValue("@icnumber", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@fullname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@parent_name", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@p_contact_no", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@p_icnumber", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@s_username", TextBox11.Text.Trim());


                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var encryptedSPass = AesOperation.EncryptString(key, TextPass.Text.Trim());


                cmd.Parameters.AddWithValue("@s_pass", encryptedSPass);
                cmd.Parameters.AddWithValue("@s_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}