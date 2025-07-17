import {url} from '../util/urls.js';
import {userInfo} from '../util/userInfo.js'

function makeDonation(petId){
    return fetch(url.getDonationUrl(), {
        method : 'POST',
        headers : {
            'content-type' : 'application/json',
            'X-Authorization' : userInfo.getToken()
        },
        body : JSON.stringify({petId})
    })
}

async function getTotalDonation(petId){
    return await fetch(url.getDonationUrl() + `?where=petId%3D%22${petId}%22&distinct=_ownerId&count`)
    .then(res => res.json())
    .then(donation => donation)
}

async function isAlreadyMade(petId, userId){
    return await fetch(url.getDonationUrl() + `?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
    .then(res => res.json())
    .then(data => data);
}


export const donations = {
    makeDonation,
    getTotalDonation,
    isAlreadyMade
}