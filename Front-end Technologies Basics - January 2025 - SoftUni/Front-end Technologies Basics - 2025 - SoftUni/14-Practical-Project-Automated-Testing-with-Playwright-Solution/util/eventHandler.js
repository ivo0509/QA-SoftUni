import page from '../node_modules/page/page.mjs'
import { requests } from '../api/requests.js'
import { userInfo } from '../util/userInfo.js'

async function onCreateSubmit(evt) {

    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { title, category, maxLevel, imageUrl, summary } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(title, category, maxLevel, imageUrl, summary)) {
        let item = {
            title,
            category,
            maxLevel,
            imageUrl,
            summary
        };

        requests.games.create(item)
        .then(res => {
            if(!res.ok){
                throw new Error('Unable to create a game!')
            }
            return res.json();
        })
        .then(game => {
            page.redirect('/');
        })
        .catch(err => alert(err.message));

    } else {
        alert("All fields are required!")
    }
}

async function onLoginSubmit(evt) {
    debugger;
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);

    let { email, password } = Object.fromEntries(formData);

    await requests.user.login(email, password)
        .then(res => {
            if (!res.ok) {
                throw new Error('Unable to log in!');
            }
            return res.json();
        })
        .then(user => {
            sessionStorage.setItem('game-user', JSON.stringify(user));
            page.redirect('/');
        })
        .catch(err => {
            alert(err.message)
        })



}

async function onRegisterSubmit(evt) {
    debugger;
    evt.preventDefault();
    let formData = new FormData(evt.currentTarget);

    let { email, password } = Object.fromEntries(formData);

    let repass = formData.get('confirm-password');

    if (isValidRegister(email, password, repass)) {
        let userInfo = {
            email,
            password
        };

        requests.user.register(userInfo)
            .then(res => {
                if (!res.ok) {
                    throw new Error("Email already exists!");
                }
                return res.json();
            })
            .then(data => {
                sessionStorage.setItem('game-user', JSON.stringify(data));
                page.redirect('/');
            })
            .catch(err => {
                alert(err.message);
            })
    } else {
        alert("No empty fields are allowed and confirm password has to match password!")
    }
}

function onEditSubmit(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);
    let id = evt.currentTarget.getAttribute('gameid');

    let { title, category, maxLevel, imageUrl, summary } = Object.fromEntries(formData);

    if (isValidCreatingOrEditing(title, category, maxLevel, imageUrl, summary)) {
        let item = {
            title,
            category,
            maxLevel,
            imageUrl,
            summary
          
        }

        requests.games.edit(item, id)
            .then(res => {
                if (!res.ok) {
                    throw new Error('Unable to edit this game!');
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
        alert("All fields are required!")
    }
}

function onCommentSubmit(evt){
    evt.preventDefault();

    let formData = new FormData(evt.currentTarget);
    let comment = formData.get('comment');
    let gameId = evt.currentTarget.getAttribute('gameid');

    let form = evt.currentTarget;
    requests.comments.postNew({gameId, comment})
    .then(res => {
        if(!res.ok){
            throw new Error('Unable to send comment');
        }
        return res.json();
    })
    .then(com => {
        form.reset();
        page.redirect(`/details/${gameId}`);
    })
    .catch(err => alert(err.message))
}

export const event = {
    onCreateSubmit,
    onLoginSubmit,
    onRegisterSubmit,
    onEditSubmit,
    onCommentSubmit
}

function isValidRegister(email, password, repass) {

    if (email == '' || password == '' || repass == '' || password != repass) {
        return false;
    }
    return true;
}

function isValidCreatingOrEditing(title, category, maxLevel, imageUrl, summary) {
    if(title == '' || category == '' || maxLevel == '' || imageUrl == '' || summary == ''){
        return false
    }
    return true;
}