import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js'; 

export function getCreateView() {
    return html`
        <div class="details-page">
            <div class="book-card">
                <form @submit=${event.onCreateSubmit} class="book-form">
                    <h2>Add Book</h2>

                    <label for="title">Title</label>
                    <input id="title" name="title" class="title" type="text" placeholder="Book title">

                    <label for="coverImage">Cover Image</label>
                    <input id="coverImage" name="coverImage" class="coverImage" type="text" placeholder="Cover Image">

                    <label for="year">Year</label>
                    <input id="year" name="year" class="year" type="text" placeholder="Year">

                    <label for="author">Author</label>
                    <input id="author" name="author" class="author" type="text" placeholder="Author">

                    <label for="genre">Genre</label>
                    <input id="genre" name="genre" class="genre" type="text" placeholder="Genre">

                    <label for="description">Description</label>
                    <textarea name="description" class="description" placeholder="Description"></textarea>

                    <button class="save-btn" type="submit">Save</button>
                </form>
            </div>
        </div>`;
}