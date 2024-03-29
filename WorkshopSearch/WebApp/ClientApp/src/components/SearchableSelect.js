﻿import React, { useState, useEffect, useRef } from 'react';
import Select from 'react-select';

const SearchableSelect = ({ name, placeholder, value, onChange }) => {
    const [inputValue, setInputValue] = useState('');
    const [filteredOptions, setFilteredOptions] = useState([]);
    const selectRef = useRef(null);

    useEffect(() => {
        const fetchOptions = async () => {
            if (inputValue.trim() === '') {
                setFilteredOptions([]);
                return;
            }

            try {
                const response = await fetch(`/api/locations?word=${inputValue}`);
                const data = await response.json();
                const newOptions = data.map((location) => {
                    const nameArray = location.name.split(',');
                    let label;
                    if (nameArray.length === 2 && nameArray[0] === nameArray[1]) {
                        label = nameArray[1];
                    } else {
                        label = location.name;
                    }
                    return {
                        value: location.name,
                        label: label,
                    };
                });

                setFilteredOptions(newOptions);
            } catch (error) {
                console.error('Error fetching locations:', error);
            }
        };

        fetchOptions();
    }, [inputValue]);

    const handleChange = (selectedOption) => {
        onChange({
            target: {
                name: name,
                value: selectedOption.value,
            },
        });
        localStorage.setItem('selectedOption', selectedOption.value);
    };

    useEffect(() => {
        const selectedValue = localStorage.getItem('selectedOption');
        if (selectedValue) {
            setInputValue(selectedValue);
        }
    }, []);

    const selectedOption = filteredOptions.find(
        (option) => option.value === value
    );

    return (
        <Select
            ref={selectRef}
            options={filteredOptions}
            placeholder={placeholder}
            noOptionsMessage={() => "Відсутні співпадіння"}
            value={selectedOption}
            onChange={handleChange}
            onInputChange={setInputValue}
            isSearchable={true}
            menuPortalTarget={document.body}
            filterOption={null}
            styles={{
                menuPortal: (base) => ({ ...base, zIndex: 9999 }),
                menuList: (base) => ({
                    ...base,
                    maxHeight: '200px',
                    overflowY: 'scroll',
                }),
            }}
        />
    );
};

export default SearchableSelect;
