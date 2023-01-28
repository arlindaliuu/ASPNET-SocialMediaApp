import React from "react";
import { Link } from "react-router-dom";
export const Header = () =>{
    return<>
        <header>
    <li><Link to='/login'>Login</Link></li>
    <li><Link to='/about'>About</Link></li>
    <li><Link to='/'>Home</Link></li>
    <li><Link to='/contact'>Contact</Link></li>

    </header>
    </>
}