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
                       string lat = parts[0];
                       string lng = parts[1];%>
                       var marker = new google.maps.Marker({
                            position: { lat: parseFloat(<%=lat%>), lng: parseFloat(<%=lng%>) },
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


            /* Info Windows */
            /*var contentString = '<div id="content">' +
                '<div id="siteNotice">' +
                '</div>' +
                '<h1 id="firstHeading" class="firstHeading">Uluru</h1>' +
                '<div id="bodyContent">' +
                '<p><b>Uluru</b>, also referred to as <b>Ayers Rock</b>, is a large ' +
                'sandstone rock formation in the southern part of the ' +
                'Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) ' +
                'south west of the nearest large town, Alice Springs; 450&#160;km ' +
                '(280&#160;mi) by road. Kata Tjuta and Uluru are the two major ' +
                'features of the Uluru - Kata Tjuta National Park. Uluru is ' +
                'sacred to the Pitjantjatjara and Yankunytjatjara, the ' +
                'Aboriginal people of the area. It has many springs, waterholes, ' +
                'rock caves and ancient paintings. Uluru is listed as a World ' +
                'Heritage Site.</p>' +
                '<p>Attribution: Uluru, <a href="https://en.wikipedia.org/w/index.php?title=Uluru&oldid=297882194">' +
                'https://en.wikipedia.org/w/index.php?title=Uluru</a> ' +
                '(last visited June 22, 2009).</p>' +
                '</div>' +
                '</div>';
            var infowindow = new google.maps.InfoWindow({
                content: contentString
            });
            var marker = new google.maps.Marker({
                position: coordCenter,
                map: map,
                title: 'Seraing'
            });
            marker.addListener('click', function () {
                infowindow.open(map, marker);
            });*/
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6pROpF7tfR4Ur9XrCqa5BQHxmAVSTmQ8&callback=initMap"></script>
</asp:Content>
