import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { userInfo } from '../util/userInfo.js';


export function getDetailsView(pet, donation, isNotDonated) { 
    return html`
    <section id="detailsPage">
            <div class="details">
                <div class="animalPic">
                    <img src=${pet.image.substring(0,1) == '/' ? `..${pet.image}` : pet.image}>
                </div>
                <div>
                    <div class="animalInfo">
                        <h1>Name: ${pet.name}</h1>
                        <h3>Breed: ${pet.breed}</h3>
                        <h4>Age: ${pet.age}</h4>
                        <h4>Weight: ${pet.weight}</h4>
                        <h4 class="donation">Donation: ${donation && donation > 0 ? donation * 100 : 0}$</h4>
                    </div>
                    
                        ${userInfo.getUserObj()
                            ? html`
                                <div class="actionBtn">
                                    ${userInfo.getUserObj()._id && userInfo.getUserObj()._id == pet._ownerId
                                        ? html`
                                            <a href="/edit/${pet._id}" class="edit">Edit</a>
                                            <a href="/delete/${pet._id}" class="remove">Delete</a>`
                                        : nothing }
                                    ${userInfo.getUserObj()._id != pet._ownerId && isNotDonated
                                        ? html`<a href="/donate/${pet._id}" class="donate">Donate</a>`
                                        : nothing}
                                </div>`
                            : nothing}
                </div>
            </div>
        </section>`;
}
