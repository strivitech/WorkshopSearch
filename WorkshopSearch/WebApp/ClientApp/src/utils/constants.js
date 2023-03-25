import React from 'react'
import {GiCompass, GiDiamondHard, GiStabbedNote} from 'react-icons/gi'

export const links = [
    {
        id: 1,
        text: 'Головна',
        url: '/',
    },
    {
        id: 2,
        text: 'Гуртки',
        url: '/workshops',
    },
]

export const services = [
    {
        id: 1,
        icon: <GiCompass/>,
        title: 'Для чого?',
        text:
            'Наш сайт допомагає батькам та дітям знайти ідеальний гурток, щоб розвивати таланти та інтереси, забезпечуючи найкращий вибір для кожної дитини.',
    },
    {
        id: 2,
        icon: <GiDiamondHard/>,
        title: 'Бачення',
        text:
            'Ми прагнемо створити спільноту, де кожна дитина зможе розкрити свій потенціал та розвинути свої здібності через участь у гуртках, наші пошукові інструменти стануть надійною опорою в цьому процесі!',
    },
    {
        id: 3,
        icon: <GiStabbedNote/>,
        title: 'Історія',
        text:
            'Наш сайт зародився з ідеї допомогти батькам та дітям знайти найкращі гуртки для розвитку здібностей.',
    },
]

export const products_url = 'workshops'
export const single_product_url = `workshops/`
