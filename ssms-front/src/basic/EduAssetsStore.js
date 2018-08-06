import axios from 'axios';

class EduAssetsStore {
  state = {
    schools: []
  }
  methods = {
    getSchools: () => {
      axios.get("/Schools/List/all")
        .then(res => this.store.setState({
          eduAssets: {
            schools: res.data
          }
        }))
    },
    getSchool: (id) => {
      const { schools } = this.store.state.eduAssets
      return schools.find(item=> item.schoolId === +id)
    }
  }
}

export default new EduAssetsStore();