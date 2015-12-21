<%@ Page Title="Défauts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Defauts.aspx.cs" Inherits="ASPWebForms.Defauts" %>

<asp:Content  runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        html, body { height: 100%; margin: 0; padding: 0; }
        #map { height: 60vh; width : 100%; }
    </style>
</asp:Content>

<asp:Content  runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <div id="map"></div>
    <script type="text/javascript">
        function initMap() {
            // Map
            var coordCenter = new google.maps.LatLng(50.6108382,5.509964599999989);
            var map = new google.maps.Map(document.getElementById('map'), {
                center: coordCenter,
                zoom: 12
            });

            <% List<BusinessLogicLayer.DTO.DefautDTO> list = BusinessLogicLayer.BLL.SelectAllDefauts();
               
            if (list == null)
                return;%>

            var contentString, infowindow, marker;<%
            foreach (BusinessLogicLayer.DTO.DefautDTO d in list)
            { %>
                contentString = '<p>Coucou ' + <%=d.IdDefaut%> + '</p>';

                // Pop-up d'info
                infowindow = new google.maps.InfoWindow({
                    content: contentString
                });
                
                // Marqueur
                <% string[] parts = d.Position.Split(',');
                string lat = parts[0];
                string lng = parts[1];%>
                marker = new google.maps.Marker({
                    position: { lat: parseFloat(<%=lat%>), lng: parseFloat(<%=lng%>) },
                    map: map
                });

                // Event click
                marker.addListener('click', function () {
                    infowindow.open(map, marker);
                });
            <% } %>
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6pROpF7tfR4Ur9XrCqa5BQHxmAVSTmQ8&callback=initMap"></script>
</asp:Content>
