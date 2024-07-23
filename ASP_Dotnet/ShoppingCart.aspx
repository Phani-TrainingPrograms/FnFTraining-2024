<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SampleWebApp.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <style>
        .plate{
            border: 1px solid grey;
            border-radius: 25px;
            padding:2px;
            margin:3px;
        }
    </style>
    <div class="row">
        <div class="col-md-3">
            <p>List of Items</p>
            <asp:ListBox runat="server" AutoPostBack="true" ID="lstProducts" Height="315px" OnSelectedIndexChanged="lstProducts_SelectedIndexChanged" Width="217px">
            </asp:ListBox>
            <asp:Label Text="" ForeColor="IndianRed" ID="lblError" runat="server" />
        </div>
        <div class="col-md-8">
            <h2>Product Details</h2>
            <div class="row">
                <div class="col-md-6">
                    <p>
                        Product ID: 
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtId" TextMode="Number" />
                    </p>
                    <p>
                        Product Name: 
                        <asp:TextBox CssClass="form-control" runat="server" ID ="txtName"/>
                    </p>
                </div>
                <div class="col-md-5">
                    <asp:Image ImageUrl="" Width="150px" Height="150px" runat="server" ID="imgProduct" />
                </div>
            </div>
            <div>
                <asp:DataList ID="dtRecentList" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                    <HeaderTemplate>
                        <p>
                            <h2>Your Recently viewed List</h2>
                        </p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="plate">
                            <img src='<%#Eval("Image")%>'/> 
                            <br />
                            <hr />
                            <p> <b><%#Eval("Name")%> <br />from Rs. <%#Eval("Price") %></b></p>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>

        </div>
    </div>
</asp:Content>
