import React, { useState } from "react";
import styled from "styled-components";
import { makeStyles } from "@material-ui/core/styles";
const useStyles = makeStyles(theme => ({
  container: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center"
  }
}));
const Name = styled.h3`
  font-family: Friz Quadrata Std Medium;
  color: white;
  margin-top: 5px;
  margin-bottom: 5px;
  padding: 5px;
  border: 3px solid white;
  border-radius: 8px;
`;

const Image = styled.img`
  margin-top: 8px;
  margin-bottom: 8px;
`;

const Dialogue = styled.div`
  background: #dfdfe5;
  font-family: Friz Quadrata Std Medium;
  color: #232b2b;
  border: 3px hidden #232b2b;
  border-radius: 8px;
  padding: 5px;
  margin: 5px;
  font-size: 22px;
`;

const Styimg = {
  border: "2px solid white",
  borderRadius: "8px"
};

const Button = styled.button`
  background-color: #4caf50;
  border: 2px solid #dfdfe5;
  border-radius: 8px;
  color: #dfdfe5;
  text-align: center;
  display: inline-block;
  font-family: Friz Quadrata Std Medium;
  cursor: pointer;
  padding: 5px 8px;
`;
const Servant = props => {
  const [image, changeImage] = useState(0);
  const images = [
    props.data.firstAscensionImage,
    props.data.finalAscensionImage
  ];
  const classes = useStyles();
  return (
    <div className={classes.container}>
      <Name>{props.data.name}</Name>
      {props.data.title === "" ? null : (
        <Name> Title/Alt: {props.data.title} </Name>
      )}
      <div>
        <Image style={Styimg} src={images[image]}></Image>
      </div>
      <Button onClick={() => changeImage((image + 1) % 2)}>Transform!</Button>
      <Dialogue>{props.data.dialogue}</Dialogue>
    </div>
  );
};

export default Servant;
