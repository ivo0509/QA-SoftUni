import { html } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';

export function getNavTemplate() {
    return html`
    <h1><a class="home" href="/">GamesPlay</a></h1>
    <nav>
        <a href="/catalog">All games</a>

        ${userInfo.getUserObj()
        ? html`
        <!-- Logged-in users -->
            <div id="user">
                <a href="/create">Create Game</a>
                <a href="/logout">Logout</a>
            </div>`
        : html`
        <!-- Guest users -->
            <div id="guest">
                <a href="/login">Login</a>
                <a href="/register">Register</a>
            </div>
        `}
    </nav>`;
}