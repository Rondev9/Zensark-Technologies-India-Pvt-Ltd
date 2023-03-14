<%@ Page Title="" Language="C#" MasterPageFile="~/Accessed Login Page.Master" AutoEventWireup="true" CodeBehind="Login Page.aspx.cs" Inherits="Web_Excerciese___04_03_2023___Zensark_website.Login_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" style="margin-top:15%;margin-bottom:15%">
        <asp:Login ID="LoginForm" runat="server" OnAuthenticate="LoginForm_Authenticate" Height="196px" Width="381px">
    </asp:Login>
    </div>

</asp:Content>
