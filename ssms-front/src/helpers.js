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