import React, { Fragment } from "react";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { connect } from "react-redux";

const SchoolsTable = ({ schools }) => {
  const columns = [
    { field: "schoolId", header: "Id" },
    { field: "schoolName", header: "Name Ar" },
    { field: "schoolNameEn", header: "Name En" },
    { field: "startDate", header: "Start Date" },
    { field: "address", header: "Start Date" },
    { field: "isActive", header: "isActive" }
  ];
  const Columns = columns.map(col => (
    <Column
      key={col.field}
      field={col.field}
      header={col.header}
      sortable={true}
      filter={true}
      filterMatchMode={"contains"}
      filterPlaceholder={`type ${col.header}`}
    />
  ));
  return (
    <Fragment>
      <DataTable
        className="responsive-table striped highlight"
        value={schools}
      >
        {Columns}
      </DataTable>
    </Fragment>
  );
};

const mapStateToProps = (state) => {
  return {...state.lookup}
}

export default connect(mapStateToProps)(SchoolsTable);