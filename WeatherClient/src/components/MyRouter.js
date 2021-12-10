import React from "react";
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom"
import LoginGoogle from "./login/LoginGoogle";
import SearchCity from "./searchCity/SearchCity";
import CurrentWeather from "./currentWeather/CurrentWeather";

export default function MyRouter() {
  
  return (
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<LoginGoogle />} />
        <Route path="/search/currentWeather" element={<CurrentWeather />} />
        <Route path="search"  element={<SearchCity />} />
      </Routes>
    </BrowserRouter>
  );
}
