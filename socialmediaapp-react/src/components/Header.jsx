import React from "react";
import { Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBell, faEnvelope, faHome, faHomeAlt } from "@fortawesome/free-solid-svg-icons";
import { NavItem } from "react-bootstrap";

export const Header = () =>{
    return<>
        {/* <header>
    <li><Link to='/about'>About</Link></li>
    <li><Link to='/'>Home</Link></li>
    <li><Link to='/contact'>Contact</Link></li>
    <li><Link to='/register'>Register</Link></li>
    <li><Link to='/login'>Login</Link></li>

    </header> */}
        <Navbar bg="light" expand="lg">
      <Container fluid>
        <Navbar.Brand href="#">Social Media App</Navbar.Brand>
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

          <NavDropdown align="end" title={<FontAwesomeIcon icon={faBell} />} >
            <NavDropdown.Item href="#">Notification 1</NavDropdown.Item>
          </NavDropdown>
          <NavDropdown align="end" title={<FontAwesomeIcon icon={faEnvelope} />} >
            <NavDropdown.Item href="#">Message 1</NavDropdown.Item>
            </NavDropdown>
          

          <Nav.Link as={Link} to="/">Home</Nav.Link>
          <Nav.Link as={Link} to="/login">Login</Nav.Link>
          <Nav.Link as={Link} to="/register">Register</Nav.Link>
          <NavDropdown align="end" title="Profile" id="navbarScrollingDropdown">
              <NavDropdown.Item href="#action3">Action</NavDropdown.Item>
              <NavDropdown.Item href="#action4">
                Another action
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action5">
                Something else here
              </NavDropdown.Item>
            </NavDropdown>
            </div>
          </Nav>
          
        </Navbar.Collapse>
      </Container>
    </Navbar>
    </>

    
}