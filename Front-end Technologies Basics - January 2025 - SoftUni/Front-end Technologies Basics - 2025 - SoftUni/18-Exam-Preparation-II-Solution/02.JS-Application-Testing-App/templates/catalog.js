import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';
import { requests } from '../api/requests.js';

export function getCatalogTemplate(pets) {
    return html`
        <section id="dashboard">
            <h2 class="dashboard-title">Services for every animal</h2>
            <div class="animals-dashboard">
            ${pets && pets.length > 0
                ? pets.map(pet => html`
                                    <div class="animals-board">
                                            <article class="service-img">
                                                <img class="animal-image-cover" src=${pet.image.substring(0,1) == '/' ? `..${pet.image}` : pet.image}>
                                            </article>
                                            <h2 class="name">${pet.name}</h2>
                                            <h3 class="breed">${pet.breed}</h3>
                                         <div class="action">
                                             <a class="btn" href="/details/${pet._id}">Details</a>
                                         </div>
                                    </div>`)
                : html`
                    <div>
                        <p class="no-pets">No pets in dashboard</p>
                    </div>`}
                
            </div>
        </section>`;
}