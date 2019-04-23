import React, { Component } from "react"
import { connect } from "react-redux"
import { userActions } from '../../store/user'

class UsersList extends Component {

  componentDidMount() {
    // dispatch getUsers Action [GET_USERS]
    // userActions.getUsers( axiosOne('get','/Users/List/all') )
    userActions.getUsers( { req: ['get','/Users/List/all'] } )
  }
  render() {
    const { loading, error, users } = this.props;
    return (
      <ol>
        { (loading)
            ? "loading ..."
            : (error)
              ? JSON.stringify(error)
              : (users.length)
                ? users.map(user => <li key={user.userId}>{user.userId}</li>)
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
