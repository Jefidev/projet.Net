<%@ Page Title="A propos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASPWebForms.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.<br /></h1>
        <h2>La sollution collaborative de gestion de l'espace public et des bâtiments</h2>
    </hgroup>

    <article>
        <p>        
            SmartCity est une solution composée de différente applications :
        </p>
        <p>        
            - SmartCity : application mobile disponible sur et Google Play.
        </p>
        <p>        
            - Admin@SmartCity : application mobile disponible sur et Google Play.
        </p>
        <p>        
            - Family@SmartCity : application mobile disponible sur et Google Play.
        </p>
    </article>
</asp:Content>