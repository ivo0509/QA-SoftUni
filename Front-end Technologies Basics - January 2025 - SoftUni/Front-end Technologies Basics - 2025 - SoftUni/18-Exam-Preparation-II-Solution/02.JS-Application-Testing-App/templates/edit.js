import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js';

export function getEditTemplate(pet) {
    return html`
        <section id="editPage">
            <form class="editForm" @submit=${event.onEditSubmit} petid=${pet._id}>
                <img src=${pet.image.substring(0,1) == '/' ? `..${pet.image}` : pet.image}>
                <div>
                    <h2>Edit Postcard</h2>
                    <div class="name">
                        <label for="name">Name:</label>
                        <input name="name" id="name" type="text" value=${pet.name}>
                    </div>
                    <div class="breed">
                        <label for="breed">Breed:</label>
                        <input name="breed" id="breed" type="text" value=${pet.breed}>
                    </div>
                    <div class="Age">
                        <label for="age">Age:</label>
                        <input name="age" id="age" type="text" value=${pet.age}>
                    </div>
                    <div class="weight">
                        <label for="weight">Weight:</label>
                        <input name="weight" id="weight" type="text" value=${pet.weight}>
                    </div>
                    <div class="image">
                        <label for="image">Image:</label>
                        <input name="image" id="image" type="text" value=${pet.image}>
                    </div>
                    <button class="btn" type="submit">Edit</button>
                </div>
            </form>
        </section>`;
}