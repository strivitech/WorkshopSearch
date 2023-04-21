import React from 'react';
import styled from 'styled-components';
import PaginationButton from './PaginationButton';

const Pagination = ({ totalPages, currentPage, changePage }) => {
    const pages = Array.from({ length: totalPages }, (_, i) => i + 1);

    return (
        <Wrapper>
            <ul className="pagination">
                {pages.map((page) => (
                    <PaginationButton
                        key={page}
                        isActive={currentPage === page}
                        onClick={() => changePage(page)}
                    >
                        <span className="page-link">{page}</span>
                    </PaginationButton>
                ))}
            </ul>
        </Wrapper>
    );
};

const Wrapper = styled.div`
  .pagination {
    display: flex;
    justify-content: center;
    align-items: center;
    list-style-type: none;
    padding: 0;
    margin: 1rem 0;
  }
`;

export default Pagination;
