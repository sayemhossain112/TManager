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
    public partial class tutorclass : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                 fillTable();
            }

        }
        
        void fillTable()
        {

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    {
                    var s = Session["username"].ToString();
                   
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM subjectregister where tutorname=(select fullname from tutor_reg where t_username= '" + s+ "')"))
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM subjectregister WHERE id='" + TextBox1.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                var s = dt.Rows.Count;
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox4.Text = dt.Rows[0][3].ToString();
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

        void clearForm()
        {
            TextBox1.Text = "";
            
        }
    }
}