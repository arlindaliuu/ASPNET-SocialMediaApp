import axios from "axios";
import React, { useEffect, useState } from "react";
import { FormControl, FormLabel, FormGroup, Form, Container } from "react-bootstrap";
import { ToastContainer, toast } from 'react-toastify';

function Register() {
    const [loginData, setLoginData] = useState({});
    const handleSubmit = (e) =>{
        e.preventDefault();

        const {name, value} = e.target;
        // console.log(name, value);


        const tempData ={
            ...loginData,
            [name]: value
        }
        setLoginData(tempData)
        console.log(tempData)


    }
    const handleRegister = (event) =>{
        event.preventDefault();
        
        
        
            axios.post("https://localhost:7080/api/authentication/register", loginData)
            .then(res=>{
                toast.success("Success!");
            }).catch(err=>{
                toast.error("Error!");
            })
    }
  return (

     <Container>
    <ToastContainer />
        <Form onSubmit={handleRegister}>
        
            <FormGroup>
                <FormLabel>Email</FormLabel>
                <FormControl name="email"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Password</FormLabel>
                <FormControl type="password" name="password" onChange={handleSubmit}/>
            </FormGroup>

            <FormGroup>
                <FormLabel>Confirm Password</FormLabel>
                <FormControl type="password" name="confirmpassword"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Username</FormLabel>
                <FormControl name="username"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>First Name</FormLabel>
                <FormControl name="first_name"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Last Name</FormLabel>
                <FormControl name="last_name"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Gender</FormLabel>
                <FormControl name="gender"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>City</FormLabel>
                <FormControl name="city"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Country</FormLabel>
                <FormControl name="country"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Profile picture</FormLabel>
                <FormControl type="file" name="profile_picture_url"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormControl type="submit" name="submit"  />
            </FormGroup>
        </Form>
        </Container>
  )
}

export default Register