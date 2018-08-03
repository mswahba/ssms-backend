import axios from 'axios';

class EduAssetsStore {
  state = {
    schools: []
  }
  methods = {}
    getSchools = () => {
      axios.get("/Schools/List/all")
        .then(res => this.setState({
          eduAssets: {
            schools: res.data
          }
        }))
    }
}

export default new EduAssetsStore();