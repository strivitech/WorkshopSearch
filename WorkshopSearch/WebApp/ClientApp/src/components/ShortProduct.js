import React from 'react'
import styled from 'styled-components'
import { formatPrice } from '../utils/helpers'
import { FaHouseUser, FaAddressCard } from 'react-icons/fa'
import { BsFillPeopleFill } from "react-icons/bs";
import { RiPriceTagFill } from "react-icons/ri";
import { Link } from 'react-router-dom'
import {Stars} from "./index";
const ShortProduct = ({ id, title, owner, minAge, maxAge, price, address, coverImageUri, rating, reviewsCount }) => {
    return (
        <Wrapper>
            <Link to={`/workshops/${id}`}>
                <div className='wrapper'>
                    <div className='container'>
                        <img src={coverImageUri} alt={title} />
                    </div>
                    <footer>
                        <h5 className='title'>{title}</h5>
                        <Stars stars={rating} reviews={reviewsCount} />
                        <p><FaHouseUser/> {owner}</p>
                        <div className='years-price'>
                            <p><BsFillPeopleFill/> {minAge}-{maxAge} years</p>
                            <p><RiPriceTagFill/> {formatPrice(price)}</p>
                        </div>
                        <p><FaAddressCard/> {address}</p>
                    </footer>
                </div>
            </Link>
        </Wrapper>
    )
}
const Wrapper = styled.article`
  .wrapper:hover {
    cursor: pointer;
    box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.2);
    transform: scale(1.05, 1.05);
  }
  .container {
    position: relative;
    background: var(--clr-black);
    border-radius: var(--radius);
  }
  img {
    width: 100%;
    display: block;
    object-fit: cover;
    border-radius: var(--radius);
    transition: var(--transition);
  }
  .container:hover img {
    opacity: 0.5;
  }
  .title {
    margin-top: 1rem;
    margin-bottom: 0.5rem;
    display: flex;
    align-items: center;
    justify-content: center;
    color: var(--clr-black);
  }
  .years-price {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }
  footer {
    font-size: 0.9rem;
    margin-top: 0.5rem;
    margin-bottom: 0.5rem;
    margin-left: 0.5rem;
    margin-right: 0.5rem;
  }
  footer h5,
  footer p {
    margin-bottom: 0;
    font-weight: 400;
    color: var(--clr-primary-5);
    letter-spacing: var(--spacing);
  }
`
export default ShortProduct
