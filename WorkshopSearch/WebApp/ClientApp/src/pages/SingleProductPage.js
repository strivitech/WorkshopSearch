import React, { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useProductsContext } from '../context/products_context';
import { formatPrice } from '../utils/helpers';
import { FaHouseUser } from 'react-icons/fa'
import { BsFillPeopleFill } from "react-icons/bs";
import { RiPriceTagFill } from "react-icons/ri";
import {
  Loading,
  Error,
  ProductImages,
  Stars
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

  const translateDayToUkrainian = (day) => {
    const daysTranslations = {
      'Monday': 'Понеділок',
      'Tuesday': 'Вівторок',
      'Wednesday': 'Середа',
      'Thursday': 'Четвер',
      'Friday': 'П’ятниця',
      'Saturday': 'Субота',
      'Sunday': 'Неділя',
    };
    return daysTranslations[day] || day;
  };
  
  useEffect(() => {
    fetchSingleProduct(`api/workshops/${id}`);
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
    contactLinks = [],
    minAge,
    maxAge,
    price,
    address = { region: '', city: '', street: '', buildingNumber: '' },
    imageUris,
    directions = [],
    description,
    owner,
    rating,
    reviewsCount,
    coverImageUri,
    days = [],
    enrollmentStatus,
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
            <Stars stars={rating} reviews={reviewsCount} />
            <EnrollmentStatus isOpen={enrollmentStatus === 1}>
              {enrollmentStatus === 1 ? "Відкрито набір" : "Набір закритий"}
            </EnrollmentStatus>
            <p className='info'>
              <span><FaHouseUser/> Власник: </span>
                {owner}
            </p>
            <p className='info'>
              <span><RiPriceTagFill/> Ціна: </span>
                {formatPrice(price)}
            </p>
            <p className='info'>
              <span>Телефон:</span>
                <span onClick={() => navigator.clipboard.writeText(phoneNumber)} style={{ cursor: 'pointer' }}>
                    {phoneNumber}
                </span>
            </p>
              <p className='info'>
                  <span>Email:</span>
                  <span onClick={() => navigator.clipboard.writeText(email)} style={{ cursor: 'pointer' }}>
                    {email}
                  </span>
              </p>
            <p className='info'>
              <span>Посилання:</span>
              {contactLinks.map((link, index) => (
                  <React.Fragment key={index}>
                    {index > 0 && <br />}
                    <a href={link} target="_blank" rel="noopener noreferrer">{link}</a>
                  </React.Fragment>
              ))}
            </p>
            <p className='info'>
              <span><BsFillPeopleFill/> Вік: </span>
                {minAge}-{maxAge} років
            </p>
            <p className='info'>
              <span>Напрями:</span>
              {directions.map((direction, index) => (
                  <React.Fragment key={direction.id}>
                    {index > 0 && <br />}
                    {direction.name}
                  </React.Fragment>
              ))}
            </p>
            <p className='info'>
              <span>Адреса:</span>
              {address.region === address.city
                  ? `${address.city}, ${address.street}, ${address.buildingNumber}`
                  : `${address.region}, ${address.city}, ${address.street}, ${address.buildingNumber}`}
            </p>
              <p className='info'>
                <span>Робочі дні:</span>
                {days.map((day, index) => (
                    <React.Fragment key={index}>
                      {index > 0 && <br />}
                      {translateDayToUkrainian(day)}
                    </React.Fragment>
                ))}
              </p>
          </section>
        </div>
        <p className='desc'>{description}</p>
      </div>
    </Wrapper>
  );
};

const EnrollmentStatus = styled.span`
    display: inline-block;
    padding: 0.25rem 0.5rem;
    border-radius: 1rem;
    background-color: ${props => props.isOpen ? "green" : "red"};
    color: white;
    margin-left: 0.5rem;
    font-size: 0.8rem;
    font-weight: bold;
`;

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
    width: 300px;
    display: grid;
    grid-template-columns: 125px 1fr;
    span {
      font-weight: 700;
    }
  }
  .info a {
    text-transform: none;
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
