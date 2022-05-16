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
    public partial class AdminStudentVerification : System.Web.UI.Page 
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //username
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (checkStudentExist())
            {
                getStudent();
                
            }
            else
            {
                Response.Write("<script>alert('User Not Exist');</script>");
            }
        }
        //active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateStatus("Active");
        }
        //pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateStatus("Pending");
        }
        //deactive
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateStatus("Deactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteStudent();
        }

        //userdefined

        void deleteStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM student_reg WHERE icnumber='" + TextBox5.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student Deleted Successful');</script>");
                
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void updateStatus(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE student_reg SET s_status='" +status+ "' WHERE s_username= '" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();

                Response.Write("<script>alert('Status Updated');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void getStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM student_reg WHERE s_username='" + TextBox1.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(2).ToString();
                        TextBox7.Text = dr.GetValue(12).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox3.Text = dr.GetValue(4).ToString();
                        TextBox4.Text = dr.GetValue(5).ToString();
                        TextBox5.Text = dr.GetValue(1).ToString();
                        TextBox9.Text = dr.GetValue(7).ToString();
                        TextBox10.Text = dr.GetValue(8).ToString();
                        TextBox11.Text = dr.GetValue(9).ToString();
                        TextBox6.Text = dr.GetValue(10).ToString();

                    }
                  
                }
                else
                {
                    Response.Write("<script>alert('Student Doesn't Exist');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkStudentExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from student_reg where s_username='" + TextBox1.Text.Trim() + "';", con);


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
}