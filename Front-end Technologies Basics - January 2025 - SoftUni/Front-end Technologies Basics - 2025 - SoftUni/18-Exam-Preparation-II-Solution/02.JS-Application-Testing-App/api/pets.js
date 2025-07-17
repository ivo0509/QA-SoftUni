import {url} from '../util/urls.js';
import {userInfo} from '../util/userInfo.js';

async function getAll(){
    return await fetch(url.getPetsUrl() + '?sortBy=_createdOn%20desc&distinct=name')
    .then(res => res.json())
    .then(items => items)
}

async function getById(id){
    return await fetch(url.getPetsUrl() + `/${id}`) 
    .then(res => res.json())
    .then(item => item);
}

function create(item){
    return fetch(url.getPetsUrl(), {
        method : 'POST',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(item)
    });
}

function deleteById(id){
    return fetch(url.getPetsUrl() + `/${id}`, {
        method : 'DELETE',
        headers : { 'X-Authorization' : userInfo.getToken() }
    });
}


function edit(item, id){
    return fetch(url.getPetsUrl() + `/${id}`, {
        method : 'PUT',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(item)
    });
}

export const pets = {
    getAll,
    getById,
    create,
    deleteById,
    edit
};