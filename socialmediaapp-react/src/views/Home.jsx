import React, { useEffect, useState } from "react";
import { Posts } from "../components/dummyData/posts";
import { Row, Container, Spinner } from "react-bootstrap";
import { Post } from "../components/Post";
import axios from "axios";

export const Home = (props) =>{

    const [allPosts, setAllPosts] = useState(null)
    const [search, setSearch] = useState('')



    // useEffect(() => {
    //     const newPosts = Posts().filter(post => {
    //         if (post.title.toLowerCase().includes(search.toLowerCase()))
    //             return true
    //         else
    //             return false
    //     })

    //     setAllPosts(newPosts)
    // }, [search])
useEffect(()=>{
    if(allPosts === null){

        axios.post('https://localhost:7080/api/posts1/',{
            caption:'Post added by api',
            latitude:12,
            longtitude: 12.2,
            post_url: "linkedin.com/123",
            
            User:   {
                "first_name": "Levant1",
                "last_name": "Dalovi1",
                "role": "User",
                "gender": "F",
                "city": "Gjilann",
                "state": "Kosove1",
                "country": null,
                "profile_picture_url": "www.insta1.com",
                "birth_date": "2009-02-04T21:23:00",
                "date_created": "2023-01-22T21:23:31.3103998",
                "date_updated": "2023-01-27T19:09:12.6427167",
                "active": "Yes1",
                "activation_key": "123452",
                "followings": null,
                "id": "2502c6a5-c680-4401-a404-b95f90d3aadd",
                "userName": "ae510444@ubt-uni.net",
                "normalizedUserName": "AE51044@UBT-UNI.NET",
                "email": "ae510444@ubt-uni.net",
                "normalizedEmail": "AE51044@UBT-UNI.NET",
                "emailConfirmed": false,
                "passwordHash": "AQAAAAEAACcQAAAAELjZM8mcXv5VIQGH8Bg5PfeUTuE7721ip4s5sGypSJssh15TM5tdZ+SHriWBn05yiA==",
                "securityStamp": "PUVY6EMI63VUZHKQ2AMVWHBDJTYZBG72",
                "concurrencyStamp": "d33cebae-14f0-4462-9e57-bf19be377f91",
                "phoneNumber": null,
                "phoneNumberConfirmed": false,
                "twoFactorEnabled": false,
                "lockoutEnd": null,
                "lockoutEnabled": true,
                "accessFailedCount": 0
            }
        


        }
        
        ).then(res=>{
            

        })


        // axios.get('https://localhost:7080/api/posts1/').then(res=>{
        //     console.log(res.data);
        //     setAllPosts(res.data)
        // }).catch(err =>{
        //     console.log(err)
        // })
    }
})

    // const getCreationDate = (dateCreated) => {

    //     //...//

    //     return dateCreated
    // }
    return<>
 
    <div>
        <input onChange={e=>setSearch(e.target.value)}  />
    </div>
    <h1>These are the posts {props.message}</h1>
    <main>
            <h1>Welcome to home page</h1>
            <div>
                <span>search:</span>
                <input onChange={e => setSearch(e.target.value)} />
            </div>
            <h3>Posts:</h3>
<Container>
<Row>
        {allPosts === null && <Spinner />}
        {allPosts?.length === 0 && <>
        <h1>Nuk ka te dhena!</h1>
        </>}
        {allPosts?.length > 0 &&
            
                 allPosts.map(post=>{
                    return <Post 
                    message={'bla bla'} 
                    title={post.caption} 
                    description={post.post_url} />
                })
            
            }


            </Row>
            </Container>
        <h1>This is home page</h1>
    </main>
    
    </>
}