import React, { Component } from 'react';
import { Segment, Button } from 'semantic-ui-react';

import Summon from './components/Summon';
import Servant from './components/Servant';

class GachaContainer extends Component {
    state = {
        summoned: false,
        loading: false,
        servant: {}
    };

    summonServant = () => {
        const newSummon = !this.state.summoned;
        this.setState({ summoned: newSummon, loading: true }, () => this.showServant());
    }

    showServant = () => {
        let servantId = Math.floor(Math.random() * 230);
        let requestUrl = `https://localhost:5001/api/Servant/${servantId}`;
        fetch(requestUrl)
            .then(response => response.json())
            .then(data => {
                this.setState({ servant: data, loading: false });
            });
    }
    render() {
        return (
            <Segment padded>
                {!this.state.summoned ?
                    <Summon summon={this.summonServant} /> :
                    this.state.loading ?
                        <h3>Loading...</h3> :
                        <div>
                            <Servant data={this.state.servant} />
                            <Button onClick={() => this.showServant()}>Roll again!</Button>
                        </div>
                }
            </Segment>
        );
    }
}

export default GachaContainer;