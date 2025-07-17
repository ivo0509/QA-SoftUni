import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { requests } from '../api/requests.js';

export function getCatalogTemplate(items) {
    return html`
    <section id="catalogPage">
    <h1>All Albums</h1>

    ${items && items.length > 0
        ? items.map(i => html`
                            <div class="card-box">
                                <img src=${i.imgUrl.substring(0,1) == '/' ? `..${i.imgUrl}` : i.imgUrl}>
                                <div>
                                    <div class="text-center">
                                        <p class="name">Name: ${i.name}</p>
                                        <p class="artist">${i.artist}</p>
                                        <p class="genre">Genre: ${i.genre}</p>
                                        <p class="price">Price: $${i.price}</p>
                                        <p class="date">Release Date: ${i.releaseDate}</p>
                                    </div>
                                    ${userInfo.getUserObj()
                                        ? html`
                                            <div class="btn-group">
                                                <a href="/details/${i._id}" id="details">Details</a>
                                            </div>`
                                        : nothing }
                                </div>
                            </div>`)
        : html`<p>No Albums in Catalog!</p>`}

    

    <!--No albums in catalog-->
    

</section>`;
}