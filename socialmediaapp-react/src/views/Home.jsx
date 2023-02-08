import React, { useEffect, useState } from "react";
import { Posts } from "../components/dummyData/posts";
import { Row, Container, Spinner, Col } from "react-bootstrap";
import { Post } from "../components/Post";
import { ProfileSideBar } from "../components/ProfileSideBar"
import { Content } from "../components/Content"
import axios from "axios";
import { FeedSideBar } from "../components/FeedSideBar";
import { useNavigate } from "react-router-dom";
import { v4 as uuidv4 } from 'uuid';
import jwt_decode from "jwt-decode";
import { Header } from '../components/Header';

export const Home = (props) =>{

    const [allPosts, setAllPosts] = useState(null)
    const [search, setSearch] = useState('')
    const [authenticated, setauthenticated] = useState(null);
    const [user, setUser] = useState();
    const [likes, setLikes] = useState();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [hasFetched, setHasFetched] = useState(false);
    const [imageSrc, setImageSrc] = useState(null);
    const navigate = useNavigate();

useEffect(() => {
        const newPosts = Posts().filter(post => {
            if (post.title.toLowerCase().includes(search.toLowerCase()))
                return true
            else
                return false
        })

        setAllPosts(newPosts)
    }, [search])
useEffect(()=>{
    if(allPosts === null){
        setLoading(true)
        axios.get('https://localhost:7080/api/posts1/',{
            headers:{
                Authorization:  'Bearer '+window.localStorage.getItem('footwork-token'),
                Accept: 'application/json'
            }
        }).then(res=>{
            setAllPosts(res.data)
            setLoading(false)
        }).catch(err =>{
            console.log(err)
        })
     }
},[])
useEffect(()=>{
    var token = window.localStorage.getItem('footwork-token');
    var decoded = jwt_decode(token);

    axios.post('https://localhost:7080/api/authentication/user',{email:decoded.Email})
    .then(res=>{
        setUser(res.data);
    }).catch(err =>{
        console.log(err.message)
    })
})
/////////////////////////////////////////////////
useEffect(() =>{
    var token = window.localStorage.getItem('footwork-token');
    var decoded = jwt_decode(token);

    axios.post('https://localhost:7080/api/authentication/user',{email:decoded.Email})
    .then(res=>{
        setUser(res.data);
    }).catch(err =>{
        console.log(err.message)
    })

   
 },[])

 useEffect(() => {
  const fetchData = async () => {
    setError(null);

    try {
      const response = await axios.get("https://localhost:7080/api/likes1/postslikes");
      setLikes(response.data);
      setHasFetched(true);
    } catch (e) {
      setError(e);
    } finally {
    
    }
  };

  if (!hasFetched) {
    fetchData();
  }
}, []);

    useEffect(() => {
    const loggedInUser = localStorage.getItem("authenticated");
        if (loggedInUser) {
        setauthenticated(loggedInUser);
    }
}, []);
if(!authenticated){
    navigate('/login')
}else{
    return<>
            <Header name={user?.first_name}/>

  <main style={{paddingTop: '100px', backgroundColor: '#f3f2ef'}}>
    
        
  
<Container>
    <Row>
    <ProfileSideBar />
        <Col className="col" align="center">
        <div>
            <Content />
        </div>
        <div>   
        
        {allPosts?.length === 0 && <>
        <h1>Nuk ka te dhena!</h1>
        </>}
        {loading? ( <Spinner />):(
        allPosts?.length > 0 &&
                
                 allPosts.map((post)=>
                    <div>
                        <Post  
                        likes={likes}
                        user={user}     
                        postlikes={
                            likes?.map(postlikes=>{
                                return post.id == postlikes.postId && <>{postlikes.count}</>

                            })
                        
                        }              
                        postId={post.id}
                        title={post.caption} 
                        description={post.post_url}
                        imageData={post.imageData}
                        date_posted={post.date_created} 
                        name={post.user?.first_name+" "+post.user?.last_name}
                        />
                 </div>
                 )
            )} </div>
            </Col>
            <FeedSideBar />
            </Row>
            </Container>
      
    </main>
    
    </>}
}