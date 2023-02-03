import React from "react";
import profilePhoto from '../assets/images/photo1.png'
import { Row, Container, Spinner, Col, Button } from "react-bootstrap";
import calendarIcon from '../assets/images/calendar.png'
import galleryIcon from '../assets/images/gallery.png'
import videoIcon from '../assets/images/video.png'


export const Content= () =>{
    return <>
    <div style={{minHeight: '50px', marginBottom: '120px'}} className="py-2 bg-white w-full rounded content__container border">
    <div className="row px-5">
        <div className="col-sm-2">
        <img style={{width: '50px', height: '50px'}} className=" bg-white object-fit-fill border rounded-circle" src={profilePhoto} />
        </div>
        <input style={{borderRadius: '150px'}} placeholder="Start a post" className="col-sm-10 my-2 border " type="text" name="" id="" />
        <label style={{textAlign: 'left'}} className="mt-2 display-1 fs-5" htmlFor="content">Write your content here!</label>
        <input itemID="content" style={{ height: '50px'}} placeholder="Content" className="col-sm-12 my-2 border rounded" type="text" name="" id="" />

    </div>
    <div className="d-flex mt-5 px-5">
    <Button variant="outline-light" className="w-100 text-start text-secondary d-flex"><img src={galleryIcon} alt="" /><span style={{margin: 'auto'}}>Photo</span></Button>
    <Button variant="outline-light" className="w-100 text-start text-secondary d-flex"><img src={videoIcon} alt="" /><span style={{margin: 'auto'}}>Video</span></Button>
    <Button variant="outline-light" className="w-100 text-start text-secondary d-flex"><img src={calendarIcon} alt="" /><span style={{margin: 'auto'}}>Event</span></Button>
    </div>
    </div>
    </>
}