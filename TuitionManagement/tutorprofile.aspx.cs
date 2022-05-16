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
    public partial class tutorprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){
            GetTutor();

            }
        }

        
        








        public void GetTutor()
        {
            
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tutor_reg where t_username='" + Session["username"] + "';", con);


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var details = new TutorRegister();
                     t_TextName.Text = reader[2].ToString();
                     TextEmail.Text = reader[6].ToString();
                     TextContact.Text = reader[5].ToString();
                     TextGender.Text = reader[4].ToString();
                     TextIC.Text = reader[1].ToString();
                     DateTime date = Convert.ToDateTime(reader[3].ToString());
                     TextDOB.Text = date.ToString("yyyy-MM-dd");
                     TextUser.Text = reader[8].ToString();
                     TextAddress.Text = reader[7].ToString();


                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                TextPassword.Text = AesOperation.DecryptString(key, reader[9].ToString());

               // TextPassword.Text = reader[9].ToString();
                }
               

        }




        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string name = t_TextName.Text;
            string dob = TextDOB.Text;
            string contact = TextContact.Text;
            string address = TextAddress.Text;
            string pass = TextPassword.Text;
            updateProfile();
        }



        void updateProfile()
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE tutor_reg SET fullname = @fullname,dob = @dateofbirth, contact_no=@contact_no,  full_address=@full_address, t_pass=@t_pass  WHERE email='" + TextEmail.Text.Trim() + "';", con);



                cmd.Parameters.AddWithValue("@fullname", t_TextName.Text );
                cmd.Parameters.AddWithValue("@dateofbirth", TextDOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextContact.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextAddress.Text.Trim());


                var encryptedNSPass = AesOperation.EncryptString(key, TextNewPass.Text.Trim());
                var encryptedSPass = AesOperation.EncryptString(key, TextPassword.Text.Trim());


                if (TextNewPass.Text.Trim().Length!=0)
                {
                    cmd.Parameters.AddWithValue("@t_pass", encryptedNSPass);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@t_pass", encryptedSPass);
                }



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Teacher Updated Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        //generate attendance but
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutorgenattendance.aspx");
        }
        //regsubjbut
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutorregistersubj.aspx");
        }
        //timetablebut
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutortimetable.aspx");
        }
        //viewhomeworkbut
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutorviewhomework.aspx");
        }
        //classbut
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutorclass.aspx");
        }
        //salarybut
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutorsalary.aspx");
        }
    }
}