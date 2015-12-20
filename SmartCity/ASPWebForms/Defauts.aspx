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
            var coordCenter = new google.maps.LatLng(50.6108382,5.509964599999989);
            var map = new google.maps.Map(document.getElementById('map'), {
                center: coordCenter,
                zoom: 12
            });

            <% List<BusinessLogicLayer.DTO.DefautDTO> list = BusinessLogicLayer.BLL.SelectAllDefauts();
               if (list != null)
               {
                   foreach (BusinessLogicLayer.DTO.DefautDTO d in list)
                   {
                       string[] parts = d.Position.Split(','); 
                       float lat = float.Parse(parts[0]);
                       float lng = float.Parse(parts[1]);%>
                        var marker = new google.maps.Marker({
                            position: { lat: float(<%=lat%>), lng: float(<%=lng%>) },
                            map: map,
                            title: 'Guillemins'
                        });
                   <% }
               } %>
            
            /*var marker = new google.maps.Marker({
                position: coordCenter,
                map: map,
                title: 'Seraing'
            });
            var marker = new google.maps.Marker({
                position: { lat: 50.6245012, lng: 5.566662199999996 },
                map: map,
                title: 'Guillemins'
            });*/
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6pROpF7tfR4Ur9XrCqa5BQHxmAVSTmQ8&callback=initMap"></script>
</asp:Content>
