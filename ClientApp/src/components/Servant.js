import React from "react"
class ServantData{
    constructor(data){
        this.id=data.id
        this.name=data.name
        this.title=data.title
        this.firstAscensionImage=data.firstAscensionImage
        this.finalAscensionImage=data.finalAscensionImage
        this.dialogue=data.dialogue
        this.audio=data.audio
    }
}
class Servant extends React.Component{
    constructor(){
        super()
        this.state={
            ServantData:{},
            transform : true,
            isLoading : true,
        }
        this.url = "https://localhost:5001/api/Servant/"
        this.id = Math.floor(Math.random() * 230)
        this.handleOnClick = this.handleOnClick.bind(this)
    }

    componentDidMount() {
        fetch(this.url+this.id)
          .then(response => response.json())
          .then(data => {
              this.setState({
              ServantData:new ServantData(data),
              isLoading : false
            })
        });
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
                    <h2>Name: {this.state.ServantData.name}</h2> 
                    <h3>ID: {this.state.ServantData.id}</h3>
                    { this.state.ServantData.title==="" ?  null : <h3> Title: {this.state.ServantData.title} </h3>}
                    <img src={this.state.transform ? this.state.ServantData.firstAscensionImage : this.state.ServantData.finalAscensionImage} alt="Image1"></img>
                    <br></br>
                    <input type="Button" value="Transform!" onClick={this.handleOnClick}/>
                    <h3>{this.state.ServantData.dialogue}</h3>
                    {/* <p>Summary: {this.state.summary}</p>         */}
                </div>
                }
            </div>
            )   
    }
}
export default Servant