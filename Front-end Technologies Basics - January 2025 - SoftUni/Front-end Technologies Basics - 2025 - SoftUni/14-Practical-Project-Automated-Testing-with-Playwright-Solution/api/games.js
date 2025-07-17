import {url} from '../util/urls.js';
import {userInfo} from '../util/userInfo.js'

async function getAll(){
    return await fetch(url.getGamesUrl() + '?sortBy=_createdOn%20desc')
    .then(res => res.json())
    .then(items => items)
}
async function getMostResently(){
    return await fetch(url.getGamesUrl() + '?sortBy=_createdOn%20desc&distinct=category')
    .then(res => res.json())
    .then(items => items)
}

async function getById(id){
    return await fetch(url.getGamesUrl() + `/${id}`) 
    .then(res => res.json())
    .then(item => item);
}

function create(item){
    return fetch(url.getGamesUrl(), {
        method : 'POST',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(item)
    });
}

function deleteById(id){
    return fetch(url.getGamesUrl() + `/${id}`, {
        method : 'DELETE',
        headers : { 'X-Authorization' : userInfo.getToken() }
    });
}

/**
 * 
 * @param {object} object should contain id of entity
 */
function edit(item, id){
    return fetch(url.getGamesUrl() + `/${id}`, {
        method : 'PUT',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify(item)
    });
}

export const games = {
    getAll,
    getById,
    create,
    deleteById,
    edit,
    getMostResently
};