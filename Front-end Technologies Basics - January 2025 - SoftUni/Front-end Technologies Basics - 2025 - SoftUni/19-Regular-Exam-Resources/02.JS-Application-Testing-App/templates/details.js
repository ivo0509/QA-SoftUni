import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';


export function getDetailsView(book) { // change params with whatever u need
    return html`
    <div class="details-page">
            <div class="book-card">
                <img src=${book.coverImage.substring(0,1) == '/' ? `..${book.coverImage}` : book.coverImage}>
                <div class="book-info">
                    <h2>${book.title}</h2>
                    <p><strong>Author:</strong> ${book.author}</p>
                    <p><strong>Genre:</strong> ${book.genre}</p>
                    <p><strong>Year:</strong> ${book.year}</p>
                    <p><strong>Description:</strong> ${book.description}</p>

                    <!-- Only for registered user and creator of the book-->
                    ${userInfo.getUserObj() && userInfo.getUserObj()._id == book._ownerId
                        ? html`
                            <div class="actions">
                                <a href="/edit/${book._id}" class="edit-btn">Edit</a>
                                <a href="/delete/${book._id}" class="delete-btn">Delete</a>
                            </div>`
                        : nothing }
                </div>
            </div>
        </div>`;
}
