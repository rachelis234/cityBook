import React, { Fragment, useState } from "react";
import {useNavigate} from "react-router-dom";
import { Button } from "react-bootstrap";
import { Typeahead } from "react-bootstrap-typeahead";
import weatherService from "../../services/weather.service";
import userService from "../../services/user.service";
import FavoriteCities from "../favoriteCities/FavoriteCities";
import "react-bootstrap-typeahead/css/Typeahead.css";
import "./SearchCity.css";

export default function SearchCity() {
  const [singleSelections, setSingleSelections] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [options, setOptions] = useState([]);
  const [selectedItem, setSelectedItem] = useState("");
  const [favoriteCities,setFavoriteCities]=useState(userService.favoriteCities);

    const navigate = useNavigate();

  const filterCities = async query => {
    return options.filter(o => o.LocalizedName.toLowerCase().includes(query));
  };

  const handleSearch = async query => {
    // debugger;
    await setIsLoading(true);
    let cities = [];
    if (query.length === 1) {
      cities = await weatherService.getCities(query);
    } else {
      cities = await filterCities(query);
    }
    await setOptions(cities);
    await setIsLoading(false);
  };

  const setAsFavorite=async(cityId)=>{
    await userService.updateUser(cityId);
    setFavoriteCities(userService.favoriteCities);
  }
  const handleClick=()=>{
     navigate("/search/currentWeather", { state: selectedItem });
  }


  return (
    <>
      <FavoriteCities favorites={favoriteCities.length} />
      <Typeahead
        {...options}
        id="basic-behaviors-example"
        isLoading={isLoading}
        labelKey="LocalizedName"
        minLength={1}
        caseSensitive={false}
        onInputChange={handleSearch}
        onChange={async (option, props) => {
          await setSingleSelections(option.LocalizedName);
          await setSelectedItem(option.Key);
        }}
        options={options}
        selected={singleSelections}
        searchText="Searching..."
        placeholder="Search for a city..."
        renderMenuItemChildren={(option, props) => (
          <Fragment>
            {/* <img
              // alt={option.login}
              // src={option.avatar_url}
              style={{
                height: "24px",
                marginRight: "10px",
                width: "24px"
              }}
            /> */}

            <span>{favoriteCities &&favoriteCities.length>0&&favoriteCities.indexOf(option.Key) ?
              <svg
                // onClick={() => {
                //   setAsFavorite(option.Key);
                // }}
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                className="bi bi-star-fill"
                viewBox="0 0 16 16"
              >
                <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
              </svg>:""}
              {option.LocalizedName}
            </span>
          </Fragment>
        )}
      />
      
        <Button
          disabled={selectedItem && selectedItem.length > 0 ? false : true}
          onClick={handleClick}
          variant="secondary"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            className="bi bi-search"
            viewBox="0 0 16 16"
          >
            <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
          </svg>
        </Button>{" "}
      
    </>
  );
}
