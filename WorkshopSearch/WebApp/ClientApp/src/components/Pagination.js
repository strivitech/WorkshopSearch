import React from 'react';
import styled from 'styled-components';
import PaginationButton from './PaginationButton';

const Pagination = ({
                        totalPages,
                        currentPage,
                        changePage,
                        maxVisiblePages = 5,
                        pageRange = 2,
                    }) => {
    const getPageNumbers = () => {
        const pageNumbers = [];

        const startPage =
            currentPage - pageRange > 0 ? currentPage - pageRange : 1;
        const endPage =
            currentPage + pageRange <= totalPages
                ? currentPage + pageRange
                : totalPages;

        if (endPage - startPage + 1 >= maxVisiblePages) {
            if (currentPage <= Math.floor(maxVisiblePages / 2)) {
                for (let i = 1; i <= maxVisiblePages; i++) {
                    pageNumbers.push(i);
                }
            } else if (currentPage >= totalPages - Math.floor(maxVisiblePages / 2)) {
                for (let i = totalPages - maxVisiblePages + 1; i <= totalPages; i++) {
                    pageNumbers.push(i);
                }
            } else {
                for (let i = startPage; i < startPage + maxVisiblePages; i++) {
                    pageNumbers.push(i);
                }
            }
        } else {
            for (let i = startPage; i <= endPage; i++) {
                pageNumbers.push(i);
            }
        }

        return pageNumbers;
    };

    const pages = getPageNumbers();
    const showFirstPage = currentPage > maxVisiblePages / 2 + 1;
    const showLastPage = currentPage < totalPages - maxVisiblePages / 2;

    return (
        <Wrapper>
            <ul className="pagination">
                {showFirstPage && (
                    <>
                        <PaginationButton
                            key={1}
                            isActive={currentPage === 1}
                            onClick={() => changePage(1)}
                        >
                            <span className="page-link">1</span>
                        </PaginationButton>
                        <li className="ellipsis">...</li>
                    </>
                )}
                {pages.map((page) => (
                    <PaginationButton
                        key={page}
                        isActive={currentPage === page}
                        onClick={() => changePage(page)}
                    >
                        <span className="page-link">{page}</span>
                    </PaginationButton>
                ))}
                {showLastPage && (
                    <>
                        <li className="ellipsis">...</li>
                        <PaginationButton
                            key={totalPages}
                            isActive={currentPage === totalPages}
                            onClick={() => changePage(totalPages)}
                        >
                            <span className="page-link">{totalPages}</span>
                        </PaginationButton>
                    </>
                )}
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

  .ellipsis {
    padding: 0.5rem 1rem;
  }
`;

export default Pagination;
