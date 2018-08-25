import M from "materialize-css";

const keepLastToast = () => {
  const toasts = document.querySelectorAll('.toast');
  const len = toasts.length;
  for (let i=0; i<len-1; i++)
    toasts[i].remove();
}

export default ({ html, time, preventMultiple}) => {
  M.toast({ html, displayLength: time })
  if(preventMultiple)
    keepLastToast();
}