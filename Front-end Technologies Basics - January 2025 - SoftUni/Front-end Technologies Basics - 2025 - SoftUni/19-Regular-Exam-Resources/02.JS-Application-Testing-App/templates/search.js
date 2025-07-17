import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js'; 

export function getSearchTemplate() {
    return html`
        <div id="searchPage" class="search-page">
            <form @submit=${event.onSearchClick} class="search-form">
                <h2>Find Your Favorite Books</h2>
                <p>Search by title, author, or genre to find what you’re looking for.</p>

                <input type="text" name="search" placeholder="Enter desired books's title" required>
                <button type="submit">Search</button>
            </form>

            <section class="search-results">
            
            </section>
        </div>`;
}