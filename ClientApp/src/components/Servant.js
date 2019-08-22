import React from "react"
import ServantList from "../ServantList.js"
function Servant(props){
    const rand=Math.floor(Math.random() * Math.floor(ServantList.length))
    return (
        <div>
            <h2>Name: {ServantList[rand].name}</h2> 
            <h3>Title: {ServantList[rand].title}</h3>
            <img src={ServantList[rand].Image1} alt="Image1"></img>
            <img src={ServantList[rand].Image2} alt="Image2"></img>
            <h3>{ServantList[rand].dialogue}</h3>
            <p>Summary: {ServantList[rand].summary}</p>        
        </div>
        )
}
export default Servant