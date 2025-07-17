import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';


export function getDetailsView(album) { // change params with whatever u need
    return html`
    <section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src=${album.imgUrl.substring(0,1) == '/' ? `..${album.imgUrl}` : album.imgUrl}>
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${album.name}</h1>
                        <h3>Artist: ${album.artist}</h3>
                        <h4>Genre: ${album.genre}</h4>
                        <h4>Price: $${album.price}</h4>
                        <h4>Date: ${album.releaseDate}</h4>
                        <p>Description: ${album.description}</p>
                    </div>

                    <!-- Only for registered user and creator of the album-->
                    ${userInfo.getUserObj() && userInfo.getUserObj()._id == album._ownerId
                        ? html`
                            <div class="actionBtn">
                                <a href="/edit/${album._id}" class="edit">Edit</a>
                                <a href="/delete/${album._id}" class="remove">Delete</a>
                            </div>`
                        : nothing }
                </div>
            </div>
        </section>`;
}
