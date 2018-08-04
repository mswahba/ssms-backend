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
          const { response: {data} } = error
          console.log(data);
          M.toast({
            html: JSON.stringify(data)
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