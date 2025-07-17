window.addEventListener('load', solve);

function solve() {
    let carModelElement = document.getElementById("car-model");
    let carYearElement = document.getElementById("car-year");
    let partNameElement = document.getElementById("part-name");
    let partNumberElement = document.getElementById("part-number");
    let conditionElement = document.getElementById("condition");

    let purchaseCarModelElement = document.getElementById("info-car-model");
    let purchaseCarYearElement = document.getElementById("info-car-year");
    let purchasePartNameElement = document.getElementById("info-part-name");
    let purchasePartNumberElement = document.getElementById("info-part-number");
    let purchaseConditionElement = document.getElementById("info-condition");

    let partInfoElement = document.getElementById("part-info");
    let confirmOrderElement = document.getElementById("confirm-order");

    let nextBtnElement = document.getElementById("next-btn");
    nextBtnElement.addEventListener("click", onNext);

    function onNext(e) {
        e.preventDefault();

        const carYearValue = Number(carYearElement.value);

        if (
            carModelElement.value == "" ||
            carYearElement.value == "" ||
            partNameElement.value == "" ||
            partNumberElement.value == "" ||
            conditionElement.value == "" ||
            carYearValue === NaN ||
            carYearValue < 1990 ||
            carYearValue > 2024
        ) {
            return;
        }

        purchaseCarModelElement.textContent = carModelElement.value;
        purchaseCarYearElement.textContent = carYearElement.value;
        purchasePartNameElement.textContent = partNameElement.value;
        purchasePartNumberElement.textContent = partNumberElement.value;
        purchaseConditionElement.textContent = conditionElement.value;

        partInfoElement.style.display = 'block';
        nextBtnElement.disabled = true;
        
        carModelElement.value = "";
        carYearElement.value = "";
        partNameElement.value = "";
        partNumberElement.value = "";
        conditionElement.value = "";
    }

    let editBtnElement = document.getElementById("edit-btn");
    editBtnElement.addEventListener("click", onEdit);

    function onEdit() {
        carModelElement.value = purchaseCarModelElement.textContent;
        carYearElement.value = purchaseCarYearElement.textContent;
        partNameElement.value = purchasePartNameElement.textContent;
        partNumberElement.value = purchasePartNumberElement.textContent;
        conditionElement.value = purchaseConditionElement.textContent;

        partInfoElement.style.display = 'none';
        nextBtnElement.disabled = false;
    }

    let confirmBtnElement = document.getElementById("confirm-btn");
    confirmBtnElement.addEventListener("click", onConfirm);

    function onConfirm() {
        partInfoElement.style.display = 'none';
        confirmOrderElement.style.display = 'block';
    }

    let newBtnElement = document.getElementById("new-btn");
    newBtnElement.addEventListener("click", onNew);

    function onNew() {
        confirmOrderElement.style.display = 'none';
        nextBtnElement.disabled = false;
    }
};


    
    
