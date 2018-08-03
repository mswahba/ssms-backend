import axios from 'axios'
import M from 'materialize-css';

class UserStore {
  state = {
    users: [],
    loggedUser: {}
  }
  methods = {
    signIn: (userId, userPassword) => {
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
          console.log(error.response.data);
          M.toast({
            html: error.response.data.UserId || error.response.data.UserPassword || error.response.data
          })
        });
    },
    getUsers: () => {
      axios.get("/Users/List/all")
          .then(res => {
            this.store.setState({ user: {users: res.data} })
          })
    }
  }
}

export default new UserStore();