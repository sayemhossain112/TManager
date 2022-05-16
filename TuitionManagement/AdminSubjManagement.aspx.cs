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
    public partial class AdminSubjManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                GetSubject();
            }
              
        }

        protected void AddButtonClick(object sender, EventArgs e)
        {
            if (checkSubExist())
            {
                Response.Write("<script>alert('Sub Already Used');</script>");
            }
            else
            {
                AddSubject();
            }
        }
        //user defined

        bool checkSubExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from subjects where SubjectName='" + TextSubject.Text.Trim() + "';", con);


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


        void AddSubject()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT into subjects(SubjectName) values (@Subject )", con);

                cmd.Parameters.AddWithValue("@Subject", TextSubject.Text.Trim()); 

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Subject Add Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }



        public void GetSubject()
        {

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            string CommandText = "Select * from subjects";

            SqlCommand cmd = new SqlCommand(CommandText, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            GridView1.DataSource = dt;

            GridView1.DataBind();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            updateSub();
        }


        void updateSub()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE subjects SET SubjectName = @subname WHERE SubjectId='" + TextSubId.Text.Trim() + "';", con);



                cmd.Parameters.AddWithValue("@subname", TextSubject.Text); 

 



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Subject Updated Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteSub();
            GetSubject();
        }


        void DeleteSub()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM subjects WHERE SubjectId='" + TextSubId.Text.Trim() + "';", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Subject Deleted Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}