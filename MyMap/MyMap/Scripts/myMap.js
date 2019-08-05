var initialize = function () {
    var mapContainer = document.getElementById("containerMap");
    // vbd.pathImgMap = 'http://images.vietbando.com/mapimagesws/mapimageservice.ashx?Action=GetTiles';
    var mapProp = {
        center: new vbd.LatLng(14.102783, 109.649506),
        zoom: 5,
        minZoom: 2,

    };

    var map = new vbd.Map(mapContainer, mapProp);
};

vbd.event.addDomListener(window, 'load', initialize);
