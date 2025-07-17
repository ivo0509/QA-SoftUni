import page from '../node_modules/page/page.mjs';
import { requests } from '../api/requests.js';

import { render} from '../node_modules/lit-html/lit-html.js';
import {templates} from '../templates/templates.js';
import {url} from '../util/urls.js'

async function onCreateSubmit(evt) {

    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { name, imgUrl, price, releaseDate, artist, genre, description } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(name, imgUrl, price, releaseDate, artist, genre, description)) {
        let item = {
            name,
            imgUrl,
            price,
            releaseDate,
            artist,
            genre,
            description

        }

        requests.items.create(item)
        .then(res => {
            if(!res.ok){
                throw new Error('Unable to create new album!')
            }
            page.redirect('/catalog')
        })
        .catch(err => alert(err.message));

    } else {
        alert('No empty fields are allowed!')
    }
}

async function onLoginSubmit(evt) {
    debugger;
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { email, password } = Object.fromEntries(formData);

    if (email == '' || password == '') {
        alert('No empty fields allowed!');
    } else {
        await requests.user.login(email, password)
            .then(res => {
                if (!res.ok) {
                    throw new Error('Wrong email or password!');
                }
                return res.json();
            })
            .then(user => {
                sessionStorage.setItem('music-user', JSON.stringify(user));
                page.redirect('/');
            })
            .catch(err => {
                alert(err.message);
            })
    }

}

async function onRegisterSubmit(evt) {
    debugger;
    evt.preventDefault();
    let formData = new FormData(evt.currentTarget);

    let { email, password } = Object.fromEntries(formData);

    let repass = formData.get('conf-pass');

    if (isValidRegister(email, password, repass)) {
        let userInfo = {
            email,
            password
        };

        requests.user.register(userInfo)
            .then(res => {
                if (!res.ok) {
                    throw new Error('Already existing email!');
                }
                return res.json();
            })
            .then(data => {
                sessionStorage.setItem('music-user', JSON.stringify(data));
                page.redirect('/');
            })
            .catch(err => {
                alert(err.message)
            })
    } else {
        alert('No empty fields are allowed! Confirm password need to match given password!')
    }
}

function onEditSubmit(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);
    let id = evt.currentTarget.getAttribute('albumid');

    let { name, imgUrl, price, releaseDate, artist, genre, description } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(name, imgUrl, price, releaseDate, artist, genre, description)) {
        let item = {
            name,
            imgUrl,
            price,
            releaseDate,
            artist,
            genre,
            description
        }

        requests.items.edit(item, id)
            .then(res => {
                if (!res.ok) {
                    throw new Error('Unable to edit this album!');
                }
                return res.json();
            })
            .then(data => {
                page.redirect(`/details/${data._id}`)
            })
            .catch(err => {
                alert(err.message);
            })
    } else {
        alert('No empty fields are allowed!');
    }
}

async function onSearchClick(evt){
    debugger;
    evt.preventDefault();
    let query = url.encodeURL(document.getElementById('search-input').value);

    let albums = await requests.items.searchAlbums(query);

    let searchContainer = document.querySelector('#searchPage .search-result');

    render(templates.getSearchCatalogTemplate(albums), searchContainer);

}


export const event = {
    onCreateSubmit,
    onLoginSubmit,
    onRegisterSubmit,
    onEditSubmit,
    onSearchClick
}

function isValidRegister(email, password, repass) {
    if (email == '' || password == '' || repass == '' || password != repass) {
        return false;
    }
    return true;
}

function isValidCreatingOrEditing(...params) {
    for (const item of params) {
        if(item == ''){
            return false;
        }
    }
    return true;
}