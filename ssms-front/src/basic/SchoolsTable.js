import React from "react";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";

export default ({ schools }) => {
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
    <DataTable
      className="responsive-table striped highlight"
      value={schools}
    >
      {Columns}
    </DataTable>
  );
};
