import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js';

export function getEditTemplate(game) {
    return html`
    <section id="edit-page" class="auth">
            <form id="edit" @submit=${event.onEditSubmit} gameid=${game._id}>
                <div class="container">

                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" value=${game.title}>

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" value=${game.category}>

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" value=${game.maxLevel}>

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" value=${game.imageUrl}>

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary">${game.summary}</textarea>
                    <input class="btn submit" type="submit" value="Edit Game">

                </div>
            </form>
        </section>`;
}