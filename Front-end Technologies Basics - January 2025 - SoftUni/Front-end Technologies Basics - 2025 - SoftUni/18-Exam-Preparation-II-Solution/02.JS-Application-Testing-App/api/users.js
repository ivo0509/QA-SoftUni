import {url} from '../util/urls.js';
import {userInfo} from '../util/userInfo.js';

/**
 * 
 * @param {string} email 
 * @param {string} password 
 * @description check if response is ok. If so, save accessToken to sessionStorage and redirect to page (common - home/main page). 
 */
function login(email, password){
    return fetch(url.getLoginUrl(), {
        method : 'POST',
        headers : { 'content-type' : 'application/json' },
        body : JSON.stringify({
            email,
            password
        })
    });
}

/**
 * @description check for status 204 if logout is successful
 */
function logout(){
    return fetch(url.getLogoutUrl(), {
        method : 'GET',
        headers : { 'X-Authorization' : userInfo.getToken() }
    });
}

/**
 * 
 * @param {object} user - object with data for user (email, password and etc)
 * @description check if response is ok. If so, redirect to page (common to login page).
 * */
function register(user){
    return fetch(url.getRegisterUrl(), {
        method : 'POST',
        headers : { 'content-type' : 'application/json' },
        body : JSON.stringify(user)
    });
}

export const user = {
    login,
    logout,
    register
}