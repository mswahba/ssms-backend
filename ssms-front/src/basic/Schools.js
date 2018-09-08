import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { lookupActions } from "../store/lookup";
import SchoolsTable from "./SchoolsTable";
import SchoolsForm from "./SchoolsForm";
import SchoolsReduxForm from "./SchoolsReduxForm";

// flag to get data only once
let fetchData = true;

const Schools = (props) => {
  // extract url from routes props
  const { match: { url } } = props;
  if(fetchData) {
    fetchData = false;
    // set the selected tables which will be used when GET_LOOKUP_DATA_FULFILLED fired
    lookupActions.setSelectedTables(['schools']);
    // fire GET_LOOKUP_DATA_PENDING
    lookupActions.getLookupData( { req: ['get','/schools/list/all']} );
    // set the selected table which will be used in ADD,UPDATE,DELETE Actions
    lookupActions.setSelectedTable({ name: 'schools', key: 'schoolId'});
  }
  return (
    <Switch>
      {/* Regular Form */}
      <Route path={`${url}/edit/:id`} component={SchoolsForm} />
      <Route path={`${url}/details/:id`} component={SchoolsForm} />
      <Route path={`${url}/new`} component={SchoolsForm} />
      <Route path={`${url}/list`} component={SchoolsTable} />
      {/* ReduxForm */}
      <Route path={`${url}/redux/edit/:id`} component={SchoolsReduxForm} />
      <Route path={`${url}/redux/details/:id`} component={SchoolsReduxForm} />
      <Route path={`${url}/redux/new`} component={SchoolsReduxForm} />
      <Redirect from="/" to={`${url}/list`} />
    </Switch>
  );
}

const mapStateToProps = (state) => ({
  "schools": state.lookup.schools
})

export default connect(mapStateToProps)(Schools)