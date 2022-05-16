<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tutorregistersubj.aspx.cs" Inherits="TuitionManagement.tutorregistersubj" %>
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
                                        <h4>Subject Register</h4>
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
                             
                             <div class="col-md-6">
                                <label>Subject Register Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Tutor Name</label>
                                <div class="form-group">
                                       <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                          <asp:ListItem Text="Tutor 1" Value="Tutor 1" />
                                          <asp:ListItem Text="Tutor 2" Value="Tutor 2" />
                                       </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-5">
                                <label>Subject Name</label>
                                <div class="form-group">
                                    <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Tutor 1" Value="Sub 1" />
                              <asp:ListItem Text="Tutor 2" Value="Sub 2" />
                           </asp:DropDownList>
                        </div>
                                </div>
                            </div>

                            <div class="col-md-7">
                                <label>Class Name</label>
                                <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                              <asp:ListItem Text="Class 1" Value="Tutor 1" />
                              <asp:ListItem Text="Class 2" Value="Tutor 2" />
                           </asp:DropDownList>
                        </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Added_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_Click" />
                            </div>
                        </div>


                    </div>
                </div>

                
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Subject List</h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT [studentname], [tutorname], [classname], [subjectname], [id] FROM [subjectregister] WHERE ([tutorname] LIKE '%' + @tutorname + '%')">
                                <SelectParameters>
                                    <asp:SessionParameter Name="tutorname" SessionField="username" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <div class="col">
                                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: auto;">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:BoundField DataField="tutorname" HeaderText="tutorname" SortExpression="tutorname" />
                                        <asp:BoundField DataField="classname" HeaderText="classname" SortExpression="classname" /> 
                                        <asp:BoundField DataField="subjectname" HeaderText="subjectname" SortExpression="subjectname" /> 
                                        <asp:BoundField DataField="studentname" HeaderText="studentname" SortExpression="studentname" />
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
