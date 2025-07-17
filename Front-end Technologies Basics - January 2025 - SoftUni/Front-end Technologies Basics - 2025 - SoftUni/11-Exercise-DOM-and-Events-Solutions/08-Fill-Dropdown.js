function addItem() {
    let inputTextElement = document.querySelector('#newItemText');
    let inputValueElement = document.querySelector('#newItemValue');

    let menu = document.querySelector('#menu');
    let option = document.createElement('option');

    option.textContent = inputTextElement.value;
    option.value = inputValueElement.value;
    menu.appendChild(option);

    inputValueElement.value = '';
    inputTextElement.value = '';
}