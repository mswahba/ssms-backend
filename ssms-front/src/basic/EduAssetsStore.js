import axios from 'axios';

class EduAssetsStore {
  state = {
    schools: [],
    maxSchoolId: 0
  }
  methods = {
    getSchools: () => {
      axios.get("/Schools/List/all")
        .then(res => this.store.setState({
          eduAssets: {
            schools: res.data,
            maxSchoolId: Math.max(...res.data.map(item=> +item.schoolId))
          }
        }))
    },
    getSchool: (id) => {
      const { schools } = this.store.state.eduAssets
      if(!schools.length)
        this.methods.getSchools();
      return schools.filter(item=> item.id === id)
    }
  }
}

export default new EduAssetsStore();