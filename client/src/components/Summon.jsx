import React from "react";
import styled from "styled-components";
const Frame = styled.div`
  font-family: Friz Quadrata Std Medium;
  justify-content: center;
  text-align: center;
  color: white;
`;
const Button = styled.button`
  background-color: #4caf50; /* Green */
  border: 2px solid #dfdfe5;
  border-radius: 8px;
  color: #dfdfe5;
  text-align: center;
  display: inline-block;
  font-family: Friz Quadrata Std Medium;
  font-size: 1em;
  cursor: pointer;
  padding: 5px 8px;
`;
const Summon = props => {
  return (
    <Frame>
      <h1>Welcome to Chaldeas.</h1>
      <h2>Please summon a Servant to accompany you on your mission</h2>
      <Button onClick={() => props.summon()}>Summon a Servant!</Button>
    </Frame>
  );
};

export default Summon;
