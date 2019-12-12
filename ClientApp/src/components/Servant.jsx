import React, { useState } from 'react';

const Servant = (props) => {
    const [image, changeImage] = useState(0);
    const images = [props.data.firstAscensionImage, props.data.finalAscensionImage];

    return (
        <div>
            <h3>{props.data.name}</h3>
            {props.data.title === "" ? null : <h3> Title: {props.data.title} </h3>}
            <img src={images[image]} alt="Servant Image"/>
            <br />
            <button onClick={() => changeImage((image + 1) % 2)}>Transform!</button>
            <h3>{props.data.dialogue}</h3>
        </div>
    )
}

export default Servant;
