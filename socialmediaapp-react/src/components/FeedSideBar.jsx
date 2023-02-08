import React from "react";
import { Row, Container, Spinner, Col, Button } from "react-bootstrap";
import profilePhoto from '../assets/images/photo1.png'
import profilePhoto1 from '../assets/images/photo2.jpg'
import profilePhoto2 from '../assets/images/photo3.jpg'
import profilePhoto3 from '../assets/images/photo4.jpg'
import profilePhoto4 from '../assets/images/photo5.jpg'
import { UserFeed } from "./UserFeed";



export const FeedSideBar = () =>{
    return <>
    <Col className="col-3 d-none d-sm-block">
            <div style={{minHeight: '600px'}} className="p-2 bg-white usercard border rounded">
                <p className="display-1 fs-6 px-2">Add to your feed</p>
                <UserFeed photo={profilePhoto2} name="Filan Fisteku" bio="This is Filan, Im 29yo, I work for Tesla company!"/>
                <UserFeed photo={profilePhoto3} name="John Doe" bio="Hi im John Doe, nice to meet you"/>
                <UserFeed photo={profilePhoto1} name="Zejdi Limani" bio="Zejdi a passionant man and a hardworker person."/>
                <UserFeed photo={profilePhoto} name="Arlind Aliu" bio="Im Arlind I want you to check my profile"/>
                <UserFeed photo={profilePhoto4} name="Rinor Rexhepi" bio="No bio given"/>
    </div>
    </Col>
    </>
}