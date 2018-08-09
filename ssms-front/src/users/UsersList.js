import React, { Component } from "react"
import { connect } from "react-redux"
import { getUsers } from './userActions'
import { axiosOne } from '../axios'

class UsersList extends Component {

  componentDidMount() {
    // dispatch getUsers Action [GET_USERS]
    getUsers( axiosOne('get','/Users/List/all') )
    console.log(this.props);
  }
  render() {
    return (
      <ol>
        { 
          (this.props.loading)
            ? "loading ..."
            : (this.props.error)
              ? JSON.stringify(this.props.error)
              : (this.props.users.length)
                ? this.props.users.map(user => <li key={user.userId}>{user.userId}</li>)
                : "no users yet ..."
        }
      </ol>
    )
  }
}

const mapStateToProps = (state) => ({
  ...state.user
})

export default connect(mapStateToProps)(UsersList)
