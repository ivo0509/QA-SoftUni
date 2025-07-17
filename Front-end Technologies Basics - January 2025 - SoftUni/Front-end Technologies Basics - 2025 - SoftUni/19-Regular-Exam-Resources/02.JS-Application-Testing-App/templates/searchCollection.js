import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { requests } from '../api/requests.js';

export function getSearchCollectionTemplate(books) {
    if (books.length == 0) {
        return html`<h3>No result.</h3>`;
    }

    return html`
        <h3>Results:</h3>
        <ul>
            ${books.map(
                (book) => html`
                    <li>
                        ${userInfo.getUserObj()
                            ? html`<a href="/details/${book._id}">${book.title}</a>`
                            : book.title}
                        by ${book.author}
                    </li>
                `
            )}
        </ul>
    `;
}