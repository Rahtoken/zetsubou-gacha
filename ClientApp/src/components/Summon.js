import React from "react"
import { Redirect } from "react-router"

class Summon extends React.Component {
    constructor() {
        super()
        this.state = { redirect: false }
        this.handleOnClick = this.handleOnClick.bind(this)

    }
    handleOnClick = () => {
        this.setState({ redirect: true })
    }
    render() {
        if (this.state.redirect) {
            return <Redirect push to="/servant" />
        }
        return (
            <div>
                <h1>Welcome to Chaldeas</h1>
                <h2>Please summon a Servant to accompany you on your mission</h2>
                <label>
                    <input value="Summon" name="Summon" type="button" onClick={this.handleOnClick} />
                </label>
            </div>
        )
    }
}
export default Summon