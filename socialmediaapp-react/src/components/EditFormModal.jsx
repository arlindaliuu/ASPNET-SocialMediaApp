import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { FormControl, FormLabel, FormGroup, Form, Container } from "react-bootstrap";

export function EditFormModal(props) {
const [users, setUser] =useState(props.slctuser)
const [loginData, setLoginData] = useState({});
const [optionValue, setOptionValue] = useState('');
console.log(users)
const handleSubmit = (e) =>{
    e.preventDefault();

    const {name, value} = e.target;
     console.log(name, value);


    const tempData ={
        ...loginData,
        [name]: value,
        'gender': optionValue
    }
    setLoginData(tempData)
    console.log(tempData)
}
const handleSelect = (e) =>{
    setOptionValue(e.target.value)
    
}

  return (
    <Modal
      {...props}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Edit Data
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
      <Form className="d-flex flex-wrap" >
        
        <FormGroup style={{width: '48%'}} >
            <FormLabel>Email</FormLabel>
            <FormControl value={users?.email} name="email"   />
        </FormGroup>

        <FormGroup style={{width: '48%', marginLeft: '4%'}}>
            <FormLabel>Username</FormLabel>
            <FormControl value={users?.userName} name="username"  />
        </FormGroup>

        <FormGroup style={{width: '48%'}} >
            <FormLabel>Birthdate</FormLabel>
            <FormControl type='date' value={users?.birth_date} name="confirmpassword"  />
        </FormGroup>

        
        <FormGroup style={{width: '48%', marginLeft: '4%'}}>
            <FormLabel>First Name</FormLabel>
            <FormControl value={users?.first_name} name="first_name" />
        </FormGroup>

        <FormGroup style={{width: '48%'}}>
            <FormLabel>Country</FormLabel>
            <FormControl value={users?.country} name="country"  onChange={handleSubmit} />
        </FormGroup>

        <FormGroup style={{width: '48%', marginLeft: '4%'}}>
            <FormLabel>Last Name</FormLabel>
            <FormControl value={users?.last_name} name="last_name" />
        </FormGroup>

        <FormGroup style={{width: '48%'}}>
                <FormLabel>Gender</FormLabel>
                <select onChange={handleSelect} className="rounded border" style={{width: '100%', height: '55%'}} name="gender" id="">
                    <option value="">--Please choose an option-</option>
                    <option value="M">Mashkull</option>
                    <option value="F">Femer</option>

                </select>
            </FormGroup>


        <FormGroup style={{width: '48%', marginLeft: '4%'}}>
            <FormLabel>City</FormLabel>
            <FormControl value={users?.city} name="city"  onChange={handleSubmit} />
        </FormGroup>

  


        <FormGroup className="w-25 m-auto mt-5">
            <FormControl style={{backgroundColor: '#339D40'}} className="text-white" type="submit" name="submit" value="Register"  />
        </FormGroup>
    </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={props.onHide}>Close</Button>
      </Modal.Footer>
    </Modal>
  );
}




