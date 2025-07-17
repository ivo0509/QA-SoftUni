import page from '../node_modules/page/page.mjs';
import { requests } from '../api/requests.js';
import {userInfo} from '../util/userInfo.js';

async function onCreateSubmit(evt) {
    
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { name, breed, age, weight, image } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(name, breed, age, weight, image)) {
        let item = {
            name,
            breed,
            age,
            weight,
            image
          
        }

        requests.pets.create(item)
        .then(res => {
            if(!res.ok){
                throw new Error('Unable to create new pet section!');
            }
            page.redirect('/catalog');
        })
        .catch(err => alert(err.message));
    } else {
        alert('All fields are required!')
    }
}

async function onLoginSubmit(evt) {
    debugger;
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { email, password } = Object.fromEntries(formData);

    if(email == '' || password == ''){
        alert('All fields are required!')
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
            alert(err.message)
        })
    }
}

async function onRegisterSubmit(evt) {
    debugger;
    evt.preventDefault();
    let formData = new FormData(evt.currentTarget);

    let { email, password, repeatPassword } = Object.fromEntries(formData);

    if (isValidRegister(email, password, repeatPassword)) {
        let userInfo = {
            email,
            password
        };

        requests.user.register(userInfo)
            .then(res => {
                if (!res.ok) {
                    throw new Error('Unable to register!');
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
        alert('All fields are required!')
    }
}

function onEditSubmit(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);
    let id = evt.currentTarget.getAttribute('petid');

    let {name, breed, age, weight, image } = Object.fromEntries(formData);

    if(isValidCreatingOrEditing(name, breed, age, weight, image)){
        let item = {
            name,
            breed,
            age,
            weight,
            image
        }

        requests.pets.edit(item, id)
        .then(res => {
            if(!res.ok){
                throw new Error('Unable to edit this pet section!');
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
        alert('All fields are required!')
    }
}


export const event = {
    onCreateSubmit,
    onLoginSubmit,
    onRegisterSubmit,
    onEditSubmit
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