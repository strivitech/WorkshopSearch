import React, { useContext, useReducer } from 'react'
import reducer from '../reducers/filter_reducer'
import {
  UPDATE_FILTERS,
  CLEAR_FILTERS,
} from '../actions'

const initialState = {
  filters: {
    text: '',
    category: null,
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
  },
}

const FilterContext = React.createContext()

export const FilterProvider = ({ children }) => {
  const [state, dispatch] = useReducer(reducer, initialState)
  const updateFilters = (e) => {
    let name = e.target.name
    let value = e.target.value
    if (name === 'category') {
      value = e.target.textContent
    }
    if (name === 'minAge' || name === 'maxAge') {
      value = Number(value)
    }
    if (name.startsWith('workingDays')) {
      const days = state.filters.workingDays
      const dayId = e.target.id.replace('working-days-', '');
      days[dayId] = e.target.checked;
      value = days
    }
    if (name === 'maxPrice' || name === 'minPrice') {
      value = Number(value)
    }
    dispatch({ type: UPDATE_FILTERS, payload: { name, value } })
  }
  const clearFilters = () => {
    dispatch({ type: CLEAR_FILTERS })
  }
  return (
    <FilterContext.Provider
      value={{
        ...state,
        updateFilters,
        clearFilters,
      }}
    >
      {children}
    </FilterContext.Provider>
  )
}

export const useFilterContext = () => {
  return useContext(FilterContext)
}
