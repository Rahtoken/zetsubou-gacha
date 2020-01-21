import React, { Component } from "react";
import { Segment, CardGroup } from "semantic-ui-react";
import Summon from "./components/Summon";
import Servant from "./components/Servant";

class GachaContainer extends Component {
  state = {
    summoned: false,
    loading: false,
    servant: {},
    number: 0
  };

  summonServant = number => {
    const newSummon = !this.state.summoned;
    this.setState({
      summoned: newSummon,
      loading: false,
      number: parseInt(number)
    });
  };

  render() {
    var items = [];
    for (var i = 0; i < this.state.number; i++) items.push(<Servant key={i} />);
    return (
      <Segment padded>
        {!this.state.summoned ? (
          <Summon summon={this.summonServant} />
        ) : this.state.loading ? (
          <h3>Loading...</h3>
        ) : (
          <CardGroup>{items}</CardGroup>
        )}
      </Segment>
    );
  }
}

export default GachaContainer;
