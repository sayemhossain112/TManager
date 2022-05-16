<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TutorRegister.aspx.cs" Inherits="TuitionManagement.TutorRegister" %>
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
                           <img width="100px" src="img/Teacher.jpg"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Tutor Registration</h4>
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
                             <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                            <asp:ListItem Text="Male" Value="Male" />
                                 <asp:ListItem Text="Female" Value="Female" />

                             </asp:DropDownList>
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
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"/>
                        </div>
                     </div>
                   </div>

                     

                     </div>
                  </div>
            </div>
          
               <center style="margin-top:10px"><br>
         </div>
      </div>

</asp:Content>
