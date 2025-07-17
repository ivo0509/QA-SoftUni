function encodeAndDecodeMessages() {
    let buttons = Array.from(document.querySelectorAll('#main button'));
    let textHolders = Array.from(document.querySelectorAll('main textarea'));

    buttons[0].addEventListener('click', sennAndCode);
    buttons[1].addEventListener('click', decode);

    function transform(text, fn) {
        return text.split('').map(fn).join('');
    }

    function nextChar(c) {
        return String.fromCharCode(c.charCodeAt(0) + 1);
    }

    function prevChar(c) {
        return String.fromCharCode(c.charCodeAt(0) - 1);
    }


    function sennAndCode() {
        textHolders[1].value = transform(textHolders[0].value, nextChar);
        textHolders[0].value = '';
    }

    function decode() {
        textHolders[1].value = transform(textHolders[1].value, prevChar)
    }
}