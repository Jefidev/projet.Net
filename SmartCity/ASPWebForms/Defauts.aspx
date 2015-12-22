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

            if (!contentArray)
                return null;

            var contentString, infowindow, marker;
            contentString = [];
            infowindow = [];
            marker = [];
            var tailleTab = contentArray.length;

            for(var i = 0; i < tailleTab; i++)
            {
                var parts = contentArray[i].split("#");

                contentString[i] = '<p>Coucou ' + parts[0] + '</p>';

                // Pop-up d'info
                infowindow[i] = new google.maps.InfoWindow({
                    content: contentString[i]
                });
                
                // Marqueur
                marker[i] = new google.maps.Marker({
                    position: { lat: parseFloat(parts[1]), lng: parseFloat(parts[2]) },
                    map: map
                });               

                // Event click
                marker[i].addListener('click', function () {
                    alert("Avant " + i);
                    infowindow[i].open(map, marker[i]);
                    alert("Après " + i);
                });
           }
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6pROpF7tfR4Ur9XrCqa5BQHxmAVSTmQ8&callback=initMap"></script>
</asp:Content>
