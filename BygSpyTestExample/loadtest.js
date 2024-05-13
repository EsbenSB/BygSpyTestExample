import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
    const baseUrl = 'https://test-api.k6.io/public/crocodiles/';

    const resGetWeatherForecast = http.get(baseUrl);
    validateResponse(resGetWeatherForecast, 200);

    const invalidId = 'invalid-id';
    const resGetWeatherForecastInvalidId = http.get(`${baseUrl}/${invalidId}`);
    validateResponse(resGetWeatherForecastInvalidId, 404);


    sleep(Math.random() * 3);
}

function validateResponse(response, expectedStatusCode) {
    if (response.status === expectedStatusCode) {
        console.log(`Test Passed - Expected status code ${expectedStatusCode}`);
    } else {
        console.error(`Test Failed - Expected status code ${expectedStatusCode}, but received ${response.status}`);
    }
}
