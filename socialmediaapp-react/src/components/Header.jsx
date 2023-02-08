import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBell, faEnvelope, faHome, faHomeAlt } from "@fortawesome/free-solid-svg-icons";
import { NavItem } from "react-bootstrap";

export const Header = (props) =>{
  const [authenticated, setauthenticated] = useState(null);
  const navigate = useNavigate()
  useEffect(() => {
    const loggedInUser = localStorage.getItem("authenticated");
        if (loggedInUser) {
        setauthenticated(loggedInUser);
    }
}, []);
const handleLogout = () =>{
  localStorage.removeItem("authenticated");

}
    return<>

        <Navbar bg="light" expand="lg">
      <Container fluid>
        <Navbar.Brand style={{fontFamily: 'Georgia, serif'}} href="#">FOOT<span style={{color: '#339D40'}} className="fs-2">W</span>ORK</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="d-flex justify-content-between my-2 my-lg-0 w-100"
            style={{ maxHeight: '100px'}}
            navbarScroll
          >
        <Form className="d-flex">
            <Form.Control
              type="search"
              placeholder="Search"
              className="me-2"
              aria-label="Search"
            />
            <Button variant="outline-success">Search</Button>
          </Form>
          <div style={{width: '500px'}} className="d-flex justify-content-between">
          <Nav.Link><FontAwesomeIcon icon={faHome} /></Nav.Link>

          <NavDropdown align="end" title={<> <FontAwesomeIcon icon={faBell} /><span className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-secondary">+99 <span className="visually-hidden">unread messages</span></span> </>} >
            <NavDropdown.Item href="#">Notification 1</NavDropdown.Item>
          </NavDropdown>
          <NavDropdown align="end" title={<FontAwesomeIcon icon={faEnvelope} />} >
            <NavDropdown.Item href="#">Message 1</NavDropdown.Item>
            </NavDropdown>
          

          <Nav.Link as={Link} to="/">Welcome, {props.name}</Nav.Link>
          {!authenticated && <> <Nav.Link as={Link} to="/login">Login</Nav.Link>
          

          <Nav.Link as={Link} to="/register">Register</Nav.Link> </>}
          {authenticated && <NavDropdown align="end" title="Profile" id="navbarScrollingDropdown">
              <NavDropdown.Item href="#action3">Action</NavDropdown.Item>
              <NavDropdown.Item href="#action4">
                Another action
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action5">
                Something else here
              </NavDropdown.Item>
              {authenticated && <NavDropdown.Item onClick={handleLogout} href="/login">
                Logout
              </NavDropdown.Item>}
            </NavDropdown>}          
            </div>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
    </>

    
}