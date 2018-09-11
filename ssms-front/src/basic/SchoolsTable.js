import React, { Component, Fragment } from "react";
import { Link } from 'react-router-dom';
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { connect } from "react-redux";
import { getTranslate } from 'react-localize-redux';
import { lookupActions } from "../store/lookup";
import { initTooltips, closeTooltips, formatDate } from '../helpers';
import '../shared/data-table.css';
class SchoolsTable extends Component {

  constructor(props) {
    super(props);
    console.log(this.props);
    const { trans } = this.props;
    // define table columns values and header
    this.columns = [
      { field: "schoolId",      header: trans("schools.fields.schoolId") },
      { field: "schoolName",    header: trans("schools.fields.schoolNameAr") },
      { field: "schoolNameEn",  header: trans("schools.fields.schoolNameEn") },
      { field: "startDate",     header: trans("schools.fields.startDate") },
      { field: "address",       header: trans("schools.fields.address") }
    ];
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
    // handle delete
    this.delete = (id) => {
      const { trans } = this.props;
      if( window.confirm( trans('schools.actions.deleteConfirm') ) ) {
        lookupActions.deleteLookupEntity( {
          req: ['delete',`/schools/delete-by-id?deleteType=physical&key=${id}`],
          fulfilledToast: ["info", trans('schools.actions.deleteSuccess')]
        });
      }
    }
    // define isActive column jsx template
    this.isActiveTemplate = (rowData) => {
      const fa = (rowData.isActive)
                  ? 'fa-check-square'
                  : 'fa-square'
      return (
        <div className="center">
          <i className={`green-text text-darken-3 far ${fa}`}></i>
        </div>
      )
    };
    // define isActive column
    this.isActiveColumn = <Column key="isActive" body={this.isActiveTemplate} header={ trans("schools.fields.isActive") } />;
    // add the isActive column to the Columns List
    this.Columns.push(this.isActiveColumn);
    // define actions column jsx template
    this.actionTemplate = (rowData) => {
      return (
        <div className="action-icons">
          <Link to={`/schools/details/${rowData.schoolId}`}>
            <i data-position="top" data-tooltip={ trans("schools.actions.details") } className="tooltipped fas fa-info-circle green-text text-darken-3"></i>
          </Link>
          <Link to={`/schools/edit/${rowData.schoolId}`}>
            <i data-position="top" data-tooltip={ trans("schools.actions.edit") } className="tooltipped fas fa-edit blue-text text-darken-3"></i>
          </Link>
          <i data-position="top"
              data-tooltip={ trans("schools.actions.delete") }
              className="tooltipped fas fa-trash-alt red-text text-darken-3"
              onClick={ () => this.delete(rowData.schoolId) }
          ></i>
        </div>
      )
    };
    // define action column
    this.actionColumn = <Column key="actions" body={this.actionTemplate} header={ trans("schools.actions.title") } />;
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
    const { trans } = this.props;
    return (
      <div className="container rtl">
        <Link to="/schools/new">
          <button className="btn waves-effect waves-light primary darken-3"
                    type="button"
                    id="btnAdd"
                    onClick={this.addSchool}
          >
            <i className="material-icons left">add</i>
            { trans("schools.actions.new") }
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
  "schools": state.lookup.schools.map( formatDate('startDate') ),
  "trans": getTranslate(state.localize),
  "localize": state.localize
})

export default connect(mapStateToProps)(SchoolsTable);