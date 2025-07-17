import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { requests } from '../api/requests.js';

export function getCollectionTemplate(items) {
    return html`
    <section id="collectionPage">
    <h1 style="color: white;">All Books</h1>

    ${items && items.length > 0
        ? items.map(i => html`
                            <div class="book">
                                <img src=${i.coverImage.substring(0,1) == '/' ? `..${i.coverImage}` : i.coverImage}>
                                <div class="book-details">
                                    <h2>${i.title}</h2>
                                    <p><strong>Author:</strong> ${i.author}</p>
                                    <p><strong>Genre:</strong> ${i.genre}</p>
                                    <p><strong>Year:</strong> ${i.year}</p>
                                    <p><strong>Description:</strong> ${i.description}</p>
                                    ${userInfo.getUserObj()
                                        ? html`<a href="/details/${i._id}" id="details">View Details</a>`
                                        : nothing }
                                </div>
                            </div>`)
        : html`<p>No Books in Collection!</p>`}

    

    <!--No books in collection-->
    

</section>`;
}