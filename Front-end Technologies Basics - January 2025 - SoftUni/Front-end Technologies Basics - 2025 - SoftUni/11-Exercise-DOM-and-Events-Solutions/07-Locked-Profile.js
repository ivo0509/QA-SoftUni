function lockedProfile() {
    let buttoneElements = Array.from(document.querySelectorAll('div button'));
    let lockElements = document.querySelectorAll('.profile input[type="radio"]');
    console.log(lockElements)
    for (let btn of buttoneElements) {
        btn.addEventListener('click', show);
    }

    function show(e) {

        let divChildren = Array.from(e.target.parentElement.children);
        let locked = divChildren[2].checked;
        if (locked == false) {
            let hiddenFieldsElement = e.target.previousElementSibling;
            if (e.target.textContent == 'Show more') {
                hiddenFieldsElement.style.display = 'inline';
                e.target.textContent = 'Hide it'
            } else {
                hiddenFieldsElement.style.display = '';
                e.target.textContent = 'Show more'
            }
        }
    }
}