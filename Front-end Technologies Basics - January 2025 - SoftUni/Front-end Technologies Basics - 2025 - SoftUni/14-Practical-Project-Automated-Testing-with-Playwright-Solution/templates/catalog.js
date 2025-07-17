import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { requests } from '../api/requests.js';

export function getCatalogTemplate(games) {
    return html`
    <section id="catalog-page">
            <h1>All Games</h1>
            <!-- Display div: with information about every game (if any) -->
            ${games && games.length > 0
                ? games.map(g => html`
                                    <div class="allGames">
                                    <div class="allGames-info">
                                        <img src=${g.imageUrl.substring(0,1) == '/' ? `..${g.imageUrl}` : g.imageUrl}>
                                        <h6>${g.category}</h6>
                                        <h2>${g.title}</h2>
                                        <a href="/details/${g._id}" class="details-button">Details</a>
                                    </div>`)
                : html`<h3 class="no-articles">No articles yet</h3>`}
            

            <!-- Display paragraph: If there is no games  -->
            
        </section>`;
}