import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { lookupActions, lookupActionTypes } from "../store/lookup";
import { axiosOne } from '../axios';
import SchoolsTable from "./SchoolsTable";
import SchoolsForm from "./SchoolsForm";

// flage to get data only once
let fetchData = true;

const Schools = (props) => {
  // extract url from routes props
  const { match: { url } } = props;
  console.log(url);
  if(fetchData && !url.includes('edit')) {
    fetchData = false;
    lookupActions.setLookupKeys(['schools']);
    lookupActions.getLookupData( { payload: axiosOne('get','/schools/List/all')} );
  }
  return (
    <Switch>
      <Route path={`${url}/edit/:id`} component={SchoolsForm} />
      <Route path={`${url}/details/:id`} component={SchoolsForm} />
      <Route path={`${url}/new`} component={SchoolsForm} />
      <Route path={`${url}/list`} component={() => <SchoolsTable schools={props.schools} />} />
      <Redirect from="/" to={`${url}/list`} />
    </Switch>
  );
}

const mapStateToProps = (state) => ({
  ...state.lookup
})

export default connect(mapStateToProps)(Schools)