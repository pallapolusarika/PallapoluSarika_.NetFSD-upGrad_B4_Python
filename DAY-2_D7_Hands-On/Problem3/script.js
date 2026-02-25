const API_KEY = 9a9610cc71614be521789c1ad34cd538

// PROMISE VERSION
const getWeatherPromise = () => {

    const city = document.getElementById("cityInput").value;

    const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric`;

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error("City not found!");
            }
            return response.json();
        })
        .then(data => {

            const report = `
Weather Report (Promises Version)
-----------------------------------
City: ${data.name}
Temperature: ${data.main.temp} °C
Weather: ${data.weather[0].description}
Humidity: ${data.main.humidity} %
            `;

            document.getElementById("output").textContent = report;

        })
        .catch(error => {
            document.getElementById("output").textContent = "Error: " + error.message;
        });
};


// ASYNC/AWAIT VERSION
const getWeatherAsync = async () => {

    try {

        const city = document.getElementById("cityInput").value;

        const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric`;

        const response = await fetch(url);

        if (!response.ok) {
            throw new Error("City not found!");
        }

        const data = await response.json();

        const report = `
Weather Report (Async/Await Version)
-------------------------------------
City: ${data.name}
Temperature: ${data.main.temp} °C
Weather: ${data.weather[0].description}
Humidity: ${data.main.humidity} %
        `;

        document.getElementById("output").textContent = report;

    } catch (error) {

        document.getElementById("output").textContent = "Error: " + error.message;
    }
};