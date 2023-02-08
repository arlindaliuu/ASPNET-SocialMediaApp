import axios from "axios";
import React, { useEffect, useState } from "react";
import { FormControl, FormLabel, FormGroup, Form, Container } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { ToastContainer, toast } from 'react-toastify';
import { Footer } from '../components/Footer';
import loginPhoto from '../assets/images/loginphoto.png'

export const Login = () =>{
    // const[email, setEmail] = useState('');
    // const[password, setPassword] = useState('');
    const navigate = useNavigate();
    const [authenticated, setauthenticated] = useState(
    localStorage.getItem(localStorage.getItem("authenticated") || false)
    );
    
    const [loginData, setLoginData] = useState({});
    const handleSubmit = (e) =>{
        e.preventDefault();

        const {name, value} = e.target;
        const tempData ={
            ...loginData,
            [name]: value
        }
        setLoginData(tempData)
        console.log(tempData)


    }
    const handleLogin = (event) =>{
        event.preventDefault();
        
            axios.post("https://localhost:7080/api/authentication/", loginData)
            .then(res=>{
                window.localStorage.setItem('footwork-token', res.data)
                toast.success("Success!");
                localStorage.setItem("authenticated", true);                
                navigate('/')
                window.location.reload(false);
            }).catch(err=>{
                toast.error("Error!" + err.message);
            })
    }
    return <>
    <Container  className="m-auto mt-5">
    <ToastContainer />
    <div  className=" border row m-auto p-5">
        <div className="col-sm-6">
            <img  className="object-fit-contain w-100 h-100" src={loginPhoto} alt="" />
        </div>
        <div className="col-sm-6">
        <h1 style={{color: '#339D40', fontWeight: '600',}} className="w-75 m-auto display-5">Login</h1>
        <Form onSubmit={handleLogin}>
        <FormGroup className="w-75 m-auto">
            <FormLabel className="mt-2">Email</FormLabel>
            <FormControl  name="email"  onChange={handleSubmit} />
        </FormGroup>

        <FormGroup className="w-75 m-auto">
            <FormLabel className="mt-3 " >Password</FormLabel>
            <FormControl type="password" name="password" onChange={handleSubmit}/>
        </FormGroup>

        <FormGroup>
            <FormControl style={{color: '#339D40'}} className="w-50 m-auto mt-5" type="submit" name="submit"  />
        </FormGroup>
    </Form>
        </div>
      
        </div>
        </Container>
        <div className="d-sm-block d-none position-absolute left-0 bottom-0 right-0 w-100">
        <Footer />
        </div>
        <div className="d-block d-sm-none position-static left-0 bottom-0 right-0 w-100">
        <Footer />
        </div>
        
     </>
}