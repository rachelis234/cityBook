import React, { useEffect } from "react";
import userService from "../../services/user.service";

export default function FavoriteCities(props) {
  let user = {};
  useEffect(() => {
    user = userService.user;
  }, []);
  return (
    <>
      {user && (
        <div>
          <div>
            <p>{user.name}</p>
          </div>
          <div>
            <p>You have {props.favorites} favorite cities.</p>
          </div>
        </div>
      )}
    </>
  );
}
