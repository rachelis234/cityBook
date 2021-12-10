import React, { Component } from "react";
import axios from "axios";
class WeatherService extends Component {
  constructor(props) {
    super(props);
    this.url = process.env.REACT_APP_SERVICE_URI
      ? process.env.REACT_APP_SERVICE_URI
      : "https://localhost:44376/";

    this.serviceUrl = process.env.ACCUWEATHERSERVICE
      ? process.env.ACCUWEATHERSERVICE
      : "http://dataservice.accuweather.com/";

    this.apiKey = process.env.APIKEY
      ? process.env.APIKEY
      : "LADNCCsAWDyiSHdhGnChuXHptm9mZ1ZS";
  }
  getCities = async q => {
    try {
      const response = await axios.get(
        `${this.serviceUrl}locations/v1/cities/autocomplete?apikey=${this.apiKey}&q=${q}&language=en`
      );
      if (response.status === 200) {
        return response.data;
      } else throw new Error(response.data);
    } catch (err) {
      return null;
    }
  };

  getCurrentWeatherForCity = async locationKey => {
    try {
      const response = await axios.get(
        `${this.serviceUrl}forecasts/v1/hourly/1hour/${locationKey}?apikey=${this.apiKey}`
      );
      if (response.status === 200) {
        return response.data;
      } else throw new Error(response.data);
    } catch (err) {
      return null;
    }
  };
}
export default new WeatherService();
