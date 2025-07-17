import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js'; 

export function getSearchTemplate() {
    return html`
        <section id="searchPage">
            <h1>Search by Name</h1>

            <div class="search">
                <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
                <button class="button-list" @click=${event.onSearchClick}>Search</button>
            </div>

            <h2>Results:</h2>

            <div class="search-result"></div>
        </section>`;
}