import React, { Fragment } from "react";
import { Switch, Route } from "react-router-dom";
import EduAssetsState from "./EduAssetsState";
import { Consumer } from "../AppStore";
import SchoolsForm from "./SchoolsForm";
import SchoolsTable from "./SchoolsTable";

export default props => (
  <Consumer>
    {({ eduAssets, getSchools }) => {
      // get url from props.match.url [nested object destructuring]
      const { match: {url} } = props;
      if(!eduAssets.schools.length)
        getSchools();
      return (
        <Switch>
          <Route path={`${url}/form`} component={SchoolsForm} />
          <Route path={`${url}/list`} component={() => <SchoolsTable schools={eduAssets.schools} />} />
          <Route path="/" component={() => <h2>Schools</h2>} />
        </Switch>
      );
    }}
  </Consumer>
);
