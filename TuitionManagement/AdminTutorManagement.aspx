<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminTutorManagement.aspx.cs" Inherits="TuitionManagement.AdminTutorManagement" %>
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
                                        <h4>Tutor Details</h4>
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
                            <div class="col-md-5">
                                <label>Tutor IC</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-7">
                                <label>Tutor Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Tutor Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-md-6">
                                 <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="username"></asp:TextBox>

                                </div>
                            </div>
                             <div class="col-md-6">
                                 <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="password"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
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
                                        <h4>Tutor List</h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                       <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT * FROM [tutor_reg]"></asp:SqlDataSource>
                            <div class="col">
                                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: auto;">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="icnumber" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="icnumber" HeaderText="ICnumber" ReadOnly="True" SortExpression="icnumber" />
                                        <asp:BoundField DataField="fullname" HeaderText="Fullname" SortExpression="fullname" />
                                        <asp:BoundField DataField="dob" HeaderText="DateOfBirth" SortExpression="dateofbirth" />
                                        <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact Number" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                        <asp:BoundField DataField="full_address" HeaderText="Full Address" SortExpression="full_address" />
                                        <asp:BoundField DataField="t_username" HeaderText="Username" SortExpression="t_username" />
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
