import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { requests } from '../api/requests.js';

export function getSearchCatalogTemplate(albums) {
    return html`
            ${albums && albums.length > 0
                ? albums.map(album => html`
                    <div class="card-box">
                        <img src=${album.imgUrl.substring(0,1) == '/' ? `..${album.imgUrl}` : album.imgUrl}>
                        <div>
                            <div class="text-center">
                                <p class="name">Name: ${album.name}</p>
                                <p class="artist">Artist: ${album.artist}</p>
                                <p class="genre">Genre: ${album.genre}</p>
                                <p class="price">Price: $${album.price}</p>
                                <p class="date">Release Date: ${album.releaseDate}</p>
                            </div>
                            ${userInfo.getUserObj()
                                ? html`
                                    <div class="btn-group">
                                        <a href="/details/${album._id}" id="details">Details</a>
                                    </div>`
                                : nothing }
                        </div>
                    </div>`)
                : html`<p class="no-result">No result.</p>`}`
}