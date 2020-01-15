import React, { useState } from "react";
import { Card, Image, Button, Transition } from "semantic-ui-react";
const Servant = props => {
  const [image, changeImage] = useState(0);
  const [visible, changeVisibilty] = useState(true);
  const images = [
    props.data.firstAscensionImage,
    props.data.finalAscensionImage
  ];

  return (
    <>
      <Card raised>
        <Transition
          visible={visible}
          animation="horizontal flip"
          duration={200}
        >
          {image % 2 === 0 ? (
            <Image src={images[image]} wrapped ui={false} />
          ) : (
            <></>
          )}
        </Transition>

        <Transition
          visible={!visible}
          animation="horizontal flip"
          duration={200}
        >
          {image % 2 ? <Image src={images[image]} wrapped ui={false} /> : <></>}
        </Transition>

        <Card.Content>
          <Card.Header>{props.data.name}</Card.Header>
          <Card.Meta>{props.data.title}</Card.Meta>
          <Card.Description>{props.data.dialogue}</Card.Description>
        </Card.Content>
      </Card>
      <Button
        onClick={() => {
          changeImage((image + 1) % 2);
          changeVisibilty(visible ^ true);
        }}
      >
        Transform!
      </Button>
    </>
  );
};

export default Servant;
