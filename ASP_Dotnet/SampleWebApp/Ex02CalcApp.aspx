<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ex02CalcApp.aspx.cs" Inherits="SampleWebApp.Ex02CalcApp" MasterPageFile="~/Main.Master" %>
<asp:Content ID="content1" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <style>
    .section{
        display:inline-block;
        width : 35%;
        vertical-align:top
    }
</style>
    <h1>MyCalc App</h1>
    <hr />
    <div class="section">
        <p>
            Enter the First Value:
            <asp:TextBox runat="server" TextMode="Number" ID="txtFirstValue" />
        </p>
        <p>
            Enter the Second Value:
            <asp:TextBox runat="server" TextMode="Number" ID="txtSecondValue" />
        </p>
        <p>
            <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click"/>
        </p>
    </div>
    <div class="section">
        <p>Select the option here: </p>
        <asp:DropDownList runat="server" ID="dpList" Height="29px" Width="191px">
            <asp:ListItem Text="Options" />
            <asp:ListItem Text="Add" />
            <asp:ListItem Text="Subtract" />
            <asp:ListItem Text="Multiply" />
            <asp:ListItem Text="Divide" />
        </asp:DropDownList>
        <asp:Label ID="lblError" ForeColor="IndianRed" runat="server" />
    </div>
    <div>
        <p>
            <asp:Label ID="lblDisplay" runat="server" BorderStyle="Solid" Height="60px" Width="469px" />
        </p>
    </div>
</div>
</asp:Content>
