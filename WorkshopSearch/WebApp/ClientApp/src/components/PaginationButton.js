import React from 'react';
import styled from 'styled-components';

const PaginationButton = ({ isActive, onClick, children }) => {
    return (
        <Button isActive={isActive} onClick={onClick}>
            {children}
        </Button>
    );
};

const Button = styled.li`
  cursor: pointer;
  margin: 0 0.25rem;

  .page-link {
    display: inline-block;
    padding: 0.5rem 0.75rem;
    background-color: ${({ isActive }) => (isActive ? '#007bff' : '#f8f9fa')};
    border: 1px solid #dee2e6;
    border-radius: 0.25rem;
    color: ${({ isActive }) => (isActive ? '#fff' : '#007bff')};
    font-weight: 600;
    transition: background-color 0.2s, border-color 0.2s, color 0.2s;
  }

  &:hover .page-link {
    background-color: #007bff;
    border-color: #007bff;
    color: #fff;
  }
`;

export default PaginationButton;
