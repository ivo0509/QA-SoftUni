function toggle() {
    let button = document.querySelector('.button');
    let text = document.getElementById('extra');

    button.textContent = button.textContent == 'More' ? 'Less' : 'More';
    text.style.display =
        text.style.display == 'none' || text.style.display == '' ?
        text.style.display = 'block' : text.style.display = 'none';
}