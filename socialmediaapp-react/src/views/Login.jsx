import axios from "axios";
import React, { useEffect, useState } from "react";
import { FormControl, FormLabel, FormGroup, Form, Container } from "react-bootstrap";
import { Link } from "react-router-dom";
import { ToastContainer, toast } from 'react-toastify';


export const Login = () =>{
    // const[email, setEmail] = useState('');
    // const[password, setPassword] = useState('');

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
    const handleLogin = (event) =>{
        event.preventDefault();
        
            axios.post("https://localhost:7080/api/authentication/", loginData)
            .then(res=>{
                toast.success("Success!");
                window.localStorage.setItem('smapp-token', res);
                this.props.history.push("/");
            }).catch(err=>{
                toast.error("Error!");
            })
    }
    return <Container>
    <ToastContainer />
        <Form onSubmit={handleLogin}>
        
            <FormGroup>
                <FormLabel>Email</FormLabel>
                <FormControl name="email"  onChange={handleSubmit} />
            </FormGroup>

            <FormGroup>
                <FormLabel>Password</FormLabel>
                <FormControl name="password" onChange={handleSubmit}/>
            </FormGroup>

            <FormGroup>
                <FormControl type="submit" name="submit"  />
            </FormGroup>
        </Form>
        </Container>
    
}