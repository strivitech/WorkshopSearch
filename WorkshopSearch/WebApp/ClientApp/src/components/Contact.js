import React from 'react'
import styled from 'styled-components'
const Contact = () => {
  return (
    <Wrapper>
      <div className='section-center'>
        <h3>Якщо у вас виникають питання або труднощі</h3>
        <div className='content'>
          <p>
            Наша команда завжди готова допомогти вам. Зв'яжіться з нами за телефоном або електронною поштою.
          </p>
          <div>
            <p>
              Наш телефон: +380 000 000 000
            </p>
            <hr/>
            <p>
              Наш e-mail: workshopsearchgroup@gmail.com
            </p>
          </div>
        </div>
      </div>
    </Wrapper>
  )
}
const Wrapper = styled.section`
  padding: 5rem 0;
  h3 {
    text-transform: none;
  }
  p {
    line-height: 2;
    max-width: 45em;
    color: var(--clr-grey-5);
  }
  @media (min-width: 992px) {
    .content {
      display: grid;
      grid-template-columns: 1fr 1fr;
      align-items: center;
      gap: 8rem;
      margin-top: 2rem;
    }
    p {
      margin-bottom: 0;
    }
  }
  @media (min-width: 1280px) {
    padding: 15rem 0;
  }
`

export default Contact
