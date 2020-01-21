import React, { useState } from "react";
import { Header, Button, Input } from "semantic-ui-react";

const Summon = props => {
  const [number, setNumber] = useState(1);
  const handleChange = event => {
    setNumber(event.target.value);
  };
  return (
    <div>
      <Header as="h1">Welcome to Chaldeas.</Header>
      <Header as="h2">
        Please summon a Servant to accompany you on your mission.
      </Header>
      <Input
        placeholder="Enter number of rolls."
        onChange={event => handleChange(event)}
      ></Input>
      <Button onClick={() => props.summon(number)}>Summon a Servant!</Button>
    </div>
  );
};

export default Summon;
