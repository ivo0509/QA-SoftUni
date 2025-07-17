import {url} from '../util/urls.js'
import {userInfo} from '../util/userInfo.js'

async function getAll(gameId){
    return await fetch(url.getBaseUrl() + `/data/comments?where=gameId%3D%22${gameId}%22`)
                    .then(res => res.json())
                    .then(c => c);
}

function postNew(comment){
    return fetch(url.getBaseUrl() + `/data/comments`, {
        method : 'POST',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(comment)
    })
}

export const comments ={
    getAll,
    postNew
}