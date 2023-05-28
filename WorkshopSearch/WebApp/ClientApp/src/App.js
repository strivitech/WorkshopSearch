import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Navbar, Sidebar, Footer } from './components';
import { Home, SingleProduct, Error, Products } from './pages';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
    return (
        <Router>
            <Navbar />
            <Sidebar />
            <ToastContainer />
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path='workshops' element={<Products />} />
                <Route path='workshops/:id' element={<SingleProduct />} />
                <Route path='error' element={<Error />} />
            </Routes>
            <Footer />
        </Router>
    );
}

export default App;
