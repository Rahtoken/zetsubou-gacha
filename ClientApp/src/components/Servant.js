import React from "react"
import ServantList from "../ServantList.js"
class Servant extends React.Component{
    constructor(){
        super()
        this.state={
            name : "",
            title : "",
            firstAscensionImage : "",
            finalAscensionImage : "",
            dialogue : "",
            audio : "",
            transform : true,
            isLoading : true,
        }
        this.url = "https://localhost:5001/api/Servant/"
        this.id = Math.floor(Math.random() * 230)
        this.handleOnClick = this.handleOnClick.bind(this)
    }

    async componentDidMount() {
        await fetch(this.url+this.id)
          .then(response => response.json())
          .then(data => this.setState({
              ...data,
              isLoading : false
            }));
        }

    handleOnClick(){
        this.setState(() => {
            return {
                transform : !this.state.transform
            }
        })
    }
    render(){
        console.log(this.id)
        return (
            <div>
                {this.state.isLoading ?
                    <h1>Loading...</h1> :
                <div>
                    <h2>Name: {this.state.name}</h2> 
                    <h3>ID: {this.state.id}</h3>
                    { this.state.title==="" ?  null : <h3> Title: {this.state.title} </h3>}
                    <img src={this.state.transform ? this.state.firstAscensionImage : this.state.finalAscensionImage} alt="Image1"></img>
                    <br></br>
                    <input type="Button" value="Transform!" onClick={this.handleOnClick}/>
                    <h3>{this.state.dialogue}</h3>
                    {/* <p>Summary: {this.state.summary}</p>         */}
                </div>
                }
            </div>
            )   
    }
}
export default Servant