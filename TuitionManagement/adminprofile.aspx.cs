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
    public partial class adminprofile : System.Web.UI.Page
    {


        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAdmin();

            }
        }

        public void GetAdmin()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * from adm_login where adm_username='" + Session["username"] + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var pasN = AesOperation.DecryptString(key, reader[2].ToString());

                TextUser.Text = reader[1].ToString();
                TextPass.Text = pasN;
            }
        }




        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            
            updatePass();
        }



        void updatePass()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE adm_login SET adm_password=@pass WHERE adm_username='" + TextUser.Text.Trim() + "';", con);


                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var pasN = AesOperation.EncryptString(key, TextNewPass.Text.Trim());
                var pas = AesOperation.EncryptString(key, TextPass.Text.Trim());




                if (TextNewPass.Text.Trim().Length != 0)
                {
                    cmd.Parameters.AddWithValue("@pass", pasN);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@t_pass", pas);
                }



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Password Updated Successful');</script>");
                GetAdmin();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        //StudManage
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStudManagement.aspx");
        }
        //subjmanage
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSubjManagement.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminTutorManagement.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminClassManagement.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminStudentVerification.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminClassAddEdit.aspx");
        }
    }
}