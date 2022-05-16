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
    public partial class studregclass : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                fillTable();
                filltutorbox();
             }

        }
        void filltutorbox()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT fullname FROM tutor_reg;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "fullname";
                DropDownList1.DataBind();

                cmd = new SqlCommand("SELECT SubjectName FROM subjects;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "SubjectName";
                DropDownList2.DataBind();


                cmd = new SqlCommand("SELECT ClassName FROM ClassList;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "ClassName";
                DropDownList3.DataBind();
            }
            catch
            {

            }

        }
        void fillTable()
        {

            using (SqlConnection con = new SqlConnection(strcon))
            {
                {
                    var s = Session["username"].ToString();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM subjectregister where studentname=(select s_username from student_reg where s_username= '" + s + "')"))
                    {
                        SqlDataAdapter dt = new SqlDataAdapter();
                        try
                        {
                            cmd.Connection = con;
                            con.Open();
                            dt.SelectCommand = cmd;

                            DataTable dTable = new DataTable();
                            dt.Fill(dTable);

                            GridView1.DataSource = dTable;
                            GridView1.DataBind();
                        }
                        catch (Exception)
                        {
                            //     
                        }
                    }
                }
            }



        }





        //update

        //delete
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (checkExist())
            {
                deleteRecord();

            }
            else
            {
                Response.Write("<script>alert('Not Exist');</script>");
            }
            fillTable();
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM subjectregister WHERE id='" + TextBox1.Text.Trim() + "' and studentname='"+Session["username"]+"'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                var s = dt.Rows.Count;
                
                if (dt.Rows.Count >= 1)
                {
                    var s1 = dt.Rows[0][1].ToString();
                    var s2 = dt.Rows[0][2].ToString();
                    var s3 = dt.Rows[0][3].ToString();
                    DropDownList1.Text = s3;
                    DropDownList2.Text = s1;
                    DropDownList3.Text = s2;
                }
                else
                {
                    Response.Write("<script>alert('Not Exist');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        void deleteRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM subjectregister WHERE id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Deleted Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
            fillTable();
        }




        bool checkExist()
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from subjectregister where id='" + TextBox1.Text.Trim() + "';", con);


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

 

        protected void Added_Click(object sender, EventArgs e)
        {
            if (checkExist())
            {
                Response.Write("<script>alert('Name Exists');</script>");
            }
            else
            {
                addRecord();
            }
        }
     
        
        //update
        protected void Update_Click(object sender, EventArgs e)
        {
            if (checkExist())
            {
                updateRecord();

            }
            else
            {
                Response.Write("<script>alert('Class Not Exist');</script>");
            }
        }
        //delete
       




        //user defined
       
        void updateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE subjectregister SET subjectname = @subjectname,classname=@classname ,tutorname=@tutorname WHERE id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@subjectname", DropDownList2.Text);
                cmd.Parameters.AddWithValue("@classname", DropDownList3.Text);
                cmd.Parameters.AddWithValue("@tutorname", DropDownList1.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Updated Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        void addRecord()
        { 

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                //sayem edit this
                SqlCommand cmd = new SqlCommand("insert into subjectregister(tutorname, subjectname,classname,studentname) values ('" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + DropDownList3.SelectedValue + "','"+Session["username"]+"')", con);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [dbo].[fee] ([tutorname] ,[studentname] ,[classname] ,[subjectname]  ,[fee] ,[statues]) VALUES('" + DropDownList1.SelectedValue + "','" + Session["username"] + "','" + DropDownList3.SelectedValue + "','" + DropDownList2.SelectedValue + "',1000,'pending')", con);


                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Add Successful');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }







        }

       
        void clearForm()
        {
            TextBox1.Text = "";
        }
    }
}
