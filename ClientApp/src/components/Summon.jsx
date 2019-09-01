import React from 'react';

const Summon = (props) => {
    return (
        <div>
            <h1>Welcome to Chaldeas.</h1>
            <h2>Please summon a Servant to accompany you on your mission</h2>
            <button onClick={() => props.summon()}>Summon a Servant!</button>
        </div>
    )
}

export default Summon;