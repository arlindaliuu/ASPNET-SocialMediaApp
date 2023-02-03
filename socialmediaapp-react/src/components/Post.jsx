import React from "react";
import { Button, Card } from "react-bootstrap";
import foto from '../assets/images/golden-retriever-dog-21668976.jpg'
import profilePhoto from '../assets/images/photo1.png'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCommenting, faGlobe, faGlobeAmericas, faShareSquare, faThumbsUp } from "@fortawesome/free-solid-svg-icons";




export const Post = ({title, description, message,name, date_posted}) => {
    return <>
        {/* <Card style={{ width: '18rem' }}>
            <Card.Img variant="top" src={foto} />
            <Card.Body>
                <Card.Title>title is: {title}</Card.Title>
                <Card.Text>
                    {description}
                </Card.Text>
                <div className="d-flex justify-content-between">
                    <Button variant="primary">Buy</Button>
                    <Button variant="primary">Add to cart</Button>
                </div>
            </Card.Body>
        </Card> */}
    <Card  style={{width: '32rem', marginBottom: '50px'}}>
      <div className="row py-2">
        <div className="col-sm-2 m-auto ">
          <img style={{width: '50px', height: '50px'}} className="object-fit-fill border rounded-circle" src={profilePhoto} />
        </div>

        <div  className="col-sm-10 text-start">
          <h3 className=" fw-normal fs-6">{name}</h3>
          <div>
          <FontAwesomeIcon icon={faGlobeAmericas} />
        </div>
        </div>

      </div>
        <Card.Img variant="top" src={foto} />
        <Card.Body>
          <Card.Title align="left" className="fw-normal fs-5">{title}</Card.Title>
          <Card.Text align="left" className="fw-light fs-6">
            {description}
          </Card.Text>
          <div align="left">
          <Button variant="light"><FontAwesomeIcon icon={faThumbsUp} /></Button>
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