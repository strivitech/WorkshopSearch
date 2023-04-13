import axios from 'axios'
import React, {useContext, useEffect, useReducer, useState} from 'react'
import reducer from '../reducers/products_reducer'
import {
  SIDEBAR_OPEN,
  SIDEBAR_CLOSE,
  GET_PRODUCTS_BEGIN,
  GET_PRODUCTS_SUCCESS,
  GET_PRODUCTS_ERROR,
  GET_SINGLE_PRODUCT_BEGIN,
  GET_SINGLE_PRODUCT_SUCCESS,
  GET_SINGLE_PRODUCT_ERROR,
} from '../actions'
import {useFilterContext} from "./filter_context";

const initialState = {
  isSidebarOpen: false,
  products_loading: false,
  products_error: false,
  products: [],
  single_product_loading: false,
  single_product_error: false,
  single_product: {},
}

const DEFAULT_FILTERS = {
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
};

const ProductsContext = React.createContext()

// TODO: Add filter validation
export const ProductsProvider = ({ children }) => {
  const DEBOUNCE_DELAY = 2000;

  function useDebounce(value, delay) {
    const [debouncedValue, setDebouncedValue] = useState(value);

    useEffect(() => {
      const timerId = setTimeout(() => {
        setDebouncedValue(value);
      }, delay);

      return () => {
        clearTimeout(timerId);
      };
    }, [value, delay]);

    return debouncedValue;
  }
  
  const { filters } = useFilterContext()
  const [state, dispatch] = useReducer(reducer, initialState)
  const debouncedFilters = useDebounce(filters, DEBOUNCE_DELAY);
  useEffect(() => {
    let filtersToUri = {}
  
    const [region, city] = filters.regionWithCity.split(',');
    filtersToUri["regionWithCity.region"] = region;
    filtersToUri["regionWithCity.city"] = city;

    filtersToUri.categoryId = filters.category;
    
    if (filters.text !== DEFAULT_FILTERS.text) {
      filtersToUri.text = filters.text;
    }

    if (filters.minAge !== DEFAULT_FILTERS.minAge) {
      filtersToUri.minAge = filters.minAge;
    }

    if (filters.maxAge !== DEFAULT_FILTERS.maxAge) {
      filtersToUri.maxAge = filters.maxAge;
    }
    
    if (filters.minPrice !== DEFAULT_FILTERS.minPrice) {
      filtersToUri.minPrice = filters.minPrice;
    }

    if (filters.maxPrice !== DEFAULT_FILTERS.maxPrice) {
      filtersToUri.maxPrice = filters.maxPrice;
    }

    const selectedDays = Object.keys(filters.workingDays).filter(key => filters.workingDays[key]);
    if (selectedDays.length > 0) {
      filtersToUri.workshop_days = selectedDays.join(',');
    }
    
    let urlParams = new URLSearchParams(filtersToUri).toString();
    if(urlParams.length > 0) {
      fetchProducts(`api/workshops` + '?' + urlParams)
    } else {
      fetchProducts(`api/workshops`)
    }
  }, [debouncedFilters])
  const openSidebar = () => {
    dispatch({ type: SIDEBAR_OPEN })
  }
  const closeSidebar = () => {
    dispatch({ type: SIDEBAR_CLOSE })
  }

  const fetchProducts = async (url) => {
    dispatch({ type: GET_PRODUCTS_BEGIN })
    try {
      const response = await axios.get(url)
      const products = response.data
      dispatch({ type: GET_PRODUCTS_SUCCESS, payload: products })
    } catch (error) {
      dispatch({ type: GET_PRODUCTS_ERROR })
    }
  }
  const fetchSingleProduct = async (url) => {
    dispatch({ type: GET_SINGLE_PRODUCT_BEGIN })
    try {
      const response = await axios.get(url)
      const singleProduct = response.data
      console.log(singleProduct)
      dispatch({ type: GET_SINGLE_PRODUCT_SUCCESS, payload: singleProduct })
    } catch (error) {
      dispatch({ type: GET_SINGLE_PRODUCT_ERROR })
    }
  }

  return (
    <ProductsContext.Provider
      value={{
        ...state,
        openSidebar,
        closeSidebar,
        fetchSingleProduct,
      }}
    >
      {children}
    </ProductsContext.Provider>
  )
}

export const useProductsContext = () => {
  return useContext(ProductsContext)
}
