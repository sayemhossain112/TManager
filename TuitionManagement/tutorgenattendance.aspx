<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tutorgenattendance.aspx.cs" Inherits="TuitionManagement.tutorgenattendance" %>
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
                                        <h4>Generate Attendace</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    
                                        <img width="100px" src="img/attendance.png" />
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
                                <label>Subject Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Subject Name" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-7">
                                <label>Class ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Class ID" ></asp:TextBox>

                                </div>
                            </div>
                        </div>
                         <div class="row">
                          

                            <div class="col-md-5">
                                <label>OTP Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Write an unique OTP" ></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-md-12">
                                 <label>Generate Attendance</label>
                                <div class="form-group">
                                     <div class="col-8">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-info" runat="server" Text="Generate QR Code"  OnClick="btnQCGenerate_Click" />
                            </div>
                                     <div class="col-4">
                            </div>
          
                                   

                                  </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Image ID="imgageQRCode" Width="100px"
               Height="100px" runat="server"
               Visible="false" />
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
                                        <h4>Attendance List</h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT [studentName], [id], [attendate], [attenstatus], [sub_name], [class_name] FROM [AttendanceTbl]"></asp:SqlDataSource>
                            <div class="col">
                                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: auto;">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:BoundField DataField="studentName" HeaderText="studentName" SortExpression="studentName" />
                                        <asp:BoundField DataField="attendate" HeaderText="attendate" SortExpression="attendate" />
                                        <asp:BoundField DataField="attenstatus" HeaderText="attenstatus" SortExpression="attenstatus" />
                                        <asp:BoundField DataField="sub_name" HeaderText="sub_name" SortExpression="sub_name" />
                                        <asp:BoundField DataField="class_name" HeaderText="class_name" SortExpression="class_name" />
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
