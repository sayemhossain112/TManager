<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminClassAddEdit.aspx.cs" Inherits="TuitionManagement.AdminClassAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Class Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="img/istockphoto-1270303682-612x612.jpg" />
                                 </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                           
                            <div class="col-md-12">
                                <label>Class Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                     <div class="col-md-6">
                        <label>Class Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Class Name" ></asp:TextBox>
                        </div>
                     </div>
                  </div>

                     
                   <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Added_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_Click" />
                            </div>
                        </div>
                </div>
           
                
                <br>
            </div>
            
            </div>
            

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Class List</h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT * FROM [ClassList]"></asp:SqlDataSource>
                            <div class="col">
                                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: auto;">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                                        <asp:BoundField DataField="ClassId" HeaderText="ClassId" SortExpression="ClassId" />
                                        <asp:BoundField DataField="ClassName" HeaderText="ClassName" SortExpression="ClassName" /> 
                                    </Columns>
                                    
                                </asp:GridView>
                                    </div>
                            </div>
                        </div>


                    </div>
                </div>


            </div>

        
    </div>
</div>
</asp:Content>
