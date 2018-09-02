import React, { Component, Fragment } from "react";
import { Link } from 'react-router-dom';
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { connect } from "react-redux";
import { lookupActions } from "../store/lookup";
import { initTooltips, closeTooltips } from '../helpers';
import '../shared/data-table.css';
class SchoolsTable extends Component {

  constructor(props) {
    super(props);
    // handle delete
    this.delete = (id) => {
      lookupActions.deleteLookupEntity( {
        req: ['delete',`/schools/delete-by-id?deleteType=physical&key=${id}`],
        fulfilledToast: ["info","this school deleted successfully ..."]
      });
    }
    // define table columns values and header
    this.columns = [
      { field: "schoolId", header: "Id" },
      { field: "schoolName", header: "Name Ar" },
      { field: "schoolNameEn", header: "Name En" },
      { field: "startDate", header: "Start Date" },
      { field: "address", header: "Start Date" },
      { field: "isActive", header: "isActive" }
    ];
    // define actions column jsx template
    this.actionTemplate = (rowData, column) => {
      return (
        <div className="action-icons">
          <Link to={`/schools/details/${rowData.schoolId}`}>
            <i data-position="top" data-tooltip="details" className="tooltipped fas fa-info-circle green-text text-darken-3"></i>
          </Link>
          <Link to={`/schools/edit/${rowData.schoolId}`}>
            <i data-position="top" data-tooltip="edit" className="tooltipped fas fa-edit blue-text text-darken-3"></i>
          </Link>
          <i data-position="top"
              data-tooltip="delete"
              className="tooltipped fas fa-trash-alt red-text text-darken-3"
              onClick={ () => this.delete(rowData.schoolId) }
          ></i>
        </div>
      )
    };
    // define action column
    this.actionColumn = <Column body={this.actionTemplate} header="Actions" />;
    // dynamically define dataTable columns List
    this.Columns = this.columns.map(col => (
      <Column
        key={col.field}
        field={col.field}
        header={col.header}
        sortable={true}
        /*filter={true}
        filterMatchMode={"contains"}
        filterPlaceholder={`type ${col.header}`}*/
      />
    ));
    // add the actions column to the Columns List
    this.Columns.push(this.actionColumn);
  }

  componentDidMount() {
    setTimeout(initTooltips, 100);
  }

  componentWillUnmount() {
    closeTooltips();
  }

  render() {
    return (
      <div className="container">
        <Link to="/schools/new">
          <button className="btn waves-effect waves-light primary darken-3"
                    type="button"
                    id="btnAdd"
                    onClick={this.addSchool}
          >
            <i className="material-icons left">add</i>
            New School
          </button>
        </Link>
        <DataTable
          className="responsive-table striped highlight"
          value={this.props.schools}
        >
          {this.Columns}
        </DataTable>
      </div>
    )
  }
}

const mapStateToProps = (state) => ({
  "schools": state.lookup.schools.map(school => ({ ...school, startDate: new Date(school.startDate).toLocaleDateString('en-gb') }) )
})

export default connect(mapStateToProps)(SchoolsTable);