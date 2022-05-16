<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="studentregister.aspx.cs" Inherits="TuitionManagement.studentregister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="img/graduate-student-icon-vector-6402261.jpg"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Student Registration</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <form action="Register_Click" method="post">

                   <div class="row">
                     <div class="col-md-4">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-4">
                         <label>Date Of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date Of Birth" TextMode="Date"></asp:TextBox>
                     </div>
                  </div>

                         <div class="col-md-4">
                         <label>Gender</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Gender"></asp:TextBox>
                     </div>
                  </div>
              </div>

                   <div class="row">
                     <div class="col-md-4">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-4">
                         <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                     </div>
                  </div>

                         <div class="col-md-4">
                         <label>IC Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="IC Number"></asp:TextBox>
                     </div>
                  </div>
              </div>

                   <div class="row">
                     <div class="col-md-4">
                        <label>Parents Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Parents Name"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-4">
                         <label>Parent Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Parents Contact Number" TextMode="Number"></asp:TextBox>
                     </div>
                  </div>

                         <div class="col-md-4">
                         <label>Parent IC Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Parents IC Number" TextMode="Number"></asp:TextBox>
                     </div>
                  </div>
              </div>

                   <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                   </div>
            
                   <div class="row">
                     <div class="col-md-6">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="Username"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextPass" runat="server" placeholder="Username"></asp:TextBox>
                        </div>
                     </div>
                   </div>

                   <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Register_Click" />
                        </div>
                     </div>
                   </div>

                     

                   </form>
                     </div>
                  </div>
            
           <center style="margin-top:10px">
            <a href="homepage.aspx">Back to Home</a><br><br>
               </center>
         </div>
      </div>
   </div>


</asp:Content>
