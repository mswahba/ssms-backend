import axios from 'axios'
import M from 'materialize-css';

export const actionTypes = {
  SIGN_IN: "SIGN_IN",
  GET_USERS: "GET_USERS"
}

const usersState = {
  users: [],
  loggedUser: {}
}

const methods = {
  SIGN_IN: (state, { userId, userPassword }) => {
    axios.post('/Users/SignIn', {
        userId,
        userPassword
    })
      .then((response) => {
        console.log(response);
        M.toast({
          html: response.data.userId
        });
      })
      .catch((error) => {
        if (!error.response)
          return;
        const { response: {data} } = error
        console.log(data);
        M.toast({
          html: JSON.stringify(data)
        })
      });
  },
  GET_USERS: (state, payload) => {
    axios.get("/Users/List/all")
        .then(res => {
          return {
            ...state,
            user: {users: res.data}
          }
          //this.store.setState({ user: {users: res.data} })
        })
  }
}

export default (state = usersState, { type, payload }) => {
  switch (type) {
    case actionTypes.SIGN_IN:
      methods[actionTypes.SIGN_IN](state, payload)
    case actionTypes.GET_USERS:
      methods[actionTypes.SIGN_IN](state, payload)
    default:
      return state;
  }
}