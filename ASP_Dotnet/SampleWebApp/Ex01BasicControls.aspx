<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Ex01BasicControls.aspx.cs" Inherits="SampleWebApp.Ex01BasicControls" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="mainContent">
     <h1>ASP.NET Training</h1>
 <hr />
     <div>
         <span>Enter the Item to Add to cart:</span>
         <asp:TextBox runat="server" ID="txtItem" />
         <asp:Button Text="Add Item" runat="server" ID="btnAdd" OnClick="btnAdd_Click" />
     </div>
     <div>
         <p>
             <span>Items that are in the cart:</span><br />
             <asp:ListBox runat="server" ID="lstItems" Height="150px" Width="150px" OnSelectedIndexChanged="lstItems_SelectedIndexChanged" AutoPostBack="True">
             </asp:ListBox>
             <asp:Label Text="" ID="lblSelected" runat="server" />
         </p>
     </div>
</asp:Content>    