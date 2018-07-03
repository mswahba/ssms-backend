import React from 'react'
import UserState from './UserState'

export default () => (
    <UserState keys={ ['signIn'] }>
        {
            ({ signIn }) => (
                <form>
                    <div className="input-field ">
                        <input id="userId" type="text" className="validate" />
                        <label htmlFor="userId">User ID</label>
                    </div>
                    <div className="input-field ">
                        <input id="userPassword" type="text" className="validate" />
                        <label htmlFor="userPassword">Password</label>
                    </div>
                    <a className="waves-effect waves-light btn"
                        onClick={() =>
                            signIn(document.getElementById('userId').value,
                                document.getElementById('userPassword').value)
                        }>
                        <i className="material-icons right">cloud</i>
                        Sign-in
                    </a>
                </form>
            )
        }
    </UserState>
);
