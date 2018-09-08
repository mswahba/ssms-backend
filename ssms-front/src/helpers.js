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

export const initDatePicker = ({ format, yearRange, defaultDate, onSelect }) => {
  const pickers = document.querySelector(".datepicker");
  const options = {
    setDefaultDate: true,
    defaultDate,
    format,
    yearRange,
    onSelect
  }
  M.Datepicker.init(pickers, options);
}

let tooltipsIns = [];

export const initTooltips = () => {
  const elems = document.querySelectorAll('.tooltipped');
  tooltipsIns = M.Tooltip.init(elems, {position: 'top'});
}

export const closeTooltips = (instances) => {
  tooltipsIns.forEach( instance => instance.close() );
}

// export const importAll = (dir, extension) => {
//   const _importAll = (r) => r.keys().map(r);
//   return _importAll(require.context(dir, false, new RegExp(extension+"$")));
// }

export const formatDate = (key) => (item) => ({
  ...item,
  [key]: new Date(item[key]).toLocaleDateString('en-gb')
});