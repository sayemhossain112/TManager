using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace TuitionManagement
{
    public partial class tutorgenattendance : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["tuitionDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                GridView1.DataBind();
            }

        }



     
      
        private void GenerateMyQCCode(string sub, string clas, string otp)
        {
            var str = sub + "__" + clas + "__" + "__" + otp;




            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(str);
            string path = Server.MapPath("~/images/'" + str + "'.jpg");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path,
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            imgageQRCode.Visible = true;

            imgageQRCode.ImageUrl = "~/images/'" + str + "'.jpg";





            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[genAtten] (sub_name,class_name,otp_num,atten_file) VALUES (@sub_name,@class_name,@otp_num,@atten_file)", con);

            cmd.Parameters.AddWithValue("@sub_name", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@class_name", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@otp_num", TextBox11.Text.Trim());
            cmd.Parameters.AddWithValue("@atten_file", imgageQRCode.ImageUrl);



            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Qr Code Generated And Saved');</script>");

        }

        protected void btnQCGenerate_Click(object sender, EventArgs e)
        {
            string sub = TextBox1.Text;
            string clas = TextBox2.Text;
            string otp = TextBox11.Text;
            GenerateMyQCCode(sub, clas, otp);
        }

    }
}