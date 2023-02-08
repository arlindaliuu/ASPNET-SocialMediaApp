import axios from "axios";
import { useNavigate } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { FormControl, FormLabel, FormGroup, Form, Container } from "react-bootstrap";
import { ToastContainer, toast } from 'react-toastify';
import { Footer } from "../components/Footer";
import { Header } from "../components/Header";

function Register() {
    const [loginData, setLoginData] = useState({});
    const [optionValue, setOptionValue] = useState('');
    const navigate = useNavigate();
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

    const handleRegister = (event) => {
        event.preventDefault();
      
        const formData = new FormData();
        formData.append("ImageFile", loginData.ImageFile);
        formData.append("first_name", loginData.first_name);
        formData.append("last_name", loginData.last_name);
        formData.append("UserName", loginData.UserName);
        formData.append("Email", loginData.Email);
        formData.append("Password", loginData.Password);
        formData.append("ConfirmPassword", loginData.ConfirmPassword);
        formData.append("birth_date", loginData.birth_date);
        formData.append("active", loginData.active);
        formData.append("date_updated", loginData.date_updated);
        formData.append("country", loginData.country);
        formData.append("city", loginData.city);
        formData.append("state", loginData.state);
        formData.append("gender", optionValue);
        formData.append("activation_key", loginData.activation_key);
      
        axios
          .post("https://localhost:7080/api/authentication/register", formData, {
            headers: { "Content-Type": "multipart/form-data" }
          })
          .then((res) => {
            toast.success("Success!");
            navigate("/login");
          })
          .catch((err) => {
            toast.error("Error! - " + err.message);
          });
      };
  return <>
    <Header />
     <Container style={{marginTop: '100px', marginBottom: '100px'}} >
            <div className="position-absolute" style={{right: '0px', top:'0px',zIndex:'-9999',width: '100%', height: '100%', backgroundColor: '#f3f2ef'}}></div>
        <div className="position-absolute" style={{left: '0px', top:'0px', transform: 'rotate(120deg)',zIndex:'-9999',width: '500px', height: '500px', backgroundColor: '#339D40'}}></div>
        <div className="position-absolute" style={{right: '0px', top:'0px', transform: 'rotate(60deg)',zIndex:'-9999',width: '500px', height: '500px', backgroundColor: '#339D40'}}></div>
    <ToastContainer />

    <div style={{backdropFilter: 'blur(20px)'}} className="border p-sm-5 p-1 ">
    <h1 style={{color: '#339D40'}} className="text-center">Register</h1>
    
        <Form className="d-flex flex-wrap" onSubmit={handleRegister}>
        
            <FormGroup style={{width: '48%'}} >
                <FormLabel>Email</FormLabel>
                <FormControl name="email"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup style={{width: '48%', marginLeft: '4%'}}>
                <FormLabel>Username</FormLabel>
                <FormControl name="username"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup style={{width: '48%'}}>
                <FormLabel>Password</FormLabel>
                <FormControl type="password" name="password" onChange={handleSubmit}/>
            </FormGroup>

            <FormGroup style={{width: '48%', marginLeft: '4%'}} >
                <FormLabel>Confirm Password</FormLabel>
                <FormControl type="password" name="confirmpassword"  onChange={handleSubmit} />
            </FormGroup>


            <FormGroup style={{width: '48%'}}>
                <FormLabel>First Name</FormLabel>
                <FormControl name="first_name"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup style={{width: '48%', marginLeft: '4%'}}>
                <FormLabel>Last Name</FormLabel>
                <FormControl name="last_name"  onChange={handleSubmit} />
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
                <FormControl name="city"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup style={{width: '48%'}}>
                <FormLabel>Country</FormLabel>
                <FormControl name="country"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup style={{width: '48%', marginLeft: '4%'}}>
                <FormLabel>Profile picture</FormLabel>
                <FormControl type="file" name="ImageFile"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup className="w-25 m-auto mt-5">
                <FormControl style={{backgroundColor: '#339D40'}} className="text-white" type="submit" name="submit" value="Register"  />
            </FormGroup>
        </Form>
        </div>
        </Container>
        <Footer />
        </>
  
}

export default Register