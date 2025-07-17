import { render } from '../node_modules/lit-html/lit-html.js'
import { templates } from '../templates/templates.js'
import { requests } from '../api/requests.js'
import page from '../node_modules/page/page.mjs';
import {userInfo} from '../util/userInfo.js'

let mainElement = document.querySelector('#box #main-content');
let headerElement = document.querySelector('#box header');

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

async function homeView(ctx) {
    // maybe /data/games?sortBy=_createdOn%20desc&distinct=category
    let games = await requests.games.getMostResently();
    render(templates.getHomeTemplate(games), mainElement);
}

async function catalogView(ctx) {
    let games = await requests.games.getAll();
    render(templates.getCatalogTemplate(games), mainElement);
}



function createView(ctx) {
    render(templates.getCreateView(), mainElement);
}

async function editView(ctx){
    let team = await requests.games.getById(ctx.params.id);

    render(templates.getEditTemplate(team), mainElement)
}

async function detailsView(ctx) {
    debugger;
    let game = await requests.games.getById(ctx.params.id);
    let comments = await requests.comments.getAll(ctx.params.id);
    render(templates.getDetailsView(game, comments), mainElement);
}

function deleteView(ctx){
    requests.games.deleteById(ctx.params.id)
    .then(res => {
        if(res.ok){
            page.redirect('/');
        }
    })
}

function logoutView(ctx){
    debugger;
    requests.user.logout()
    .then(res => {
        if(res.status == 204){
            sessionStorage.removeItem('game-user');
            page.redirect('/');
        }
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
    deleteView
}