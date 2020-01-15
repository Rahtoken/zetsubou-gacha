import React from 'react';
import { Header, Button } from 'semantic-ui-react';

const Summon = (props) => {
    return (
        <div>
            <Header as="h1">Welcome to Chaldeas.</Header>
            <Header as="h2">Please summon a Servant to accompany you on your mission.</Header>
            <Button onClick={() => props.summon()}>Summon a Servant!</Button>
        </div>
    )
}

export default Summon;