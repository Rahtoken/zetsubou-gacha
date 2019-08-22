import React from 'react';
import Servant from "./components/Servant.js"
import Summon from "./components/Summon.js"
import {BrowserRouter as Router, Switch, Route} from "react-router-dom"
class App extends React.Component{
  
  constructor(){
    super()
    this.state={}
  }
  
  render(){
    return(
    <Router>
      <div>
        <Switch>
          <Route path="/" exact component={Summon}/>
          <Route path="/servant" exact component={Servant}/>
        </Switch>
      </div>
    </Router>
    );
  }

}
export default App;
