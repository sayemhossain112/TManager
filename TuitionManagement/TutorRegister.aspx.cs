using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuitionManagement
{
    public partial class TutorRegister : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkTutorExist())
            {
                Response.Write("<script>alert('Username Already Used');</script>");
            }
            else
            {
                signupTutor();
            }
        }
        //user defined

        bool checkTutorExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tutor_reg where t_username='" + TextBox11.Text.Trim() + "';", con);


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


        void signupTutor()
        {
           
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT tutor_reg(icnumber," +
                "fullname,dob,gender,contact_no,email," +
                "full_address,t_username,t_pass) " +
                "values (@icnumber," +
                "@fullname,@dateofbirth,@gender,@contact_no,@email," +
                "@full_address,@t_username,@t_pass )", con);

                cmd.Parameters.AddWithValue("@icnumber", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@fullname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@t_username", TextBox11.Text.Trim());



                //Encrypt password
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var encryptedSPass = AesOperation.EncryptString(key, TextPass.Text.Trim());

                cmd.Parameters.AddWithValue("@t_pass", encryptedSPass);

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