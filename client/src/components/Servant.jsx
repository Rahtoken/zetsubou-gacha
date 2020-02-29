import React, { useState } from "react";
import { Card, Image, Button } from 'semantic-ui-react';

const Servant = (props) => {

  const [image, changeImage] = useState(0);

  const images = [
    props.data.firstAscensionImage,
    props.data.finalAscensionImage
  ];

  return (
    <>
      <Card raised>
        <Image src={images[image]} wrapped ui={false} />
        <Card.Content>
          <Card.Header>{props.data.name}</Card.Header>
          <Card.Meta>{props.data.title}</Card.Meta>
          <Card.Description>{props.data.dialogue}</Card.Description>
        </Card.Content>
      </Card>
      <Button onClick={() => changeImage((image + 1) % 2)}>Transform!</Button>
    </>
  );
};

export default Servant;
