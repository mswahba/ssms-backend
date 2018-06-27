import React, { Component } from 'react';
import axios from 'axios';   
import M from 'materialize-css';

class SignIn extends Component {
   
    signIn = (userId, userPassword) => {
        axios.post('http://localhost:5000/Users/SignIn', {
            userId, userPassword
        })
            .then((response) => {
                console.log(response);
                M.toast({ html: response.data.userId });
            })
            .catch((error) => {
                if (!error.response)
                    return;
                console.log(error.response.data);
                M.toast({ html: error.response.data.UserId || error.response.data.UserPassword || error.response.data})
            });
    }

    render() {
        return (
            <form>
                <div className="input-field ">
                    <input id="userId" type="text" class="validate" />
                    <label htmlFor="userId">User ID</label>
                </div>
                <div className="input-field ">
                    <input id="userPassword" type="text" class="validate" />
                    <label htmlFor="userPassword">Password</label>
                </div>
                <a class="waves-effect waves-light btn"
                    onClick={() =>
                        this.signIn(document.getElementById('userId').value,
                            document.getElementById('userPassword').value)
                    }>
                    <i class="material-icons right">cloud</i>
                    Sign-in
                </a>
            </form>
        );
    }
}

export default SignIn;
