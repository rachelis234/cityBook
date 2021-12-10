import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import weatherService from "../../services/weather.service";

export default function CurrentWeather(props) {
  const [currentWeather, setCurrentWeather] = useState({});
  let city = useLocation();
  console.log(city);

  useEffect(async () => {
    const weather = await weatherService.getCurrentWeatherForCity(city);
    if (weather) {
      console.log(weather);

      await setCurrentWeather(weather);
    }
  }, [currentWeather]);

  return (
    <>
      <h1>current weather:</h1>
      {Object.keys(currentWeather).length > 0 && (
        <div>
          <div>
            <div>DateTime:</div>
            <div>{currentWeather.DateTime}</div>
          </div>
          <div>
            <div>WeatherIcon:</div>
            <div>{currentWeather.WeatherIcon}</div>
          </div>
          <div>
            <div>IsDaylight:</div>
            <div>{currentWeather.IsDaylight}</div>
          </div>
          <div>
            <div>HasPrecipitation:</div>
            <div>{currentWeather.HasPrecipitation}</div>
          </div>
          <div>
            <div>Temperature:</div>
            <div>{currentWeather.Temperature}</div>
          </div>
        </div>
      )}
    </>
  );
}
