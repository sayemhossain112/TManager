<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminprofile.aspx.cs" Inherits="TuitionManagement.adminprofile" %>
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
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextUser" runat="server" placeholder="Username" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                   

                    
                     <div class="col-md-4">
                        <label>Old Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextPass" runat="server" placeholder="Old Password" ReadOnly="true"></asp:TextBox>
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
                           <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
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
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button4" runat="server" Text="Student Management" OnClick="Button4_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button3" runat="server" Text="Subject Management" OnClick="Button3_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button2" runat="server" Text="Tutor Management" OnClick="Button2_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button9" runat="server" Text="Class Management" OnClick="Button9_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button6" runat="server" Text="Class Assigned" OnClick="Button6_Click"/>
                         <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button5" runat="server" Text="Student Verification" OnClick="Button5_Click" />
                     </div>
                  </div>

          
                     

                     </div>
               </div>

          </div>
       
      </div>
   </div>


</asp:Content>
