import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { event } from '../util/eventHandler.js'; 

export function getLoginTemplate() {
    return html`
     <div class="login-page">
            <form @submit=${event.onLoginSubmit} class="login-form">
                <h2>Welcome Back</h2>
                <p>Access your personalized book collection.</p>

                <input name="email" type="text" placeholder="Email" required>

                <input name="password" type="password" placeholder="Password" required>

                <button type="submit">Login</button>
                
                <p class="register-link">
                    Don't have an account? <a href="/register">Register here</a>.
                </p>
            </form>
        </div>`;
}




