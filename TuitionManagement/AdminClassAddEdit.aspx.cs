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
    public partial class AdminClassAddEdit : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add button
        protected void Added_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                Response.Write("<script>alert('Class Name');</script>");
            }
            else
            {
                addNewStudent();
            }
        }
        //update
        protected void Update_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                updateStudent();

            }
            else
            {
                Response.Write("<script>alert('Class Not Exist');</script>");
            }
        }
        //delete
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (checkStudExist())
            {
                deleteStudent();

            }
            else
            {
                Response.Write("<script>alert('Class Not Exist');</script>");
            }
        }
        //search button
        protected void ButtonSearch_Click(object sender, EventArgs e)
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM ClassList WHERE ClassId='" + TextBox2.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Class Not Exist');</script>");
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

                SqlCommand cmd = new SqlCommand("DELETE FROM ClassList WHERE ClassId='" + TextBox2.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Class Deleted Successful');</script>");
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

                SqlCommand cmd = new SqlCommand("UPDATE ClassList SET ClassId = @classid,ClassName=@classname WHERE classid='" + TextBox2.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@classid", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@classname", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Class Updated Successful');</script>");
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

                SqlCommand cmd = new SqlCommand("insert into ClassList(ClassId,ClassName) values ('" + TextBox2.Text.Trim() + "','" + TextBox3.Text.Trim() + "')", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Class Add Successful');</script>");
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

                    SqlCommand cmd = new SqlCommand("SELECT * from ClassList where ClassId='" + TextBox2.Text.Trim() + "';", con);


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
             TextBox2.Text = "";
             TextBox3.Text = "";
         }
    }
}