import React, { useEffect, useState } from "react";
import Table from 'react-bootstrap/Table';
import axios from "axios";
import { Button, Spinner } from "react-bootstrap";
import { ToastContainer, toast } from 'react-toastify';
import { EditFormModal  } from "./EditFormModal";

export const AllUsers = () =>{
const [users, setUsers] = useState(null)
const [modalShow, setModalShow] = React.useState(false);
const [id, setId] = useState(null);
const [email, setEmail] = useState(null);
const [selectedUser, setselectedUser] =useState(null)

    useEffect(()=>{

        axios.get('https://localhost:7080/api/authentication/allusers')
        .then(res=>{
            setUsers(res.data) 
        })
        .catch(err=>{
            console.log(err.message)
        })

    },[])

    const handleEdit = (id, email) =>{
        setModalShow(true)

        axios.post("https://localhost:7080/api/authentication/user", {email:email})
        .then(res=>{
            setselectedUser(res.data);
        }).catch(err =>{
            console.log(err.message)
        })
        
    }
    const handleDelete = (id) =>{
        
        axios.delete("https://localhost:7080/api/authentication/"+id)
        .then(res=>{
            toast.success("Deleted successfully!");
            window.location.reload(false);
        }).catch(err =>{
            toast.error("Something went wrong - "+ err.message)
        })
    }

    return <>
    <EditFormModal slctuser={selectedUser} show={modalShow}
        onHide={() =>{ setModalShow(false)}} />
      <ToastContainer />
    <h1>Welcome to admin panel </h1>
        <Table striped bordered hover variant="dark">
      <thead>
        <tr>
          <th>#</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
          <th>Email</th>
          <th>Gender</th>
          <th>Country</th>
          <th>City</th>
          <th>Birthdate</th>
          <th></th>
          <th></th>
          
        </tr>
      </thead>
      <tbody>
      {users?.map((user) =>{
                return <>
        <tr>
            <td>1</td>
            <td>{user.first_name}</td>
            <td>{user.last_name}</td>
            <td>{user.userName}</td>
            <td>{user.email}</td>
            <td>{user.gender}</td>
            <td>{user.country}</td>
            <td>{user.city}</td>
            <td>{user.birth_date}</td>
                         

          
            <td><Button onClick={() => handleEdit(user.id, user.email)} className="btn btn-warning">Edit</Button></td>
            <td><Button onClick={()=>{handleDelete(user.id)}} className="btn btn-danger">Delete</Button></td>
        </tr>

 
        
        </>   })}
      </tbody>
    </Table>
    </>
}