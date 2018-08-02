import React, { Fragment } from "react";
import { Switch, Route } from 'react-router-dom';
import EduAssetsState from "./EduAssetsState";
import SchoolsForm from "./SchoolsForm";
import SchoolsTable from "./SchoolsTable";

export default (props) => (
  <EduAssetsState keys={["schools"]}>
    {({ schools }) => (
      <Switch>
        <Route path={`${props.match.url}/form`} component={SchoolsForm} />
        <Route path={`${props.match.url}/list`} component={() => <SchoolsTable schools={schools} /> } />
        <Route path='/' component={() => <h2>Schools</h2> } />
      </Switch>
    )}
  </EduAssetsState>
);