import React from "react";
import { Button, Card } from "react-bootstrap";
import foto from '../assets/images/golden-retriever-dog-21668976.jpg'


export const Post = ({title, description, message}) => {
    return <>
        <Card style={{ width: '18rem' }}>
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
        </Card>
    </>
}