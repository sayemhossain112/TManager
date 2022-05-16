using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TuitionManagement
{
    public partial class studhomework : System.Web.UI.Page
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
        //addbut
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkHomeworkExist())
            {
                Response.Write("<script>alert('Homework Already Exist, try other homework ID');</script>");
            }
            else
            {
                addHomework();
            }
        }
        //updatebut
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateHomework();
        }
        //deletebut
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteHomework();
        }
        //gobut
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getHomework();
        }

        /*protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
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
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        */
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

        void addHomework()
        {
            try
            {

                //file upload
               string filepath = "~/homework_file/homework.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("homework_file/" + filename));
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;

                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("homework_file/" + filename));
                    filepath = "~/homework_file/" + filename;
                }
               


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO studenthomework_table(homework_id," +
                "homework_name,subject_name,tutor_name,homework_desc,homework_file)" +
                "VALUES (@homework_id,@homework_name,@subject_name,@tutor_name,@homework_desc,@homework_file)", con);

                cmd.Parameters.AddWithValue("@homework_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@homework_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@subject_name", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@tutor_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@homework_desc", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@homework_file ",filepath);

               

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Homework Uploaded');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        

           }

        void deleteHomework()
        {
            if (checkHomeworkExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from studenthomework_table WHERE homework_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Homework Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Homework ID');</script>");
            }
        }

        void updateHomework()
        {
            if (checkHomeworkExist())
            {
                try
                {


                    string filepath = "~/homework_file/homework.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("homework_file/" + filename));
                        filepath = "~/homework_file/" + filename;
                    }
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE studenthomework_table SET homework_name=@homework_name, subject_name=@subject_name, tutor_name=@tutor_name, homework_desc=@homework_desc, homework_file=@homework_file WHERE homework_id='"+TextBox1.Text.Trim()+"'", con);

                    cmd.Parameters.AddWithValue("@homework_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@subject_name", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@tutor_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@homework_desc", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@homework_file ", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Homework Updated Successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Homework ID');</script>");
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
                  

                    DropDownList1.SelectedValue = dt.Rows[0]["subject_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["tutor_name"].ToString().Trim();
                    global_filepath = dt.Rows[0]["homework_file"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Homework ID');</script>");
                }
                }


            catch(Exception ex)
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