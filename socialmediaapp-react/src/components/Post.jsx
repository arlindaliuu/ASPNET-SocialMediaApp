import React, { useEffect, useState } from "react";
import { Button, Card } from "react-bootstrap";
import profilePhoto from '../assets/images/photo1.png'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCommenting, faGlobe, faGlobeAmericas, faShareSquare, faThumbsUp } from "@fortawesome/free-solid-svg-icons";
import axios from "axios";


export const Post = ({title, description, postId,name, date_posted, user, postlikes, imageData}) => {

  const handlePostClick = (postId) => {
  
     const userData = {
      UserId: user?.id,
      PostId: postId
     }
    
     axios.post('https://localhost:7080/api/likes1/', userData)
     .then(res=>{
  
     }).catch(err =>{
   
     })
    }
    return <>
    <Card  style={{ marginBottom: '50px'}}>
      <div className="row py-2">
        <div className="col-2  m-auto ">
          <img style={{width: '50px', height: '50px'}} className="object-fit-fill border rounded-circle" src={profilePhoto} />
        </div>

        <div  className="col-10 text-start">
          <h3 className=" fw-normal fs-6">{name}</h3>
          <div>
          <FontAwesomeIcon icon={faGlobeAmericas} />
        </div>
        </div>

      </div>
        <Card.Img style={{maxHeight:"400px"}} variant="top" src={`data:image/jpeg;base64,${imageData}`} />
        <Card.Body>
          <Card.Title align="left" className="fw-normal fs-5">{title}</Card.Title>
          <Card.Text align="left" className="fw-light fs-6">
            {description}
          </Card.Text>
          <div align="left">
          <Button onClick={() => handlePostClick(postId)}  variant="light"><FontAwesomeIcon icon={faThumbsUp} /><span style={{color: '#339D40'}}> {postlikes}</span> </Button>
          
          <Button variant="light"><FontAwesomeIcon icon={faCommenting} /></Button>
          <Button variant="light"><FontAwesomeIcon icon={faShareSquare} /></Button>
          </div>
        </Card.Body>
        <Card.Footer>
          <small className="text-muted">{date_posted}</small>
        </Card.Footer>
      </Card>
    </>
}