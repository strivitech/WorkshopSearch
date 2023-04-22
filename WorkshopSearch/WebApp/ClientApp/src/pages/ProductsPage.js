import React from 'react'
import styled from 'styled-components'
import { Filters, ProductList } from '../components'
import Pagination from "../components/Pagination";
import {useProductsContext} from "../context/products_context";
const ProductsPage = () => {
  const { changePage, totalPages, currentPage } = useProductsContext();
  
  return (
      <main>
        <Wrapper className='page'>
          <div className='section-center products'>
            <Filters />
            <div>
              <ProductList />
              <Pagination
                  totalPages={totalPages}
                  currentPage={currentPage}
                  changePage={changePage}
              />
            </div>
          </div>
        </Wrapper>
      </main>
  );
};

const Wrapper = styled.div`
  .products {
    display: grid;
    gap: 3rem 1.5rem;
    margin: 4rem auto;
  }
  @media (min-width: 768px) {
    .products {
      grid-template-columns: 200px 1fr;
    }
  }
`

export default ProductsPage
