import { html } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';

export function getNavTemplate() {
    return html`
            <nav>
                <a href="/">Home</a>
                <a href="/collection">Collection</a>
                <a href="/search">Search</a>
                ${userInfo.getUserObj()
                    ? html`
                        <a href="/create">Create Book</a>
                        <a href="/logout">Logout</a>`
                    : html`
                        <a href="/login">Login</a>
                        <a href="/register">Register</a>`}
            </nav>`;
}