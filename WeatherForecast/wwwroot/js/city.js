Array.from(document.querySelectorAll('.cities')).forEach(city => {
    city.addEventListener('click', e => {
        getWeather(e.target.closest('li').dataset.latitude, e.target.closest('li').dataset.longitude);
    })
})