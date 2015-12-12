<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ASPWebForms.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Email :</h3>
        </header>
        <p>
            <span><a href="mailto:oceane.seel@hotmail.com">oceane.seel@hotmail.com</a></span>
        </p>
        <p>
            <span><a href="mailto:jeromefink@hotmail.com">jeromefink@hotmail.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Ecole :</h3>
        </header>
        <p>
            Haute Ecole de la Province de Liège<br />
            Rue Peetermans 40<br />
            4100 Seraing
        </p>
    </section>
</asp:Content>