import React, { Fragment } from "react";
import EduAssetsState from "./EduAssetsState";
import SchoolsForm from "./SchoolsForm";
import SchoolsTable from "./SchoolsTable";

export default () => (
  <EduAssetsState keys={["schools"]}>
    {({ schools }) => (
      <Fragment>
        <SchoolsForm />
        <SchoolsTable schools={schools} />
      </Fragment>
    )}
  </EduAssetsState>
);