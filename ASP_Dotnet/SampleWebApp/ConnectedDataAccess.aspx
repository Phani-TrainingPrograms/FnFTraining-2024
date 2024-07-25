<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConnectedDataAccess.aspx.cs" Inherits="SampleWebApp.ConnectedDataAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <h1>ADO.NET Connected Data Example</h1>
        <h3>List of Students:</h3>
        <table style="vertical-align: top">
            <tr style="vertical-align:top">
                <td>
                    <asp:ListBox ID="lstStudents" runat="server" AutoPostBack="True" Height="228px" Width="401px" OnSelectedIndexChanged="lstStudents_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td>
                    <div>
                        <h2>Details of the Student</h2>
                        <hr />
                        <p>
                            Student ID:<asp:TextBox ID="txtId" CssClass="form-control" runat="server" TextMode="Number" />
                        </p>
                        <p>
                            Student Name:<asp:TextBox ID="txtName" CssClass="form-control" runat="server" />
                        </p>
                        <p>
                            Student Email:<asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                        </p>
                        <p>
                            Student Contact:<asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" TextMode="Phone" />
                        </p>
                        <p>
                            <asp:Button Text="Add" ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                            <asp:Button Text="Delete" ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                            <asp:Button Text="Update" ID="btnUpdate" runat="server" CssClass="btn btn-warning" />
                        </p>
                    </div>
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="lblError" ForeColor="IndianRed" Font-Size="14pt" runat="server" />
        </p>
    </div><!--
    Create 4 stored procs to insert a student in the database. 
-->
</asp:Content>
