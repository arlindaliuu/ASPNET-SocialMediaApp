import React from "react";

export const Footer = () => <footer className="page-footer mt-5   w-100 bg-dark  font-small blue pt-4">
    <div className="container-fluid text-center text-md-left">
        <div className="row">
            <div className="col-md-6 mt-md-0 mt-3">
                <h5 style={{fontFamily: 'Georgia, serif'}} className="text-uppercase text-white fs-2">Foot<span  style={{color: '#339D40'}} className="fs-1">W</span>ork</h5>
                <p className="text-white fs-3">We bring the action into your creative content.</p>
            </div>

            <hr className="clearfix w-100 d-md-none pb-0"/>

            <div className="col-md-3 mb-md-0 mb-3">
                <h5 className="text-uppercase text-white">General</h5>
                <ul className="list-unstyled">
                    <li><a className="text-white text-decoration-none" href="#!">Services</a></li>
                    <li><a className="text-white text-decoration-none" href="#!">Login</a></li>
                    <li><a className="text-white text-decoration-none" href="#!">Sign Up</a></li>                </ul>
            </div>

            <div className="col-md-3 mb-md-0 mb-3">
                <h5 className="text-uppercase text-white">About</h5>
                <ul className="list-unstyled">
                    <li><a className="text-white text-decoration-none" href="#!">Help Center</a></li>
                    <li><a className="text-white text-decoration-none" href="#!">News</a></li>
                    <li><a className="text-white text-decoration-none" href="#!">About us</a></li>
                    <li><a className="text-white text-decoration-none" href="#!">Blog</a></li>
                </ul>
            </div>
        </div>
    </div>

    <div className="footer-copyright text-center text-white py-3">© 2023 Copyright: FOOTWORK
    </div>

</footer>

