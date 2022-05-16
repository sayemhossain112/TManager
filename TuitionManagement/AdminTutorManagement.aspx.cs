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
    public partial class AdminTutorManagement : System.Web.UI.Page
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
                addNewteacher();
            }
        }
        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                updateteacher();

            }
            else
            {
                Response.Write("<script>alert('teacher Not Exist');</script>");
            }
        }
        //delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                deleteteacher();

            }
            else
            {
                Response.Write("<script>alert('teacher Not Exist');</script>");
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM tutor_reg WHERE icnumber='" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][2].ToString();
                    TextBox3.Text = dt.Rows[0][8].ToString();

                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var pasN = AesOperation.DecryptString(key, dt.Rows[0][9].ToString());
                    TextBox4.Text = pasN;
                }
                else
                {
                    Response.Write("<script>alert('teacher Not Exist');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void deleteteacher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM tutor_reg WHERE icnumber='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('teacher Deleted Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }
        void updateteacher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE tutor_reg SET fullname = @fullname,t_username=@t_username, t_pass=@t_pass WHERE icnumber='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@icnumber", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@fullname", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@t_username", TextBox3.Text.Trim());

                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                var pasN = AesOperation.EncryptString(key, TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@t_pass", pasN);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('teacher Updated Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        void addNewteacher()
        {




            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into tutor_reg(icnumber,fullname,t_username,t_pass) values ('" + Convert.ToInt32(TextBox1.Text.Trim()) + "','" + TextBox2.Text.Trim() + "','" + TextBox3.Text.Trim() + "','" + TextBox4.Text.Trim() + "')", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('teacher Add Successful');</script>");
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

                    SqlCommand cmd = new SqlCommand("SELECT * from tutor_reg where icnumber='" + TextBox1.Text.Trim() + "';", con);


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
//user defined
