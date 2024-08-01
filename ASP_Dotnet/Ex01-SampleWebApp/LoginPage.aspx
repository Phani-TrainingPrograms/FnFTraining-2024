<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SampleWebApp.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <asp:Login runat="server" ID="loginCtrl" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CreateUserText="New User? Sign Up" DisplayRememberMe="False" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="181px" LoginButtonText="Get Me in!!!" OnAuthenticate="Unnamed1_Authenticate" PasswordLabelText="UR Secret Password:" UserNameLabelText="UR User Name please:" Width="439px" CreateUserUrl="~/Registraion.aspx" >
    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
    <TextBoxStyle Font-Size="0.8em" />
    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
</asp:Login>
</asp:Content>
