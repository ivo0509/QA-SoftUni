window.addEventListener("load", solve);

function solve() {
  let ticketNumElement = document.getElementById("num-tickets");
  let seatingElement = document.getElementById("seating-preference");
  let nameElement = document.getElementById("full-name");
  let emailElement = document.getElementById("email");
  let phoneElement = document.getElementById("phone-number");

  let purchaseTicketNumElement = document.getElementById("purchase-num-tickets");
  let purchaseSeatingElement = document.getElementById("purchase-seating-preference");
  let purchaseNameElement = document.getElementById("purchase-full-name");
  let purchaseEmailElement = document.getElementById("purchase-email");
  let purchasePhoneElement = document.getElementById("purchase-phone-number");

  let ticketPreviewElement = document.getElementById("ticket-preview");
  let purchaseSuccessElement = document.getElementById("purchase-success");

  let addBtnElement = document.getElementById("purchase-btn");
  addBtnElement.addEventListener("click", onAdd);

  function onAdd(e) {
    e.preventDefault();

    if (
      ticketNumElement.value == "" ||
      seatingElement.value == "" ||
      nameElement.value == "" ||
      emailElement.value == "" ||
      phoneElement.value == ""
    ) {
      return;
    }

    purchaseTicketNumElement.textContent = ticketNumElement.value;
    purchaseSeatingElement.textContent = seatingElement.value;
    purchaseNameElement.textContent = nameElement.value;
    purchaseEmailElement.textContent = emailElement.value;
    purchasePhoneElement.textContent = phoneElement.value;

    ticketPreviewElement.style.display = 'block';
    addBtnElement.disabled = true;
    
    ticketNumElement.value = "";
    seatingElement.value = "";
    nameElement.value = "";
    emailElement.value = "";
    phoneElement.value = "";
  }

  let editBtnElement = document.getElementById("edit-btn");
  editBtnElement.addEventListener("click", onEdit);

  function onEdit() {
    ticketNumElement.value = purchaseTicketNumElement.textContent;
    seatingElement.value = purchaseSeatingElement.textContent;
    nameElement.value = purchaseNameElement.textContent;
    emailElement.value = purchaseEmailElement.textContent;
    phoneElement.value = purchasePhoneElement.textContent;

    ticketPreviewElement.style.display = 'none';
    addBtnElement.disabled = false;
  }

  let buyBtnElement = document.getElementById("buy-btn");
  buyBtnElement.addEventListener("click", onBuy);

  function onBuy() {
    ticketPreviewElement.style.display = 'none';
    purchaseSuccessElement.style.display = 'block';
  }

  let backBtnElement = document.getElementById("back-btn");
  backBtnElement.addEventListener("click", onBack);

  function onBack() {
    purchaseSuccessElement.style.display = 'none';
    addBtnElement.disabled = false;
  }
}