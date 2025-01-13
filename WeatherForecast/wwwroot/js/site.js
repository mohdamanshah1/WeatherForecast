dgetLocation();


function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(getPosition, showLocationError);
    } else {
        console.log("geolocation not supported");
    }
}

function getPosition(position) {
    const latitude = position.coords.latitude;
    const longitude = position.coords.longitude;
    getWeather(latitude, longitude);
}

function showLocationError(error) {
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
function showApiError(error) {
    if (error.readyState === 0) {
        toastr.error("something went wrong");
        return;
    }
    console.log(error.status);
    console.log(error.responseJSON.message);
    toastr.error(error.responseJSON.message);
}


async function getWeather(latitude, longitude) {
    const endPoint = "weather/getcurrentweather";
    const url = `${endPoint}?latitude=${latitude}&longitude=${longitude}`;

    $.ajax({
        method: 'get',
        url: url,
        success: populateWeatherData,
        error: showApiError
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
        success: populateSuggestions,
        error: showApiError
    });
});

document.querySelector('.currentLocationButton').addEventListener('click', e => {
    getLocation();
});



