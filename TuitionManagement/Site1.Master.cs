using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TuitionManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (Session["role"]==null)
                {
                    LinkButton1.Visible = true; //loginbutton
                    LinkButton2.Visible = true; //singupbutton
                    LinkButton3.Visible = false; //logoutbutton
                    LinkButton7.Visible = false; //hello user
                    LinkButton4.Visible = false; //view profile
                    LinkButton6.Visible = true; //admin foot
                    LinkButton11.Visible = true; //tutor foot
                    LinkButton12.Visible = true; //stud foot
                    LinkButton8.Visible = false; //hw foot
                    LinkButton9.Visible = false; //timetable foot
                   


                }
                else if (Session["role"].Equals("student"))
                {
                    LinkButton1.Visible = false; //loginbutton
                    LinkButton2.Visible = false; //singupbutton
                    LinkButton3.Visible = true; //logoutbutton
                    LinkButton4.Visible = true; //view profile
                    LinkButton7.Visible = true; //hello user
                    LinkButton7.Text = "Hello " +Session["username"].ToString(); //hello user


                    LinkButton6.Visible = false; //admin foot
                    LinkButton11.Visible = false; //tutor foot
                    LinkButton12.Visible = false; //stud foot
                    LinkButton8.Visible = true; //hw foot
                    LinkButton9.Visible = true; //timetable foot
                }
                else if (Session["role"].Equals("tutor"))
                {
                    LinkButton1.Visible = false; //loginbutton
                    LinkButton2.Visible = false; //singupbutton
                    LinkButton3.Visible = true; //logoutbutton
                    LinkButton4.Visible = true; //view profile
                    LinkButton7.Visible = true; //hello user
                    LinkButton7.Text = "Hello " + Session["username"].ToString(); //hello user


                    LinkButton6.Visible = false; //admin foot
                    LinkButton11.Visible = false; //tutor foot
                    LinkButton12.Visible = false; //stud foot
                    LinkButton8.Visible = false; //hw foot
                    LinkButton9.Visible = false; //timetable foot
                }


                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //loginbutton
                    LinkButton2.Visible = false; //singupbutton
                    LinkButton3.Visible = true; //logoutbutton
                    LinkButton4.Visible = true; //view profile
                    LinkButton7.Visible = true; //hello user
                    LinkButton7.Text = "Hello Admin"; //hello user


                    LinkButton6.Visible = false; //admin foot
                    LinkButton11.Visible = false; //tutor foot
                    LinkButton12.Visible = false; //stud foot
                    LinkButton8.Visible = false; //hw foot
                    LinkButton9.Visible = false; //timetable foot
                }
            }
            catch(Exception ex)
            {

            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("tutorlogin.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentlogin.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("studhomework.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("studtimetable.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentregister.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("admin"))
            {
                Response.Redirect("adminprofile.aspx");
            }
            else if (Session["role"].Equals("student"))
            {
                Response.Redirect("studentprofile.aspx");
            }
            else if (Session["role"].Equals("tutor"))
            {
                Response.Redirect("tutorprofile.aspx");
            }
        }





        //logout
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true; //loginbutton
            LinkButton2.Visible = true; //singupbutton
            LinkButton3.Visible = false; //logoutbutton
            LinkButton4.Visible = false; //view profile
            LinkButton7.Visible = false; //hello user
            LinkButton6.Visible = true; //admin foot
            LinkButton11.Visible = true; //tutor foot
            LinkButton12.Visible = true; //stud foot
            LinkButton8.Visible = false; //hw foot
            LinkButton9.Visible = false; //timetable foot
            Response.Redirect("homepage.aspx");
        }
        
    }
}