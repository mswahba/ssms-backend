import M from "materialize-css";

const keepLastToast = () => {
  const toasts = document.querySelectorAll('.toast');
  const len = toasts.length;
  for (let i=0; i<len-1; i++)
    toasts[i].remove();
}

export const toast = ({ html, time, preventMultiple}) => {
  M.toast({ html, displayLength: time })
  if(preventMultiple)
    keepLastToast();
}
// initialize a datepicker [one element] with the given options
export const initDatePicker = ({ format, yearRange, defaultDate, onSelect }) => {
  const picker = document.querySelector(".datepicker");
  const options = {
    setDefaultDate: true,
    defaultDate,
    format,
    yearRange,
    onSelect
  }
  M.Datepicker.init(picker, options);
}
// initialize AutoComplete [elements] with the given options
// options is an Object where each key represents elementId
// and the value hold the element Autocomplete options
export const initAutoComplete = (options) => {
  const autoCompleteLists = document.querySelectorAll('.autocomplete');
  autoCompleteLists.forEach(elem => {
    M.Autocomplete.init(autoCompleteLists, options[elem.id]);
  });
}
// initialize a Select [elements] with empty options
export const initSelect = () => {
  const selectLists = document.querySelectorAll('select');
  M.FormSelect.init(selectLists, {});
}
// hold tooltips Instances
let tooltipsIns = [];
// initialize a Tooltip [elements] with fixed options
// and store all Tooltips Instances in [tooltipsIns]
export const initTooltips = () => {
  const elems = document.querySelectorAll('.tooltipped');
  tooltipsIns = M.Tooltip.init(elems, {position: 'top'});
}
// loop through all Tooltips Instances and close them
export const closeTooltips = (instances) => {
  tooltipsIns.forEach( instance => instance.close() );
}
// fixed format any date field => [toLocaleDateString('en-gb')]
export const formatDate = (key,format = true) => (item) => ({
  ...item,
  [key]: (format)? new Date(item[key]).toLocaleDateString('en-gb') : new Date(item[key])
});
// initialize a Select [elements] with empty options
export const initSidenav = (options = {}) => {
  const sidenavs = document.querySelectorAll('.sidenav');
  M.Sidenav.init(sidenavs, options);
}
// initialize a Select [elements] with empty options
export const initDropdown = (options = {}) => {
  const dropdowns = document.querySelectorAll('.dropdown-trigger');
  M.Dropdown.init(dropdowns, options);
}
// initialize a Select [elements] with empty options
export const initSlider = (options = {}) => {
  const sliders = document.querySelectorAll('.slider');
  M.Slider.init(sliders, options);
}
// get the Slider Instance
export const getSlider = (id) => M.Slider.getInstance(document.getElementById(id));
