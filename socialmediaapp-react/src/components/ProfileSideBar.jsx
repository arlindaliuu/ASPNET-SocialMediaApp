import React, { useEffect, useState } from "react";
import { Row, Container, Spinner, Col, Button } from "react-bootstrap";
import profilePhoto from '../assets/images/photo1.png'
import axios from "axios";
import friendIcon from '../assets/images/friends.png'
import groupIcon from '../assets/images/people.png'
import calendarIcon from '../assets/images/calendar.png'



export const ProfileSideBar = () =>{
    const [user, setUser] = useState(null);
    // useEffect(()=> {
    //     axios.get('https://localhost:7080/api/posts1/',{
           
    //     }).then(res=>{
    //         console.log(res.data);
            
    //     }).catch(err =>{
    //         console.log(err)
    //     })
    // })
    return <>
    <Col className="col-sm-3 d-none d-sm-block">
        <div style={{minHeight: '600px'}} className=" bg-white usercard border rounded">
            <div style={{height: '60px', backgroundColor: '#339D40'}} className="background" />
            <img style={{width: '80px', height: '80px', marginTop: '-50px'}} className="bg-white object-fit-fill border rounded-circle d-block mx-auto" src={profilePhoto} />
            <p className="text-center text-secondary">Biography</p>
            <hr />
            <Button variant="outline-light" className="w-100 text-start text-secondary d-flex"><img src={friendIcon} alt="" /><span style={{margin: 'auto'}}>Friends</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><img src={groupIcon} alt="" /><span style={{margin: 'auto'}}>Groups</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><img src={calendarIcon} alt="" /><span style={{margin: 'auto'}}>Events</span></Button>
            <hr />
            <p className="px-2 text-secondary">Profile</p>
            <hr />
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><span style={{margin: 'auto'}}>My Profile</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><span style={{margin: 'auto'}}>My Posts</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><span style={{margin: 'auto'}}>Account</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><span style={{margin: 'auto'}}>Help & Support</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><span style={{margin: 'auto'}}>Privacy</span></Button>
            <Button variant="outline-light" className="mt-2 w-100 text-start text-secondary d-flex"><span style={{margin: 'auto'}}>Logout</span></Button>

        </div>
    </Col>
    </>
}