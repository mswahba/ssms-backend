import React, { Component } from 'react'
import UserState from './UserState'

export default () => (
    <UserState keys={ ['signIn'] }>
        {
            ({ signIn }) => (
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
                            signIn(document.getElementById('userId').value,
                                document.getElementById('userPassword').value)
                        }>
                        <i class="material-icons right">cloud</i>
                        Sign-in
                    </a>
                </form>
            )
        }
    </UserState>
);
