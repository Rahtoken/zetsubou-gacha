import React, { useState, useEffect } from "react";
import {
  Image,
  Card,
  Button,
  Loader,
  Dimmer,
  Placeholder
} from "semantic-ui-react";
import ServantImage from "./ServantImage";
import axios from "axios";
const Servant = () => {
  const [imageIndex, changeImage] = useState(0);
  const [visible, changeVisibilty] = useState(true);
  const [data, setData] = useState({});
  const [loading, setLoading] = useState(true);
  const [reroll, setReroll] = useState(0);

  useEffect(() => {
    async function getServant() {
      let servantId = Math.floor(Math.random() * 230);
      const result = await axios(
        `https://localhost:5001/api/Servant/${servantId}`
      );
      setData(result.data);
      const timer = setTimeout(() => {
        setLoading(false);
      }, 200);
      return () => clearTimeout(timer);
    }
    getServant();
  }, [reroll]);

  const images = [data.firstAscensionImage, data.finalAscensionImage];

  return (
    <Dimmer.Dimmable as={Card} dimmed={loading}>
      {/* <Dimmer inverted active={loading}>
        <Loader inverted>Loading...</Loader>
      </Dimmer> */}
      {loading ? (
        <Placeholder>
          <Placeholder.Image rectangular />
        </Placeholder>
      ) : (
        <ServantImage
          imageIndex={imageIndex}
          images={images}
          visible={visible}
        ></ServantImage>
      )}
      <Card.Content>
        {loading ? (
          <Placeholder>
            <Placeholder.Header>
              <Placeholder.Line length="short" />
              <Placeholder.Line length="medium" />
            </Placeholder.Header>
            <Placeholder.Paragraph>
              <Placeholder.Line length="long" />
            </Placeholder.Paragraph>
          </Placeholder>
        ) : (
          <>
            <Card.Header>{data.name}</Card.Header>
            <Card.Meta>{data.title}</Card.Meta>
            <Card.Description>{data.dialogue}</Card.Description>
          </>
        )}
      </Card.Content>

      <Button
        onClick={() => {
          changeImage((imageIndex + 1) % 2);
          changeVisibilty(!visible);
        }}
      >
        Transform!
      </Button>
      <Button
        onClick={() => {
          setLoading(true);
          setReroll(reroll + 1);
        }}
      >
        Roll again!
      </Button>
    </Dimmer.Dimmable>
  );
};

export default Servant;
