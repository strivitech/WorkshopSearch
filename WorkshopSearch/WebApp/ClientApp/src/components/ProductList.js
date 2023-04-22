import React from 'react';
import GridView from './GridView';
import { useProductsContext } from '../context/products_context';

const ProductList = () => {
  const { products } = useProductsContext();

  if (!products || products.length < 1) {
    return (
        <h5 style={{ textTransform: 'none' }}>
          Вибачте, жодного гуртка не знайдено за вашим запитом :(
        </h5>
    );
  }

  return <GridView products={products} />;
};

export default ProductList;
