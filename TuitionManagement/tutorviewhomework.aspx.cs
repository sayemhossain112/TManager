using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace TuitionManagement
{
    public partial class tutorviewhomework : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filltutorbox();
            }

            GridView1.DataBind();
        }
       
       
        //gobut
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getHomework();
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            if (TextBox7.Text != "")
            {
                int id = int.Parse(TextBox7.Text);
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select homework_file from studenthomework_table where homework_id=@homework_id";
                        cmd.Parameters.AddWithValue("@homework_id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if (TextBox11.Text != null)
                            {
                                string filePath = TextBox11.Text;
                                Response.ContentType = ContentType;
                                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                                Response.WriteFile(filePath);
                                Response.End();
                            }
                            else Response.Write("<script>alert('no homework found');</script>");
                        }
                        con.Close();
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Select First');</script>");
            }

            
             
        }

        //userdefined
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
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "fullname";
                DropDownList2.DataBind();

                cmd = new SqlCommand("SELECT subject_name FROM subject_table;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "subject_name";
                DropDownList1.DataBind();
            }
            catch
            {

            }

        }


     

        void getHomework()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from studenthomework_table WHERE homework_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["homework_name"].ToString();
                    TextBox6.Text = dt.Rows[0]["homework_desc"].ToString();
                    TextBox11.Text = dt.Rows[0]["homework_file"].ToString();
                    TextBox7.Text = dt.Rows[0]["id"].ToString();


                    DropDownList1.SelectedValue = dt.Rows[0]["subject_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["tutor_name"].ToString().Trim();
                    global_filepath = dt.Rows[0]["homework_file"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Homework ID');</script>");
                }
            }


            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkHomeworkExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from studenthomework_table where homework_id='" + TextBox1.Text.Trim() + "';", con);


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