import React, { useState, useRef, useEffect } from 'react';
import Select from 'react-select';

const SearchableSelect = ({ options, name, placeholder, value, onChange }) => {
    const [inputValue, setInputValue] = useState('');
    const [filteredOptions, setFilteredOptions] = useState(options);
    const selectRef = useRef(null);

    useEffect(() => {
        const filterOptions = () => {
            const searchValue = inputValue.toLowerCase();
            const newOptions = options.filter(option =>
                option.label.toLowerCase().includes(searchValue)
            );
            setFilteredOptions(newOptions);
        };

        filterOptions();
    }, [inputValue, options]);

    const handleChange = (selectedOption) => {
        onChange({
            target: {
                name: name,
                value: selectedOption.value,
            },
        });
    };

    const selectedOption = options.find(option => option.value === value);

    return (
        <Select
            ref={selectRef}
            options={filteredOptions}
            placeholder={placeholder}
            value={selectedOption}
            onChange={handleChange}
            onInputChange={setInputValue}
            isSearchable={true}
            menuPortalTarget={document.body}
            styles={{
                menuPortal: base => ({ ...base, zIndex: 9999 }),
                menuList: base => ({ ...base, maxHeight: '200px', overflowY: 'scroll' })
            }}
        />
    );
};

export default SearchableSelect;
