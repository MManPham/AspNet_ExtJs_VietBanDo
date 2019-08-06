var initialize = function () {
    var mapContainer = document.getElementById("containerMap");
    var mapProp = {
        center: new vbd.LatLng(14.102783, 109.649506),
        zoom: 5,
        minZoom: 2,

    };

    var map = new vbd.Map(mapContainer, mapProp);

    vbd.event.addListener(map, 'click', function (param) {
        var marker = new vbd.Marker({
            position: param.LatLng
        });
        marker.setMap(map);
    });
};

vbd.event.addDomListener(window, 'load', initialize);
