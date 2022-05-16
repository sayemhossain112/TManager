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
    public partial class AdminStudManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                Response.Write("<script>alert('Ic Number Already Used');</script>");
            }
            else
            {
                addNewStudent();
            }
        }
        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                updateStudent();

            }
            else
            {
                Response.Write("<script>alert('Student Not Exist');</script>");
            }
        }
        //delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                deleteStudent();

            }
            else
            {
                Response.Write("<script>alert('Student Not Exist');</script>");
            }
        }
        //search button
        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchBut();
        }



        //user defined
        void SearchBut()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM student_reg WHERE icnumber='" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var pasN = AesOperation.DecryptString(key, dt.Rows[0][13].ToString());
                    TextBox2.Text = dt.Rows[0][2].ToString();
                    TextBox3.Text = dt.Rows[0][11].ToString();
                    TextBox4.Text = pasN;
                 }
                else
                {
                    Response.Write("<script>alert('Student Not Exist');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }



        void deleteStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM student_reg WHERE icnumber='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student Deleted Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }
        void updateStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE student_reg SET fullname = @fullname,s_username=@s_username, s_pass=@s_pass WHERE icnumber='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@icnumber", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@fullname", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@s_username", TextBox3.Text.Trim());

                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var pasN = AesOperation.EncryptString(key, TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@s_pass", pasN);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student Updated Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        void addNewStudent()
        {




            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into student_reg(icnumber,fullname,s_username,s_pass) values ('"+Convert.ToInt32(TextBox1.Text.Trim())+ "','" +  TextBox2.Text.Trim() + "','" + TextBox3.Text.Trim() + "','" + TextBox4.Text.Trim() + "')", con);
 

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student Add Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }






           
        }

        bool checkStudExist()
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from student_reg where icnumber='" + TextBox1.Text.Trim() + "';", con);


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
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
}