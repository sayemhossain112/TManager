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
    public partial class studentprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    {
                    //getUserPersonalDetails();
                    GetProfile();
                    }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }





        public void GetProfile()
        {

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from student_reg where s_username='" + Session["username"] + "';", con);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var details = new TutorRegister();
                TextIC.Text = reader[1].ToString();
                TextName.Text = reader[2].ToString();
                DateTime date = Convert.ToDateTime(reader[3].ToString());
                Textdob.Text = date.ToString("yyyy-MM-dd");
                TextGender.Text = reader[4].ToString();
                TextContact.Text = reader[5].ToString();
                TextEmail.Text = reader[6].ToString();
                TextParentName.Text = reader[7].ToString();
                TextParentContact.Text = reader[8].ToString();
                TextParentIc.Text = reader[9].ToString();
                TextAddress.Text = reader[10].ToString();
                TextUserName.Text = reader[11].ToString();




                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                TextPassword.Text = AesOperation.DecryptString(key, reader[13].ToString());

                // TextPassword.Text = reader[9].ToString();


               // TextPassword.Text = reader[13].ToString();
               
                 
            }


        }






        //homeworkbut
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("studhomework.aspx");
        }
        //attendancebut
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentattendance.aspx");
        }
        //regclassbut
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("studregclass.aspx");
        }
        //timetablebut
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("studtimetable.aspx");
        }
        //feepaymentbut
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeePayment.aspx");
        }




        //updatebutton
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateStudent();
        }


        //userdefined

        void updateStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE student_reg SET fullname = @fullname,dateofbirth = @dateofbirth, contact_no=@contact_no, email=@email, parent_name=@parent_name, p_contact_no=@p_contact_no, full_address=@full_address, s_pass=@s_pass  WHERE email='" +TextEmail.Text.Trim() + "';", con);



                cmd.Parameters.AddWithValue("@fullname", TextName.Text.Trim());
                cmd.Parameters.AddWithValue("@dateofbirth", Textdob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextContact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@parent_name", TextParentName.Text.Trim());
                cmd.Parameters.AddWithValue("@p_contact_no", TextParentContact.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextAddress.Text.Trim());


                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var encryptedNSPass = AesOperation.EncryptString(key, TextNewPass.Text.Trim());
                var encryptedSPass = AesOperation.EncryptString(key, TextPassword.Text.Trim());


                if (TextNewPass.Text.Trim() != null)
                {
                    cmd.Parameters.AddWithValue("@s_pass", encryptedNSPass);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@s_pass", encryptedSPass);
                }



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student Updated Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        /*void getDetails()
         {
             try
             {
                 SqlConnection con = new SqlConnection(strcon);
                 if (con.State == ConnectionState.Closed)
                 {
                     con.Open();
                 }

                 SqlCommand cmd = new SqlCommand("SELECT * FROM student_reg where s_username='" + Session["username"].ToString() + "';", con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);

                 TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                 TextBox2.Text = dt.Rows[0]["dateofbirth"].ToString();
                 TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                 TextBox4.Text = dt.Rows[0]["email"].ToString();
                 TextBox7.Text = dt.Rows[0]["icnumber"].ToString();
                 TextBox5.Text = dt.Rows[0]["parent_name"].ToString();
                 TextBox6.Text = dt.Rows[0]["p_contact_no"].ToString();
                 TextBox9.Text = dt.Rows[0]["p_icnumber"].ToString();
                 TextBox8.Text = dt.Rows[0]["gender"].ToString();
                 TextBox10.Text = dt.Rows[0]["full_address"].ToString();



             }
             catch (Exception ex)
             {
                 Response.Write("<script>alert('" + ex.Message + "');</script>");

             }

         }*/

        //void getUserPersonalDetails()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(strcon);
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }

        //        SqlCommand cmd = new SqlCommand("SELECT * from student_reg where s_username='" + Session["username"].ToString() + "';", con);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        TextBox1.Text = dt.Rows[0]["full_name"].ToString();
        //        TextBox2.Text = dt.Rows[0]["dateofbirth"].ToString();
        //        TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
        //        TextBox4.Text = dt.Rows[0]["email"].ToString();
        //        TextBox7.Text = dt.Rows[0]["icnumber"].ToString();
        //        TextBox5.Text = dt.Rows[0]["parent_name"].ToString();
        //        TextBox6.Text = dt.Rows[0]["p_contact_no"].ToString();
        //        TextBox9.Text = dt.Rows[0]["p_icnumber"].ToString();
        //        TextBox8.Text = dt.Rows[0]["gender"].ToString();
        //        TextBox10.Text = dt.Rows[0]["full_address"].ToString();


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");

        //    }
        //}


    }
}
