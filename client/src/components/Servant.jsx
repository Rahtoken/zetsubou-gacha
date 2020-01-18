import React, { useState, useEffect } from "react";
import { Card, Button, Loader, Dimmer } from "semantic-ui-react";
import ServantImage from "./ServantImage";
import axios from "axios";
const Servant = () => {
  const [imageIndex, changeImage] = useState(0);
  const [visible, changeVisibilty] = useState(true);
  const [data, setData] = useState({});
  const [loading, setLoading] = useState(true);

  useEffect(async () => getServant(), []);

  const getServant = async () => {
    let servantId = Math.floor(Math.random() * 230);
    const result = await axios(
      `https://localhost:5001/api/Servant/${servantId}`
    );
    setData(result.data);
    const timer = setTimeout(() => {
      setLoading(false);
    }, 200);
  };

  const images = [data.firstAscensionImage, data.finalAscensionImage];

  return (
    <>
      <Dimmer.Dimmable dimmed={loading}>
        <Dimmer inverted active={loading}>
          <Loader inverted>Loading...</Loader>
        </Dimmer>

        <Card raised>
          <ServantImage
            imageIndex={imageIndex}
            images={images}
            visible={visible}
          ></ServantImage>
          <Card.Content>
            <Card.Header>{data.name}</Card.Header>
            <Card.Meta>{data.title}</Card.Meta>
            <Card.Description>{data.dialogue}</Card.Description>
          </Card.Content>

          <Button
            onClick={() => {
              changeImage((imageIndex + 1) % 2);
              changeVisibilty(visible ^ true);
            }}
          >
            Transform!
          </Button>
          <Button onClick={() => getServant()}>Roll again!</Button>
        </Card>
      </Dimmer.Dimmable>
    </>
  );
};

export default Servant;
