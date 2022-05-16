<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="studentattendance.aspx.cs" Inherits="TuitionManagement.studentattendance" %>
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
                                        <h4>ATTENDANCE</h4>
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
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Subject Name" ReadOnly="True"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-7">
                                <label>Class ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Class ID" ReadOnly="True"></asp:TextBox>

                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-7">
                                <label>QR KEY (Scan the QR)</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="xxxxxxxx"></asp:TextBox>   
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-5">  
                                 <label></label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:Button ID="Button11" class="btn btn-lg btn-block btn-info" runat="server" Text="Attendance" OnClick="btnConfirm_Click" />
                                    </div>
                                </div>
                                 
                            </div>

                        </div>
                        <div class="row">
                             <div class="col-md-12"  style="text-align:center;">
                                 <label>Scan Attendance and fill the code</label>
                                <div class="form-group">
                                    <asp:Image ID="imgageQRCode" Width="200px"
                                    Height="200px" runat="server"
                                    Visible="false" />
                                  </div>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT * FROM [AttendanceTbl]"></asp:SqlDataSource>
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
