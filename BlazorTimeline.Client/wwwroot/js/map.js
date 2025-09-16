window.mapInterop = {
    initializeMap: function (mapId, lat, lon, zoom) {
        var map = L.map(mapId).setView([lat, lon], zoom);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
        return map;
    },
    addMarkers: function (map, markers) {
        if (!map || !markers) return;
        markers.forEach(marker => {
            L.marker([marker.latitude, marker.longitude]).addTo(map)
                .bindPopup(marker.popupText);
        });
    },
    clearMarkers: function(map) {
        if (!map) return;
        map.eachLayer(function (layer) {
            if (layer instanceof L.Marker) {
                map.removeLayer(layer);
            }
        });
    }
};
