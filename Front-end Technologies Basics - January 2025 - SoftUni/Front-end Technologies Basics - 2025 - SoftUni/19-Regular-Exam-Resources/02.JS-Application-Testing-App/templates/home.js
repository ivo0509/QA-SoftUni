import { html } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';

export function getHomeTemplate() {
    return html`
        <section class="features">
            <div class="feature">
                <h2>Organize</h2>
                <p>Keep track of all your books with ease.</p>
            </div>
            <div class="feature">
                <h2>Search</h2>
                <p>Find books by title, author, or genre instantly.</p>
            </div>
            <div class="feature">
                <h2>Create</h2>
                <p>Add new books to expand your collection.</p>
            </div>
        </section>
        `;
}