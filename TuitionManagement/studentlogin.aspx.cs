using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuitionManagement
{
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //User login
        protected void StuLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var pas = AesOperation.EncryptString(key, TextBox2.Text.Trim());


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM student_reg where s_username ='" + TextBox1.Text.Trim() + "' AND s_pass ='" + pas + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful');</script>");
                        Session["username"] = dr.GetValue(11).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "student";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Username or Password Is Incorrect');</script>");
                }
            }


            catch (Exception ex)
            {

            }

            //Response.Write("<script>alert('Sign In Successful');</script>");
        }

        //user defined




    }
}