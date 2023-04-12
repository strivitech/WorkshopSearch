import {
  UPDATE_FILTERS,
  CLEAR_FILTERS
} from '../actions'

const filter_reducer = (state, action) => {
  if (action.type === UPDATE_FILTERS) {
    const { name, value } = action.payload
    return { ...state, filters: { ...state.filters, [name]: value } }
  }
  if (action.type === CLEAR_FILTERS) {
    return {
      ...state,
      filters: {
        ...state.filters,
        text: '',
        category: 1,
        minAge: 0,
        maxAge: 100,
        minPrice: 0,
        maxPrice: 100000,
        workingDays: {
          monday: false,
          tuesday: false,
          wednesday: false,
          thursday: false,
          friday: false,
          saturday: false,
          sunday: false,
        },
        regionWithCity: 'Київ,Київ'
      },
    }
  }
  throw new Error(`No Matching "${action.type}" - action type`)
}

export default filter_reducer
