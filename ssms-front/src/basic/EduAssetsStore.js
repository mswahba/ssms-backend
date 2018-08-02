import axios from 'axios';

export default class EduAssetsStore {
  constructor() {
    this.getSchools();
  }
  state = {
    schools: []
  }
  methods = {}
  getSchools = () => {
    axios.get("/Schools/List/all")
      .then(res => this.setState({
        schools: res.data
      }))
  }
}