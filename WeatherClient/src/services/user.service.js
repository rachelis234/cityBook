import React, { Component } from "react";
import axios from "axios";
class UserService extends Component {
  constructor(props) {
    super(props);
    this.url = process.env.REACT_APP_SERVICE_URI
      ? process.env.REACT_APP_SERVICE_URI
      : "https://localhost:44355/";
    this.user = null;
    this.favoriteCities = [];
  }

  createUser = async (name, email) => {
    try {
      const newUser = {
        Name: name,
        Email: email
      };
      const response = await axios.post(`${this.url}`, { newUser });

      if (response.status === 200) {
        this.user = response.data;
        this.favoriteCities = [];
      } else throw new Error(response.data);
    } catch (err) {
      return null;
    }
  };

  updateUser = async cityId => {
    try {
      const userToUpdate = {
        Name: this.user.name,
        Email: this.user.Email,
        FavoriteCities: this.user.FavoriteCities.concat(cityId)
      };
      const updatedUser = await axios.put(
        `${this.url}/${cityId}`,
        userToUpdate
      );
      this.user = updatedUser;
      this.favoriteCities = updatedUser.FavoriteCities.split(",");
    } catch (err) {
      console.log(err);
    }
  };
}
export default new UserService();
