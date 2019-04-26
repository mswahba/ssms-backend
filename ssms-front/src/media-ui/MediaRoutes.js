import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Home from './Home'
import Sections from "./Sections";
import Facilities from "./Facilities";
import Admission from "./Admission";

export default function MediaRoutes({}) {
  return (
    <Switch>
      <Route path="/home" component={Home} />
      <Route path="/sections" component={Sections} />
      <Route path="/facilities" component={Facilities} />
      <Route path="/admission" component={Admission} />
      <Redirect to="/home" />
    </Switch>
  );
}
