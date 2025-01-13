getLocation();


function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    } else {
        console.log("geolocation not supported");
    }
}

function showPosition(position) {
    const latitude = position.coords.latitude;
    const longitude = position.coords.longitude;
    getWeather(latitude, longitude);
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            toastr.error("User denied the request for Geolocation.");
            break;
        case error.POSITION_UNAVAILABLE:
            toastr.error("Location information is unavailable.");
            break;
        case error.TIMEOUT:
            toastr.error("The request to get user location timed out.");
            break;
        case error.UNKNOWN_ERROR:
            toastr.error("An unknown error occurred.");
            break;
    }
}


async function getWeather(latitude, longitude) {
    const endPoint = "weather/getcurrentweather";
    const url = `${endPoint}?latitude=${latitude}&longitude=${longitude}`;

    $.ajax({
        method: 'get',
        url: url,
        success: populateWeatherData
    });
}

function populateWeatherData(result) {
    $('#weatherWidget').empty();
    $('#weatherWidget').html(result);
}

function populateSuggestions(result) {
    $('#suggestedcities').empty();
    $('#suggestedcities').html(result);
}

document.getElementById('location').addEventListener('input', e => {
    if (!e.target.value) {
        $('#suggestedcities').empty();
        return;
    }
    document.querySelector('.sideBar').scrollTo(top);
    $.ajax({
        method: 'get',
        url: `geolocation/getplaces?name=${e.target.value}`,
        success: populateSuggestions
    });
});

document.querySelector('.currentLocationButton').addEventListener('click', e => {
    getLocation();
});