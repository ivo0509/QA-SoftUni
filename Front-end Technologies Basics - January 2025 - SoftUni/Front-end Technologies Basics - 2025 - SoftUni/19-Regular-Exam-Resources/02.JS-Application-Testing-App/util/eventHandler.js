import page from '../node_modules/page/page.mjs';
import { requests } from '../api/requests.js';

import { render} from '../node_modules/lit-html/lit-html.js';
import {templates} from '../templates/templates.js';
import {url} from '../util/urls.js'

async function onCreateSubmit(evt) {

    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { title, coverImage, year, author, genre, description } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(title, coverImage, year, author, genre, description)) {
        let item = {
            title,
            coverImage,
            year,
            author,
            genre,
            description
        }

        requests.items.create(item)
        .then(res => {
            if(!res.ok){
                throw new Error('Unable to create new book!')
            }
            page.redirect('/collection')
        })
        .catch(err => alert(err.message));

    } else {
        alert('No empty fields are allowed!')
    }
}

async function onLoginSubmit(evt) {
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
                sessionStorage.setItem('app-user', JSON.stringify(user));
                page.redirect('/');
            })
            .catch(err => {
                alert(err.message);
            })
    }

}

async function onRegisterSubmit(evt) {
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
                sessionStorage.setItem('app-user', JSON.stringify(data));
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
    let id = evt.currentTarget.getAttribute('bookid');

    let { title, coverImage, year, author, genre, description } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(title, coverImage, year, author, genre, description)) {
        let item = {
            title,
            coverImage,
            year,
            author,
            genre,
            description
        }

        requests.items.edit(item, id)
            .then(res => {
                if (!res.ok) {
                    throw new Error('Unable to edit this book!');
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
    evt.preventDefault();
    let formData = new FormData(evt.currentTarget);

    let { search } = Object.fromEntries(formData);

    let books = await requests.items.searchBooks(search);

    let searchContainer = document.querySelector('section.search-results');

    render(templates.getSearchCollectionTemplate(books), searchContainer);
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