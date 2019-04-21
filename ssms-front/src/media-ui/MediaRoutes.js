import React from "react";
import { Switch, Route } from "react-router-dom";
import Home from './Home'

export function MediaRoutes({}) {
  return (
    <Switch>
      <Route path="/home" component={Home} />
    </Switch>
  );
}
