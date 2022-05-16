<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tutorviewhomework.aspx.cs" Inherits="TuitionManagement.tutorviewhomework" %>
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
                           <h4>Homework Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" height="150px" width="100px" src="homework_file/homework.png" />
                            
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
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Homework ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Homework Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Homework Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Subject</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Mathematic" Value="Math" />
                              <asp:ListItem Text="English" Value="Eng" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Bahasa Melayu" Value="BM" />
                              <asp:ListItem Text="AddMath " Value="AddMath" /> 
                           </asp:DropDownList>
                        </div>
                   
                     </div>
                     <div class="col-md-6">
                             <label>Tutor Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Tutor 1" Value="Tutor 1" />
                              <asp:ListItem Text="Tutor 2" Value="Tutor 2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                      </div>
                   <div class="row">
                     <div class="col-6">
                        <label>Class Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Class Name"></asp:TextBox>
                          </div>
                         <div class="form-group" hidden>
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="id"></asp:TextBox>
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder=" "></asp:TextBox>
                         </div>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col-12">
                        <label>Homework Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Homework Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                         </div>
                     </div>
                  </div>
                      

                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-info" runat="server" Text="Download" OnClick="DownloadFile" />
                     </div>
                   
                  </div>
               </div>
            </div>
               <center style="margin-top:10px">
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Homework List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
<div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT * FROM [studenthomework_table]"></asp:SqlDataSource>
                     <div class="col">
                         <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: auto;">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="homework_id" DataSourceID="SqlDataSource1" >
                            <Columns>
                                <asp:BoundField DataField="homework_id" HeaderText="Homework ID" ReadOnly="True" SortExpression="homework_id" />
                                <asp:BoundField DataField="homework_name" HeaderText="Homework Name" SortExpression="homework_name" />
                                <asp:BoundField DataField="subject_name" HeaderText="Subj Name" SortExpression="subject_name" />
                                <asp:BoundField DataField="tutor_name" HeaderText="Tutor Name" SortExpression="tutor_name" />
                                <asp:BoundField DataField="homework_desc" HeaderText="Description" SortExpression="homework_desc" />
                                <asp:BoundField DataField="homework_file" HeaderText="File" SortExpression="homework_file" />
                              
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
