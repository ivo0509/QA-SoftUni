import {url} from '../util/urls.js';
import {userInfo} from '../util/userInfo.js'

async function getAll(){
    return await fetch(url.getItemsUrl() + '?sortBy=_createdOn%20desc&distinct=name')
    .then(res => res.json())
    .then(items => items)
}

async function getById(id){
    return await fetch(url.getItemsUrl() + `/${id}`) 
    .then(res => res.json())
    .then(item => item);
}

function create(item){
    return fetch(url.getItemsUrl(), {
        method : 'POST',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(item)
    });
}

function deleteById(id){
    return fetch(url.getItemsUrl() + `/${id}`, {
        method : 'DELETE',
        headers : { 'X-Authorization' : userInfo.getToken() }
    });
}

/**
 * 
 * @param {object} object should contain id of entity
 */
function edit(item, id){
    return fetch(url.getItemsUrl() + `/${id}`, {
        method : 'PUT',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(item)
    });
}

async function searchAlbums(query){
    return await fetch(url.getItemsUrl() + `?where=name%20LIKE%20%22${query}%22`)
    .then(res => res.json())
    .then(items => items);
}

export const items = {
    getAll,
    getById,
    create,
    deleteById,
    edit,
    searchAlbums
};