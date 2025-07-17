import { render } from '../node_modules/lit-html/lit-html.js'
import { templates } from '../templates/templates.js'
import { requests } from '../api/requests.js'
import page from '../node_modules/page/page.mjs';
import {userInfo} from '../util/userInfo.js'

let mainElement = document.querySelector('#content');
let headerElement = document.querySelector('body header');

function navView(ctx, next) {
    debugger;
    render(templates.getNavTemplate(), headerElement);
    next();
}

function loginView(ctx) {
    render(templates.getLoginTemplate(), mainElement);
}

function registerView(ctx) {
    render(templates.getRegisterTemplate(), mainElement);
}

function homeView(ctx) {
    render(templates.getHomeTemplate(), mainElement);
}

async function catalogView(ctx) {
    let pets = await requests.pets.getAll();
    render(templates.getCatalogTemplate(pets), mainElement);
}



function createView(ctx) {
    render(templates.getCreateView(), mainElement);
}

async function editView(ctx){
    let pet = await requests.pets.getById(ctx.params.id);

    render(templates.getEditTemplate(pet), mainElement)
}

async function detailsView(ctx) {
    debugger;
    let petId = ctx.params.id;
    let pet = await requests.pets.getById(petId);
    let totalDonation = await requests.donations.getTotalDonation(petId);

    let isNotDonated = true;

    let isDonated = await requests.donations.isAlreadyMade(petId, userInfo.getUserObj()._id);
    if(isDonated == 1){
        isNotDonated = false;
    }

    render(templates.getDetailsView(pet, totalDonation, isNotDonated), mainElement);
}

function deleteView(ctx){
    requests.pets.deleteById(ctx.params.id)
    .then(res => {
        if(res.ok){
            page.redirect('/catalog');
        }
    });
}

function logoutView(ctx){
    debugger;
    requests.user.logout()
    .then(res => {
        if(res.status == 204){
            sessionStorage.removeItem('app-user');
            page.redirect('/');
        }
    });
}

function donateView(ctx){
    let petId = ctx.params.id;

    requests.donations.makeDonation(petId)
    .then(res => {
        if(!res.ok){
            alert('Unable to make donation!');
        }
        page.redirect(`/details/${petId}`);
    });
    
}

export const viewHandler = {
    navView,
    homeView,
    catalogView,
    loginView,
    registerView,
    logoutView,
    detailsView,
    createView,
    editView,
    deleteView,
    donateView
}