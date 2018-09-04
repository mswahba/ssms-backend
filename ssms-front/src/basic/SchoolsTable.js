import React, { Component, Fragment } from "react";
import { Link } from 'react-router-dom';
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { connect } from "react-redux";
import { getTranslate } from 'react-localize-redux';
import { lookupActions } from "../store/lookup";
import { initTooltips, closeTooltips } from '../helpers';
import '../shared/data-table.css';
class SchoolsTable extends Component {

  constructor(props) {
    super(props);
    console.log(this.props);
    const { translate } = this.props;
    // define table columns values and header
    this.columns = [
      { field: "schoolId",      header: translate("schools.fields.schoolId") },
      { field: "schoolName",    header: translate("schools.fields.schoolNameAr") },
      { field: "schoolNameEn",  header: translate("schools.fields.schoolNameEn") },
      { field: "startDate",     header: translate("schools.fields.startDate") },
      { field: "address",       header: translate("schools.fields.address") },
      { field: "isActive",      header: translate("schools.fields.isActive") }
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
      lookupActions.deleteLookupEntity( {
        req: ['delete',`/schools/delete-by-id?deleteType=physical&key=${id}`],
        fulfilledToast: ["info","this school deleted successfully ..."]
      });
    }
    // define actions column jsx template
    this.actionTemplate = (rowData, column) => {
      return (
        <div className="action-icons">
          <Link to={`/schools/details/${rowData.schoolId}`}>
            <i data-position="top" data-tooltip={ translate("schools.actions.details") } className="tooltipped fas fa-info-circle green-text text-darken-3"></i>
          </Link>
          <Link to={`/schools/edit/${rowData.schoolId}`}>
            <i data-position="top" data-tooltip={ translate("schools.actions.edit") } className="tooltipped fas fa-edit blue-text text-darken-3"></i>
          </Link>
          <i data-position="top"
              data-tooltip={ translate("schools.actions.delete") }
              className="tooltipped fas fa-trash-alt red-text text-darken-3"
              onClick={ () => this.delete(rowData.schoolId) }
          ></i>
        </div>
      )
    };
    // define action column
    this.actionColumn = <Column key="actions" body={this.actionTemplate} header={ translate("schools.actions.title") } />;
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
    const { translate } = this.props
    return (
      <div className="container rtl">
        <Link to="/schools/new">
          <button className="btn waves-effect waves-light primary darken-3"
                    type="button"
                    id="btnAdd"
                    onClick={this.addSchool}
          >
            <i className="material-icons left">add</i>
            { translate("schools.actions.new") }
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
  "schools": state.lookup.schools.map(school => ({ ...school, startDate: new Date(school.startDate).toLocaleDateString('en-gb') }) ),
  "translate": getTranslate(state.localize),
  "localize": state.localize
})

export default connect(mapStateToProps)(SchoolsTable);