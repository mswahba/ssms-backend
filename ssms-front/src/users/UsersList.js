import React from 'react'
import UserState from './UserState'

export default () => (
  <UserState>
      {
        ({ users }) => (
          <ul>
            {users && users.map( user => <li key={user.userId}>{user.userId}</li> )}
          </ul>
        )
      }
  </UserState>
)