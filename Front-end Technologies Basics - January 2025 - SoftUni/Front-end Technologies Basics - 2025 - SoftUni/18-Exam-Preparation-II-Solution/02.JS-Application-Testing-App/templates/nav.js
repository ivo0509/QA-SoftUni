import { html } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';

export function getNavTemplate() {
    return html`
        <nav>
            <section class="logo">
                <img src="./images/logo.png" alt="logo">
            </section>
            <ul>
                <li><a href="/">Home</a></li>
                <li><a href="/catalog">Dashboard</a></li>
                ${userInfo.getUserObj() 
                    ? html`
                        <li><a href="/create">Create Postcard</a></li>
                    <li><a href="/logout">Logout</a></li>`
                    : html`
                        <li><a href="/login">Login</a></li>
                        <li><a href="/register">Register</a></li>`}
            </ul>
        </nav>`;
}