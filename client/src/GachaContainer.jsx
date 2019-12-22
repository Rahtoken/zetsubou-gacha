import React, { Component } from "react";
import styled from "styled-components";

import Summon from "./components/Summon";
import Servant from "./components/Servant";

const Container = styled.div`
background: #232b2b;
text-align: center;
}
`;
const Button = styled.div`
  background-color: #4caf50; /* Green */
  border: 2px solid #dfdfe5;
  border-radius: 8px;
  color: #dfdfe5;
  text-align: center;
  display: inline-block;
  font-family: Friz Quadrata Std Medium;
  cursor: pointer;
  padding: 5px 8px;
`;
class GachaContainer extends Component {
  state = {
    summoned: false,
    loading: false,
    servant: {}
  };

  summonServant = () => {
    const newSummon = !this.state.summoned;
    this.setState({ summoned: newSummon, loading: true }, () =>
      this.showServant()
    );
  };

  showServant = () => {
    let servantId = Math.floor(Math.random() * 230);
    let requestUrl = `https://localhost:5001/api/Servant/${servantId}`;
    fetch(requestUrl)
      .then(response => response.json())
      .then(data => {
        this.setState({ servant: data, loading: false });
      });
  };
  render() {
    return (
      <div>
        <Container>
          {!this.state.summoned ? (
            <Summon summon={this.summonServant} />
          ) : this.state.loading ? (
            <h3>Loading...</h3>
          ) : (
            <div>
              <Servant data={this.state.servant} />
              <Button onClick={() => this.showServant()}>Roll again!</Button>
            </div>
          )}
        </Container>
      </div>
    );
  }
}

export default GachaContainer;
