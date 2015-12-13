<%@ Page Title="Defauts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Defauts.aspx.cs" Inherits="ASPWebForms.Defauts" %>

<asp:Content  runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <asp:Label ID="FiltreLabel" runat="server" Text="Filtre :"></asp:Label>
    <asp:ListView ID="DefautsLV" runat="server" DataSourceID="ObjectDataSource">
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource" runat="server"></asp:ObjectDataSource>
</asp:Content>
