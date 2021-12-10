import React from "react";
import { useNavigate } from "react-router-dom";
import GoogleLogin from "react-google-login";
import userService from "../../services/user.service";

export default function LoginGoogle() {

  const navigate = useNavigate();
  const responseGoogle =async response => {
    await userService.createUser(response.neme,response.email)
    navigate("/search");
  };

  const onFailure = response => {
    console.log(response);
    navigate("/");
  };

  return (
    <GoogleLogin
      clientId="624763551910-4j0h3a02g28plipac9gho7p6ak1t5qbt.apps.googleusercontent.com"
      buttonText="Login"
      onSuccess={responseGoogle}
      onFailure={onFailure}
      cookiePolicy={"single_host_origin"}
    />
  );
}
