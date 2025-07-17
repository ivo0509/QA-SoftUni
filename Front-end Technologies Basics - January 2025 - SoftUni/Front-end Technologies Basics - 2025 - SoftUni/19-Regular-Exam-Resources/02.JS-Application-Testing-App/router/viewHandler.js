import { render } from '../node_modules/lit-html/lit-html.js'
import { templates } from '../templates/templates.js'
import { requests } from '../api/requests.js'
import page from '../node_modules/page/page.mjs';
import { userInfo } from '../util/userInfo.js'

let mainElement = document.querySelector('main');
let headerElement = document.querySelector('header');
function navView(ctx, next) {
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

async function collectionView(ctx) {
    let books = await requests.items.getAll();
    render(templates.getCollectionTemplate(books), mainElement);
}



function createView(ctx) {
    render(templates.getCreateView(), mainElement);
}

async function editView(ctx) {
    let team = await requests.items.getById(ctx.params.id);

    render(templates.getEditTemplate(team), mainElement)
}

async function detailsView(ctx) {
    let item = await requests.items.getById(ctx.params.id);

    render(templates.getDetailsView(item), mainElement);
}

function deleteView(ctx) {
    requests.items.deleteById(ctx.params.id)
        .then(res => {
            if (res.ok) {
                page.redirect('/collection');
            }
        });
}

function logoutView(ctx) {
    requests.user.logout()
        .then(res => {
            if (res.status == 204) {
                sessionStorage.removeItem('app-user');
                page.redirect('/');
            }
        });
}

function searchView(ctx){
    render(templates.getSearchTemplate(), mainElement);
}

export const viewHandler = {
    navView,
    homeView,
    collectionView,
    loginView,
    registerView,
    logoutView,
    detailsView,
    createView,
    editView,
    deleteView,
    searchView
}