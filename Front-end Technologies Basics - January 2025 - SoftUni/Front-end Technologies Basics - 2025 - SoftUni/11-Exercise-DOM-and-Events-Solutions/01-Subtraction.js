function subtract() {
    const num1 = Number(document.getElementById('firstNumber').value);
    const num2 = Number(document.getElementById('secondNumber').value);

    let sum = num1 - num2;

    const result = document.getElementById('result').textContent = sum;
}