import React, {useEffect, useState} from 'react'
import styled from 'styled-components'
import {useFilterContext} from '../context/filter_context'
import SearchableSelect from "./SearchableSelect";

const Filters = () => {
    const {
        filters: {
            text,
            category,
            minAge,
            maxAge,
            maxPrice,
            minPrice,
            workingDays,
            regionWithCity
        },
        updateFilters,
        clearFilters,
    } = useFilterContext()
    
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        async function fetchCategories() {
            try {
                const response = await fetch('/api/directions');
                const data = await response.json();
                setCategories(data.map((category) => ({ value: category.id, label: category.name })));
            } catch (error) {
                console.error('Error fetching categories:', error);
            }
        }
        fetchCategories();
    }, []);
    
    return (
        <Wrapper>
            <div className='content'>
                <form onSubmit={(e) => e.preventDefault()}>

                    <div className='form-control'>
                        <SearchableSelect
                            name='regionWithCity'
                            placeholder='Select an option'
                            value={regionWithCity}
                            onChange={updateFilters}
                        />
                    </div>
                    
                    <div className='form-control'>
                        <input
                            type='text'
                            name='text'
                            value={text}
                            placeholder='Пошук'
                            onChange={updateFilters}
                            className='search-input'
                        />
                    </div>

                    <div className='form-control'>
                        <h5>Категорія</h5>
                        <div>
                            {categories.map((c, index) => {
                                return (
                                    <button
                                        data-id={c.value}
                                        key={index}
                                        onClick={updateFilters}
                                        type='button'
                                        name='category'
                                        value={c.value}
                                        className={`${category === c.value ? 'active' : null}`}
                                    >
                                        {c.label}
                                    </button>
                                );
                            })}
                        </div>
                    </div>
                    <div className='form-control'>
                        <h5>Вік</h5>
                        <div className='form-control'>
                            <input
                                type='text'
                                name='minAge'
                                placeholder='Від'
                                onChange={updateFilters}
                                className='age'
                            />
                            <input
                                type='text'
                                name='maxAge'
                                placeholder='До'
                                onChange={updateFilters}
                                className='age'
                            />
                        </div>
                    </div>
                    
                    <div className='form-control'>
                        <h5>Робочі дні</h5>
                        <div className='working-days-checker'>
                            <label htmlFor='working-days-monday'>Понеділок</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-monday'
                                checked={workingDays.monday}
                                onChange={updateFilters}
                            />
                            <label htmlFor='working-days-tuesday'>Вівторок</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-tuesday'
                                checked={workingDays.tuesday}
                                onChange={updateFilters}
                            />
                            <label htmlFor='working-days-wednesday'>Середа</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-wednesday'
                                checked={workingDays.wednesday}
                                onChange={updateFilters}
                            />
                            <label htmlFor='working-days-thursday'>Четвер</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-thursday'
                                checked={workingDays.thursday}
                                onChange={updateFilters}
                            />
                            <label htmlFor='working-days-friday'>П'ятниця</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-friday'
                                checked={workingDays.friday}
                                onChange={updateFilters}
                            />
                            <label htmlFor='working-days-saturday'>Субота</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-saturday'
                                checked={workingDays.saturday}
                                onChange={updateFilters}
                            />
                            <label htmlFor='working-days-sunday'>Неділя</label>
                            <input
                                type='checkbox'
                                name='workingDays[]'
                                id='working-days-sunday'
                                checked={workingDays.sunday}
                                onChange={updateFilters}
                            />
                        </div>    
                    </div>
                    
                    <div className='form-control'>
                        <h5>Ціна</h5>
                        <input
                            type='text'
                            name='minPrice'
                            placeholder='Від'
                            onChange={updateFilters}
                            className='price'
                        />
                        <input
                            type='text'
                            name='maxPrice'
                            placeholder='До'
                            onChange={updateFilters}
                            className='price'
                        />
                    </div>
                </form>
                <button
                    type='button'
                    className='clear-btn'
                    onClick={() => window.location.reload()}
                >
                    Очистити фільтри
                </button>
            </div>
        </Wrapper>
    )
}

const Wrapper = styled.section`
  .form-control {
    margin-bottom: 1.25rem;
    h5 {
      margin-bottom: 0.5rem;
    }
  }
  .working-days-checker {
    display: grid;
    grid-template-columns: auto 1fr;
    align-items: center;
    column-gap: 0.5rem;
    margin-bottom: 0.5rem;
  }
  .search-input, .age, .price {
    padding: 0.5rem;
    background: var(--clr-grey-10);
    border-radius: var(--radius);
    border-color: transparent;
    letter-spacing: var(--spacing);
  }
  .search-input::placeholder, .age::placeholder {
    text-transform: capitalize;
  }
  .age, .price {
    margin-bottom: 0.5rem;
  }
  button {
    display: block;
    margin: 0.25em 0;
    padding: 0.25rem 0;
    text-transform: capitalize;
    background: transparent;
    border: none;
    border-bottom: 1px solid transparent;
    letter-spacing: var(--spacing);
    color: var(--clr-grey-5);
    cursor: pointer;
  }
  .active {
    border-color: var(--clr-grey-5);
    opacity: 1;
    text-decoration: underline;
  }
  .clear-btn {
    background: var(--clr-red-dark);
    color: var(--clr-white);
    padding: 0.25rem 0.5rem;
    border-radius: var(--radius);
  }
  @media (min-width: 768px) {
    .content {
      position: sticky;
      top: 1rem;
    }
  }
`

export default Filters
