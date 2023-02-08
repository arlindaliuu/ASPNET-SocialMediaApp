import React from "react";
import { Row, Container, Spinner, Col, Button } from "react-bootstrap";
import profilePhoto from '../assets/images/photo1.png'
import '../assets/css/styles.css'

export const UserFeed = (props) => {
    return <> 
        <div className="addfriendcard row px-2 mt-2">
            <div className="col-1">
                <img className="bg-white border rounded-circle" style={{width: '60px', height: '60px'}} src={props.photo} alt="" />
            </div>
            <div  className="col-7 flex m-auto">
                <p style={{height: '1px'}}>{props.name}</p>
                <p style={{fontSize: '12px', minHeight: '1px'}} className="fw-normal text-secondary pt-2">{props.bio}</p>
            </div>
                <div>
                    <Button style={{borderRadius: '50px', color: '#339D40'}} className="px-5 btn btn-sample btn-outline-light bg-white border m-auto d-block">Follow</Button>
                </div>
        </div>
    </>
}