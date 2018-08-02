import axios from 'axios'

export default class SharedStore {
  constructor() {
    this.getSignUpParentFormData();
  }
  state = {
    docTypes: [],
    countries: []
  }
  methods = {
    SignUpParentFormSubmit: (entity) => {
      // reshapping and adjustment entity
      console.log(entity);
      const user = {
        userId: entity.parentId,
        userPassword: entity.password,
        userTypeId: 3,
        _parent: {
          parentId: entity.parentId,
          fName: entity.fName,
          mName: entity.mName,
          gName: entity.gName,
          lName: entity.lName,
          idType: entity.idType,
          idExpireDateG: entity.idExpireDateG,
          mobile1: entity.mobile,
          email: entity.email,
          countryId: entity.countryId
        }
      };
      console.log(user);
      axios.post("/Users/Add", user)
            .then(res => {
              console.log(res);
              console.log(res.data);
            })
    }
  }
  getSignUpParentFormData = () => {
    axios.all([
      axios.get('/DocTypes?filters=docTypeId|<|4&fields=docTypeId,docTypeAr,docTypeEn'),
      axios.get('/Countries?fields=countryId,countryAr,countryEn')
    ])
      .then(
        axios.spread( (docTypes, countries) => {
          this.state.docTypes = docTypes.data,
          this.state.countries = countries.data
        })
      )
  }
}
