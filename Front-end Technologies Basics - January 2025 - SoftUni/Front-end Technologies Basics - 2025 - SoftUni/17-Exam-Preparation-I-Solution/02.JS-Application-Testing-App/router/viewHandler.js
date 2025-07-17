import { render } from '../node_modules/lit-html/lit-html.js'
import { templates } from '../templates/templates.js'
import { requests } from '../api/requests.js'
import page from '../node_modules/page/page.mjs';
import { userInfo } from '../util/userInfo.js'

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

function homeView(ctx) {
    render(templates.getHomeTemplate(), mainElement);
}

async function catalogView(ctx) {
    let albums = await requests.items.getAll();
    render(templates.getCatalogTemplate(albums), mainElement);
}



function createView(ctx) {
    render(templates.getCreateView(), mainElement);
}

async function editView(ctx) {
    let team = await requests.items.getById(ctx.params.id);

    render(templates.getEditTemplate(team), mainElement)
}

async function detailsView(ctx) {
    debugger;
    let item = await requests.items.getById(ctx.params.id);

    render(templates.getDetailsView(item), mainElement);
}

function deleteView(ctx) {
    requests.items.deleteById(ctx.params.id)
        .then(res => {
            if (res.ok) {
                page.redirect('/catalog');
            }
        });
}

function logoutView(ctx) {
    debugger;
    requests.user.logout()
        .then(res => {
            if (res.status == 204) {
                sessionStorage.removeItem('music-user');
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
    catalogView,
    loginView,
    registerView,
    logoutView,
    detailsView,
    createView,
    editView,
    deleteView,
    searchView
}