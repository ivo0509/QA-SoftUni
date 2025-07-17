import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js';

export function getEditTemplate(book) {
    return html`
        <div class="details-page">
            <div class="book-card">
                <form @submit=${event.onEditSubmit} bookid=${book._id} class="book-form">
                    <h2>Edit Book</h2>

                    <label for="title">Title</label>
                    <input id="title" name="title" class="title" type="text" value=${book.title}>

                    <label for="coverImage">Cover Image</label>
                    <input id="coverImage" name="coverImage" class="coverImage" type="text" value=${book.coverImage}>

                    <label for="year">Year</label>
                    <input id="year" name="year" class="year" type="text" value=${book.year}>

                    <label for="author">Author</label>
                    <input id="author" name="author" class="author" type="text" value=${book.author}>

                    <label for="genre">Genre</label>
                    <input id="genre" name="genre" class="genre" type="text" value=${book.genre}>

                    <label for="description">Description</label>
                    <textarea name="description" class="description" rows="10"
                        cols="10">${book.description}</textarea>

                    <button class="save-btn" type="submit">Save Changes</button>
                </form>
            </div>
        </div>`;
}