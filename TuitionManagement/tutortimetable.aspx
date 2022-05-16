<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tutortimetable.aspx.cs" Inherits="TuitionManagement.tutortimetable" %>
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
                       <h4>Timetable Details</h4>
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

                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="attendate" HeaderText="attendate" SortExpression="attendate" />
                        <asp:BoundField DataField="studentName" HeaderText="studentName" SortExpression="studentName" />
                        <asp:BoundField DataField="class_name" HeaderText="class_name" SortExpression="class_name" />
                        <asp:BoundField DataField="sub_name" HeaderText="sub_name" SortExpression="sub_name" />
                        <asp:BoundField DataField="attenstatus" HeaderText="attenstatus" SortExpression="attenstatus" />
                    </Columns>
           </asp:GridView>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tuitionDBConnectionString %>" SelectCommand="SELECT [class_name], [sub_name], [attenstatus], [attendate], [studentName], [id] FROM [AttendanceTbl]"></asp:SqlDataSource>

                
                <br>
                </div>
            </div>
            </div>

</asp:Content>
