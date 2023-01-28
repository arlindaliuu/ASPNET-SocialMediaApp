import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import {Home} from './views/Home'
import {About} from './views/About'
import { Footer } from './components/Footer';
import { Header } from './components/Header';
import 'bootstrap/dist/css/bootstrap.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
  <Header />
  <Routes>
    
    <Route path={'/'} element={<Home message="props posts"/>} />
    <Route path={'/login'} element={<App />}/>
    <Route path='/about' element={<About />}/>
    <Route />

  </Routes>
  <Footer />
  </BrowserRouter>
  /* <React.StrictMode>
    <App />
  </React.StrictMode> */
  
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();