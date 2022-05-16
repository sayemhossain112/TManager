<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tutorclass.aspx.cs" Inherits="TuitionManagement.tutorclass" %>

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

                                    <img width="100px" src="img/72-722660_free-png-for-teachers-for-writing-icon-class.png" />
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                <label>Subject Name</label>

                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>

                                </div>

                            </div>

                            <div class="col-md-7">
                                <label>Class Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                    </div>






                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4">
                            <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_Click" />
                        </div>
                        <div class="col-4">
                        </div>
                    </div>


                </div>
            </div>


            <br>


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
                        <style>
                            .table td, .table th {
                                padding: 0.75rem;
                                vertical-align: top;
                                padding-right: 35px;
                                border-top: 1px solid #dee2e6;
                            }
                        </style>
                        <div class="row">
                            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate><%#Eval("id")%></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Tutor">
                                        <ItemTemplate><%#Eval("tutorname")%></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Class">
                                        <ItemTemplate><%#Eval("classname")%></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate><%#Eval("subjectname")%></ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Student">
                                        <ItemTemplate><%#Eval("studentname")%></ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>


                    </div>
                </div>


            </div>

        </div>
    </div>
</asp:Content>
