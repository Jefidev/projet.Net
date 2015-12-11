<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPWebForms.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
</asp:ListView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
<asp:CheckBox ID="CheckBox1" runat="server" />
</asp:Content>
