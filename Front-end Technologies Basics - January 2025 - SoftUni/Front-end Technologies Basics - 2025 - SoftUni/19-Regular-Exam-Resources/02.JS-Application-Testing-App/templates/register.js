import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js'; 

export function getRegisterTemplate() {
    return html`
    <div class="register-page">
            <form @submit=${event.onRegisterSubmit} class="register-form">
                <h2>Create an Account</h2>
                <p>Start building your personalized book collection today.</p>

                <input name="email" type="email" placeholder="Email" required>

                <input name="password" type="password" placeholder="Password" required>

                <input name="conf-pass" type="password" placeholder="Confirm Password" required>

                <button type="submit">Register</button>
            </form>
        </div>`;
}




