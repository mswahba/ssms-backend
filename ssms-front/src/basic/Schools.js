import React, { Fragment } from "react";
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
    <Fragment>
      <Switch>
        <Route path={`${url}/edit/:id`} component={SchoolsForm} />
        <Route path={`${url}/details/:id`} component={SchoolsForm} />
        <Route path={`${url}/new`} component={SchoolsForm} />
        <Route path={`${url}/list`} component={SchoolsTable} />
        <Redirect from="/" to={`${url}/list`} />
      </Switch>
    </Fragment>
  );
}

const mapStateToProps = (state) => ({
  "schools": state.lookup.schools
})

export default connect(mapStateToProps)(Schools)