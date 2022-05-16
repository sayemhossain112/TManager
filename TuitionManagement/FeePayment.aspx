<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FeePayment.aspx.cs" Inherits="TuitionManagement.FeePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-12">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Fee Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                    </div>
                </div>

                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"  CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="tutorname" HeaderText="tutorname" SortExpression="tutorname" />
                        <asp:BoundField DataField="studentname" HeaderText="studentname" SortExpression="studentname" />
                        <asp:BoundField DataField="classname" HeaderText="classname" SortExpression="classname" />
                        <asp:BoundField DataField="subjectname" HeaderText="subjectname" SortExpression="subjectname" />
                        <asp:BoundField DataField="fee" HeaderText="fee" SortExpression="fee" />
                        <asp:BoundField DataField="statues" HeaderText="statues" SortExpression="statues" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT * FROM [fee] WHERE ([studentname] LIKE '%' + @studentname + '%')">
                    <SelectParameters>
                        <asp:SessionParameter Name="studentname" SessionField="username" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

                
                <br>
                </div>
            </div>
            </div>
</asp:Content>
