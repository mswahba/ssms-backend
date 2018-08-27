import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { lookupActions } from "../store/lookup";
import SchoolsTable from "./SchoolsTable";
import SchoolsForm from "./SchoolsForm";

// flag to get data only once
let fetchData = true;

const Schools = (props) => {
  // extract url from routes props
  const { match: { url } } = props;
  if(fetchData && !url.includes('edit')) {
    fetchData = false;
    lookupActions.setSelectedTables(['schools']);
    lookupActions.getLookupData( { req: ['get','/schools/List/all']} );
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