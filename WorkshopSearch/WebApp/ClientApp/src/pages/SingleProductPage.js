import React, { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useProductsContext } from '../context/products_context';
import { single_product_url as url } from '../utils/constants';
import { formatPrice } from '../utils/helpers';
import { FaHouseUser } from 'react-icons/fa'
import { BsFillPeopleFill } from "react-icons/bs";
import { RiPriceTagFill } from "react-icons/ri";
import {
  Loading,
  Error,
  ProductImages,
} from '../components';
import styled from 'styled-components';
import { Link } from 'react-router-dom';
const SingleProductPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const {
    single_product_loading: loading,
    single_product_error: error,
    single_product: product,
    fetchSingleProduct,
  } = useProductsContext();

  useEffect(() => {
    fetchSingleProduct(`${url}${id}`);
    // eslint-disable-next-line
  }, [id]);
  useEffect(() => {
    if (error) {
      setTimeout(() => {
        navigate('/');
      }, 3000);
    }
    // eslint-disable-next-line
  }, [error]);
  if (loading) {
    return <Loading />;
  }
  if (error) {
    return <Error />;
  }

  const {
    title,
    phoneNumber,
    email,
    contactLinks,
    minAge,
    maxAge,
    price,
    address,
    imageUris,
    directionIds,
    description,
    owner
  } = product;
  return (
    <Wrapper>
      <div className='section section-center page'>
        <Link to='/workshops' className='btn'>
          назад до гуртків
        </Link>
        <div className='product-center'>
          <ProductImages images={imageUris} />
          <section className='content'>
            <h2>{title}</h2>
            <h5><FaHouseUser/> {owner}</h5>
            <p><RiPriceTagFill/> {formatPrice(price)}</p>
            <p className='info'>
              <span>PhoneNumber :</span>
              {phoneNumber}
            </p>
            <p className='info'>
              <span>Email :</span>
              {email}
            </p>
            <p className='info'>
              <span>ContactLinks :</span>
              {contactLinks}
            </p>
            <p><BsFillPeopleFill/> {minAge}-{maxAge} years</p>
            <p className='info'>
              <span>DirectionIds :</span>
              {directionIds}
            </p>
            <p className='info'>
              <span>Address :</span>
              {address}
            </p>
          </section>
        </div>
        <p className='desc'>{description}
          Lorem ipsum dolor sit amet co nsectetur a dipisicing elit. Quisquam
          Lorem ipsum dolor sit amet co nsectetur a dipisicing elit. Quisquam
          Lorem ipsum dolor sit amet co nsectetur a dipisicing elit. Quisquam
          Lorem ipsum dolor sit amet co nsectetur a dipisicing elit. Quisquam
          Lorem ipsum dolor sit amet co nsectetur a dipisicing elit. Quisquam
        </p>
      </div>
    </Wrapper>
  );
};

const Wrapper = styled.main`
  .product-center {
    display: grid;
    gap: 4rem;
    margin-top: 2rem;
    align-items: start !important;
  }
  .price {
    color: var(--clr-primary-5);
  }
  .desc {
    margin-top: 2rem;
    line-height: 2;
  }
  .info {
    text-transform: capitalize;
    width: 300px;
    display: grid;
    grid-template-columns: 125px 1fr;
    span {
      font-weight: 700;
    }
  }

  @media (min-width: 992px) {
    .product-center {
      grid-template-columns: 1fr 1fr;
      align-items: center;
    }
    .price {
      font-size: 1.25rem;
    }
  }
`;

export default SingleProductPage;
