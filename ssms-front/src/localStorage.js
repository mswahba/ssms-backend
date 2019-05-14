export default class LS {
  static get(key) {
    try {
      return JSON.parse(localStorage.getItem(key));
    } catch (err) {
      return localStorage.getItem(key);
    }
  }
  static set(key, value) {
    typeof value === "object"
      ? localStorage.setItem(key, JSON.stringify(value))
      : localStorage.setItem(key, value);
  }
  static remove(key) {
    localStorage.removeItem(key);
  }
}
