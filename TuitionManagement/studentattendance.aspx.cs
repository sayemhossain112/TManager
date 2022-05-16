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
    public partial class studentattendance : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                filltutorbox();
                GridView1.DataBind();
            }
        }


        void filltutorbox()
        {
            
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * FROM genAtten where id=(select max(id) from genAtten)", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        TextBox1.Text = dt.Rows[0]["sub_name"].ToString();
                        TextBox2.Text = dt.Rows[0]["class_name"].ToString();

                        imgageQRCode.Visible = true;

                        imgageQRCode.ImageUrl = dt.Rows[0]["atten_file"].ToString();

                }
                    else
                    {
                        Response.Write("<script>alert('Not Found');</script>");
                    }
                }


                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(checkExist())
            {
                AddAttendanceConfirm();
               
            }
            else
            {
                Response.Write("<script>alert('Not Matched1');</script>");
            }
        }



        bool checkExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from genAtten where otp_num='" + TextBox3.Text.Trim() + "';", con);


                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    string s = TextBox3.Text;
                   // TextBox3.Text = dt.Rows[0]["otp_num"].ToString();
                    if(dt.Rows[0]["otp_num"].ToString() == s)
                    {
                        return true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Not Matched');</script>");
                        return false;
                    }

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

        void AddAttendanceConfirm()
        {
            try
            {

                if (checkExist())
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }



                    SqlCommand cmd = new SqlCommand("INSERT INTO AttendanceTbl(studentName,attendate,attenstatus,sub_name,class_name,otp_num) values (@studentName, @attendate, @attenstatus, @sub_name, @class_name, @otp_num)", con);

                    cmd.Parameters.AddWithValue("@studentName", Session["username"]);
                    cmd.Parameters.AddWithValue("@attendate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@attenstatus", "Success");
                    cmd.Parameters.AddWithValue("@sub_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@class_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@otp_num", TextBox3.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Attedance Successful');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Not Found');</script>");

                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}