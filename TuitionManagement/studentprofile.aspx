<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="studentprofile.aspx.cs" Inherits="TuitionManagement.studentprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
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
                           <h4>Profile</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                     <div class="col-md-4">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextName" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-4">
                         <label>Date Of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Textdob" runat="server" placeholder="Date Of Birth" TextMode="Date"></asp:TextBox>
                     </div>
                  </div>

                         <div class="col-md-4">
                         <label>Gender</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextGender" runat="server" placeholder="Gender" ReadOnly="True"></asp:TextBox>
                     </div>
                  </div>
              </div>

                   <div class="row">
                     <div class="col-md-4">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextContact" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-4">
                         <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                     </div>
                  </div>

                         <div class="col-md-4">
                         <label>IC Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextIC" runat="server" placeholder="IC Number" ReadOnly="True"></asp:TextBox>
                     </div>
                  </div>
              </div>

                   <div class="row">
                     <div class="col-md-4">
                        <label>Parents Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextParentName" runat="server" placeholder="Parents Name"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col-md-4">
                         <label>Parent Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextParentContact" runat="server" placeholder="Parents Contact Number" TextMode="Number"></asp:TextBox>
                     </div>
                  </div>

                         <div class="col-md-4">
                         <label>Parent IC Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextParentIc" runat="server" placeholder="Parents IC Number" TextMode="Number" ReadOnly="True"></asp:TextBox>
                     </div>
                  </div>
              </div>

                   <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                     </div>
                   </div>
            
                   <div class="row">
                     <div class="col-md-4">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextUserName" runat="server" placeholder="Username" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                   

                    
                     <div class="col-md-4">
                        <label>Old Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextPassword" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                   

                    
                     <div class="col-md-4">
                        <label>New Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextNewPass" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                   </div>

                   <div class="row">
                     <div class="col">
                         <center>
                        <div class="form-group">
                           <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                        </div>
                        </center>
                     </div>
                   </div>

                     

                     </div>
                  </div>
            
          
            
         </div>

          <div class="col-md-7">
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
                           <h4>Option</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                     
                   
                   <div class="row">
                     <div class="col">
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button4" runat="server" Text="Attendance" OnClick="Button4_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button3" runat="server" Text="Register Class" OnClick="Button3_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button2" runat="server" Text="Timetable" OnClick="Button2_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button6" runat="server" Text="Homework" OnClick="Button6_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button5" runat="server" Text="Payment Fee" OnClick="Button5_Click" />
                     </div>
                  </div>

          
                     

                     </div>
               </div>

          </div>
       
      </div>
   </div>


</asp:Content>
