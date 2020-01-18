import React from "react";
import { Image, Transition } from "semantic-ui-react";
const ServantImage = props => {
  return (
    <>
      <Transition
        visible={props.visible}
        animation="horizontal flip"
        duration={400}
      >
        {props.imageIndex % 2 === 0 ? (
          <div>
            <Image src={props.images[props.imageIndex]} wrapped ui={true} />
            <Image
              hidden={true}
              src={props.images[props.imageIndex + 1]}
              wrapped
              ui={true}
            />
          </div>
        ) : (
          <></>
        )}
      </Transition>

      <Transition
        visible={!props.visible}
        animation="horizontal flip"
        duration={400}
      >
        {props.imageIndex % 2 ? (
          <div>
            <Image src={props.images[props.imageIndex]} wrapped ui={true} />
            <Image
              hidden={true}
              src={props.images[props.imageIndex - 1]}
              wrapped
              ui={true}
            />
          </div>
        ) : (
          <></>
        )}
      </Transition>
    </>
  );
};

export default ServantImage;
