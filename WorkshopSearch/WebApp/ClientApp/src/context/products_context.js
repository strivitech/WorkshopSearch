import axios from 'axios';
import React, {useContext, useEffect, useReducer, useState} from 'react';
import reducer from '../reducers/products_reducer';
import {
    SIDEBAR_OPEN,
    SIDEBAR_CLOSE,
    GET_PRODUCTS_BEGIN,
    GET_PRODUCTS_SUCCESS,
    GET_PRODUCTS_ERROR,
    GET_SINGLE_PRODUCT_BEGIN,
    GET_SINGLE_PRODUCT_SUCCESS,
    GET_SINGLE_PRODUCT_ERROR,
} from '../actions';
import {useFilterContext} from './filter_context';
import { toast } from 'react-toastify';

const initialState = {
    isSidebarOpen: false,
    products_loading: false,
    products_error: false,
    products: [],
    single_product_loading: false,
    single_product_error: false,
    single_product: {},
    totalPages: 0,
    currentPage: 1,
};

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
    regionWithCity: 'Київ,Київ',
};

const ProductsContext = React.createContext();

// TODO: Add filter validation
export const ProductsProvider = ({children}) => {
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

    const {filters} = useFilterContext();

    const [currentPage, setCurrentPage] = useState(1, (page) => {
        fetchData(page);
    });
    const [state, dispatch] = useReducer(reducer, initialState);
    const debouncedFilters = useDebounce(filters, DEBOUNCE_DELAY);
    const [pageChanged, setPageChanged] = useState(false);

    useEffect(() => {
        setCurrentPage(1);
        fetchData(1);
    }, [debouncedFilters]);

    useEffect(() => {
        if (pageChanged) {
            fetchData(currentPage);
            setPageChanged(false);
        }
    }, [currentPage, pageChanged]);


    const fetchData = async (page) => {
        let filtersToUri = {};

        const [region, city] = filters.regionWithCity.split(',');
        filtersToUri['regionWithCity.region'] = region;
        filtersToUri['regionWithCity.city'] = city;

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

        const selectedDays = Object.keys(filters.workingDays).filter(
            (key) => filters.workingDays[key],
        );

        selectedDays.forEach((day) => {
            filtersToUri[`workingDays`] = filtersToUri[`workingDays`] || [];
            filtersToUri[`workingDays`].push(day);
        });

        let urlParams = new URLSearchParams();

        Object.keys(filtersToUri).forEach((key) => {
            if (Array.isArray(filtersToUri[key])) {
                filtersToUri[key].forEach((value) => {
                    urlParams.append(key, value);
                });
            } else {
                urlParams.append(key, filtersToUri[key]);
            }
        });

        let params = urlParams.toString();
        const from = page;
        const size = 9;
        if (params.length > 0) {
            fetchProducts(`api/workshops` + '?' + params, from, size);
        } else {
            fetchProducts(`api/workshops`, from, size);
        }
    };


    const openSidebar = () => {
        dispatch({ type: SIDEBAR_OPEN });
    };
    const closeSidebar = () => {
        dispatch({ type: SIDEBAR_CLOSE });
    };
    
    const changePage = (newPage) => {
        setPageChanged(true);
        setCurrentPage(newPage);
    };

    const fetchProducts = async (url, from, size) => {
        dispatch({ type: GET_PRODUCTS_BEGIN });
        try {
            const response = await axios.get(`${url}&from=${from}&size=${size}`);
            if (response.status < 200 || response.status >= 300) {
                throw new Error('Server responded with an error status');
            }
            const data = response.data;
            dispatch({ type: GET_PRODUCTS_SUCCESS, payload: data });
        } catch (error) {
            dispatch({ type: GET_PRODUCTS_ERROR });
            toast.error("Виникла помилка. Перевірте введені дані.", {
                position: toast.POSITION.TOP_CENTER
            });
        }
    };

    const fetchSingleProduct = async (url) => {
        dispatch({ type: GET_SINGLE_PRODUCT_BEGIN });
        try {
            const response = await axios.get(url);
            if (response.status < 200 || response.status >= 300) {
                throw new Error('Server responded with an error status');
            }
            const singleProduct = response.data;
            dispatch({ type: GET_SINGLE_PRODUCT_SUCCESS, payload: singleProduct });
        } catch (error) {
            dispatch({ type: GET_SINGLE_PRODUCT_ERROR });
            toast.error("Виникла помилка. Перевірте введені дані.", {
                position: toast.POSITION.TOP_CENTER
            });
        }
    };

    return (
        <ProductsContext.Provider
            value={{
                ...state,
                openSidebar,
                closeSidebar,
                fetchSingleProduct,
                changePage,
                currentPage,
            }}
        >
            {children}
        </ProductsContext.Provider>
    );
};

export const useProductsContext = () => {
    return useContext(ProductsContext);
};

