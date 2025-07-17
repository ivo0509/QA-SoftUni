import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { event } from '../util/eventHandler.js';


export function getDetailsView(game, comments) { // change params with whatever u need
    return html`
    <section id="game-details">
            <h1>Game Details</h1>
            <div class="info-section">

                <div class="game-header">
                    <img class="game-img" src=${game.imageUrl.substring(0, 1)=='/' ? `..${game.imageUrl}` : game.imageUrl} />
                    <h1>${game.title}</h1>
                    <span class="levels">MaxLevel: ${game.maxLevel}</span>
                    <p class="type">${game.category}</p>
                </div>

                <p class="text">${game.summary}</p>

                <!-- Bonus ( for Guests and Users ) -->
                <div class="details-comments">
                    <h2>Comments:</h2>
                    ${comments && comments.length > 0
                        ? html`
                            <ul>
                                ${comments.map(c => html`<li class="comment">
                                                             <p>Content: ${c.comment}</p>
                                                         </li>`)}
                            </ul>`
                        : html`<p class="no-comment">No comments.</p>` }
                    <!-- Display paragraph: If there are no games in the database -->
                    
                </div>

                <!-- Edit/Delete buttons ( Only for creator of this game )  -->
                ${userInfo.getUserObj() && userInfo.getUserObj()._id == game._ownerId
                    ? html`<div class="buttons">
                                <a href="/edit/${game._id}" class="button">Edit</a>
                                <a href="/delete/${game._id}" class="button">Delete</a>
                            </div>`
                    : nothing }
            </div>

            <!-- Bonus -->
            <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
            ${userInfo.getUserObj() && userInfo.getUserObj()._id != game._ownerId
                ? html`
                    <article class="create-comment">
                        <label>Add new comment:</label>
                        <form class="form" @submit=${event.onCommentSubmit} gameid=${game._id}>
                            <textarea name="comment" placeholder="Comment......"></textarea>
                            <input class="btn submit" type="submit" value="Add Comment">
                        </form>
                    </article>`
                : nothing }

        </section>`;
}


