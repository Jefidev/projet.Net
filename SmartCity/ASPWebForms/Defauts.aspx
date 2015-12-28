<%@ Page Title="Défauts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Defauts.aspx.cs" Inherits="ASPWebForms.Defauts" %>

<asp:Content  runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        html, body { height: 100%; margin: 0; padding: 0; }
        #map { height: 60vh; width : 100%; }
        .photo {
            width: auto;
            height: auto;
            max-width: 200px;
            max-height: 200px;
        }
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
            marker = [];

            for (var i = 0; i < contentArray.length; i++)
            {
                var parts = contentArray[i].split("#");
                /*
                0 : latitude
                1 : longitude
                2 : id défaut
                3 : description
                4 : liste des interventions (séparées par |)
                5 : éventuelle photo du défaut
                */

                
                if (parts[3] == null) { alert("Pas d'image " + parts[2]); continue; }
                else { alert(parts[2] + "                        " + parts[3]); }

                contentString = '<img class="photo" src="data:image/jpg;base64,' + parts[5] + ' alt="Photo du défaut" />';
                
                // Marqueur
                marker[i] = new google.maps.Marker({
                    position: { lat: parseFloat(parts[0]), lng: parseFloat(parts[1]) },
                    map: map,
                    image: contentString
                });               

                // Event click
                google.maps.event.addListener(marker[i], 'click', function () {
                    infowindow = new google.maps.InfoWindow();
                    infowindow.setContent(this.image);
                    infowindow.open(map, this);
                });
            }
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6pROpF7tfR4Ur9XrCqa5BQHxmAVSTmQ8&callback=initMap"></script>
</asp:Content>
