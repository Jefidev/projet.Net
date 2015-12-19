<%@ Page Title="A propos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASPWebForms.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.<br /></h1>
        <h2>La sollution collaborative de gestion de l'espace public et des bâtiments</h2>
    </hgroup>

    <article>
        <h3>
            SmartCity est une solution composée de différentes applications :
        </h3>
        <p>        
            - SmartCity : application mobile disponible sur le Windows Store et Google Play permettant aux citoyens de signaler un défaut qu'ils ont repéré.
        </p>
        <p>        
            - Admin@SmartCity : application dédiée à l'administration communale pour gérer les défauts signalés par les citoyens.
        </p>
        <p>        
            - Family@SmartCity : Site web permettant aux citoyens de découvrir les défauts et de suivre l'avancement de ceux-ci.
        </p>
    </article>
</asp:Content>